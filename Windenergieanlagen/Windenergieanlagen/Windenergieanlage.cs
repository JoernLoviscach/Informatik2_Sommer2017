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

        public virtual double BestimmeLeistung(double v) // Sollte abstract sein!
        {
            return 0.0;
        }
    }

    class IdealeWEA : Windenergieanlage
    {
        public override double BestimmeLeistung(double v)
        {
            return 0.5 * 1.225 * Math.PI * Math.Pow(0.5 * Durchmesser, 2.0) * Math.Pow(v, 3.0);
        }
    }

    class Betz : IdealeWEA
    {
        public override double BestimmeLeistung(double v)
        {
            return 16.0 / 27.0 * base.BestimmeLeistung(v);
        }
    }

    class BetzNennleistung : IdealeWEA
    {
        double nennleistung;

        public override double BestimmeLeistung(double v)
        {
            return Math.Min(16.0 / 27.0 * base.BestimmeLeistung(v), nennleistung);
        }
    }

    class W127 : Windenergieanlage
    {

    }
}
