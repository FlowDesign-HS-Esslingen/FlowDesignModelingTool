using System.Xml.Serialization;

namespace FlowDesign.Model.Components.Prototype
{
    /// <summary>
    /// Alle möglichen Komponenten eines Maskenprototyps.
    /// </summary>
    public enum PrototypeComponentTypes
    {
        Mockup,
        Delegation,
        SelfDelegation
    }

    /// <summary>
    /// Basisklasse für alle Komponenten, die in einem Maskenprototpy verwendet werden sollen.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Component" />
    [XmlInclude(typeof(MockupComponent))]
    [XmlInclude(typeof(SelfDelegationComponent))]
    [XmlInclude(typeof(DelegationComponent))]
    public abstract class PrototypeComponent : Component
    {
        /// <summary>
        /// Typ der Maskenprototyp Komponente.
        /// </summary>
        public PrototypeComponentTypes PrototypeComponentType { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public PrototypeComponent()
        {
            this.Type = ComponentType.Prototype;
        }
    }
}
