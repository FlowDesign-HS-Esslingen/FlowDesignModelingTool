using FlowDesign.Model;
using FlowDesign.Model.Components;
using System.Collections.Generic;

namespace FlowDesign.Service.ComponentServices
{
    /// <summary>
    /// Enthält Positions Informationen für die erstellung einer Komponente.
    /// </summary>
    public class PositionInfo
    {
        /// <summary>
        /// Die Position des Linken Rands der Komponente.
        /// </summary>
        public double LeftPosition { get; set; }

        /// <summary>
        /// Die Position des Oberen Rands der Komponente.
        /// </summary>
        public double TopPosition { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="leftPosition">Die Position des Linken Rands der Komponente.</param>
        /// <param name="topPosition">Die Position des Oberen Rands der Komponente.</param>
        public PositionInfo(double leftPosition, double topPosition)
        {
            LeftPosition = leftPosition;
            TopPosition = topPosition;
        }
    }

    /// <summary>
    /// Interface für einen Komponenten Service.
    /// </summary>
    public interface IComponentService
    {
        /// <summary>
        /// Fügt einem Diagramm eine Komponente hinzu.
        /// </summary>
        /// <param name="type">Der Typ der Komponente. (Entspricht dem Namen in der Komponentenliste der UI</param>
        /// <param name="diagram">Das Diagramm, dem die Komponente hinzugefügt werden soll.</param>
        /// <param name="positionInfo">Die Positionsinformation</param>
        /// <returns>Die hinzugefügte Komponente.</returns>
        Component AddComponent(string type, Diagram diagram, PositionInfo positionInfo);

        /// <summary>
        /// Gibt eine Liste zurück, die alle verfügbaren Komponenten beinhaltet.
        /// Diese Liste wird genutzt, um die Komponentenliste auf der UI zu füllen.
        /// </summary>
        /// <returns>Liste mit Namen von Komponenten.</returns>
        List<string> GetAvailableComponents();
    }
}
