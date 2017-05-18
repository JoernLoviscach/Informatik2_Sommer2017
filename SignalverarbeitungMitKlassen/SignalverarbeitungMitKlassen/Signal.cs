using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalverarbeitungMitKlassen
{
    class Signal
    {
        int abtastrate;
        public int Abtastrate
        {
            get { return abtastrate; }
        }

        public Signal(int abtastrate)
        {
            this.abtastrate = abtastrate;
        }

        public virtual double HoleSample(int index)
        {
            return 0.0;
        }

        public void SpieleAb(int länge)
        {
            double[] signal = new double[länge * Abtastrate];
            for (int i = 0; i < signal.Length; i++)
            {
                signal[i] = HoleSample(i);
            }
            Audio.Play(signal, Abtastrate);
        }
    }

    class Sinus : Signal
    {
        double frequenz;
        double amplitude;

        public Sinus(double frequenz, double amplitude, int abtastrate)
            : base(abtastrate)
        {
            this.frequenz = frequenz;
            this.amplitude = amplitude;
        }

        public override double HoleSample(int index)
        {
            return amplitude * Math.Sin(2.0 * Math.PI * frequenz * index / Abtastrate);
        }
    }

    class Mischer : Signal
    {
        Signal s1, s2;
        double faktor1, faktor2;

        public Mischer(Signal s1, double faktor1, Signal s2, double faktor2)
            : base(s1.Abtastrate) // TODO: Ist s1.Abtastrate == s2.Abtastrate?
        {
            this.s1 = s1;
            this.faktor1 = faktor1;
            this.s2 = s2;
            this.faktor2 = faktor2;
        }

        public override double HoleSample(int index)
        {
            return faktor1 * s1.HoleSample(index) + faktor2 * s2.HoleSample(index);
        }
    }

    class SignalVonPlatte : Signal
    {
        double[] werte;

        public SignalVonPlatte(string datei, int abtastrate)
            : base(abtastrate)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(datei));
            long byteZahl = br.BaseStream.Length;
            int anzahlWerte = (int)byteZahl / sizeof(double);
            werte = new double[anzahlWerte];
            for (int i = 0; i < anzahlWerte; i++)
            {
                werte[i] = br.ReadDouble();
            }
            br.Close();
        }

        public override double HoleSample(int index)
        {
            return werte[index];
        }
    }
}
