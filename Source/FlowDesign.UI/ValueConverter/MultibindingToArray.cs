using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FlowDesign.UI.ValueConverter
{
    /// <summary>
    /// Konvertiert ein Multibinding zu einem Object array un zurück.
    /// </summary>
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    public class MultibindingToArray : IMultiValueConverter
    {
        /// <summary>
        /// Konvertiert von Multibinding zu object array.
        /// </summary>
        /// <param name="values">Der Wertearray, den die Quellbindungen in dem <see cref="T:System.Windows.Data.MultiBinding" /> erzeugen.Der Wert <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> gibt an, dass die Quellbindung keinen Wert für die Konvertierung bereitstellen kann.</param>
        /// <param name="targetType">Der Typ der Bindungsziel-Eigenschaft.</param>
        /// <param name="parameter">Der zu verwendende Konverterparameter.</param>
        /// <param name="culture">Die im Konverter zu verwendende Kultur.</param>
        /// <returns>
        /// Ein konvertierter Wert.Wenn die Methode null zurückgibt, wird der gültige null-Wert verwendet.Der Rückgabewert <see cref="T:System.Windows.DependencyProperty" />.<see cref="F:System.Windows.DependencyProperty.UnsetValue" /> gibt an, dass der Konverter keinen Wert erstellt und dass die Bindung den <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> verwendet, falls vorhanden, oder andernfalls den Standardwert.Der Rückgabewert <see cref="T:System.Windows.Data.Binding" />.<see cref="F:System.Windows.Data.Binding.DoNothing" /> gibt an, dass die Bindung den Wert nicht überträgt oder den <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> oder den Standardwert verwendet.
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        /// <summary>
        /// Konvertiert von object array zu Multibinding.
        /// </summary>
        /// <param name="value">Der Wert, den das Bindungsziel erzeugt.</param>
        /// <param name="targetTypes">Das Array der Typen, in die konvertiert werden soll.Die Arraylänge gibt die Anzahl und die Typen der Werte an, die der Methode für die Rückgabe vorgeschlagen werden.</param>
        /// <param name="parameter">Der zu verwendende Konverterparameter.</param>
        /// <param name="culture">Die im Konverter zu verwendende Kultur.</param>
        /// <returns>
        /// Ein Array von Werten, die aus dem Zielwert in die Quellwerte zurückkonvertiert wurden.
        /// </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { value };
        }
    }
}
