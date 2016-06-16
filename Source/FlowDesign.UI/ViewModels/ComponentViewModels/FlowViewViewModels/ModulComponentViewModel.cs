using System;
using System.Collections.Generic;
using System.Linq;
using FlowDesign.Model.Components;
using FlowDesign.Model.Components.FlowView;
using FlowDesign.Model.Flow;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für eine Modul eines FlowView Diagramms.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class ModulComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// ID des Parent FlowView Diagramms. 
        /// Wird benötigt um in der FlowViewHistory zu einem anderen FlowView Diagramm zu springen.
        /// </summary>
        public Guid ParentID
        {
            get
            {
                return ((ModulComponent)Component).ParentID;
            }

            set
            {
                ((ModulComponent)Component).ParentID = value;
            }
        }

        /// <summary>
        /// ID des Child FlowView Diagramms. 
        /// Wird benötigt um in der FlowViewHistory zu einem anderen FlowView Diagramm zu springen.
        /// </summary>
        public Guid ChildID
        {
            get
            {
                return ((ModulComponent)Component).ChildID;
            }

            set
            {
                ((ModulComponent)Component).ChildID = value;
            }
        }

        /// <summary>
        /// Name des Child FlowView Diagramms. 
        /// Wird für als Binding Ziel im Eigenschaften panel benötigt.
        /// </summary>
        private string childName = string.Empty;

        /// <summary>
        /// Name des Child FlowView Diagramms. 
        /// Wird für als Binding Ziel im Eigenschaften panel benötigt.
        /// </summary>
        public string ChildName
        {
            get
            {
                if(ChildID == Guid.Empty)
                {
                    return childName;
                }

                FlowViewDiagram flowViewDiagram = (FlowViewDiagram)ParentViewModel.FlowViewDiagrams.Where(e => 
                {
                    if(e.ID == ChildID)
                    {
                        return true;
                    }

                    return false;

                 }).FirstOrDefault();

                if(flowViewDiagram != null)
                {
                    childName = flowViewDiagram.Name;
                }

                return childName;
            }

            set
            {
                childName = value;
                RaisePropertyChanged();

                FlowViewDiagram flowViewDiagram = (FlowViewDiagram)ParentViewModel.FlowViewDiagrams.Where(e => e.Name == value).FirstOrDefault();

                if(flowViewDiagram != null)
                {
                    ChildID = flowViewDiagram.ID;
                    ParentID = Component.ParentDiagramID;
                }
                else
                {
                    ChildID = Guid.Empty;
                    ParentID = Guid.Empty;
                }
                
            }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Modul Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public ModulComponentViewModel(ModulComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            parentViewModel.FlowViewDiagrams.OnItemAdded += FlowViewDiagrams_OnItemAdded;
            parentViewModel.FlowViewDiagrams.OnItemRemoved += FlowViewDiagrams_OnItemRemoved;

            List<object> availableSubModuls = parentViewModel.FlowViewDiagrams.Where(e => e.ID != component.ParentDiagramID).Select(e => e.Name).ToList<object>();
            PropertyDescriptions.Add(new EnumerationPropertyDescription("ChildName", "Sub Modul", availableSubModuls));
        }

        /// <summary>
        /// Wird aufgerufen wenn im MainPageViewModel ein FlowViewDiagram entfernt wird.
        /// </summary>
        private void FlowViewDiagrams_OnItemRemoved(Model.Diagram item)
        {
            if (item.ID == ChildID)
            {
                ChildName = string.Empty;
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn im MainPageViewModel ein FlowViewDiagram hinzugefügt wird.
        /// </summary>
        private void FlowViewDiagrams_OnItemAdded(Model.Diagram item)
        {
            List<object> availableSubModuls = ParentViewModel.FlowViewDiagrams.Where(e => e.ID != Component.ParentDiagramID).Select(e => e.Name).ToList<object>();

            EnumerationPropertyDescription prop = (EnumerationPropertyDescription)PropertyDescriptions.Where(e => e.PropertyName == "ChildName").FirstOrDefault();

            if (prop != null)
            {
                // Erst die Property aus der list löschen und dann wieder hinzufügen, so Updated sich die UI sicher.
                PropertyDescriptions.Remove(prop);
                prop = new EnumerationPropertyDescription("ChildName", "Sub Modul", availableSubModuls);
                PropertyDescriptions.Add(prop);
            }
        }
    }
}
