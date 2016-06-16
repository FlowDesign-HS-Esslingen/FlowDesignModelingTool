using System.Xml.Serialization;

namespace FlowDesign.Model.Components.SystemEnvironment
{
    /// <summary>
    /// Alle möglichen Komponenten eines System-Umwelt Diagramms.
    /// </summary>
    public enum SystemEnvComponentType
    {
        Actors,
        Resources,
        Adapter,
        System,
    }

    /// <summary>
    /// Basisklasse für alle Komponenten, die in einem System-Umwelt Diagramm verwendet werden sollen.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Component" />
    [XmlInclude(typeof(ActorComponent))]
    [XmlInclude(typeof(ResourceComponent))]
    [XmlInclude(typeof(SystemComponent))]
    [XmlInclude(typeof(AdapterComponent))]
    public abstract class SystemEnvironmentComponent : Component
    {
        /// <summary>
        /// Typ der System-Umwelt Komponente.
        /// </summary>
        public SystemEnvComponentType SystemEnvType { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SystemEnvironmentComponent()
        {
            this.Type = ComponentType.SystemEnvironment;
        }
    }
}
