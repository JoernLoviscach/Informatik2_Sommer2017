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

namespace SignalverarbeitungMitKlassen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Sinus s = new Sinus(880.0, 0.03, 44100);
            Sinus t = new Sinus(723.0, 0.03, 44100);
            Mischer m = new Mischer(s, 0.5, t, 0.5);
            m.SpieleAb(2);
        }
    }
}
