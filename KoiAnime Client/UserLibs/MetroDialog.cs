using KoiAnime_Client.Dialogs;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAnime_Client.UserLibs
{
    class MetroDialog
    {
        public MetroDialog()
        {

        }

        /// <summary>
        /// Creates a MessageBox
        /// </summary>
        /// <param name="metroWindow"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task MessageBoxAsync(MetroWindow metroWindow, string title, string message)
        {
            await metroWindow.ShowMessageAsync(title, message);
        }
    }
}
