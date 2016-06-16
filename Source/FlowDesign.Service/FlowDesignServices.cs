using FlowDesign.Model.Flow;
using FlowDesign.Service.ComponentServices;
using FlowDesign.Service.Diagrams.Flow;

namespace FlowDesign.Service
{
    /// <summary>
    /// Verwaltet die Implementierungen der Service Klassen.
    /// </summary>
    public static class FlowDesignServices
    {
        /// <summary>
        /// Gibt für einen Diagrammtyp den passenden Component Service zurück.
        /// </summary>
        /// <typeparam name="DiagramType">Der Typ des Diagramms.</typeparam>
        /// <returns>Der Component Service.</returns>
        public static IComponentService ComponentService<DiagramType>()
        {
            if(typeof(DiagramType) == typeof(SystemEnvDiagram))
            {
                return new SystemEnvCompService();
            }

            if (typeof(DiagramType) == typeof(PrototypeDiagram))
            {
                return new PrototypeCompService();
            }

            if (typeof(DiagramType) == typeof(FlowViewDiagram))
            {
                return new FlowViewComponentService();
            }

            return new NullComponentService();
        }

        /// <summary>
        /// Gibt für einen Komponent Type den passenden Component Service zurück.
        /// </summary>
        /// <param name="type">Der Typ der Komponente.(Entspricht dem Namen, der auf der UI in der Komponentenliste angezeigt wird.)</param>
        /// <returns>Der Component Service.</returns>
        public static IComponentService ComponentServiceFromType(string type)
        {
            IComponentService commonService = new CommonComponentService();
            IComponentService systemEnvService = new SystemEnvCompService();
            IComponentService prototypeService = new PrototypeCompService();
            IComponentService flowViewService = new FlowViewComponentService();

            if(commonService.GetAvailableComponents().Contains(type))
            {
                return commonService;
            }

            if (systemEnvService.GetAvailableComponents().Contains(type))
            {
                return systemEnvService;
            }

            if (prototypeService.GetAvailableComponents().Contains(type))
            {
                return prototypeService;
            }

            if (flowViewService.GetAvailableComponents().Contains(type))
            {
                return flowViewService;
            }

            return new NullComponentService();
        }

        /// <summary>
        /// Gibt eine DiagramFactory zurück.
        /// </summary>
        /// <returns>Die DiagramFactory.</returns>
        public static DiagramFactory DiagramFactory()
        {
            DiagramFactory factory = new Service.DiagramFactory();

            factory.Register(typeof(SystemEnvDiagram), new SystemEnvDiagramFactory());
            factory.Register(typeof(PrototypeDiagram), new PrototypeDiagramFactory());
            factory.Register(typeof(FlowViewDiagram), new FlowViewDiagramFactory());

            return factory;
        }

    }
}
