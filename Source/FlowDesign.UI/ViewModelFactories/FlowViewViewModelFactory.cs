using System.Collections.Generic;
using FlowDesign.Model;
using FlowDesign.Model.Components;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using FlowDesign.Model.Components.FlowView;
using FlowDesign.UI.ViewModels;

namespace FlowDesign.UI
{
    /// <summary>
    /// Erstellt ViewModels für eine FlowView Diagramm.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.IViewModelFactory" />
    public class FlowViewViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Erstellt ein ViewModel, das zu einer Komponente passt.
        /// </summary>
        /// <param name="component">Die Komponente, für die das ViewModel erstellt werden soll.</param>
        /// <param name="parentDiagram">Das Diagramm, zudem die Komponente gehört.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite.</param>
        /// <returns>
        /// Eine Liste von ViewModels. Für eine Komponenten können mehere ViewModels erstellen z.B. Line und LinePart
        /// </returns>
        public List<ComponentViewModel> CreateViewModelsFromComponent(Component component, Diagram parentDiagram, MainPageViewModel parentViewModel)
        {
            FlowViewComponent flowViewComponent = (FlowViewComponent)component;

            if(flowViewComponent.FlowViewType == FlowViewTypes.Modul)
            {
                return new List<ComponentViewModel> { new ModulComponentViewModel((ModulComponent)component, parentViewModel) };
            }

            if(flowViewComponent.FlowViewType == FlowViewTypes.InputOutput)
            {
                return new List<ComponentViewModel> { new InputOutputComponentViewModel((InputOutputComponent)component, parentViewModel) };
            }

            return new List<ComponentViewModel>();
        }
    }
}
