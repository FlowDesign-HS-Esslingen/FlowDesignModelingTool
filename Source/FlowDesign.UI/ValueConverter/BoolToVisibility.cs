using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FlowDesign.UI.ValueConverter
{
    /// <summary>
    /// Konvertiert einen boolschen Wert zu einem visibility Wert von WPF und zurück.
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class BoolToVisibility : IValueConverter
    {
        /// <summary>
        /// Konvertiert von bool to visibility.
        /// </summary>
        /// <param name="value">Der von der Bindungsquelle erzeugte Wert.</param>
        /// <param name="targetType">Der Typ der Bindungsziel-Eigenschaft.</param>
        /// <param name="parameter">Der zu verwendende Konverterparameter.</param>
        /// <param name="culture">Die im Konverter zu verwendende Kultur.</param>
        /// <returns>
        /// Ein konvertierter Wert. Wenn die Methode null zurückgibt, wird der gültige NULL-Wert verwendet.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = (bool)value;

            if (result)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        /// <summary>
        /// Konvertiert von visibility zu bool.
        /// </summary>
        /// <param name="value">Der Wert, der vom Bindungsziel erzeugt wird.</param>
        /// <param name="targetType">Der Typ, in den konvertiert werden soll.</param>
        /// <param name="parameter">Der zu verwendende Konverterparameter.</param>
        /// <param name="culture">Die im Konverter zu verwendende Kultur.</param>
        /// <returns>
        /// Ein konvertierter Wert.Wenn die Methode null zurückgibt, wird der gültige NULL-Wert verwendet.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = (Visibility)value;
            if (result == Visibility.Visible)
                return true;
            else
                return false;
        }
    }
}
