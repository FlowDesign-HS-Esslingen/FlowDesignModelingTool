using System.Collections.Generic;
using FlowDesign.Model.Components;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using FlowDesign.Model.Components.SystemEnvironment;
using FlowDesign.Model;
using FlowDesign.UI.ViewModels;

namespace FlowDesign.UI
{
    /// <summary>
    /// Erstellt ViewModels für ein System-Umwelt Diagramm.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.IViewModelFactory" />
    public class SystemEnvViewModelFactory : IViewModelFactory
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
            SystemEnvironmentComponent systemEnvComponent = (SystemEnvironmentComponent)component;

            if(systemEnvComponent.SystemEnvType == SystemEnvComponentType.System)
            {
                return new List<ComponentViewModel> { new SystemComponentViewModel((SystemComponent)component, parentViewModel) };
            }

            if(systemEnvComponent.SystemEnvType == SystemEnvComponentType.Resources)
            {
                return new List<ComponentViewModel> { new ResourceComponentViewModel((ResourceComponent)component, parentViewModel) };
            }

            if(systemEnvComponent.SystemEnvType == SystemEnvComponentType.Adapter)
            {
                return new List<ComponentViewModel> { new AdapterComponentViewModel((AdapterComponent)component, parentViewModel) };
            }

            if(systemEnvComponent.SystemEnvType == SystemEnvComponentType.Actors)
            {
                return new List<ComponentViewModel> { new ActorComponentViewModel((ActorComponent)component, parentViewModel) };
            }

            return null;
        }
    }
}
