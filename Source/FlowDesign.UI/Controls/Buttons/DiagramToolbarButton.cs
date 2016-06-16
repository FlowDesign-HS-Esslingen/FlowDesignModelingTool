using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using FlowDesign.UI.Commands;
using FlowDesign.Model;
using System.Collections.ObjectModel;

namespace FlowDesign.UI.Controls.Buttons
{
    /// <summary>
    /// Button, der für die erstelltung von Diagrammen dient.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Primitives.ToggleButton" />
    public class DiagramToolbarButton : ToggleButton
    {
        /// <summary>
        /// Margin des Contents im Button.
        /// </summary>
        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(DiagramToolbarButton), new PropertyMetadata(new Thickness(0,0,0,0)));

        /// <summary>
        /// Vertikaler Offset des Popups.
        /// </summary>
        public int PopupVerticalOffset
        {
            get { return (int)GetValue(PopupVerticalOffsetProperty); }
            set { SetValue(PopupVerticalOffsetProperty, value); }
        }

        public static readonly DependencyProperty PopupVerticalOffsetProperty =
            DependencyProperty.Register("PopupVerticalOffset", typeof(int), typeof(DiagramToolbarButton), new PropertyMetadata(20));

        /// <summary>
        /// Horizontaler Offset des Popups.
        /// </summary>
        public int PopupHorizontalOffset
        {
            get { return (int)GetValue(PopupHorizontalOffsetProperty); }
            set { SetValue(PopupHorizontalOffsetProperty, value); }
        }

        public static readonly DependencyProperty PopupHorizontalOffsetProperty =
            DependencyProperty.Register("PopupHorizontalOffset", typeof(int), typeof(DiagramToolbarButton), new PropertyMetadata(0));

        /// <summary>
        /// Hintergrundfarbe des Popups.
        /// </summary>
        /// </value>
        public SolidColorBrush PopupBackground
        {
            get { return (SolidColorBrush)GetValue(PopupBackgroundProperty); }
            set { SetValue(PopupBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.Register("PopupBackground", typeof(SolidColorBrush), typeof(DiagramToolbarButton), new PropertyMetadata(Brushes.White));


        /// <summary>
        /// Kommando das ausgeführt wird, wenn der erstellen Button geklickt wird.
        /// </summary>
        public DelegateCommand CreateDiagramCommand
        {
            get { return (DelegateCommand)GetValue(CreateDiagramCommandProperty); }
            set { SetValue(CreateDiagramCommandProperty, value); }
        }

        public static readonly DependencyProperty CreateDiagramCommandProperty =
            DependencyProperty.Register("CreateDiagramCommand", typeof(DelegateCommand), typeof(DiagramToolbarButton), new PropertyMetadata(null));

        /// <summary>
        /// Liste von Diagrammen, die im Popup angezeigt werden sollen.
        /// </summary>
        public ObservableCollection<Diagram> Diagrams
        {
            get { return (ObservableCollection<Diagram>)GetValue(DiagramsProperty); }
            set { SetValue(DiagramsProperty, value); }
        }

        public static readonly DependencyProperty DiagramsProperty =
            DependencyProperty.Register("Diagrams", typeof(ObservableCollection<Diagram>), typeof(DiagramToolbarButton), new PropertyMetadata(null));

        /// <summary>
        /// Statischer Konstruktor.
        /// </summary>
        static DiagramToolbarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DiagramToolbarButton), new FrameworkPropertyMetadata(typeof(DiagramToolbarButton)));
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public DiagramToolbarButton()
        {
            this.Loaded += DiagramToolbarButton_Loaded;
        }

        /// <summary>
        /// Wird ausgelöst, wenn der Button vollständig geladen ist.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void DiagramToolbarButton_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Popup popup = base.Template.FindName("PART_Popup", this) as Popup;
                popup.MouseLeave += Popup_MouseLeave;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Wird ausgelöst, wenn die Maus das Popup des Buttons verlässt.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Popup_MouseLeave(object sender, MouseEventArgs e)
        {
            this.IsChecked = false;

            TextBox textBoxDiagramName = this.Template.FindName("PART_TextBoxDiagramName", this) as TextBox;
            textBoxDiagramName.Text = string.Empty;
        }
    }
}
