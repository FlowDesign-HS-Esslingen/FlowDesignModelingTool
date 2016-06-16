using System.Collections.Generic;
using FlowDesign.Model;
using FlowDesign.Model.Components;
using FlowDesign.Model.Components.SystemEnvironment;

namespace FlowDesign.Service.ComponentServices
{
    /// <summary>
    /// Komponenten Service für ein System-Umwelt Diagramm.
    /// </summary>
    /// <seealso cref="FlowDesign.Service.ComponentServices.IComponentService" />
    internal class SystemEnvCompService : IComponentService
    {
        // Keys für die Komponenten.
        private const string SYSTEM_COMPONENT_KEY = "System";
        private const string ACTOR_COMPONENT_KEY = "Actor";
        private const string ADAPTER_COMPONENT_KEY = "Adapter";
        private const string RESOURCE_COMPONENT_KEY = "Resource";

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SystemEnvCompService()
        {
        }

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

            if(type == SYSTEM_COMPONENT_KEY)
            {
                component = new SystemComponent();
                component.UIProperties.Width = 200;
                component.UIProperties.Height = 200;
            }

            if (type == RESOURCE_COMPONENT_KEY)
            {
                component = new ResourceComponent();
            }

            if (type == ACTOR_COMPONENT_KEY)
            {
                component = new ActorComponent();
            }

            if (type == ADAPTER_COMPONENT_KEY)
            {

                component = new AdapterComponent();
                component.UIProperties.Height = 50;
                component.UIProperties.Width = 50;
                component.UIProperties.ZIndex = 49;
            }

            if(component != null)
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
            List<string> components = new List<string>();

            components.Add(SYSTEM_COMPONENT_KEY);
            components.Add(RESOURCE_COMPONENT_KEY);
            components.Add(ADAPTER_COMPONENT_KEY);
            components.Add(ACTOR_COMPONENT_KEY);
            components.Add(CommonComponentKeys.TEXT_COMPONENT_KEY);
            components.Add(CommonComponentKeys.COMMENT_COMPONENT_KEY);

            return components;
        }
    }
}
