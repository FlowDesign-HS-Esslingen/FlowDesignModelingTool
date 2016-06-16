using FlowDesign.Model;
using FlowDesign.Model.Components;
using FlowDesign.UI.ViewModels;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using System.Collections.Generic;

namespace FlowDesign.UI
{
    /// <summary>
    /// Interface für eine ViewModelFactory.
    /// </summary>
    public interface IViewModelFactory
    {
        /// <summary>
        /// Erstellt ein ViewModel, das zu einer Komponente passt.
        /// </summary>
        /// <param name="component">Die Komponente, für die das ViewModel erstellt werden soll.</param>
        /// <param name="parentDiagram">Das Diagramm, zudem die Komponente gehört.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite.</param>
        /// <returns>Eine Liste von ViewModels. Für eine Komponenten können mehere ViewModels erstellen z.B. Line und LinePart</returns>
        List<ComponentViewModel> CreateViewModelsFromComponent(Component component, Diagram parentDiagram, MainPageViewModel parentViewModel);
    }
}
