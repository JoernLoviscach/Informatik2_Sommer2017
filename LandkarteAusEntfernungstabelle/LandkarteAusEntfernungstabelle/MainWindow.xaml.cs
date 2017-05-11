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

namespace LandkarteAusEntfernungstabelle
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] orte = { "Berlin", "Bielefeld", "Frankfurt a.M.", "Hamburg", "Köln", "München", "Saarbrücken" };
        //int[,] distanzen = { { 0, 335, ....}, { 335, 0, ...}, ... };
        int[][] distanzen = { new int[] { 335 },
                              new int[] { 425, 215 },
                              new int[] { 255, 195, 395 },
                              new int[] { 480, 165, 155, 355 },
                              new int[] { 505, 485, 305, 615, 455 },
                              new int[] { 580, 330, 155, 525, 190, 360 }};

        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}