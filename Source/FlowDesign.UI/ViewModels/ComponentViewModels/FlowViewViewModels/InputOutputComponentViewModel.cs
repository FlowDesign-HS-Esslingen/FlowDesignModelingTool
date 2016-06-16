using FlowDesign.Model.Components.FlowView;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für ein Input/Output eines FlowViewDiagramms.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class InputOutputComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Input/Output Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public InputOutputComponentViewModel(InputOutputComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
        }
    }
}
