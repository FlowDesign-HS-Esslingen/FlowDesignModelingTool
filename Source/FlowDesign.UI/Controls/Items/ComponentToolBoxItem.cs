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

namespace FlowDesign.UI.Controls.Items
{
    public class ComponentToolBoxItem : Control
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ComponentToolBoxItem), new PropertyMetadata(string.Empty));



        static ComponentToolBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComponentToolBoxItem), new FrameworkPropertyMetadata(typeof(ComponentToolBoxItem)));
        }
    }
}
