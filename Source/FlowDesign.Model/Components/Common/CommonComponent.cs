using System.Xml.Serialization;

namespace FlowDesign.Model.Components.Common
{
    /// <summary>
    /// Alle möglichen Komponenten für den Allgemein gebrauch.
    /// </summary>
    public enum CommonComponentTypes
    {
        Undefined,
        Text,
        Comment,
        Connection,
        Line,
        LinePart,
    }

    /// <summary>
    /// Basisklasse für alle allgemeingültigen Komponenten.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Component" />
    [XmlInclude(typeof(CommentComponent))]
    [XmlInclude(typeof(TextComponent))]
    [XmlInclude(typeof(LineComponent))]
    [XmlInclude(typeof(LinePartComponent))]
    public class CommonComponent : Component
    {
        /// <summary>
        /// Typ der allgemeinen Komponente.
        /// </summary>
        public CommonComponentTypes CommonComponentType { get; set; } = CommonComponentTypes.Undefined;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public CommonComponent()
        {
            Type = ComponentType.Common;
        }

    }
}
