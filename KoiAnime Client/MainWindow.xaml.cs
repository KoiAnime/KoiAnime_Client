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
using MahApps.Metro.Controls;
using RestSharp;

namespace KoiAnime_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        RestClient client = new RestClient("http://localhost:5550/");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
