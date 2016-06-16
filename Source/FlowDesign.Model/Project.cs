using System;
using System.Collections.Generic;

namespace FlowDesign.Model
{
    /// <summary>
    /// Info für ein Projekt.
    /// </summary>
    [Serializable()]
    public class ProjectInfo
    {
        /// <summary>
        /// Der Name des Projekts.
        /// </summary>
        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; } = "Unnamed Project";

        /// <summary>
        /// Das Erstellungsdatum des Projekts.
        /// </summary>
        [System.Xml.Serialization.XmlElement("CreationDate")]
        public DateTime CreationDate { get; } = DateTime.Now;

        /// <summary>
        /// Das Datum, an dem das Projekt verändert wurde.
        /// </summary>
        [System.Xml.Serialization.XmlElement("ModifiedDate")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Der Pfad unter dem das Projekt gespeichert ist.
        /// </summary>
        [System.Xml.Serialization.XmlElement("Filepath")]
        public string Filepath { get; set; } = string.Empty;
    }

    /// <summary>
    /// Das Projekt.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Info des Projekts.
        /// </summary>
        public ProjectInfo Info { get; set; } = new ProjectInfo();

        /// <summary>
        /// Alle Diagramme des Projekts.
        /// </summary>
        public List<Diagram> Diagrams { get; set; } = new List<Diagram>();
    }
}
