using FlowDesign.Model.Components.SystemEnvironment;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für eine Resource des System-Umwelt-Diagramms.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class ResourceComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Resource Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public ResourceComponentViewModel(ResourceComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
        }
    }
}
