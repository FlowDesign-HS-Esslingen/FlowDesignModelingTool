using System;
using System.Collections.Generic;
using System.Linq;
using FlowDesign.Model.Flow;
using FlowDesign.Model.Components.Prototype;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für eine Selbstdelegation eines Maskenprototyps.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class SelfDelegationComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Die ID des FlowViews auf die die Delegation zeigt.
        /// </summary>
        public Guid FlowViewID
        {
            get
            {
                return ((SelfDelegationComponent)Component).FlowViewID;
            }

            set
            {
                ((SelfDelegationComponent)Component).FlowViewID = value;
            }
        }

        /// <summary>
        /// Name des FlowViewDiagramms. Wird für die DropDown Liste im Eigenschaften Panel benötigt.
        /// </summary>
        private string flowViewName = string.Empty;

        /// <summary>
        /// Name des FlowViewDiagramms. Wird für die DropDown Liste im Eigenschaften Panel benötigt.
        /// </summary>
        public string FlowViewName
        {
            get
            {
                if (FlowViewID == Guid.Empty || ParentViewModel.FlowViewDiagrams.Count == 0)
                {
                    return flowViewName;
                }

                // Sucht das Diagramm zu dem die FlowViewID passt.
                FlowViewDiagram diagram = (FlowViewDiagram)ParentViewModel.FlowViewDiagrams.Where(e =>
                {
                    if (e.ID == FlowViewID)
                    {
                        return true;
                    }

                    return false;

                }).FirstOrDefault();

                if (diagram != null)
                {
                    flowViewName = diagram.Name;
                }

                return flowViewName;
            }

            set
            {
                flowViewName = value;
                RaisePropertyChanged();

                // Sucht das FlowViewDiagramm zu dem der Name passt, der in Value steht und gesetzt werden soll.
                FlowViewDiagram flowViewDiagram = (FlowViewDiagram)ParentViewModel.FlowViewDiagrams.Where(e => e.Name == value).FirstOrDefault();
                if (flowViewDiagram != null)
                {
                    FlowViewID = flowViewDiagram.ID;
                }
                else
                {
                    FlowViewID = Guid.Empty;
                }
            }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die SelfDelegation Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public SelfDelegationComponentViewModel(SelfDelegationComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            parentViewModel.FlowViewDiagrams.OnItemAdded += FlowViewDiagrams_OnItemAdded;
            parentViewModel.FlowViewDiagrams.OnItemRemoved += FlowViewDiagrams_OnItemRemoved;

            List<object> availableFlowViews = ParentViewModel.FlowViewDiagrams.Where(e => e is FlowViewDiagram).Select(e => e.Name).ToList<object>();
            PropertyDescriptions.Add(new EnumerationPropertyDescription("FlowViewName", "FlowView", availableFlowViews));
        }

        /// <summary>
        /// Wird aufgerufen wenn im MainPageViewModel ein FlowViewDiagram entfernt wird.
        /// </summary>
        private void FlowViewDiagrams_OnItemRemoved(Model.Diagram item)
        {
            if (item.ID == FlowViewID)
            {
                FlowViewName = string.Empty;
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn im MainPageViewModel ein FlowViewDiagram hinzugefügt wird.
        /// </summary>
        private void FlowViewDiagrams_OnItemAdded(Model.Diagram item)
        {
            List<object> availableFlowViews = ParentViewModel.FlowViewDiagrams.Where(e => e is FlowViewDiagram).Select(e => e.Name).ToList<object>();

            EnumerationPropertyDescription prop = (EnumerationPropertyDescription)PropertyDescriptions.Where(e => e.PropertyName == "FlowViewName").FirstOrDefault();

            if (prop != null)
            {
                // Erst die Property aus der list löschen und dann wieder hinzufügen, so Updated sich die UI sicher.
                PropertyDescriptions.Remove(prop);
                prop = new EnumerationPropertyDescription("FlowViewName", "FlowView", availableFlowViews);
                PropertyDescriptions.Add(prop);
            }
        }
    }
}
