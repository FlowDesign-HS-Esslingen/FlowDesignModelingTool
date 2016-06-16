using FlowDesign.Model.Components.Common;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für einen Kommentar.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class CommentComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Wrapper Property für den Text der Kommentar Komponente.
        /// </summary>
        public string Text
        {
            get { return ((CommentComponent)Component).Text; }
            set
            {
                ((CommentComponent)Component).Text = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentComponentViewModel"/> class.
        /// </summary>
        /// <param name="component">Die Kommentar Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public CommentComponentViewModel(CommentComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            PropertyDescriptions.Add(new SinglePropertyDescription("Text","Text"));
        }
    }
}
