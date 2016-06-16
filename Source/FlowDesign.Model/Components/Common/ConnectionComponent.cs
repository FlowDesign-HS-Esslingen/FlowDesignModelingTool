using System;

namespace FlowDesign.Model.Components.Common
{
    /// <summary>
    /// Richtungen, an denen ein Connector sein kann.
    /// </summary>
    public enum ConnectionDirection
    {
        Undefined,
        Left,
        Right,
        Top,
        Bottom
    }

    /// <summary>
    /// Enthält die Information für eine Verbindung zwischen zwei Komponenten.
    /// </summary>
    public class ConnectionComponent : CommonComponent
    {
        /// <summary>
        /// Die ID der Komponente die als Quelle der Verbindung dient.
        /// </summary>
        public Guid SourceComponentID { get; set; }

        /// <summary>
        /// Die ID der Komponente die als Ziel der Verbindung dient.
        /// </summary>
        public Guid TargetComponentID { get; set; }

        /// <summary>
        /// Richtung des Verbinders bei der Quell Komponente.
        /// </summary>
        public ConnectionDirection SourceDirection { get; set; } = ConnectionDirection.Undefined;

        /// <summary>
        /// Richtung des Verbinders bei der Ziel Komponente.
        /// </summary>
        public ConnectionDirection TargetDirection { get; set; } = ConnectionDirection.Undefined;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ConnectionComponent()
        {
            CommonComponentType = CommonComponentTypes.Connection;
        }
    }
}
