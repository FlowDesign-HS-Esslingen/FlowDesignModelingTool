namespace FlowDesign.Model.Components.Common
{
    /// <summary>
    /// Komponente für einen Linien Kontrollpunkt.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Common.CommonComponent" />
    public class LinePartComponent : CommonComponent
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public LinePartComponent()
        {
            CommonComponentType = CommonComponentTypes.LinePart;
        }
    }
}
