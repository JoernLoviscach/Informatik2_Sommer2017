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
            double[] signal = new double[2 * 44100];
            for (int i = 0; i < signal.Length; i++)
            {
                signal[i] = Math.Sin(2.0 * Math.PI * 440.0 * i / 44100.0);
            }
            Audio.Play(signal, 44100);
        }
    }
}
