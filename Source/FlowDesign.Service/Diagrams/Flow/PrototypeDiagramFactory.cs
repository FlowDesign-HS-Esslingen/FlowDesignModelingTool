using FlowDesign.Model;

namespace FlowDesign.Service.Diagrams.Flow
{
    /// <summary>
    /// Strategy, die einen Maskenprototyp erstellt.
    /// </summary>
    /// <seealso cref="FlowDesign.Service.Diagrams.IDiagramStrategy" />
    public class PrototypeDiagramFactory : IDiagramStrategy
    {
        /// <summary>
        /// Erstellt ein leeres Diagramm.
        /// </summary>
        /// <param name="name">Der Name des Diagramms.</param>
        /// <returns>
        /// Das erstellte Diagramm.
        /// </returns>
        public Diagram CreateEmptyDiagram(string name)
        {
            return new Model.Flow.PrototypeDiagram { Name = name };
        }
    }
}
