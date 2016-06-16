using FlowDesign.UI.ViewModels.ComponentViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FlowDesign.UI.Controls.Components
{
    /// <summary>
    /// Thumb um bei einem UI Element die Größe zu verändern.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Primitives.Thumb" />
    public class ResizeThumb : Thumb
    {
        /// <summary>
        /// Punkt auf dem Element von dem
        /// </summary>
        private Point transformOrigin;

        /// <summary>
        /// ViewModel der Komponente, die vergrößert werden soll.
        /// </summary>
        private ComponentViewModel viewModel;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ResizeThumb()
        {
            
            DragStarted += new DragStartedEventHandler(this.ResizeThumb_DragStarted);
            DragDelta += new DragDeltaEventHandler(this.ResizeThumb_DragDelta);
        }

        /// <summary>
        /// Wird ausgelöst, wenn das Drag Event gestartet wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void ResizeThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            viewModel = (ComponentViewModel)((Control)sender).DataContext;

            transformOrigin = new Point(0.5, 0.5);
        }

        /// <summary>
        /// Wird ausgelöst, wenn der Anfasser bewegt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            switch (VerticalAlignment)
            {
                case System.Windows.VerticalAlignment.Bottom:
                    ResizeHeightBottom(e.VerticalChange);
                    break;
                case System.Windows.VerticalAlignment.Top:
                    ResizeHeightTop(e.VerticalChange);
                    break;
                default:
                    break;
            }

            switch (HorizontalAlignment)
            {
                case System.Windows.HorizontalAlignment.Left:
                    ResizeWidthLeft(e.HorizontalChange);
                    break;
                case System.Windows.HorizontalAlignment.Right:
                    ResizeWidthRight(e.HorizontalChange);
                    break;
                default:
                    break;
            }

            e.Handled = true;
        }

        /// <summary>
        /// Verändert die Größe nach unten.
        /// </summary>
        /// <param name="verticalChange">Größenänderung vertikal.</param>
        private void ResizeHeightBottom(double verticalChange)
        {
            double deltaVertical = Math.Min(-verticalChange, viewModel.Height - 50);
            viewModel.Height -= deltaVertical;
        }

        /// <summary>
        /// Verändert die Größe nach oben.
        /// </summary>
        /// <param name="verticalChange">Größenänderung vertikal.</param>
        private void ResizeHeightTop(double verticalChange)
        {
            double deltaVertical = Math.Min(verticalChange, viewModel.Height - 50);
            viewModel.Top = viewModel.Top + deltaVertical;
            viewModel.Height -= deltaVertical;
        }

        /// <summary>
        /// Verändert die Größe nach links.
        /// </summary>
        /// <param name="horizontalChange">Größenänderung horizontal.</param>
        private void ResizeWidthLeft(double horizontalChange)
        {
            double deltaHorizontal = Math.Min(horizontalChange, viewModel.Width - 50);
            viewModel.Left = viewModel.Left + deltaHorizontal;
            viewModel.Width -= deltaHorizontal;
        }

        /// <summary>
        /// Verändert die Größe nach rechts.
        /// </summary>
        /// <param name="horizontalChange">Größenänderung horizontal.</param>
        private void ResizeWidthRight(double horizontalChange)
        {
            double deltaHorizontal = Math.Min(-horizontalChange, viewModel.Width - 50);
            viewModel.Left = viewModel.Left;
            viewModel.Width -= deltaHorizontal;
        }

    }
}
