using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal static class Dialog
    {
        private const string defaultCloseButtonText = "Ok";
        public static string DefaultErrorTitle() => "Erreur systeme";
        public static string DefaultErrorContent() => "Desole nous avons rencontre une erreur. S'il vous plait, veuillez ressayer plus tard.";


        /*   --- Dialog Box with only close button ---   */
        public static async Task<ContentDialogResult> VoidDialog(string title, string content, string closeButtonText = defaultCloseButtonText)
        {
            ContentDialog dialog = new ContentDialog()
            {
                XamlRoot = WindowSingleton.Instance().DialogPanel.XamlRoot,
                Title = title,
                Content = content,
                CloseButtonText = closeButtonText,
            };

            return await dialog.ShowAsync();
        }
    }
}
