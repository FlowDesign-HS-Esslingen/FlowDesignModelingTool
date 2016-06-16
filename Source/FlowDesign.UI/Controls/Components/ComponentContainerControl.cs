using FlowDesign.UI.ViewModels.ComponentViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlowDesign.UI.Controls.Components
{
    /// <summary>
    /// Container, in dem sich UI-Elemente für eine Komponente einbetten lassen.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ContentControl" />
    public class ComponentContainerControl : ContentControl
    {
        /// <summary>
        /// Statischer Konstruktor.
        /// </summary>
        static ComponentContainerControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComponentContainerControl), new FrameworkPropertyMetadata(typeof(ComponentContainerControl)));
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ComponentContainerControl()
        {
            PreviewMouseLeftButtonDown += ComponentControl_PreviewMouseLeftButtonDown;

            MouseEnter += ComponentContainerControl_MouseEnter;
            MouseLeave += ComponentControl_MouseLeave;
        }

        /// <summary>
        /// Wird aufgerufen, wenn die Maus den Container betritt.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void ComponentContainerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ComponentViewModel viewModel = (ComponentViewModel)DataContext;
            viewModel.IsConnectorVisible = true;
        }

        /// <summary>
        /// Wird aufgerufen, wenn die Maus den Container verlässt.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void ComponentControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if(!(DataContext is ComponentViewModel))
            {
                return;
            }

            ComponentViewModel viewModel = (ComponentViewModel)DataContext;
            viewModel.IsConnectorVisible = false;

            Control control = this.Content as Control;
            if (control == null)
            {
                return;
            }

            control.IsHitTestVisible = false;
            Keyboard.ClearFocus();
        }

        /// <summary>
        /// Wird aufgerufen, wenn mit der linken Maustaste auf den Container geklickt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void ComponentControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 1)
            {
                ComponentViewModel viewModel = (ComponentViewModel)DataContext;
                viewModel.IsResizerVisible = true;
                viewModel.IsSelected = true;
            }

            if(e.ClickCount == 2)
            {
                Control temp = this.Content as Control;
                if(temp == null)
                {
                    return;
                }

                temp.IsHitTestVisible = true;
            }
                
        }
    }
}
