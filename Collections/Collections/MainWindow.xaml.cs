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

namespace Collections
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int[] a = new int[23];
            List<int> b = new List<int>();
            b.Add(13);
            b.Add(7);
            b.Add(4);
            b.RemoveAt(0);
            int x = b[0];
            int y = b.Count;

            // Warteschlange von Listen von Messwerten
            Queue<List<Messwert>> warteschlange = new Queue<List<Messwert>>();

            //List<Messwert> liste1 = new List<Messwert>();
            //liste1.Add(new Lufttemperatur()); // Polymorphie!!!
            //liste1.Add(new Windgeschwindigkeit());
            //warteschlange.Enqueue(liste1);

            List<Messwert> liste1
                = new List<Messwert> { new Lufttemperatur(),
                                       new Windgeschwindigkeit() };
            warteschlange.Enqueue(liste1);

            List<Messwert> liste2
                = new List<Messwert> { new Windgeschwindigkeit(),
                                       new Windrichtung(),
                                       new Windrichtung() };
            warteschlange.Enqueue(liste2);

            liste1.RemoveAt(0);
            Messwert m = warteschlange.Dequeue()[0];

            //Stapel von Listen von Messwerten
            Stack<List<Messwert>> stapel = new Stack<List<Messwert>>();
            stapel.Push(liste1);
            stapel.Push(liste2);
            Messwert m1 = stapel.Pop()[1];

            List<Queue<int>> u = new List<Queue<int>>();
            Queue<int> q = new Queue<int>();
            u.Add(q);
            u.Add(q);
            q.Enqueue(7);
            q.Enqueue(4);
            Queue<int> p = new Queue<int>();
            p.Enqueue(13);
            u.Add(p);
            int x1 = q.Dequeue();
            int x2 = u[1].Dequeue();
        }
    }

    abstract class Messwert
    {
        DateTime zeitpunkt;
    }

    class Lufttemperatur : Messwert
    {
        double temperatur;
    }

    class Windgeschwindigkeit : Messwert
    {
        double geschwindigkeit;
    }

    class Windrichtung : Messwert
    {
        double richtung;
    }
}
