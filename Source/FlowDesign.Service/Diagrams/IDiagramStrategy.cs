using FlowDesign.Model;

namespace FlowDesign.Service.Diagrams
{
    /// <summary>
    /// Interface für eine Strategy, die ein Diagramm erstellt.
    /// </summary>
    public interface IDiagramStrategy
    {
        /// <summary>
        /// Erstellt ein leeres Diagramm.
        /// </summary>
        /// <param name="name">Der Name des Diagramms.</param>
        /// <returns>Das erstellte Diagramm.</returns>
        Diagram CreateEmptyDiagram(string name);
        
    }
}
