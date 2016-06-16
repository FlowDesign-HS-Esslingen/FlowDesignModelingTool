namespace FlowDesign.Model.Flow
{
    /// <summary>
    /// FlowView Diagramm
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Flow.FlowDiagram" />
    public class FlowViewDiagram:FlowDiagram
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public FlowViewDiagram()
        {
            this.Type = DiagramType.FlowDiagram;
            this.FlowType = FlowDiagramType.FlowViewDiagram;
        }
    }
}
