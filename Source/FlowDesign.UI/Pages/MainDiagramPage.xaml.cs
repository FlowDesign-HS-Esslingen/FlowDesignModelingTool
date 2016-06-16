using FlowDesign.Model;
using FlowDesign.Model.Flow;
using FlowDesign.UI.Helper;
using FlowDesign.UI.ViewModels;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FlowDesign.UI.Pages
{
    /// <summary>
    /// Interaktionslogik für MainDiagramPage.xaml
    /// </summary>
    public partial class MainDiagramPage : Page
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public MainDiagramPage()
        {
            InitializeComponent();
            Loaded += MainDiagramPage_Loaded;
        }

        /// <summary>
        /// Wird aufgerufen, wenn die Page vollständig geladen wurde.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void MainDiagramPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Eventhandler für das Canvas.
            diagramCanvas.MouseLeftButtonDown += DiagramCanvas_MouseLeftButtonDown;

            ((MainPageViewModel)((Page)sender).DataContext).OnSelectionChanged += MainDiagramPage_OnSelectionChanged;
        }

        /// <summary>
        /// Wird aufgerufen, wenn eine Komponente auf der Zeichenfläche ausgewählt wird.
        /// </summary>
        /// <param name="sender">Die Komponente, die ausgewählt wurde.</param>
        private void MainDiagramPage_OnSelectionChanged(ComponentViewModel sender)
        {
            PropertiesUIBuilder builder = new PropertiesUIBuilder();
            List<Grid> properties = builder.Build(sender);

            propertiesStackPanel.Children.Clear();

            foreach (Grid property in properties)
            {
                for(int i = 0; i < property.Children.Count;i++)
                {
                    if(property.Children[i] is Label)
                    {
                        ((Label)property.Children[i]).Foreground = (SolidColorBrush)propertiesStackPanel.FindResource("TextBody");
                    }
                }

                propertiesStackPanel.Children.Add(property);
            }
        }

        /// <summary>
        /// Wird ausgelöst, wenn auf eine leere Stelle auf der Zeichenfläche geklickt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void DiagramCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DrawAreaHelper.Hide(sender as ItemsControl);
        }

        /// <summary>
        /// Wird ausgelöst, wenn eine Komponente auf die Zeichenfläche gedroppt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            // Überprüfen die Daten strings sind.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                Point dropPosition = e.GetPosition(diagramCanvas);
                ((MainPageViewModel)DataContext).AddComponent(dataString, dropPosition.X, dropPosition.Y);
            }

            // Event Routing beenden sonst erhalten noch mehr Controls das Event.
            e.Handled = true;
        }

        /// <summary>
        /// Wird ausgelöst, wenn mit der rechten Maustaste auf eine Verbindung geklickt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Path_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Path path = sender as Path;

            ConnectionViewModel viewModel = (ConnectionViewModel)path.DataContext;
            viewModel.ParentViewModel.RemoveConnection(viewModel);
        }

        /// <summary>
        /// Wird ausgelöst, wenn auf eine Linie mit der linken Maustaste geklickt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Line_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LineComponentViewModel viewModel = (LineComponentViewModel)((Shape)sender).DataContext;
            viewModel.LinePartStartViewModel.IsLinePartVisible = true;
            viewModel.LinePartEndViewModel.IsLinePartVisible = true;
            viewModel.IsSelected = true;

            if(e.ClickCount == 2 && viewModel is DelegationComponentViewModel)
            {
                DelegationComponentViewModel delegationViewModel = (DelegationComponentViewModel)viewModel;

                Diagram flowViewDiagram = viewModel.ParentViewModel.FlowViewDiagrams.Where(param => param.Name == delegationViewModel.FlowViewName).FirstOrDefault();
                if(flowViewDiagram != null)
                {
                    viewModel.ParentViewModel.ChangeToFlowLayer((FlowViewDiagram)flowViewDiagram);
                    propertiesStackPanel.Children.Clear();
                }
            }

            e.Handled = true;
        }

        /// <summary>
        /// Wird ausgelöst, wenn auf einem Modul in einem FlowView Diagramm ein Doppelklick ausgeführt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void ModulComponent_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ModulComponentViewModel viewModel = (ModulComponentViewModel)((Control)sender).DataContext;

            FlowViewDiagram parentDiagram = (FlowViewDiagram)viewModel.ParentViewModel.FlowViewDiagrams.Where(a => a.ID == viewModel.ParentID).FirstOrDefault();
            FlowViewDiagram childDiagram = (FlowViewDiagram)viewModel.ParentViewModel.FlowViewDiagrams.Where(a => a.ID == viewModel.ChildID).FirstOrDefault();

            if(childDiagram != null)
            {
                viewModel.ParentViewModel.FlowLayers.Add(parentDiagram);
                viewModel.ParentViewModel.ChangeToFlowLayer(childDiagram);
            }
        }

        /// <summary>
        /// Wird ausgelöst, wenn auf einer Selbst Delegation in einem Maskenprototpy ein Doppelklick ausgeführt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void SelfDelegationComponent_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelfDelegationComponentViewModel viewModel = (SelfDelegationComponentViewModel)((Control)sender).DataContext;

            Diagram flowViewDiagram = viewModel.ParentViewModel.FlowViewDiagrams.Where(param => param.Name == viewModel.FlowViewName).FirstOrDefault();
            if (flowViewDiagram != null)
            {
                viewModel.ParentViewModel.ChangeToFlowLayer((FlowViewDiagram)flowViewDiagram);
                propertiesStackPanel.Children.Clear();
            }
        }

        /// <summary>
        /// Wird gebraucht, wenn man während eines Drag'n Drop Vorgangs die richtige Mausposition will.
        /// </summary>
        public static class MouseUtilities
        {
            public static Point CorrectGetPosition(Visual relativeTo)
            {
                Win32Point w32Mouse = new Win32Point();
                GetCursorPos(ref w32Mouse);
                return relativeTo.PointFromScreen(new Point(w32Mouse.X, w32Mouse.Y));
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct Win32Point
            {
                public Int32 X;
                public Int32 Y;
            };

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GetCursorPos(ref Win32Point pt);
        }
    }
}
