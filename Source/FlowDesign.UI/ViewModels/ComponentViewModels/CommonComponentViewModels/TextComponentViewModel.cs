using FlowDesign.Model.Components;
using FlowDesign.Model.Components.Common;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für einen Text.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class TextComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Wrapper Property für den Text der Komponente.
        /// </summary>
        public string Text
        {
            get { return ((TextComponent)Component).Text; }
            set { ((TextComponent)Component).Text = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Text Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public TextComponentViewModel(TextComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            PropertyDescriptions.Add(new SinglePropertyDescription("Text","Text"));
        }
    }
}
