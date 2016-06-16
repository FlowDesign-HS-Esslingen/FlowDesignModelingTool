using FlowDesign.UI.ViewModels.ComponentViewModels;
using System;
using System.Windows.Controls;

namespace FlowDesign.UI.Helper
{
    /// <summary>
    /// Hilft dabei, Komponenten zu verstecken, wenn auf eine leere Stelle der Zeichenfläche geklickt wird.
    /// </summary>
    public static class DrawAreaHelper
    {
        /// <summary>
        /// Versteckt von allen Komponenten die sich im Canvas befinden den Resize rahmen/Line Parts und deselektiert alles.
        /// </summary>
        /// <param name="drawArea">Das Canvas in dem das Diagramm gezeichnet wird.</param>
        public static void Hide(ItemsControl drawArea)
        {
            if(drawArea == null)
            {
                throw new ArgumentNullException("Das übergebene Canvas um die ResizeThumbs zu verstecken ist null");
            }

            for (int i = 0; i < drawArea.Items.Count; i++)
            {
                ComponentViewModel viewModel = drawArea.Items[i] as ComponentViewModel;
                HideResizer(viewModel);
                Deselect(viewModel);

                if(viewModel is LineComponentViewModel)
                {
                    HideLinePart(drawArea, (LineComponentViewModel)viewModel);
                }
            }
        }

        /// <summary>
        /// Versteckt die Resize Anfasser.
        /// </summary>
        /// <param name="viewModel">Das ViewModel, für das die Resizer versteckt werden soll.</param>
        public static void HideResizer(ComponentViewModel viewModel)
        {
            viewModel.IsResizerVisible = false;
        }

        /// <summary>
        /// Deselektiert eine Komponente.
        /// </summary>
        /// <param name="viewModel">Das ViewModel, das deslektiert werden soll.</param>
        public static void Deselect(ComponentViewModel viewModel)
        {
            viewModel.IsSelected = false;
        }

        /// <summary>
        /// Zeigt alle Verbinder an.
        /// </summary>
        /// <param name="drawArea">Die Zeichenfläche.</param>
        /// <exception cref="System.ArgumentNullException">Das übergebene Canvas ist null</exception>
        public static void ShowConnector(ItemsControl drawArea)
        {
            if (drawArea == null)
            {
                throw new ArgumentNullException("Das übergebene Canvas ist null");
            }

            for (int i = 0; i < drawArea.Items.Count; i++)
            {
                ComponentViewModel c = drawArea.Items[i] as ComponentViewModel;
                c.IsConnectorVisible = true;
            }
        }

        /// <summary>
        /// Versteckt alle Verbinder.
        /// </summary>
        /// <param name="drawArea">Die Zeichenfläche.</param>
        /// <exception cref="System.ArgumentNullException">Das übergebene Canvas ist null</exception>
        public static void HideConnector(ItemsControl drawArea)
        {
            if (drawArea == null)
            {
                throw new ArgumentNullException("Das übergebene Canvas ist null");
            }

            for (int i = 0; i < drawArea.Items.Count; i++)
            {
                ComponentViewModel c = drawArea.Items[i] as ComponentViewModel;
                c.IsConnectorVisible = false;
            }
        }

        /// <summary>
        /// Versteckt die Anfasser für die Linie.
        /// </summary>
        /// <param name="drawArea">Die Zeichenfläche.</param>
        /// <param name="lineComponentViewModel">Die Linie, für die die Anfasser versteckt werden sollen.</param>
        public static void HideLinePart(ItemsControl drawArea, LineComponentViewModel lineComponentViewModel)
        {
            lineComponentViewModel.LinePartStartViewModel.IsLinePartVisible = false;
            lineComponentViewModel.LinePartEndViewModel.IsLinePartVisible = false;
        }

    }
}
