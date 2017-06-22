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

namespace ClassInterfaceStruct
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            A a = new A();
            A aKopie = a;
            a.X = 42;
            int u = aKopie.X;

            B b = new B();
            B bKopie = b;
            b.X = 42;
            int v = bKopie.X;

            DreiDPunkt d3 = new DreiDPunkt(3.0, 4.0, 5.0);
        }
    }

    class A : ICloneable
    {
        public int X;

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

    struct B
    {
        public int X;
    }

    abstract class C
    {
        public int X;

        abstract public void TuWas();
    }

    abstract class D : C
    {
        public int Y;
    }

    interface IKannWas
    {
        void TuWas();
    }

    interface IKannMehr : IKannWas
    {
        void TuMehr();
    }

    class E : A, IKannWas
    {
        public void TuWas()
        {
        }
    }

    struct DreiDPunkt
    {
        double x, y, z;
        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Z { get { return z; } }

        public DreiDPunkt(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
