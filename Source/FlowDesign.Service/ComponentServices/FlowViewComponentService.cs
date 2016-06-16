using System.Collections.Generic;
using FlowDesign.Model;
using FlowDesign.Model.Components;
using FlowDesign.Model.Components.FlowView;

namespace FlowDesign.Service.ComponentServices
{
    /// <summary>
    /// Komponenten Service für ein FlowView Diagramm.
    /// </summary>
    /// <seealso cref="FlowDesign.Service.ComponentServices.IComponentService" />
    internal class FlowViewComponentService : IComponentService
    {
        // Keys für die Komponenten. 
        private const string MODUL_COMPONENT_KEY = "Modul";
        private const string INPUT_OUTPUT_COMPONENT_KEY = "Input/Output";

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

            if (type == MODUL_COMPONENT_KEY)
            {
                component = new ModulComponent {Name = "Modul" };
                component.UIProperties.Width = 200;
            }

            if(type == INPUT_OUTPUT_COMPONENT_KEY)
            {
                component = new InputOutputComponent { Name = "Input/Output" };
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
        /// Gibt eine Liste zurück, die alle verfügbaren Komponenten beinhaltet.
        /// Diese Liste wird genutzt, um die Komponentenliste auf der UI zu füllen.
        /// </summary>
        /// <returns>
        /// Liste mit Namen von Komponenten.
        /// </returns>
        public List<string> GetAvailableComponents()
        {
            List<string> result = new List<string>();

            result.Add(MODUL_COMPONENT_KEY);
            result.Add(INPUT_OUTPUT_COMPONENT_KEY);
            result.Add(CommonComponentKeys.TEXT_COMPONENT_KEY);
            result.Add(CommonComponentKeys.COMMENT_COMPONENT_KEY);

            return result;
        }
    }
}
