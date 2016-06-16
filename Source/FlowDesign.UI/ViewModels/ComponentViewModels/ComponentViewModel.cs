using FlowDesign.Model.Components;
using FlowDesign.Model.Components.Common;
using FlowDesign.UI.Commands;
using System.Collections.Generic;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// Basis Klasse für ViewModels die eine Komponente beinhalten und auf der UI angezeigt werden sollen.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ViewModelBase" />
    public class ComponentViewModel : ViewModelBase
    {
        public delegate void OnSelectionChangedHandler(ComponentViewModel sender);

        /// <summary>
        /// Tritt ein, wenn eine Komponente auf der Zeichenfläche ausgewählt wird.
        /// </summary>
        public event OnSelectionChangedHandler OnSelectionChanged;

        #region Eigenschaften

        /// <summary>
        /// Enthält die Beschreibungen der Eigenschaften, die auf der UI angezeigt werden sollen.
        /// </summary>
        public List<PropertyDescription> PropertyDescriptions { get; } = new List<PropertyDescription>();

        /// <summary>
        /// Die Komponente, die dem ViewModel zugeordnet ist (interner Wert).
        /// </summary>
        private Component component;

        /// <summary>
        /// Die Komponente, die dem ViewModel zugeordnet ist.
        /// </summary>
        public Component Component
        {
            get { return component; }
            set { component = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Das ViewModel der Hauptseite. Erleichert den Zugriff auf Komponenten/ViewModels/Diagramme.
        /// </summary>
        private MainPageViewModel parentViewModel;

        /// <summary>
        /// Das ViewModel der Hauptseite. Erleichert den Zugriff auf Komponenten/ViewModels/Diagramme.
        /// </summary>
        public MainPageViewModel ParentViewModel
        {
            get { return parentViewModel; }
            set { parentViewModel = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Wrapper Property für den Namen der Komponente.
        /// Dadruch kann RaisePropertyChanged() verwendet werden.
        /// </summary>
        public string Name
        {
            get { return Component.Name; }
            set { Component.Name = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Wrapper Property für die Left Position der Komponente.
        /// Dadruch kann RaisePropertyChanged() verwendet werden.
        /// </summary>
        public double Left
        {
            get { return Component.UIProperties.Left; }
            set { Component.UIProperties.Left = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Wrapper Property für die Top Position der Komponente.
        /// Dadruch kann RaisePropertyChanged() verwendet werden.
        /// </summary>
        public double Top
        {
            get { return Component.UIProperties.Top; }
            set { Component.UIProperties.Top = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Wrapper Property für die Breite der Komponente.
        /// Dadruch kann RaisePropertyChanged() verwendet werden.
        /// </summary>
        public double Width
        {
            get { return Component.UIProperties.Width; }
            set { Component.UIProperties.Width = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Wrapper Property für die Höhe der Komponente.
        /// Dadruch kann RaisePropertyChanged() verwendet werden.
        /// </summary>
        public double Height
        {
            get { return Component.UIProperties.Height; }
            set { Component.UIProperties.Height = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Wrapper Property für den ZIndex der Komponente.
        /// Dadruch kann RaisePropertyChanged() verwendet werden.
        /// </summary>
        public int ZIndex
        {
            get { return component.UIProperties.ZIndex; }
            set { component.UIProperties.ZIndex = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Legt fest, ob die Resize Anfasser sichtbar sind.
        /// </summary>
        private bool isResizerVisible = false;

        /// <summary>
        /// Legt fest, ob die Resize Anfasser sichtbar sind.
        /// </summary>
        public bool IsResizerVisible
        {
            get { return isResizerVisible; }
            set { isResizerVisible = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Legt fest, ob die Verbinder sichtbar sind.
        /// </summary>
        private bool isConnectorVisible = false;

        /// <summary>
        /// Legt fest, ob die Verbinder sichtbar sind.
        /// </summary>
        public bool IsConnectorVisible
        {
            get { return isConnectorVisible; }
            set { isConnectorVisible = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Gibt an, ob die Komponente auf der Zeichenfläche ausgewählt ist.
        /// </summary>
        private bool isSelected = false;

        /// <summary>
        /// Gibt an, ob die Komponente auf der Zeichenfläche ausgewählt ist.
        /// Löst das Event OnSelectionChanged aus.
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }

            set
            {
                isSelected = value;

                OnSelectionChanged?.Invoke(this);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Enthält alle Verbindungen, die zu dieser Komponente gehen.
        /// </summary>
        public ObservableCollectionExtended<ConnectionComponent> Connections { get; private set; } = new ObservableCollectionExtended<ConnectionComponent>();
        #endregion

        #region Commands        
        /// <summary>
        /// Kommando um die Komponente einen Schritt in den Vordergrund zu schieben.
        /// </summary>
        public DelegateCommand IncrementZIndexCommand { get; private set; } = null;

        /// <summary>
        /// Kommando um die Komponente einen Schritt in den Hintergrund zu schieben.
        /// </summary>
        public DelegateCommand DecrementZIndexCommand { get; private set;} = null;
        #endregion

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public ComponentViewModel(Component component, MainPageViewModel parentViewModel)
        {
            Component = component;
            ParentViewModel = parentViewModel;

            PropertyDescriptions.Add(new SinglePropertyDescription("Name","Name"));
            PropertyDescriptions.Add(new SinglePropertyDescription("Width", "Breite"));
            PropertyDescriptions.Add(new SinglePropertyDescription("Height", "Höhe"));
            PropertyDescriptions.Add(new SinglePropertyDescription("Left", "Links"));
            PropertyDescriptions.Add(new SinglePropertyDescription("Top", "Oben"));
            PropertyDescriptions.Add(new SinglePropertyDescription("ZIndex", "Z-Index"));

            InitializeCommand();
        }

        /// <summary>
        /// Initialisiert die Kommandos. Wird im Konstruktor aufgerufen.
        /// </summary>
        private void InitializeCommand()
        {
            IncrementZIndexCommand = new DelegateCommand(e => true, e => { ZIndex++; });
            DecrementZIndexCommand = new DelegateCommand(e => true, e => ZIndex--);
        }
    }
}
