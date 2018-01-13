using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;
using Shell32;

namespace KoiAnime_Client.Dialogs
{
    /// <summary>
    /// Interaction logic for TItleInfo.xaml
    /// </summary>
    public partial class TItleInfo : MetroWindow
    {
        public TItleInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get duration of a video
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static bool GetDuration(string filename, out TimeSpan duration)
        {
            try
            {
                Shell shl = new Shell();
                var fldr = shl.NameSpace(System.IO.Path.GetDirectoryName(filename));
                var itm = fldr.ParseName(System.IO.Path.GetFileName(filename));

                // Index 27 is the video duration [This may not always be the case]
                var propValue = fldr.GetDetailsOf(itm, 27);

                return TimeSpan.TryParse(propValue, out duration);
            }
            catch (Exception)
            {
                duration = new TimeSpan();
                return false;
            }
        }
    }
}
