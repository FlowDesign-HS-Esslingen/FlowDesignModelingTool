using System.Collections.Generic;
using FlowDesign.Model;
using FlowDesign.Model.Components;
using FlowDesign.Model.Components.Common;

namespace FlowDesign.Service.ComponentServices
{
    /// <summary>
    /// Komponenten Service, für alle allgemein gültigen Komponenten.
    /// </summary>
    /// <seealso cref="FlowDesign.Service.ComponentServices.IComponentService" />
    internal class CommonComponentService : IComponentService
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
            Component component = null;

            if (type == CommonComponentKeys.TEXT_COMPONENT_KEY)
            {
                component = new TextComponent();
            }

            if (type == CommonComponentKeys.COMMENT_COMPONENT_KEY)
            {
                component = new CommentComponent {Text = "Kommentar" };
            }

            if (type == CommonComponentKeys.LINE_COMPONENT_KEY)
            {
                LinePartComponent lineStart = new LinePartComponent();
                CalcPosition(lineStart.UIProperties, positionInfo.LeftPosition, positionInfo.TopPosition);
                lineStart.ParentDiagramID = diagram.ID;

                LinePartComponent lineEnd = new LinePartComponent();
                CalcPosition(lineEnd.UIProperties, positionInfo.LeftPosition + 50, positionInfo.TopPosition);
                lineEnd.ParentDiagramID = diagram.ID;

                LineComponent line = new LineComponent(lineStart.ID, lineEnd.ID);
                line.ParentDiagramID = diagram.ID;

                diagram.DiagramComponents.Add(lineStart);
                diagram.DiagramComponents.Add(lineEnd);
                diagram.DiagramComponents.Add(line);

                // In diesem Fall muss sofort ein return ausgeführt werden, da es drei Komponenten sind die hinzugefügt werden müssen 
                // und sonst unten wieder eine Komponent hinzugefügt wird.
                return line;
            }

            if (component != null)
            {
                component.ParentDiagramID = diagram.ID;
                component.UIProperties.Left = positionInfo.LeftPosition - component.UIProperties.Width * 0.5;
                component.UIProperties.Top = positionInfo.TopPosition - component.UIProperties.Height * 0.5;

                diagram.DiagramComponents.Add(component);
            }
            
            return component;
        }

        /// <summary>
        /// Berechnet die richtige Position einer Komponente.
        /// </summary>
        /// <param name="uiProperty">Die UI property.</param>
        /// <param name="left">Position Links.</param>
        /// <param name="top">Position Oben.</param>
        private void CalcPosition(ComponentUIProperties uiProperty, double left, double top)
        {
            uiProperty.Left = left - uiProperty.Width * 0.5;
            uiProperty.Top = top - uiProperty.Height * 0.5;
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
            List<string> result = new List<string>();
            result.Add(CommonComponentKeys.COMMENT_COMPONENT_KEY);
            result.Add(CommonComponentKeys.TEXT_COMPONENT_KEY);

            return result;
        }
    }
}
