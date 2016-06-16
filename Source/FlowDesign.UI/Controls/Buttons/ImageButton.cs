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

namespace FlowDesign.UI.Controls.Buttons
{
    /// <summary>
    /// Button mit einem Bild auf der rechten Seite.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Button" />
    public class ImageButton : Button
    {
        /// <summary>
        /// Quelle des Bildes.
        /// </summary>
        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata());

        /// <summary>
        /// Farbe, wenn die Maus über dem Button ist.
        /// </summary>
        public SolidColorBrush HighlightedColor
        {
            get { return (SolidColorBrush)GetValue(MouseOverColorProperty); }
            set { SetValue(MouseOverColorProperty, value); }
        }

        public static readonly DependencyProperty MouseOverColorProperty =
            DependencyProperty.Register("HighlightedColor", typeof(SolidColorBrush), typeof(ImageButton), new PropertyMetadata(Brushes.LightGray));

        /// <summary>
        /// Farbe der Border, wenn die Maus über dem Button ist.
        /// </summary>
        public SolidColorBrush BorderHighlightedColor
        {
            get { return (SolidColorBrush)GetValue(BorderHighlightedColorProperty); }
            set { SetValue(BorderHighlightedColorProperty, value); }
        }

        public static readonly DependencyProperty BorderHighlightedColorProperty =
            DependencyProperty.Register("BorderHighlightedColor", typeof(SolidColorBrush), typeof(ImageButton), new PropertyMetadata(Brushes.LightGreen));

        /// <summary>
        /// Margin des Contents.
        /// </summary>
        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(ImageButton), new PropertyMetadata(new Thickness(2, 2, 2, 2)));

        /// <summary>
        /// Margin des Textes.
        /// </summary>
        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(ImageButton), new PropertyMetadata(new Thickness(5, 0, 0, 0)));

        /// <summary>
        /// Statischer Konstruktor.
        /// </summary>
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }
    }
}
