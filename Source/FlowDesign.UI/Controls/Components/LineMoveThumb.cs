using FlowDesign.UI.ViewModels.ComponentViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FlowDesign.UI.Controls.Components
{
    /// <summary>
    /// Anfasser für die Kontrollpunkte einer Linie.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.Controls.Components.MoveThumb" />
    public class LineMoveThumb : MoveThumb
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public LineMoveThumb()
        {
            Loaded += LineMoveThumb_Loaded;
            DragDelta += LineMoveThumb_DragDelta;
        }

        /// <summary>
        /// Handles the Loaded event of the LineMoveThumb control.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void LineMoveThumb_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePositionInViewModel();
        }

        /// <summary>
        /// Wird aufgerufen, wenn der Anfasser bewegt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void LineMoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            UpdatePositionInViewModel();
        }

        /// <summary>
        /// Wird aufgerufen, wenn sich das Layout ändert.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void LineMoveThumb_LayoutUpdated(object sender, EventArgs e)
        {
            ComponentViewModel viewModel = (ComponentViewModel)((Control)this).DataContext;
        }

        /// <summary>
        /// Aktualisiert die Position des Anfassers im zugehörigen ViewModel.
        /// </summary>
        private void UpdatePositionInViewModel()
        {
            ComponentViewModel viewModel = (ComponentViewModel)((Control)this).DataContext;
            LinePartComponentViewModel linePartViewModel = (LinePartComponentViewModel)viewModel;

            linePartViewModel.Position = GetPosition();
        }

        /// <summary>
        /// Gibt die Position des UI Elements zurück.
        /// </summary>
        /// <returns>Die Position</returns>
        private Point GetPosition()
        {
            ItemsControl itemsControl = GetParentItemsControl(this);
            return this.TransformToAncestor(itemsControl).Transform(new Point(Width * 0.5, Height * 0.5));
        }

        /// <summary>
        /// Gibt die Zeichenfläche zurück.
        /// </summary>
        /// <param name="element">Das Element das sich in der Zeichenfläche befindet.</param>
        /// <returns>Die Zeichenfläche.</returns>
        private ItemsControl GetParentItemsControl(DependencyObject element)
        {
            while (element != null && !(element is ItemsControl))
                element = VisualTreeHelper.GetParent(element);

            return element as ItemsControl;
        }
    }
}
