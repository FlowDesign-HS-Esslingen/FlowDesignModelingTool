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

namespace FlowDesign.UI.Controls.Seperator
{
    /// <summary>
    /// Interaktionslogik für InsetSeperator.xaml
    /// </summary>
    public partial class InsetSeperator : UserControl
    {
        public Brush DarkPartBackground
        {
            get { return (Brush)GetValue(DarkPartBackgroundProperty); }
            set { SetValue(DarkPartBackgroundProperty, value); }
        }

        public static readonly DependencyProperty DarkPartBackgroundProperty =
            DependencyProperty.Register("DarkPartBackground", typeof(Brush), typeof(InsetSeperator), new PropertyMetadata(Brushes.DarkGray));

        public Brush LightPartBackground
        {
            get { return (Brush)GetValue(LightPartBackgroundProperty); }
            set { SetValue(LightPartBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LightPartBackgroundProperty =
            DependencyProperty.Register("LightPartBackground", typeof(Brush), typeof(InsetSeperator), new PropertyMetadata(Brushes.LightGray));

        public int DarkPartHeight
        {
            get { return (int)GetValue(DarkPartHeightProperty); }
            set { SetValue(DarkPartHeightProperty, value); }
        }

        public static readonly DependencyProperty DarkPartHeightProperty =
            DependencyProperty.Register("DarkPartHeight", typeof(int), typeof(InsetSeperator), new PropertyMetadata(4));
            
        public int LightPartHeight
        {
            get { return (int)GetValue(LightPartHeightProperty); }
            set { SetValue(LightPartHeightProperty, value); }
        }

        public static readonly DependencyProperty LightPartHeightProperty =
            DependencyProperty.Register("LightPartHeight", typeof(int), typeof(InsetSeperator), new PropertyMetadata(1));



        public InsetSeperator()
        {
            InitializeComponent();
        }
    }
}
