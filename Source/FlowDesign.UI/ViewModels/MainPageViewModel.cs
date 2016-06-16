using FlowDesign.DataAccess;
using FlowDesign.Model;
using FlowDesign.Model.Components;
using FlowDesign.Model.Components.Common;
using FlowDesign.Model.Components.FlowView;
using FlowDesign.Model.Flow;
using FlowDesign.Service;
using FlowDesign.Service.ComponentServices;
using FlowDesign.UI.Commands;
using FlowDesign.UI.Controls.Components;
using FlowDesign.UI.Helper;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FlowDesign.UI.ViewModels
{
    /// <summary>
    /// ViewModel für die Hauptseite der Anwendung.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ViewModelBase" />
    public class MainPageViewModel : ViewModelBase
    {
        public delegate void OnSelectionChangedHandler(ComponentViewModel sender);
        /// <summary>
        /// Tritt ein, wenn auf der Zeichenfläche eine Komponenten ausgewählt wird.
        /// </summary>
        public event OnSelectionChangedHandler OnSelectionChanged;

        /// <summary>
        /// Das aktuell bearbeitete Projekt (interner Wert).
        /// </summary>
        private Project currentProject;

        /// <summary>
        /// Das aktuell bearbeitete Projekt.
        /// </summary>
        public Project CurrentProject
        {
            get { return currentProject; }
            set
            {
                currentProject = value;

                EnviromentDiagrams.Clear();
                var envDiagrams = value.Diagrams.Where(e => e is SystemEnvDiagram);
                foreach (var t in envDiagrams)
                {
                    EnviromentDiagrams.Add(t);
                }

                ProtoypeDiagrams.Clear();
                var protDiagrams = value.Diagrams.Where(e => e is PrototypeDiagram);
                foreach (var t in protDiagrams)
                {
                    ProtoypeDiagrams.Add(t);
                }

                FlowViewDiagrams.Clear();
                var flowDiagrams = value.Diagrams.Where(e => e is FlowViewDiagram);
                foreach (var t in flowDiagrams)
                {
                    FlowViewDiagrams.Add(t);
                }

                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Das aktuell bearbeitete Diagramm (interner Wert).
        /// </summary>
        private Diagram currentDiagram;

        /// <summary>
        /// Das aktuell bearbeitete Diagramm
        /// </summary>
        public Diagram CurrentDiagram
        {
            get { return currentDiagram; }
            set { currentDiagram = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Legt fest, ob das Eigenschaftsfenster der Komponenten sichtbar ist (interner Wert).
        /// </summary>
        private bool isPropertiesPanelVisible = false;

        /// <summary>
        /// Legt fest, ob das Eigenschaftsfenster der Komponenten sichtbar ist.
        /// </summary>
        public bool IsPropertiesPanelVisible
        {
            get { return isPropertiesPanelVisible; }
            set { isPropertiesPanelVisible = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Enthält alle System-Umwelt Diagramme.
        /// </summary>
        public ObservableCollection<Diagram> EnviromentDiagrams { get; private set; } = new ObservableCollection<Diagram>();

        /// <summary>
        /// Enthält alle Maskenprototypen.
        /// </summary>
        public ObservableCollection<Diagram> ProtoypeDiagrams { get; private set; } = new ObservableCollection<Diagram>();

        /// <summary>
        /// Enthält alle Flow View Diagramme.
        /// </summary>
        public ObservableCollectionExtended<Diagram> FlowViewDiagrams { get; private set; } = new ObservableCollectionExtended<Diagram>();

        /// <summary>
        /// Alle Komponenten, die für die aktuelle Diagrammart verfügbar ist.
        /// </summary>
        public ObservableCollectionExtended<string> AvailableComponents { get; private set; } = new ObservableCollectionExtended<string>();

        /// <summary>
        /// Enthält alle Komponenten, die im aktuellen Diagramm sind. Notwendig, da die Diagramme keine ViewModels enthalten die UI aber ViewModels braucht.
        /// </summary>
        public ObservableCollection<ComponentViewModel> CurrentComponents { get; private set; } = new ObservableCollection<ComponentViewModel>();

        /// <summary>
        /// Gets the flow layers.
        /// </summary>
        public ObservableCollection<FlowViewDiagram> FlowLayers { get; private set; } = new ObservableCollection<FlowViewDiagram>();

        #region Commands
        public DelegateCommand CreateEnviromentDiagramCommand { get; private set; }
        public DelegateCommand CreatePrototypeDiagramCommand { get; private set; }
        public DelegateCommand CreateFlowViewDiagramCommand { get; private set; }

        public DelegateCommand ChangeDiagramCommand { get; private set; }
        public DelegateCommand DeleteComponentCommand { get; private set; }
        public DelegateCommand DeleteDiagramCommand { get; private set; }
        #endregion

        #region Validation        
        /// <summary>
        /// Validiert das erstellen eines Diagramms.
        /// </summary>
        private Service.Validation createDiagramValidation;
        #endregion

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public MainPageViewModel()
        {
            InitializeCommands();
            InitializeValidation();
        }

        /// <summary>
        /// Initialisiert alle Kommandos.
        /// </summary>
        private void InitializeCommands()
        {
            CreateEnviromentDiagramCommand = new DelegateCommand(e => true, e =>
            {
                CreateDiagram<SystemEnvDiagram>((string)e);
            });

            CreatePrototypeDiagramCommand = new DelegateCommand(e => true, e =>
            {
                CreateDiagram<PrototypeDiagram>((string)e);
            });

            CreateFlowViewDiagramCommand = new DelegateCommand(e => true, e =>
            {
                CreateDiagram<FlowViewDiagram>((string)e);
            });

            ChangeDiagramCommand = new DelegateCommand(e => true, e =>
            {
                Diagram diagram = e as Diagram;

                ChangeToDiagram(diagram);
            });

            DeleteComponentCommand = new DelegateCommand(e => true, e =>
            {
                ComponentViewModel viewModel = (ComponentViewModel)e;
                DeleteComponent(viewModel);

                DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(CurrentProject);
            });

            DeleteDiagramCommand = new DelegateCommand(e => true, e =>
            {
                Diagram diagramToDelete = (Diagram)e;
                IRepository repository = DataAccessProvider.GetRepository(DataAccessType.Local);

                if (diagramToDelete is SystemEnvDiagram)
                {
                    EnviromentDiagrams.Remove(diagramToDelete);
                }

                if (diagramToDelete is PrototypeDiagram)
                {
                    ProtoypeDiagrams.Remove(diagramToDelete);
                }

                if (diagramToDelete is FlowViewDiagram)
                {
                    FlowViewDiagrams.Remove(diagramToDelete);

                    foreach (FlowViewDiagram flowView in FlowViewDiagrams)
                    {
                        List<ModulComponent> viewModels = flowView.DiagramComponents.Where(comp =>
                        {
                            if (comp is ModulComponent)
                            {
                                ModulComponent modul = (ModulComponent)comp;

                                return modul.ChildID == diagramToDelete.ID;
                            }

                            return false;
                        }).Cast<ModulComponent>().ToList();

                        for (int i = 0; i < viewModels.Count; i++)
                        {
                            viewModels[i].ChildID = Guid.Empty;
                        }

                    }
                }

                repository.DeleteObject(diagramToDelete, currentProject.Info.Filepath);
                CurrentProject.Diagrams.Remove(diagramToDelete);

                if(CurrentDiagram != null && CurrentDiagram.ID != diagramToDelete.ID)
                {
                    ChangeToDiagram(CurrentDiagram);
                }

                if(CurrentDiagram != null && CurrentDiagram.ID == diagramToDelete.ID)
                {
                    CurrentDiagram = null;
                    CurrentComponents.Clear();
                    AvailableComponents.Clear();
                }

                // Alle Komponenten deselektieren, damit die Properties aktualisiert werden.
                // Alle Properties Panels müssen geupdate werden, da es sein kann, dass das gelöschte Diagramm irgendwo als Eigenschaft festgelegt wurde.
                for (int i = 0; i < CurrentComponents.Count; i++)
                {
                    CurrentComponents[i].IsSelected = false;
                }

                DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(CurrentProject);
            });
        }

        /// <summary>
        /// Initialisiert alle Validierer.
        /// </summary>
        private void InitializeValidation()
        {
            createDiagramValidation = new Service.Validation((arguments) =>
            {
                string diagramName = (string)arguments.Arguments[0];
                if (string.IsNullOrWhiteSpace(diagramName))
                {
                    createDiagramValidation.ValidationMessages.Add("Es muss ein Diagrammname eingegeben werden.");
                    return false;
                }

                if (CurrentProject.Diagrams.Exists(e => e.Name == diagramName))
                {
                    createDiagramValidation.ValidationMessages.Add($"Es existiert bereits ein Diagramm mit dem Namen {diagramName}.");
                    return false;
                }

                return true;
            });

        }

        /// <summary>
        /// Fügt eine Komponente hinzu.
        /// </summary>
        public void AddComponent(string type, double left, double top)
        {
            IComponentService componentService = FlowDesignServices.ComponentServiceFromType(type);
            Component component = componentService.AddComponent(type, CurrentDiagram, new PositionInfo(left, top));

            IViewModelFactory viewModelFactory = ViewModelFactoryManager.GetViewModelFactory(component);
            List<ComponentViewModel> viewModels = null;
            viewModels = viewModelFactory.CreateViewModelsFromComponent(component, CurrentDiagram, this);

            for (int i = 0; i < viewModels.Count; i++)
            {
                viewModels[i].ParentViewModel = this;
                viewModels[i].OnSelectionChanged += ViewModel_OnSelectionChanged;
                CurrentComponents.Add(viewModels[i]);
            }

            DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(CurrentProject);
        }

        /// <summary>
        /// Löscht eine Komponente.
        /// </summary>
        public void DeleteComponent(ComponentViewModel viewModel)
        {
            // Falls das View Model eine LineComponent ist, müssen noch die anhängen view models gelöscht werden.
            if (viewModel is LineComponentViewModel)
            {
                DeleteLineComponents(viewModel);
            }

            // Komponenten löschen
            DeleteComponentFromLists(viewModel);

            // Alle Verbindungen löschen.
            DeleteConnections(viewModel);

            DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(CurrentProject);
        }

        /// <summary>
        /// Läscht eine Linie.
        /// </summary>
        /// <param name="viewModel"></param>
        private void DeleteLineComponents(ComponentViewModel viewModel)
        {
            LineComponentViewModel lineComponentViewModel = (LineComponentViewModel)viewModel;

            DeleteComponentFromLists(lineComponentViewModel.LinePartStartViewModel);
            DeleteComponentFromLists(lineComponentViewModel.LinePartEndViewModel);
        }

        /// <summary>
        /// Löscht alle Verbindungen die zu dem löschenden view model hin-/oder wegführen.
        /// </summary>
        /// <param name="viewModel"></param>
        private void DeleteConnections(ComponentViewModel viewModel)
        {
            // Alle ViewModels holen, in der das zu löschende view model als Source oder Target auftaucht.
            List<ComponentViewModel> connectionViewModels = CurrentComponents.Where(e =>
            {
                if (e is ConnectionViewModel)
                {
                    ConnectionViewModel connectionViewModel = (ConnectionViewModel)e;
                    ConnectionComponent connectionComponent = (ConnectionComponent)connectionViewModel.Component;
                    if (viewModel.Component.ID == connectionComponent.SourceComponentID || viewModel.Component.ID == connectionComponent.TargetComponentID)
                    {
                        return true;
                    }
                }

                return false;
            }).ToList();

            for (int i = 0; i < connectionViewModels.Count; i++)
            {
                ConnectionViewModel currentConnectionViewModel = (ConnectionViewModel)connectionViewModels[i];

                CurrentComponents.Remove(currentConnectionViewModel);
                CurrentDiagram.DiagramComponents.Remove(currentConnectionViewModel.Component);
                Connector.AllConnections.Remove(currentConnectionViewModel);
            }
        }

        /// <summary>
        /// Löscht die Komponente aus allen Listen im MainPageViewModel.
        /// </summary>
        /// <param name="viewModel">Das View Model, das aus den Listen gelöscht werden soll.</param>
        private void DeleteComponentFromLists(ComponentViewModel viewModel)
        {
            CurrentComponents.Remove(viewModel);
            CurrentDiagram.DiagramComponents.Remove(viewModel.Component);
        }

        /// <summary>
        /// Fügt dem Diagramm und dem Canvas eine Verbindung hinzu.
        /// </summary>
        public void AddConnection(ConnectionViewModel connection)
        {
            CurrentDiagram.DiagramComponents.Add(connection.Component);
            CurrentComponents.Add(connection);

            DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(CurrentProject);
        }

        /// <summary>
        /// Löscht eine Verbindung.
        /// </summary>
        public void RemoveConnection(ConnectionViewModel connection)
        {
            CurrentComponents.Remove(connection);
            CurrentDiagram.DiagramComponents.Remove(connection.Component);

            DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(CurrentProject);
        }

        /// <summary>
        /// Erstellt ein Diagramm.
        /// </summary>
        /// <typeparam name="DiagramType">Der Typ des Diagramms.</typeparam>
        /// <param name="name">Der Name des Diagramms.</param>
        private void CreateDiagram<DiagramType>(string name)
        {
            if (!createDiagramValidation.Validate(new ValidationParameters(name)))
            {
                UIServices.StatusBar.PrintStatus(createDiagramValidation.ValidationMessages.FirstOrDefault<string>(), Status.Danger);
                return;
            }

            Diagram createdDiagram = FlowDesignServices.DiagramFactory().CreateDiagram<DiagramType>(name);

            AddDiagramToList(createdDiagram);
            CurrentProject.Diagrams.Add(createdDiagram);

            DataAccess.DataAccessProvider.GetRepository(DataAccess.DataAccessType.Local).SaveProject(CurrentProject);

            UIServices.StatusBar.PrintStatus($"Diagramm - {name} erstellt", Status.Info);
        }

        /// <summary>
        /// Fügt das Diagramm entsprechend seines Typs in die richtige List ein.
        /// </summary>
        /// <param name="diagram">Das Diagramm, das hinzugefügt werden soll.</param>
        private void AddDiagramToList(Diagram diagram)
        {
            if (diagram is SystemEnvDiagram)
            {
                EnviromentDiagrams.Add(diagram);
            }

            if (diagram is PrototypeDiagram)
            {
                ProtoypeDiagrams.Add(diagram);
            }

            if (diagram is FlowViewDiagram)
            {
                FlowViewDiagrams.Add(diagram);
            }

        }

        /// <summary>
        /// Stellt sicher, dass alles für einen Diagramm wechsel vorbereitet ist.
        /// </summary>
        private void ChangeToDiagramPrecondition()
        {
            Connector.AllConnections.Clear();
            AvailableComponents.Clear();
        }

        /// <summary>
        /// Lädt alle Components und Connections eines Diagramms.
        /// </summary>
        /// <param name="diagram">Das Diagramm zu dem gewechselt werden soll.</param>
        private void ChangeToDiagram(Diagram diagram)
        {
            ChangeToDiagramPrecondition();

            CurrentDiagram = diagram;

            LoadCurrentComponents();
            LoadCurrentConnections();

            if (diagram is SystemEnvDiagram)
            {
                ChangeToEnviromentDiagram(diagram);
            }

            if (diagram is PrototypeDiagram)
            {
                ChangeToPrototypeDiagram(diagram);
            }

            if (diagram is FlowViewDiagram)
            {
                ChangeToFlowViewDiagram(diagram);
            }
        }

        /// <summary>
        /// Wechselt zu einem System-Umwelt Diagramm. Ändert die CurrentComponents und die AvailableComponents
        /// </summary>
        private void ChangeToEnviromentDiagram(Diagram diagram)
        {
            AvailableComponents.AddRange(FlowDesignServices.ComponentService<SystemEnvDiagram>().GetAvailableComponents());
        }

        /// <summary>
        /// Wechselt zu einem Maskenprototyp. Ändert die CurrentComponents und die AvailableComponents
        /// </summary>
        private void ChangeToPrototypeDiagram(Diagram diagram)
        {
            AvailableComponents.AddRange(FlowDesignServices.ComponentService<PrototypeDiagram>().GetAvailableComponents());
        }

        /// <summary>
        /// Wechselt zu einem FlowView Diagramm. Ändert die CurrentComponents und die AvailableComponents
        /// </summary>
        private void ChangeToFlowViewDiagram(Diagram diagram)
        {
            FlowLayers.Clear();
            AvailableComponents.AddRange(FlowDesignServices.ComponentService<FlowViewDiagram>().GetAvailableComponents());
        }

        /// <summary>
        /// Springt zu einem Flow View, das in Flow View Ebenen History angeklickt wurde.
        /// Im Gegensatz zu ChangeToFlowViewDiagram(...) wird die FlowLayers Liste nicht gelöscht.
        /// </summary>
        /// <param name="diagram">Das Diagramm zu dem gewechselt werden soll.</param>
        public void ChangeToFlowLayer(FlowViewDiagram diagram)
        {
            ChangeToDiagramPrecondition();

            CurrentDiagram = diagram;

            LoadCurrentComponents();
            LoadCurrentConnections();

            AvailableComponents.AddRange(FlowDesignServices.ComponentService<FlowViewDiagram>().GetAvailableComponents());
        }

        /// <summary>
        /// Lädt für das aktuelle Diagramm die Components in die ViewModels für die Anzeige. 
        /// </summary>
        private void LoadCurrentComponents()
        {
            CurrentComponents.Clear();

            foreach (Component c in CurrentDiagram.DiagramComponents)
            {
                IViewModelFactory viewModelFactory = ViewModelFactoryManager.GetViewModelFactory(c);
                List<ComponentViewModel> viewModels = null;
                viewModels = viewModelFactory.CreateViewModelsFromComponent(c, CurrentDiagram, this);

                for (int i = 0; i < viewModels.Count; i++)
                {
                    viewModels[i].ParentViewModel = this;
                    viewModels[i].OnSelectionChanged += ViewModel_OnSelectionChanged;
                    CurrentComponents.Add(viewModels[i]);
                }
            }

        }

        /// <summary>
        /// Lädt für das aktuelle Diagramm die Verbindungen in die ViewModels für die Anzeige.
        /// </summary>
        private void LoadCurrentConnections()
        {
            // Alle Verbindungen holen.
            List<Component> connections = CurrentDiagram.DiagramComponents.Where(e => e is ConnectionComponent).ToList();

            for (int connectionIndex = 0; connectionIndex < connections.Count; connectionIndex++)
            {
                // Holt alle View models die zu einer Connection passen.
                List<ComponentViewModel> componentsForConnection = CurrentComponents.Where(e =>
                {
                    ConnectionComponent connectionComponent = (ConnectionComponent)connections[connectionIndex];

                    if (e.Component.ID == connectionComponent.SourceComponentID || e.Component.ID == connectionComponent.TargetComponentID)
                        return true;

                    return false;
                }).ToList();

                // Alle ViewModels durchgehen und diesen die Connection hinzufügen, damit die Connectors informiert werden.
                for (int i = 0; i < componentsForConnection.Count; i++)
                {
                    componentsForConnection[i].Connections.Add((ConnectionComponent)connections[connectionIndex]);
                }
            }
        }

        /// <summary>
        /// Wird aufgerufen, wenn eine Komponente im Canvas ausgewählt wird.
        /// </summary>
        private void ViewModel_OnSelectionChanged(ComponentViewModel sender)
        {
            IsPropertiesPanelVisible = sender.IsSelected;
            OnSelectionChanged?.Invoke(sender);
        }
    }
}