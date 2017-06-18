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

namespace Windenergieanlagen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Windenergieanlage w = new W127();
            //double x1 = w.BestimmeLeistung_kW(1.0);
            //double x2 = w.BestimmeLeistung_kW(2.0);
            //double x3 = w.BestimmeLeistung_kW(10.0);
            //double x4 = w.BestimmeLeistung_kW(11.8);
            //double x5 = w.BestimmeLeistung_kW(31.0);
            //double x6 = w.BestimmeLeistung_kW(42.0);
            double x = w.BestimmeJahresenergieertrag_kWh(10.0);

            Windenergieanlage iw = new IdealeWEA(127.0);
            double y = iw.BestimmeJahresenergieertrag_kWh(10.0);
        }
    }
}
