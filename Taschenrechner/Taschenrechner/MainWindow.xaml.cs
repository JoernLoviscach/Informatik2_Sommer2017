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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int aktuellerWert = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 1;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 2;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 3;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 4;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 5;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 6;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 7;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 8;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            aktuellerWert = aktuellerWert * 10 + 9;
            textBlockAusgabe.Text = aktuellerWert.ToString();
        }
    }
}
