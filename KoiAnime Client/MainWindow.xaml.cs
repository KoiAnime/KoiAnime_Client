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
using KoiAnime_Client.UserLibs;
using MahApps.Metro.Controls;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace KoiAnime_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        RestClient client = new RestClient("http://localhost:5550/");
        public static List<string> InvalidJsonElements;
        //Title[] topRated;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Methods

        /// <summary>
        /// Deserialize to Ilist<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static IList<T> DeserializeToList<T>(string jsonString)
        {
            InvalidJsonElements = null;
            var array = JArray.Parse(jsonString);
            IList<T> objectsList = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    // CorrectElements
                    objectsList.Add(item.ToObject<T>());
                }
                catch (Exception ex)
                {
                    InvalidJsonElements = InvalidJsonElements ?? new List<string>();
                    InvalidJsonElements.Add(item.ToString());
                }
            }

            return objectsList;
        }
        #endregion

        private void Pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tabItem = e.Source as TabItem;

            switch(tabItem.Name)
            {
                case "TopRated":
                    var request = new RestRequest("{id}", Method.GET);
                    request.AddUrlSegment("id", "TopRated");
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;
                    break;
            }
        }
    }
}
