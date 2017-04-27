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

namespace GameOfLife
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        const int anzahlZellenBreit = 30;
        const int anzahlZellenHoch = 30;
        Rectangle[,] felder = new Rectangle[anzahlZellenBreit, anzahlZellenHoch];

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < anzahlZellenHoch; i++)
            {
                for (int j = 0; j < anzahlZellenBreit; j++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = zeichenfläche.ActualWidth / anzahlZellenBreit - 2.0;
                    r.Height = zeichenfläche.ActualHeight / anzahlZellenHoch - 2.0;
                    r.Fill = Brushes.Cyan;
                    zeichenfläche.Children.Add(r);
                    Canvas.SetLeft(r, j * zeichenfläche.ActualWidth / anzahlZellenBreit);
                    Canvas.SetTop(r, i * zeichenfläche.ActualHeight / anzahlZellenHoch);
                    r.MouseDown += R_MouseDown;

                    felder[i, j] = r;
                }
            }
        }

        private void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill =
                (((Rectangle)sender).Fill == Brushes.Cyan) ? Brushes.Red : Brushes.Cyan;
        }

        private void ButtonNächster_Click(object sender, RoutedEventArgs e)
        {
            int[,] anzahlNachbarn = new int[anzahlZellenHoch, anzahlZellenBreit];
            for (int i = 0; i < anzahlZellenHoch; i++)
            {
                for (int j = 0; j < anzahlZellenBreit; j++)
                {
                    int iDarüber = i - 1;
                    if (iDarüber < 0)
                    { iDarüber = anzahlZellenHoch - 1; }
                    int iDarunter = i + 1;
                    if (iDarunter >= anzahlZellenHoch)
                    { iDarunter = 0; }
                    int jLinks = j - 1;
                    if (jLinks < 0)
                    { jLinks = anzahlZellenBreit - 1; }
                    int jRechts = j + 1;
                    if (jRechts >= anzahlZellenBreit)
                    { jRechts = 0; }

                    int nachbarn = 0;

                    if (felder[iDarüber, jLinks].Fill == Brushes.Red)
                    { nachbarn++; }
                    if (felder[iDarüber, j].Fill == Brushes.Red)
                    { nachbarn++; }
                    if (felder[iDarüber, jRechts].Fill == Brushes.Red)
                    { nachbarn++; }
                    if (felder[i, jLinks].Fill == Brushes.Red)
                    { nachbarn++; }
                    if (felder[i, jRechts].Fill == Brushes.Red)
                    { nachbarn++; }
                    if (felder[iDarunter, jLinks].Fill == Brushes.Red)
                    { nachbarn++; }
                    if (felder[iDarunter, j].Fill == Brushes.Red)
                    { nachbarn++; }
                    if (felder[iDarunter, jRechts].Fill == Brushes.Red)
                    { nachbarn++; }

                    anzahlNachbarn[i, j] = nachbarn;
                }
            }

            for (int i = 0; i < anzahlZellenHoch; i++)
            {
                for (int j = 0; j < anzahlZellenBreit; j++)
                {
                    if(anzahlNachbarn[i, j] < 2 || anzahlNachbarn[i, j] > 3)
                    {
                        felder[i, j].Fill = Brushes.Cyan;
                    }
                    else if (anzahlNachbarn[i, j] == 3)
                    {
                        felder[i, j].Fill = Brushes.Red;
                    }
                }
            }
        }
    }
}
