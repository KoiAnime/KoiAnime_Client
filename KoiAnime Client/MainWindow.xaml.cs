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
using KoiAnime.UserLibs;
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
        private static IList<Title> titles = null;
        private static SimpleLogger logger = new SimpleLogger();

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
            TabControl tabControl = sender as TabControl; // e.Source could have been used instead of sender as well
            TabItem tabItem = tabControl.SelectedValue as TabItem;

            if (tabItem != e.Source)
            {
                if (tabItem != null)
                {
                    if (tabItem.Name != null)
                    {
                        switch (tabItem.Name)
                        {
                            case "TopRated":
                                TopTen.Items.Clear();
                                var requestrated = new RestRequest("{id}", Method.GET);
                                requestrated.AddUrlSegment("id", "TopRated");
                                IRestResponse responserated = client.Execute(requestrated);
                                var contentrated = responserated.Content;
                                CreateTopRated(contentrated);
                                break;

                            case "Gallery":
                                TopTen.Items.Clear();
                                var requestgallery = new RestRequest("{id}", Method.GET);
                                requestgallery.AddUrlSegment("id", "Gallery");
                                IRestResponse responsegallery = client.Execute(requestgallery);
                                var contentgallery = responsegallery.Content;
                                CreateGallery(contentgallery);
                                break;
                        }
                    }
                }
            }   
        }

        private void CreateTopRated(string json)
        {
            TopTen.Items.Clear();

            titles = null;

            titles = DeserializeToList<Title>(json);

            for (int i = 0;i < titles.Count;i++)
            {
                Title t = titles[i];
                Cover c = c = new Cover(t.TitleId, t.TitleName, t.TitleDescription, t.TitleCategory, t.TitleNumberChapters, t.TitleStartDateTime, t.TitleCoverImg, t.TitleState, t.TitleViews);
                c.MouseLeftButtonDown += new MouseButtonEventHandler(Cover_click);
                TopTen.Items.Add(c);
            }
        }

        private void CreateGallery(string json)
        {
            GalleryBox.Items.Clear();

            titles = null;

            titles = DeserializeToList<Title>(json);

            for (int i = 0; i < titles.Count; i++)
            {
                Title t = titles[i];
                Cover c = c = new Cover(t.TitleId, t.TitleName, t.TitleDescription, t.TitleCategory, t.TitleNumberChapters, t.TitleStartDateTime, t.TitleCoverImg, t.TitleState, t.TitleViews);
                c.MouseLeftButtonDown += new MouseButtonEventHandler(Cover_click);
                GalleryBox.Items.Add(c);
            }
        }

        private async void Cover_click(object sender, MouseButtonEventArgs e)
        {
            //await MetroDialog.MessageBoxAsync(this, "This works", "Info");
        }
    }
}
