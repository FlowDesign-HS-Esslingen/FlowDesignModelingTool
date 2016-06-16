using FlowDesign.UI.Helper;
using FlowDesign.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FlowDesign.UI.Pages
{
    /// <summary>
    /// Interaktionslogik für CreateProjectPage.xaml
    /// </summary>
    public partial class CreateProjectPage : Page
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public CreateProjectPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Eventhandler, der aufgerufen wird, wenn auf den abbruch Button bei der Diagramm erstellung geklickt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void CreationCancelButton_Click(object sender, RoutedEventArgs e)
        {
            UIServices.StartPageManager.SwitchPageByName("info");
        }

        /// <summary>
        /// Eventhandler, der aufgerufen wird, wenn auf den druchsuchen Button geklickt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void BrowseFileButton_Click(object sender, RoutedEventArgs e)
        {
            ((CreateProjectViewModel)DataContext).ProjectFilepath = UIServices.FileBrowserDialog();
        }
    }
}
