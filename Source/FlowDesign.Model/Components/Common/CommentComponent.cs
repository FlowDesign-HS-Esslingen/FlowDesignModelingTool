namespace FlowDesign.Model.Components.Common
{
    /// <summary>
    /// Kommentar.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Common.CommonComponent" />
    public class CommentComponent : CommonComponent
    {
        /// <summary>
        /// Der Text des Kommentars.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public CommentComponent()
        {
            CommonComponentType = CommonComponentTypes.Comment;
        }
    }
}
