using FlowDesign.Model.Components.SystemEnvironment;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für einen Actor des System-Umwelt-Diagramms.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class ActorComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Actor Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public ActorComponentViewModel(ActorComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
        }
    }
}
