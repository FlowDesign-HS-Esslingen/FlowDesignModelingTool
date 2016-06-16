namespace FlowDesign.Model.Flow
{
    /// <summary>
    /// System-Umwelt Diagramm.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Flow.FlowDiagram" />
    public class SystemEnvDiagram : FlowDiagram
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SystemEnvDiagram()
        {
            this.Type = DiagramType.FlowDiagram;
            this.FlowType = FlowDiagramType.SystemEnvDiagram;
        }
    }
}
