using System.Collections.Generic;
using FlowDesign.Model;
using FlowDesign.Model.Components;
using FlowDesign.Model.Components.Prototype;
using FlowDesign.Model.Components.Common;

namespace FlowDesign.Service.ComponentServices
{
    /// <summary>
    /// Komponenten Service für einen Maskenprototyp.
    /// </summary>
    /// <seealso cref="FlowDesign.Service.ComponentServices.IComponentService" />
    internal class PrototypeCompService : IComponentService
    {
        // Keys für die Komponenten.
        private const string MOCK_COMPONENT_KEY = "Mockup";
        private const string DELEGATION_COMPONENT_KEY = "Delegation";
        private const string SELF_DELEGATION_COMPONENT_KEY = "Selbst Delegation";

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

            if (type == MOCK_COMPONENT_KEY)
            {
                component = new MockupComponent();
            }

            if (type == SELF_DELEGATION_COMPONENT_KEY)
            {
                component = new SelfDelegationComponent();
            }

            if(type == DELEGATION_COMPONENT_KEY)
            {
                LinePartComponent lineStart = new LinePartComponent();
                CalcPosition(lineStart.UIProperties, positionInfo.LeftPosition, positionInfo.TopPosition);
                lineStart.ParentDiagramID = diagram.ID;

                LinePartComponent lineEnd = new LinePartComponent();
                CalcPosition(lineEnd.UIProperties, positionInfo.LeftPosition + 50, positionInfo.TopPosition);
                lineEnd.ParentDiagramID = diagram.ID;

                LineComponent line = new LineComponent(lineStart.ID, lineEnd.ID);
                line.ParentDiagramID = diagram.ID;

                DelegationComponent delegationComponent = new DelegationComponent();
                delegationComponent.Line = line;

                // Die line ansich darf nicht hinzugefügt werden, da sonst beim laden zwei LineViewModels erstellt werden.
                // Ein ViewModel für Line und eines für Delegation.
                diagram.DiagramComponents.Add(delegationComponent);
                diagram.DiagramComponents.Add(lineStart);
                diagram.DiagramComponents.Add(lineEnd);

                // In diesem Fall muss sofort ein return ausgeführt werden, da es drei Komponenten sind die hinzugefügt werden müssen 
                // und sonst unten wieder eine Komponent hinzugefügt wird.
                return delegationComponent;
            }

            if (component != null)
            {
                component.ParentDiagramID = diagram.ID;
                CalcPosition(component.UIProperties, positionInfo.LeftPosition, positionInfo.TopPosition);

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

            result.Add(MOCK_COMPONENT_KEY);
            result.Add(DELEGATION_COMPONENT_KEY);
            result.Add(SELF_DELEGATION_COMPONENT_KEY);
            result.Add(CommonComponentKeys.TEXT_COMPONENT_KEY);
            result.Add(CommonComponentKeys.COMMENT_COMPONENT_KEY);

            return result;
        }
    }
}
