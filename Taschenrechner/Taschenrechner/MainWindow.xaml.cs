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

namespace Taschenrechner
{
    public partial class MainWindow : Window
    {
        int aktuellerWert = 0;
        int letztesErgebnis = 0;
        bool zahleneingabeLäuft = true;
        char letzteRechenoperation = '=';

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZifferAnhängen(int z)
        {
            if(zahleneingabeLäuft)
            {
                aktuellerWert = aktuellerWert * 10 + z;
            }
            else
            {
                aktuellerWert = z;
                zahleneingabeLäuft = true;
            }
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(0);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(2);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(3);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(4);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(5);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(6);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(7);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(8);
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen(9);
        }

        private void Rechne(char rechenoperation)
        {
            switch (letzteRechenoperation)
            {
                case '+':
                    letztesErgebnis = letztesErgebnis + aktuellerWert;
                    break;
                case '-':
                    letztesErgebnis = letztesErgebnis - aktuellerWert;
                    break;
                case '*':
                    letztesErgebnis = letztesErgebnis * aktuellerWert;
                    break;
                case '/':
                    letztesErgebnis = letztesErgebnis / aktuellerWert;
                    break;
                case '=':
                    // TODO: Gleichheitszeichen mehrfach drücken?!
                    // TODO: +, -, *, / direkt nach Gleichheitszeichen?!
                    letztesErgebnis = aktuellerWert;
                    break;
            }
            textBlockAusgabe.Text = letztesErgebnis.ToString();
            zahleneingabeLäuft = false;
            letzteRechenoperation = rechenoperation;
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            Rechne('+');
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            Rechne('-');
        }

        private void ButtonMal_Click(object sender, RoutedEventArgs e)
        {
            Rechne('*');
        }

        private void ButtonGeteilt_Click(object sender, RoutedEventArgs e)
        {
            Rechne('/');
        }

        private void ButtonGleich_Click(object sender, RoutedEventArgs e)
        {
            Rechne('=');
        }
    }
}
