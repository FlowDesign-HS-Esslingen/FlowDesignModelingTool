namespace FlowDesign.Model.Components.Common
{
    /// <summary>
    /// Text Komponente.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Common.CommonComponent" />
    public class TextComponent : CommonComponent
    {
        /// <summary>
        /// Der Text, der auf der UI angezeigt wird..
        /// </summary>
        public string Text { get; set; } = "Text";

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public TextComponent()
        {
            CommonComponentType = CommonComponentTypes.Text;
        }
    }
}
