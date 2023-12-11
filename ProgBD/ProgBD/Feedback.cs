using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal static class Feedback
    {
        /*   --- Dialog Box with only close button ---   */
        public static async Task<ContentDialogResult> VoidDialog(string title, string content, string closeButtonText)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = WindowSingleton.Instance().DialogPanel.XamlRoot;
            dialog.Title = title;
            dialog.Content = content;
            dialog.CloseButtonText = closeButtonText;

            return await dialog.ShowAsync();
        }
    }
}
