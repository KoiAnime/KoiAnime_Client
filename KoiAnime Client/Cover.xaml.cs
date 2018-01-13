using System;
using System.Collections.Generic;
using System.IO;
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
using KoiAnime_Client;

namespace KoiAnime_Client
{
    /// <summary>
    /// Lógica de interacción para COver.xaml
    /// </summary>
    public partial class Cover : UserControl
    {
        private int _titleId { get; set; }
        private string _titleName { get; set; }
        public string _titleDescription { get; set; }
        public int _titleCategory { get; set; }
        public int _titleNumberChapters { get; set; }
        public DateTime _titleStartDateTime { get; set; }
        public string _titleCoverImg { get; set; }
        public int _titleState { get; set; }
        public long _titleViews { get; set; }

        public Cover()
        {
            InitializeComponent();
        }

        //initiate cover
        /// <inheritdoc />
        /// <summary>
        /// Creates a cover for a Title and pass info to TitlePage
        /// </summary>
        /// <param name="t"></param>
        public Cover(int titleid,string titlename,string description,int category,int numchapters,DateTime date,string cover,int state,long views)
        {
            InitializeComponent();
            _titleId = titleid;
            titleName.Content = titlename;
            _titleCoverImg = cover;
            _titleCategory = category;
            _titleDescription = description;
            _titleName = titlename;
            _titleNumberChapters = numchapters;
            _titleStartDateTime = date;
            _titleState = state;
            _titleViews = views;
            SetImageFromRow();
            Badge.Badge = _titleNumberChapters;
        }

        // set image from cover
        /// <summary>
        /// Set image of the title cover
        /// </summary>
        private void SetImageFromRow()
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(_titleCoverImg);
            bitmapImage.EndInit();
            cover.Source = bitmapImage;
        }
    }
}
