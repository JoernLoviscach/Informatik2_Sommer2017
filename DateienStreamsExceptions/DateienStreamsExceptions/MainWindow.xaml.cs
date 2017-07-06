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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //File.WriteAllText("bla.txt", "äöüßÄÖÜsdizfhsiufhseiuf");

            string[] daten = File.ReadAllLines("daten.txt");
            for (int i = 0; i < daten.Length; i++)
            {
                string[] teile = daten[i].Split(';');
                double x = double.Parse(teile[1]);
                // Dann etwas mit x tun.
            }

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

            //Stream fs = new FileStream("test.bla", FileMode.Create);
            //fs.WriteByte(64);
            //fs.WriteByte(65);
            //fs.WriteByte(66);
            //fs.WriteByte(67);
            //fs.Seek(2, SeekOrigin.Begin);
            //fs.WriteByte(68);
            //fs.Close();

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

            FileStream fs = new FileStream("test.gz", FileMode.Create);
            GZipStream gs = new GZipStream(fs, CompressionMode.Compress);
            gs.WriteByte(64);
            gs.WriteByte(65);
            gs.WriteByte(66);
            gs.Close();
            //fs.Close();
        }
    }
}
