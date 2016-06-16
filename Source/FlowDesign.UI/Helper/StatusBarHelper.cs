using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FlowDesign.UI.Helper
{
    /// <summary>
    /// Die möglichen Status der Statusleiste.
    /// </summary>
    public enum Status
    {
        Info,
        Success,
        Danger,
    }

    /// <summary>
    /// Ermöglicht den vereinfachten Zugriff auf die Statusleiste.
    /// </summary>
    public class StatusBarHelper
    {
        /// <summary>
        /// Das Statusbar Item, über das die Nachrichten angezeigt werden sollen.
        /// </summary>
        public StatusBarItem StatusItem { get; set; }

        /// <summary>
        /// Statusbar, deren Hintergrundfarbe der Nachricht angepasst werden soll.
        /// </summary>
        public StatusBar StatusBar { get; set; }

        /// <summary>
        /// Gibt auf der Statusleiste eine Nachricht aus.
        /// </summary>
        /// <param name="message">Die Nachricht.</param>
        /// <param name="status">Der Status.</param>
        public void PrintStatus(string message, Status status)
        {
            if(StatusItem == null && StatusBar == null)
            {
                return;
            }

            StatusItem.Content = message;

            if (status == Status.Info)
            {
                SolidColorBrush color = (SolidColorBrush)StatusBar.FindResource("Info");
                StatusBar.Background = color;
            }

            if (status == Status.Success)
            {
                SolidColorBrush color = (SolidColorBrush)StatusBar.FindResource("Success");
                StatusBar.Background = color;
            }

            if (status == Status.Danger)
            {
                SolidColorBrush color = (SolidColorBrush)StatusBar.FindResource("Danger");
                StatusBar.Background = color;
            }
        }

    }
}
