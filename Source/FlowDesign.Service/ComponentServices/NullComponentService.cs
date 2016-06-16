using System.Collections.Generic;
using FlowDesign.Model;
using FlowDesign.Model.Components;

namespace FlowDesign.Service.ComponentServices
{
    /// <summary>
    /// Ersatz für Null, falls ein ComponentService zurückgegeben werden muss, der nicht existiert.
    /// </summary>
    /// <seealso cref="FlowDesign.Service.ComponentServices.IComponentService" />
    public class NullComponentService : IComponentService
    {
        /// <summary>
        /// Fügt einem Diagramm eine Komponente hinzu.
        /// </summary>
        /// <param name="type">Der Typ der Komponente. (Entspricht dem Namen in der Komponentenliste der UI</param>
        /// <param name="diagram">Das Diagramm, dem die Komponente hinzugefügt werden soll.</param>
        /// <param name="positionInfo">Die Positionsinformation</param>
        /// <returns>
        /// Die hinzugefügte Komponente.
        /// </returns>
        public Component AddComponent(string type, Diagram diagram, PositionInfo positionInfo)
        {
            return null;
        }

        /// <summary>
        /// Gibt eine Liste zurück, die alle verfügbaren Komponenten beinhaltet.
        /// Diese Liste wird genutzt, um die Komponentenliste auf der UI zu füllen.
        /// </summary>
        /// <returns>
        /// Liste mit Namen von Komponenten.
        /// </returns>
        public List<string> GetAvailableComponents()
        {
            return new List<string>();
        }
    }
}
