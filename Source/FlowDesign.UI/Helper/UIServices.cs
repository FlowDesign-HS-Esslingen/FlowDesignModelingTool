namespace FlowDesign.UI.Helper
{
    public static class UIServices
    {
        /// <summary>
        /// Gets the page manager.
        /// </summary>
        /// </value>
        public static PageManager PageManager { get; private set; }

        /// <summary>
        /// PageManager für alle Pages die auf der rechten Seite der Startseite angezeigt werden können.
        /// </summary>
        public static PageManager StartPageManager { get; private set; }

        /// <summary>
        /// Helper für die globale Statusleiste unten.
        /// </summary>
        public static StatusBarHelper StatusBar { get; private set; }

        /// <summary>
        /// Initialisiert alles. Muss vor Verwendung aufgerufen werden.
        /// </summary>
        public static void Initialize()
        {
            StartPageManager = new PageManager();
            StartPageManager.RegisterPage(new Pages.InfoPage(), "info");
            StartPageManager.RegisterPage(new Pages.CreateProjectPage(), "createProject");

            PageManager = new PageManager();
            PageManager.RegisterPage(new Pages.StartPage(), "startseite");
            PageManager.RegisterPage(new Pages.MainDiagramPage(), "hauptseite");

            StatusBar = new StatusBarHelper();
        }

        /// <summary>
        /// Öffnet einen FolderBrowserDialog um eine Projekt zu öffnen.
        /// </summary>
        /// <returns>Der ausgewählte Ordner Pfad</returns>
        public static string FolderBrowserDialogProject()
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.DefaultExt = ".flow";
            fileDialog.Filter = "Flow Project (.flow)|*.flow";

            if (fileDialog.ShowDialog() == false)
            {
                return string.Empty;
            }

            return fileDialog.FileName;
        }

        /// <summary>
        /// Öffnet einen FileBrowserDialog.
        /// </summary>
        /// <returns>Der ausgewählte Datei Pfad.</returns>
        public static string FileBrowserDialog()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return string.Empty;
            }

            return dialog.SelectedPath;
        }
    }
}
