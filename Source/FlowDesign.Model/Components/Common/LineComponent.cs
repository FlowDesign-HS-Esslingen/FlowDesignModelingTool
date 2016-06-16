using System;

namespace FlowDesign.Model.Components.Common
{
    /// <summary>
    /// Komponente für eine Linie.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Common.CommonComponent" />
    public class LineComponent : CommonComponent
    {
        /// <summary>
        /// ID für die Start Komponente der Linie.
        /// </summary>
        public Guid LinePartStartId { get; set; }

        /// <summary>
        /// ID für die Ende Komponentne der Linie.
        /// </summary>
        public Guid LinePartEndId { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public LineComponent()
        {

        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="linePartStartId">ID für die Start Komponente der Linie.</param>
        /// <param name="linePartEndId">ID für die Ende Komponentne der Linie.</param>
        public LineComponent(Guid linePartStartId, Guid linePartEndId)
        {
            CommonComponentType = CommonComponentTypes.Line;

            LinePartStartId = linePartStartId;
            LinePartEndId = linePartEndId;
        }
    }
}
