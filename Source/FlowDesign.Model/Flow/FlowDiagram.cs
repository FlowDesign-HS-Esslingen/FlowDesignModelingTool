using System.Xml.Serialization;

namespace FlowDesign.Model.Flow
{
    /// <summary>
    /// Alle möglichen Diagramm bei FlowDesign.
    /// </summary>
    public enum FlowDiagramType
    {
        SystemEnvDiagram,
        PrototypeDiagram,
        FlowViewDiagram
    }

    /// <summary>
    /// Basisklasse für alle Diagramme im FlowDesign Entwurfsmuster.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Diagram" />
    [XmlInclude(typeof(FlowViewDiagram))]
    [XmlInclude(typeof(PrototypeDiagram))]
    [XmlInclude(typeof(SystemEnvDiagram))]
    public abstract class FlowDiagram : Diagram
    {
        /// <summary>
        /// Der Typ des FlowDesign Diagramms.
        /// </summary>
        [System.Xml.Serialization.XmlElement("FlowType")]
        public FlowDiagramType FlowType { get; set; }

        public override string ToString()
        {
            return (base.ToString() + "\n FlowDiagrammTyp: " + this.FlowType);
        }
    }
}
