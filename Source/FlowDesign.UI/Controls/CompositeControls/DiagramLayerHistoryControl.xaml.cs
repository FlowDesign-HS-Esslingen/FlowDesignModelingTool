using FlowDesign.Model.Flow;
using FlowDesign.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowDesign.UI.Controls.CompositeControls
{
    /// <summary>
    /// Interaktionslogik für DiagramLayerHistoryControl.xaml
    /// </summary>
    public partial class DiagramLayerHistoryControl : UserControl
    {
        public DiagramLayerHistoryControl()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainPageViewModel mainPageViewModel = (MainPageViewModel)DataContext;
            FlowViewDiagram diagram = (FlowViewDiagram)((Control)sender).DataContext;

            int indexOfDiagram = mainPageViewModel.FlowLayers.IndexOf(diagram);

            List<FlowViewDiagram> diagramsToRemove = new List<FlowViewDiagram>();

            for(int i = indexOfDiagram; i< mainPageViewModel.FlowLayers.Count;i++)
            {
                diagramsToRemove.Add(mainPageViewModel.FlowLayers[i]);
            }

            for(int i = 0; i < diagramsToRemove.Count;i++)
            {
                mainPageViewModel.FlowLayers.Remove(diagramsToRemove[i]);
            }

            mainPageViewModel.ChangeToFlowLayer(diagram);
        }
    }
}
