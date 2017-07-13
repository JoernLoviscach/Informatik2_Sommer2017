using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace WebCrawler
{
    public partial class MainWindow : Window
    {
        List<string> urls = new List<string>();
        ConcurrentQueue<Aufgabe> aufgaben = new ConcurrentQueue<Aufgabe>();
        string basisUrl = "http://www.j3L7h2.de/crawlertest/";

        public MainWindow()
        {
            InitializeComponent();

            Thread[] threads = new Thread[4];
            // heute: Task, async, await
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Arbeite);
                threads[i].IsBackground = true;
                threads[i].Priority = ThreadPriority.Lowest;
                threads[i].Name = "Mein Thread Nr. " + i;
                threads[i].Start();
            }
        }

        void Arbeite()
        {
            while (true)
            {
                Aufgabe aufgabe;
                bool istArbeitDa = aufgaben.TryDequeue(out aufgabe);
                if (istArbeitDa)
                {
                    ErledigeAufgabe(aufgabe);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            aufgaben.Enqueue(new Aufgabe("0.html", 4));
        }

        void ErledigeAufgabe(Aufgabe aufgabe)
        {
            WebClient c = new WebClient();
            c.Encoding = Encoding.UTF8; // TODO: Was tun, wenn nicht UTF8?
            string s = c.DownloadString(basisUrl + aufgabe.Url);

            MatchCollection m = Regex.Matches(s, "<a href=\"([^\"]*)\">");
            //TODO: In <a ...> dürfen weitere Sachen stehen! 
            for (int i = 0; i < m.Count; i++)
            {
                string gefundeneUrl = m[i].Groups[1].Value;
                if (!urls.Contains(gefundeneUrl))
                {
                    urls.Add(gefundeneUrl);
                    System.Diagnostics.Debug.Print(Thread.CurrentThread.Name + " " + gefundeneUrl);
                    Dispatcher.BeginInvoke(new Action(
                        () => textBox.Text += " " + gefundeneUrl  
                    ));
                    if (aufgabe.WieVieleSchritteNoch > 1)
                    {
                        aufgaben.Enqueue(new Aufgabe(gefundeneUrl, aufgabe.WieVieleSchritteNoch - 1));
                    }
                }
            }
        }
    }

    class Aufgabe
    {
        string url;
        public string Url { get { return url; } }
        int wieVieleSchritteNoch;
        public int WieVieleSchritteNoch { get { return wieVieleSchritteNoch; } }

        public Aufgabe(string url, int wieVieleSchritteNoch)
        {
            this.url = url;
            this.wieVieleSchritteNoch = wieVieleSchritteNoch;
        }
    }
}
