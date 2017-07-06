using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

namespace DateienStreamsExceptions
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double HoleWert()
        {
            double summe = 0.0;
            string[] daten = File.ReadAllLines("daten42.txt");
            for (int i = 0; i < daten.Length; i++)
            {
                string[] teile = daten[i].Split(';');
                summe += double.Parse(teile[1]);
            }
            return summe;
        }

        double FindeSchnittpunktX(double m1, double b1, double m2, double b2)
        {
            // y1 = m1 * x + b1
            // y2 = m2 * x + b2
            // Schnittpunkt: m1 * x + b1 = m2 * x + b2
            // Auflösen: x = (b2-b1) / (m1-m2)

            if(Math.Abs(m1-m2) < 1e-40)
            {
                throw new ApplicationException("Geraden sind parallel.");
            }

            return (b2 - b1) / (m1 - m2);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    double x = FindeSchnittpunktX(2.0, 3.0, 2.0, 3.0);
            //    textBlock.Text = x.ToString();
            //}
            //catch(ApplicationException ex)
            //{
            //    textBlock.Text = ex.Message;
            //}

            //try
            //{
            //    textBlock.Text = HoleWert().ToString();
            //}
            //catch (System.IO.FileNotFoundException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Ein Fehler ist aufgetreten.");
            //}

            //File.WriteAllText("bla.txt", "äöüßÄÖÜsdizfhsiufhseiuf");

            //string[] daten = File.ReadAllLines("daten.txt");
            //for (int i = 0; i < daten.Length; i++)
            //{
            //    string[] teile = daten[i].Split(';');
            //    double x = double.Parse(teile[1]);
            //    // Dann etwas mit x tun.
            //}

            // Oder: XML, JSON

            // Warum nicht immer so mit Dateien arbeiten?
            // * Menge an Daten zu groß?
            // * Werden Daten noch geschrieben?
            // Und ein Grund aus Objektorientierung:
            // Speichern und Laden nicht auf Dateien beschränken.

            // Deshalb: Stream (abstrakte Klasse)
            // Microsoft: "Provides a generic view of a sequence of bytes."
            // Typische Methoden:
            // Open (Constructor)
            // Seek (nicht immer)
            // Write (nicht immer), C++: << ... << ... <<
            // Read (nicht immer), C++: >> ... >> ... >>
            // Close

            Stream fs = null;
            try
            {
                fs = new FileStream("test.bla", FileMode.Create);
                fs.WriteByte(64);
                fs.WriteByte(65);
                fs.WriteByte(66);
                fs.WriteByte(67);
                fs.Seek(2, SeekOrigin.Begin);
                fs.WriteByte(68);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(fs != null)
                {
                    fs.Close();
                }
            }

            // schönere Schreibweise:
            using (FileStream fs3 = new FileStream("test.bla", FileMode.Create))
            {
                fs3.WriteByte(42);
            } // In jedem Fall wird hier Close aufgerufen.

            //Stream fs2 = new FileStream("test.bla", FileMode.Open);
            //int a = fs2.ReadByte();
            //int b = fs2.ReadByte();
            //int c = fs2.ReadByte();
            //int d = fs2.ReadByte();
            //int f = fs2.ReadByte();
            //int g = fs2.ReadByte();
            //int h = fs2.ReadByte();
            //fs2.Close();

            //Stream fs = new MemoryStream();
            //fs.WriteByte(64);
            //fs.WriteByte(65);
            //fs.WriteByte(66);
            //fs.WriteByte(67);
            //fs.Seek(2, SeekOrigin.Begin);
            //fs.WriteByte(68);
            //fs.Seek(0, SeekOrigin.Begin);
            //int a = fs.ReadByte();
            //int b = fs.ReadByte();
            //int c = fs.ReadByte();
            //int d = fs.ReadByte();
            //int f = fs.ReadByte();
            //int g = fs.ReadByte();
            //int h = fs.ReadByte();
            //fs.Close();

            //FileStream fs = new FileStream("test.gz", FileMode.Create);
            //GZipStream gs = new GZipStream(fs, CompressionMode.Compress);
            //gs.WriteByte(64);
            //gs.WriteByte(65);
            //gs.WriteByte(66);
            //gs.Close();
            ////darin schon erledigt: fs.Close();

            //FileStream fs = new FileStream("test.bla", FileMode.Create);
            //BinaryWriter w = new BinaryWriter(fs);
            //w.Write(true);
            //w.Write(12.345);
            //w.Write("abcd");
            //w.Close(); // darin schon erledigt: fs.Close()
            //// Exception durch: fs.WriteByte(42);

            //FileStream fs2 = new FileStream("test.bla", FileMode.Open);
            //BinaryReader r = new BinaryReader(fs2);
            //bool a = r.ReadBoolean();
            //double b = r.ReadDouble();
            //string c = r.ReadString();
            //// Exception durch: double d = r.ReadDouble();
            //r.Close(); // darin schon erledigt: fs2.Close()

            //FileStream fs = new FileStream("test.txt", FileMode.Create);
            //StreamWriter w = new StreamWriter(fs);
            //w.Write(true);
            //w.Write(12.345);
            //w.Write("abcd");
            //w.Close();

            //FileStream fs2 = new FileStream("test.txt", FileMode.Open);
            //StreamReader r = new StreamReader(fs2);
            //int a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //bool z = r.EndOfStream;
            //a = r.Read();
            //a = r.Read();
            //a = r.Read();
            //r.Close();
        }
    }
}
