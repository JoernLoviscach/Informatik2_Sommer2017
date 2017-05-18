using System;
using System.Collections.Generic;
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
}
