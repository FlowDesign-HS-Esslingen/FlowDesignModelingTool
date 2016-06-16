using FlowDesign.DataAccess;
using FlowDesign.Model;
using FlowDesign.Service;
using FlowDesign.Service.Application;
using FlowDesign.UI.Commands;
using FlowDesign.UI.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace FlowDesign.UI.ViewModels
{
    /// <summary>
    /// ViewModel für die Startseite.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ViewModelBase" />
    public class StartPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Validiert das Laden eines Projekts.
        /// </summary>
        private Validation loadProjectValidation;

        /// <summary>
        /// Alle Projekte die zuletzt geöffnet wurden, und deren Dateipfad noch gefunden werden kann.
        /// </summary>
        public ObservableCollection<RecentlyUsedProject> RecentlyOpenedProjects { get; set; }

        /// <summary>
        /// Das gelande Projekt (interner Wert).
        /// </summary>
        private Project loadedProject;

        /// <summary>
        /// Das gelande Projekt.
        /// </summary>
        public Project LoadedProject
        {
            get { return loadedProject; }
            set { loadedProject = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Kommando für das laden eines Projekts.
        /// </summary>
        public DelegateCommand LoadProjectCommand { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public StartPageViewModel()
        {
            LoadProjectCommand = new DelegateCommand(e => true, e =>
            {
                string path = (string)e;

                LoadProject(path);
            });

            loadProjectValidation = new Validation(() =>
            {
                if(LoadedProject == null)
                {
                    loadProjectValidation.ValidationMessages.Add("Projekt konnte nicht geladen werden");
                    return false;
                }

                return true;
            });

            RecentlyOpenedProjects = new ObservableCollection<RecentlyUsedProject>();

            LoadRecentlyOpenedProjects();
        }

        /// <summary>
        /// Lädt ein Projekt aus einem Repository.
        /// </summary>
        /// <param name="filepath">Der Pfad zum zu öffnenden Projekt.</param>
        public void LoadProject(string filepath)
        {
            if(string.IsNullOrEmpty(filepath))
            {
                return;
            }

            IRepository saveTest = DataAccessProvider.GetRepository(DataAccessType.Local);
            LoadedProject = saveTest.LoadProject(filepath);

            if(!loadProjectValidation.Validate())
            {
                // TODO (JS): Fehler ausgeben.
                return;
            }

            ApplicationService.AddRecentlyUsed(new RecentlyUsedProject { Name = LoadedProject.Info.Name, Filepath = LoadedProject.Info.Filepath + "/ProjectInfo.flow" });
            ApplicationService.SaveConfig();

            InitializeMainPage();
            GoToMainPage();
        }

        /// <summary>
        /// Übergibt das geladene Projekt an das ViewModel der Hauptseite.
        /// </summary>
        private void InitializeMainPage()
        {
            // Projekt an Hauptseite übergeben.
            MainPageViewModel mainPageViewModel = (MainPageViewModel)UIServices.PageManager.GetPage("hauptseite").DataContext;
            mainPageViewModel.CurrentProject = LoadedProject;
        }

        /// <summary>
        /// Öffnet die Seite für die Hauptseite.
        /// </summary>
        private void GoToMainPage()
        {
            UIServices.PageManager.SwitchPageByName("hauptseite");
            UIServices.StatusBar.PrintStatus("Projekt geladen", Status.Success);
        }

        /// <summary>
        /// Lädt alle kürzlich geöffnenten Projekte und fügt sie einer Liste hinzu, damit sie auf der Startseite angezeigt werden könnnen.
        /// 
        /// </summary>
        private void LoadRecentlyOpenedProjects()
        {
            ApplicationConfig config = ApplicationService.GetConfig();

            if (config.RecentlyUsedProjects == null)
            {
                return;
            }

            List<RecentlyUsedProject> projectsToRemove = new List<RecentlyUsedProject>();

            foreach (RecentlyUsedProject project in config.RecentlyUsedProjects)
            {
                // Wenn das Projekt nicht mehr aufgefunden werden kann, aus der Liste löschen.
                if(File.Exists(project.Filepath))
                {
                    if(!RecentlyOpenedProjects.Contains(project))
                        RecentlyOpenedProjects.Add(project);
                }
                else
                {
                    projectsToRemove.Add(project);
                }
            }

            // Speichert die kürzlich hinzugefügten Projekte in der Config.
            foreach(RecentlyUsedProject project in projectsToRemove)
            {
                config.RecentlyUsedProjects.Remove(project);
            }

            ApplicationService.SaveConfig();
        }
    }
}
