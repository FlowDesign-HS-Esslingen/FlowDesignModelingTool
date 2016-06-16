using FlowDesign.UI.Helper;
using FlowDesign.UI.ViewModels;
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

namespace FlowDesign.UI.Pages
{
    /// <summary>
    /// Interaktionslogik für StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public StartPage()
        {
            InitializeComponent();

            // Initialisierung des Pagemanagers für die startseite.
            UIServices.StartPageManager.FrameControl = startPageFrame;
            UIServices.StartPageManager.SwitchPageByName("info");
        }

        /// <summary>
        /// Eventhandler, der aufgerufen wird, wenn auf erstellen geklickt wird.s
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void NewProjectButton_Clicked(object sender, RoutedEventArgs e)
        {
            UIServices.StartPageManager.SwitchPageByName("createProject");
        }

        /// <summary>
        /// Eventhandler, der aufgerufen wird, wenn auf den Projekt laden Button geklickt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void LoadProjectButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((StartPageViewModel)DataContext).LoadProject(UIServices.FolderBrowserDialogProject());
        }
    }
}
