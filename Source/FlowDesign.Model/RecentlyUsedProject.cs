using System;

namespace FlowDesign.Model
{
    /// <summary>
    /// Enthält Informationen für ein kürzlich verwendets Projekt.
    /// </summary>
    [Serializable]
    public class RecentlyUsedProject
    {
        /// <summary>
        /// Name des kürzlich verwendeten Projekts.
        /// </summary>
        /// <value>
        public string Name { get; set; }

        /// <summary>
        /// Pfad des kürzlich verwendeten Projekts.
        /// </summary>
        public string Filepath { get; set; }

        public override bool Equals(object obj)
        {
            RecentlyUsedProject project = (RecentlyUsedProject)obj;

            return (project.Name == this.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
