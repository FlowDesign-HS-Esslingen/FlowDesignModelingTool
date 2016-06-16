using FlowDesign.DataAccess;
using FlowDesign.Model;
using FlowDesign.Service;
using FlowDesign.Service.Application;
using FlowDesign.UI.Commands;
using FlowDesign.UI.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.UI.ViewModels
{
    /// <summary>
    /// ViewModel für Seite, auf der eine Projekt erstellt werden kann.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ViewModelBase" />
    public class CreateProjectViewModel : ViewModelBase
    {
        /// <summary>
        /// Validierung für das erstellen eines Projekts.
        /// </summary>
        private Validation projectValidation;

        /// <summary>
        /// Das erstellte Projekt (interner Wert).
        /// </summary>
        private Project createdProject = null;

        /// <summary>
        /// Das erstellte Projekt.
        /// </summary>
        public Project CreatedProject
        {
            get { return createdProject; }
            set { createdProject = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Der Name des Projekts (interner Wert).
        /// </summary>
        private string projectName;

        /// <summary>
        /// Der Name des Projekts (interner Wert).
        /// </summary>
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Der Dateipfad, an dem das Projekt gespeichert werden soll. 
        /// Enthält nur den Pfad, nicht den Pojektnamen (interner Wert)
        /// </summary>
        private string projectFilepath;

        /// <summary>
        /// Der Dateipfad, an dem das Projekt gespeichert werden soll. 
        /// Enthält nur den Pfad, nicht den Pojektnamen.
        /// </summary>
        public string ProjectFilepath
        {
            get { return projectFilepath; }
            set { projectFilepath = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Kommando um ein Projekt zu erstellen.
        /// </summary>
        public DelegateCommand CreateProjectCommand { get; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public CreateProjectViewModel()
        {
            CreateProjectCommand = new DelegateCommand(e => true, e => { CreateEmptyProject(); });

            projectValidation = new Validation(() =>
            {
                if(string.IsNullOrEmpty(ProjectName))
                {
                    projectValidation.ValidationMessages.Add("Projektname darf nicht leer sein.");
                    return false;
                }

                if(string.IsNullOrEmpty(ProjectFilepath))
                {
                    projectValidation.ValidationMessages.Add("Projektpfad darf nicht leer sein.");
                    return false;
                }

                if(!Directory.Exists(ProjectFilepath))
                {
                    projectValidation.ValidationMessages.Add("Ungültige Pfadangabe");
                    return false;
                }

                return true;
            });
        }

        /// <summary>
        /// Erstellt ein leeres Projekt.
        /// </summary>
        private void CreateEmptyProject()
        {
            if(!projectValidation.Validate())
            {
                UIServices.StatusBar.PrintStatus(projectValidation.ValidationMessages.FirstOrDefault<string>(), Status.Danger);
                return;
            }

            CreatedProject = new Project();
            CreatedProject.Info.Name = ProjectName;
            CreatedProject.Info.Filepath = $"{ProjectFilepath}/{ProjectName}";

            IRepository saveTest = DataAccessProvider.GetRepository(DataAccessType.Local);
            if(!saveTest.SaveProject(CreatedProject))
            {
                UIServices.StatusBar.PrintStatus($"Projekt konnte nicht erstellt werden - Name: {ProjectName} - Speicherort: {ProjectFilepath}", Status.Success);
            }

            ApplicationService.GetConfig().RecentlyUsedProjects.Add(new RecentlyUsedProject {Name = CreatedProject.Info.Name, Filepath = CreatedProject.Info.Filepath + "/ProjectInfo.flow" });
            ApplicationService.SaveConfig();

            InitializeMainPage();
            GoToMainPage();
        }

        /// <summary>
        /// Übergibt das erstellte Projekt an das ViewModel der Hauptseite.
        /// </summary>
        private void InitializeMainPage()
        {
            // Erstelltes Projekt an die Hautpseite übergeben.
            MainPageViewModel mainPageViewModel = (MainPageViewModel)UIServices.PageManager.GetPage("hauptseite").DataContext;
            mainPageViewModel.CurrentProject = CreatedProject;
        }

        /// <summary>
        /// Springt in der UI zu Hauptseite.
        /// </summary>
        private void GoToMainPage()
        {
            UIServices.PageManager.SwitchPageByName("hauptseite");
            UIServices.StatusBar.PrintStatus($"Projekt erstellt - Name: {ProjectName} - Speicherort: {ProjectFilepath}", Status.Success);
        }
    }
}
