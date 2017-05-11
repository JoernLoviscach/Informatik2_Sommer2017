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
using System.Windows.Threading;

namespace LandkarteAusEntfernungstabelle
{
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
        DispatcherTimer timer = new DispatcherTimer();
        Random würfel = new Random();
        Point[] positionen;
        double energie;

        public MainWindow()
        {
            InitializeComponent();
            positionen = new Point[orte.Length];
            energie = BestimmeEnergie(positionen);
            timer.Interval = TimeSpan.FromSeconds(0.001); // so schnell kann es natürlich nicht werden
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {         
            Point[] positionenNeu = new Point[orte.Length];
            for (int j = 0; j < orte.Length; j++)
            {
                positionenNeu[j].X = positionen[j].X + würfel.NextDouble() - 0.5;
                positionenNeu[j].Y = positionen[j].Y + würfel.NextDouble() - 0.5;
            }
            double energieNeu = BestimmeEnergie(positionenNeu);
            if (energieNeu < energie)
            {
                energie = energieNeu;
                positionen = positionenNeu;
            }

            zeichenfläche.Children.Clear();
            for (int j = 0; j < orte.Length; j++)
            {
                Ellipse elli = new Ellipse(); // TODO: nur einmal anlegen und beim nächsten Mal wiederverwenden
                elli.Fill = Brushes.Red;
                elli.Width = 10.0;
                elli.Height = 10.0;
                Canvas.SetLeft(elli, 300.0 + 0.5 * positionen[j].X);
                Canvas.SetTop(elli, 300.0 + 0.5 * positionen[j].Y);
                zeichenfläche.Children.Add(elli);

                TextBlock text = new TextBlock(); // TODO: nur einmal anlegen und beim nächsten Mal wiederverwenden
                text.Text = orte[j];
                Canvas.SetLeft(text, 300.0 + 0.5 * positionen[j].X);
                Canvas.SetTop(text, 300.0 + 0.5 * positionen[j].Y);
                zeichenfläche.Children.Add(text);
            }
        }

        int BestimmeDistanz(int ort1, int ort2)
        {
            if(ort1 == ort2)
            {
                return 0;
            }
            if (ort1 > ort2)
            {
                return distanzen[ort1 - 1][ort2];
            }
            return distanzen[ort2 - 1][ort1];
        }

        double BestimmeEnergie(Point[] positionen)
        {
            double energie = 0.0;
            for (int i = 0; i < orte.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int d = BestimmeDistanz(i, j);
                    double xDiff = positionen[i].X - positionen[j].X;
                    double yDiff = positionen[i].Y - positionen[j].Y;
                    double dAktuell = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
                    double längenDifferenz = d - dAktuell;
                    energie += längenDifferenz * längenDifferenz;
                }
            }
            return energie;
        }
    }
}