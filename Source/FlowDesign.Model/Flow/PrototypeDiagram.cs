namespace FlowDesign.Model.Flow
{
    /// <summary>
    /// Maskenprototyp.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Flow.FlowDiagram" />
    public class PrototypeDiagram : FlowDiagram
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public PrototypeDiagram()
        {
            this.Type = DiagramType.FlowDiagram;
            this.FlowType = FlowDiagramType.PrototypeDiagram;
        }
    }
}
