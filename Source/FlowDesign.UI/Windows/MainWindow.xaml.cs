using FlowDesign.UI.Helper;
using FlowDesign.UI.ViewModels;
using System;
using System.Windows;

namespace FlowDesign.UI.Windows
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDarkColorTheme = true;

        public MainWindow()
        {
            InitializeComponent();

            UIServices.Initialize();

            // Initialisierung des PageManagers.
            UIServices.PageManager.FrameControl = mainFrame;
            UIServices.PageManager.SwitchPageByName("startseite");

            UIServices.StatusBar.StatusItem = statusItem;
            UIServices.StatusBar.StatusBar = statusBar;
        }

        private void NewProject(object sender, RoutedEventArgs e)
        {
            UIServices.StartPageManager.SwitchPageByName("createProject");
            UIServices.PageManager.SwitchPageByName("startseite");
        }

        private void OpenProject(object sender, RoutedEventArgs e)
        {
            StartPageViewModel viewModel = (StartPageViewModel)UIServices.PageManager.GetPage("startseite").DataContext;
            viewModel.LoadProject(UIServices.FolderBrowserDialogProject());
        }

        private void SaveProject(object sender, RoutedEventArgs e)
        {
            MainPageViewModel viewModel = (MainPageViewModel)UIServices.PageManager.GetPage("hauptseite").DataContext;
            if(DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(viewModel.CurrentProject))
            {
                UIServices.StatusBar.PrintStatus($"Projekt {viewModel.CurrentProject.Info.Name} erfolgreich gespeichert.", Status.Success);
            }
            else
            {
                UIServices.StatusBar.PrintStatus($"Projekt {viewModel.CurrentProject.Info.Name} nicht gespeichert.", Status.Danger);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(isDarkColorTheme)
            {
                
                isDarkColorTheme = false;
            }
            else
            {
                
                isDarkColorTheme = true;
            }

        }

        private void DarkColorTheme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary colorTheme = new ResourceDictionary();
            colorTheme.Source = new Uri("Resources/ColorThemes/DarkColorTheme.xaml", UriKind.Relative);

            RemoveColorTheme();
            Application.Current.Resources.MergedDictionaries.Add(colorTheme);
        }

        private void LightColorTheme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary colorTheme = new ResourceDictionary();
            colorTheme.Source = new Uri("Resources/ColorThemes/LightColorTheme.xaml", UriKind.Relative);

            RemoveColorTheme();
            Application.Current.Resources.MergedDictionaries.Add(colorTheme);
        }

        /// <summary>
        /// Löscht das ResourceDictionary für das ColorTheme.
        /// </summary>
        private void RemoveColorTheme()
        {
            int resourceIndexOfColorTheme = -1;
            for (int i = 0; i < Application.Current.Resources.MergedDictionaries.Count; i++)
            {
                if (Application.Current.Resources.MergedDictionaries[i].Source.ToString().Contains("Resources/ColorThemes/"))
                {
                    resourceIndexOfColorTheme = i;
                    break;
                }
            }

            Application.Current.Resources.MergedDictionaries.RemoveAt(resourceIndexOfColorTheme);
        }

        
    }


}
