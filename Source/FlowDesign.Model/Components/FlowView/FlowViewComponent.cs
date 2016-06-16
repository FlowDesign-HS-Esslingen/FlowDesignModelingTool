using System.Xml.Serialization;

namespace FlowDesign.Model.Components.FlowView
{
    /// <summary>
    /// Alle möglichen Komponenten für ein FlowView Diagramm.
    /// </summary>
    public enum FlowViewTypes
    {
        Undefined,
        Modul,
        InputOutput,
    }

    /// <summary>
    /// Basisklasse für eine Komponente, die in einem FlowView Diagramm verwendet werden soll.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Component" />
    [XmlInclude(typeof(ModulComponent))]
    [XmlInclude(typeof(InputOutputComponent))]
    public class FlowViewComponent : Component
    {
        /// <summary>
        /// Typ der FlowView Komponente.
        /// </summary>
        public FlowViewTypes FlowViewType { get; set; } = FlowViewTypes.Undefined;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public FlowViewComponent()
        {
            Type = ComponentType.FlowView;
        }
    }
}
