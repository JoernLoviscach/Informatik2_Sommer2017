using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windenergieanlagen
{
    class Windenergieanlage // Sollte abstract sein!
    {
        double durchmesser;
        public double Durchmesser { get { return durchmesser; } }

        public Windenergieanlage(double durchmesser)
        {
            this.durchmesser = durchmesser;
        }

        public virtual double BestimmeLeistung_kW(double v) // Sollte abstract sein!
        {
            return 0.0;
        }

        // Wahrscheinlichkeit, dass aktuelle Windgeschwindigkeit zwischen 0 und v liegt.
        static double Rayleigh(double mittlereWindgeschwindigkeit, double v)
        {
            return 1.0 - Math.Exp(- Math.PI * v * v / (4.0 * mittlereWindgeschwindigkeit * mittlereWindgeschwindigkeit));
        }

        public double BestimmeJahresenergieertrag_kWh(double mittlereWindgeschwindkeit)
        {
            double ertrag_kWh = 0.0;

            const double vSchritt = 0.5;
            for (double v = 1.0; v < 40.0; v += vSchritt) // TODO: keine double-Variable als Laufvariable
            {
                double vUnten = v;
                double vOben = v + vSchritt;
                double leistungMitte = BestimmeLeistung_kW(0.5 * (vUnten + vOben));
                double wahrscheinlichkeit = Rayleigh(mittlereWindgeschwindkeit, vOben) - Rayleigh(mittlereWindgeschwindkeit, vUnten);
                ertrag_kWh += wahrscheinlichkeit * 365.0 * 24.0 * leistungMitte;
            }

            return ertrag_kWh;
        }
    }

    class IdealeWEA : Windenergieanlage
    {
        public IdealeWEA(double durchmesser)
            : base(durchmesser)
        { }

        public override double BestimmeLeistung_kW(double v)
        {
            return 0.001 * 0.5 * 1.225 * Math.PI * Math.Pow(0.5 * Durchmesser, 2.0) * Math.Pow(v, 3.0);
        }
    }

    class Betz : IdealeWEA
    {
        public Betz(double durchmesser)
            : base(durchmesser)
        { }

        public override double BestimmeLeistung_kW(double v)
        {
            return 16.0 / 27.0 * base.BestimmeLeistung_kW(v);
        }
    }

    class BetzNennleistung : IdealeWEA
    {
        double nennleistung_kW;

        public BetzNennleistung(double durchmesser, double nennleistung_kW)
            : base(durchmesser)
        {
            this.nennleistung_kW = nennleistung_kW;
        }

        public override double BestimmeLeistung_kW(double v)
        {
            return Math.Min(16.0 / 27.0 * base.BestimmeLeistung_kW(v), nennleistung_kW);
        }
    }

    class W127 : Windenergieanlage
    {
        static double[,] leistungskurve_kW =
        {
            {2.0, 0.0},
            {3.0, 58.0},
            {4.0, 185.0},
            {5.0, 400.0},
            {6.0, 745.0},
            {7.0, 1200.0},
            {8.0, 1790.0},
            {9.0, 2450.0},
            {10.0, 3120.0},
            {11.0, 3660.0},
            {12.0, 4000.0},
            {13.0, 4150.0},
            {14.0, 4200.0},
            {30.0, 4200.0},
            {31.0, 0.0}
        };

        public W127()
            : base(127.0)
        {
        }

        public override double BestimmeLeistung_kW(double v)
        {
            int i = 0;
            bool gefunden = false;
            for (; i < leistungskurve_kW.GetLength(0); i++)
            {
                if(leistungskurve_kW[i, 0] > v)
                {
                    gefunden = true;
                    break;
                }
            }
            if(!gefunden || i == 0)
            {
                return 0.0;
            }
            // Jetzt sicher: Liegen innerhalb der Tabelle.

            int iDavor = i - 1;
            double anteilDavor = (leistungskurve_kW[i, 0] - v) / (leistungskurve_kW[i, 0] - leistungskurve_kW[iDavor, 0]);
            double anteilDanach = (v - leistungskurve_kW[iDavor, 0]) / (leistungskurve_kW[i, 0] - leistungskurve_kW[iDavor, 0]);
            return anteilDavor * leistungskurve_kW[iDavor, 1] + anteilDanach * leistungskurve_kW[i, 1];
        }

    }
}
