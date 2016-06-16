using FlowDesign.UI.Controls.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für DiagramComponentsControl.xaml
    /// </summary>
    public partial class DiagramComponentsControl : UserControl
    {
        public ObservableCollection<string> AvailableComponents
        {
            get { return (ObservableCollection<string>)GetValue(AvailableComponentsProperty); }
            set { SetValue(AvailableComponentsProperty, value); }
        }

        public static readonly DependencyProperty AvailableComponentsProperty =
            DependencyProperty.Register("AvailableComponents", typeof(ObservableCollection<string>), typeof(DiagramComponentsControl), new PropertyMetadata());


        public DiagramComponentsControl()
        {
            InitializeComponent();
        }

        private void ToolBoxItem_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ComponentToolBoxItem item = (ComponentToolBoxItem)sender;

                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, item.Text);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
