using FlowDesign.UI.ViewModels.ComponentViewModels;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FlowDesign.UI.Controls.Components
{
    /// <summary>
    /// Anfasser um eine Komponente zu verschieben.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Primitives.Thumb" />
    public class MoveThumb : Thumb
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public MoveThumb()
        {
            DragDelta += MoveThumb_DragDelta;
        }

        /// <summary>
        /// Wird ausgelöst, wenn der Anfasser bewegt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        protected void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            ComponentViewModel viewModel = (ComponentViewModel)((Control)sender).DataContext;

            viewModel.Left += e.HorizontalChange;
            viewModel.Top += e.VerticalChange;
        }

       
    }
}
