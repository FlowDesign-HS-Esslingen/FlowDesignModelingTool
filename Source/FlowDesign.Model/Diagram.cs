using FlowDesign.Model.Components;
using FlowDesign.Model.Flow;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlowDesign.Model
{
    /// <summary>
    /// Alle möglichen Diagrammarten.
    /// </summary>
    public enum DiagramType
    {
        FlowDiagram
    }

    /// <summary>
    /// Basisklasse für alle Diagramme.
    /// </summary>
    [XmlInclude(typeof(FlowDiagram))]
    public abstract class Diagram
    {
        /// <summary>
        /// Einzigartige ID des Diagramms.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name des Diagramms.
        /// </summary>
        [System.Xml.Serialization.XmlElement("Name")]
        public String Name { get; set; } = "Unnamed Diagram";

        /// <summary>
        /// Typ des Diagramms.
        /// </summary>
        [System.Xml.Serialization.XmlElement("Type")]
        public DiagramType Type{ get; set; }

        /// <summary>
        /// Erstellungsdatum des Diagramms.
        /// </summary>
        [System.Xml.Serialization.XmlElement("CreationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Datum an dem das Diagramm geändert wurde.
        /// </summary>
        [System.Xml.Serialization.XmlElement("ModifiedDate")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Alle Komponenten des Diagramms.
        /// </summary>
        [System.Xml.Serialization.XmlElement("DiagramComponents")]
        public List<Component> DiagramComponents { get; set; } = new List<Component>();

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public Diagram()
        {
            ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            return ("Diagrammtyp: " + this.Type);
        }
    }
}
