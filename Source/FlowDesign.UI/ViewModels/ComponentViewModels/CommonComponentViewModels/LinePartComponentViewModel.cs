using System.Windows;
using FlowDesign.Model.Components.Common;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für einen Anfasser einer Linie.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class LinePartComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Die Position des Anfassers.
        /// </summary>
        private Point position;

        /// <summary>
        /// Die Position des Anfassers.
        /// </summary>
        public Point Position
        {
            get { return position; }
            set { position = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Legt fest, ob der Anfasser sichtbar ist.
        /// </summary>
        private bool isLinePartVisible;

        /// <summary>
        /// Legt fest, ob der Anfasser sichtbar ist.
        /// </summary>
        public bool IsLinePartVisible
        {
            get { return isLinePartVisible; }
            set { isLinePartVisible = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Linien Anfasser Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public LinePartComponentViewModel(LinePartComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            component.UIProperties.ZIndex = 100;
        }
    }
}
