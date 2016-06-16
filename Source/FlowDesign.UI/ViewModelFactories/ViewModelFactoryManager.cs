using FlowDesign.Model.Components;

namespace FlowDesign.UI
{
    /// <summary>
    /// Managt die ViewModel Factories.
    /// </summary>
    public static class ViewModelFactoryManager
    {
        /// <summary>
        /// Gibt eine ViewModelFactory anhand des Typs einer Komponente zurück.
        /// </summary>
        /// <param name="component">Die Komponenten, für die eine ViewModel factory erstellt werden soll.</param>
        /// <returns>Die ViewModel Factory.</returns>
        public static IViewModelFactory GetViewModelFactory(Component component)
        {
            if(component.Type == ComponentType.Common)
            {
                return new CommonComponentViewModelFactory();
            }

            if(component.Type == ComponentType.SystemEnvironment)
            {
                return new SystemEnvViewModelFactory();
            }

            if(component.Type == ComponentType.Prototype)
            {
                return new PrototypeViewModelFactory();
            }

            if (component.Type == ComponentType.FlowView)
            {
                return new FlowViewViewModelFactory();
            }

            return null;
        }
    }
}
