using FlowDesign.Model.Components.SystemEnvironment;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für ein System des System-Umwelt-Diagramms.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class SystemComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die System Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public SystemComponentViewModel(SystemComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {

        }
    }
}
