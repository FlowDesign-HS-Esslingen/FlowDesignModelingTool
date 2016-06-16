using FlowDesign.UI.ViewModels;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FlowDesign.UI
{
    /// <summary>
    /// Enthält Basisinformationen für eine Eigenschaft, die in der UI angezeigt werden soll.
    /// </summary>
    public abstract class PropertyDescription
    {
        /// <summary>
        /// Name der C# Eigenschaft.
        /// </summary>
        public string PropertyName { get; protected set; } = string.Empty;

        /// <summary>
        /// Name der auf der UI angezeigt werden soll.
        /// </summary>
        public string DisplayName { get; protected set; } = string.Empty;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="propertyName">Name der C# Eigenschaft.</param>
        /// <param name="displayName">Name der auf der UI angezeigt werden soll.</param>
        public PropertyDescription(string propertyName, string displayName)
        {
            PropertyName = propertyName;
            DisplayName = displayName;
        }
    }

    /// <summary>
    /// Eine Eigenschaft, die nur einen Wert annehmen kann und als TextBox dargestellt wird.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.PropertyDescription" />
    public class SinglePropertyDescription : PropertyDescription
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="propertyName">Name der C# Eigenschaft.</param>
        /// <param name="displayName">Name der auf der UI angezeigt werden soll.</param>
        public SinglePropertyDescription(string propertyName, string displayName) : base(propertyName, displayName)
        {
        }
    }

    /// <summary>
    /// Eine Eigenschaft, die als DropDown liste dargestellt wird.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.PropertyDescription" />
    public class EnumerationPropertyDescription : PropertyDescription
    {
        /// <summary>
        /// Die Werte, die in der DropDown liste angezeigt werden sollen.
        /// </summary>
        public List<object> Values { get; private set; } = new List<object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerationPropertyDescription"/> class.
        /// </summary>
        /// <param name="propertyName">Name der C# Eigenschaft.</param>
        /// <param name="displayName">Name der auf der UI angezeigt werden soll.</param>
        /// <param name="values">Die Werte, die in der DropDown liste angezeigt werden sollen.</param>
        public EnumerationPropertyDescription(string propertyName, string displayName,List<object> values) : base(propertyName, displayName)
        {
            Values = values;
        }
       
    }
}
