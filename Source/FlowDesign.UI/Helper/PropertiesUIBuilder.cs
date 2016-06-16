using FlowDesign.UI.ViewModels.ComponentViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FlowDesign.UI.Helper
{
    /// <summary>
    /// Baut anhand von PropertiesDescriptions eine UI.
    /// </summary>
    public class PropertiesUIBuilder
    {
        /// <summary>
        /// Baut anhand von PropertiesDescriptions eine UI.
        /// </summary>
        /// <param name="sourceViewModel">Das ViewModel, das die PropertyDescriptions beinhaltet.</param>
        /// <returns>Eine Liste von UI Elementen für die Properties.</returns>
        public List<Grid> Build(ComponentViewModel sourceViewModel)
        {
            List<Grid> result = new List<Grid>();

            for (int i = 0; i < sourceViewModel.PropertyDescriptions.Count; i++)
            {
                PropertyDescription currentDescription = sourceViewModel.PropertyDescriptions[i];

                Grid grid = new Grid();
                ColumnDefinition columnDefintionLabel = new ColumnDefinition();
                columnDefintionLabel.Width = new GridLength(60);

                ColumnDefinition columnDefintionValue = new ColumnDefinition();

                grid.ColumnDefinitions.Add(columnDefintionLabel);
                grid.ColumnDefinitions.Add(columnDefintionValue);

                Label label = new Label();
                label.Foreground = Brushes.Black;
                label.Margin = new Thickness(0, 0, 10, 0);
                label.Content = currentDescription.DisplayName;


                Control control = null;

                if(currentDescription is SinglePropertyDescription)
                {
                    control = BuildTextBox(sourceViewModel ,currentDescription as SinglePropertyDescription);
                }

                if(currentDescription is EnumerationPropertyDescription)
                {
                    control = BuildComboBox(sourceViewModel, currentDescription as EnumerationPropertyDescription);
                }


                Grid.SetColumn(label, 0);
                Grid.SetColumn(control, 1);
                grid.Children.Add(label);
                grid.Children.Add(control);

                result.Add(grid);
            }

            return result;
        }

        /// <summary>
        /// Baut für eine SingleProperty eine TextBox.
        /// </summary>
        /// <param name="source">Das ViewModel, das die Property beinhaltet.</param>
        /// <param name="property">Die Property.</param>
        /// <returns>Eine TextBox.</returns>
        private TextBox BuildTextBox(ComponentViewModel source ,SinglePropertyDescription property)
        {
            TextBox textBox = new TextBox();
            textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBox.Margin = new Thickness(0, 0, 2, 0);
            textBox.MaxWidth = 125;

            Binding valueBinding = new Binding();
            valueBinding.Source = source;
            valueBinding.Path = new PropertyPath(property.PropertyName);
            valueBinding.Mode = BindingMode.TwoWay;
            valueBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            textBox.SetBinding(TextBox.TextProperty, valueBinding);

            return textBox;
        }

        /// <summary>
        /// Baut für eine EnumerationProperty eine ComboBox.
        /// </summary>
        /// <param name="source">Das ViewModel, das die Property beinhaltet.</param>
        /// <param name="property">Die Property.</param>
        /// <returns>Eine ComboBox</returns>
        private ComboBox BuildComboBox(ComponentViewModel source, EnumerationPropertyDescription property)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Margin = new Thickness(0, 0, 2, 0);
            comboBox.MaxWidth = 125;

            foreach (object value in property.Values)
            {
                comboBox.Items.Add(value);
            }

            Binding valueBinding = new Binding();
            valueBinding.Source = source;
            valueBinding.Path = new PropertyPath(property.PropertyName);
            valueBinding.Mode = BindingMode.TwoWay;
            valueBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            comboBox.SetBinding(ComboBox.SelectedValueProperty, valueBinding);

            return comboBox;
        }
    }
}
