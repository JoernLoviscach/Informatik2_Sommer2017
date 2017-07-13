using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
        string basisUrl = "http://www.j3L7h2.de/crawlertest/";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WebClient c = new WebClient();
            c.Encoding = Encoding.UTF8; // TODO: Was tun, wenn nicht UTF8?
            string s = c.DownloadString(basisUrl + "0.html");

            MatchCollection m = Regex.Matches(s, "<a href=\"([^\"]*)\">");
            //TODO: In <a ...> dürfen weitere Sachen stehen! 
            int trefferAnzahl = m.Count;

            string x = m[3].Groups[1].Value;
        }

        void SammleUrls(string url)
        {


        }
    }
}
