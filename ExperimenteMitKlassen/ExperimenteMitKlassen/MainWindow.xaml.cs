using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExperimenteMitKlassen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Tür t = new Tür();
            t.Öffne();
            bool türIstZu = t.IstGeschlossen;
            //t.IstGeschlossen = true;

            Auto a = new Auto("BI-AB 123", 4);
            bool b = a.IstAbfahrbereit;
            //Title = b.ToString();
            //System.Diagnostics.Debug.WriteLine(b.ToString());
        }
    }

    class Auto
    {
        string kennzeichen;
        Tür[] türen;

        public Auto(string kennzeichen, int anzahlTüren) // Konstruktor
        {
            this.kennzeichen = kennzeichen;
            türen = new Tür[anzahlTüren];
            for (int i = 0; i < türen.Length; i++)
            {
                türen[i] = new Tür();
            }
        }

        public bool IstAbfahrbereit
        {
            get
            {
                for (int i = 0; i < türen.Length; i++)
                {
                    if (!türen[i].IstGeschlossen)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }

    class Tür
    {
        bool istGeschlossen = true;
        //public bool IstGeschlossen()
        //{
        //    return istGeschlossen;
        //}
        public bool IstGeschlossen
        {
            get { return istGeschlossen; }
        }
        public void Öffne()
        {
            istGeschlossen = false;
        }
        public void Schließe()
        {
            istGeschlossen = true;
        }
    }
}
