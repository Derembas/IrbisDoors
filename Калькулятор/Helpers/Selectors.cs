using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculator.Helpers
{
    public class PropertyTemplateSelector: DataTemplateSelector
    {
        public DataTemplate ComboBoxTemplate { get; set; }
        public DataTemplate TextBoxTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //получаем вызывающий контейнер
            var curProp = item as BaseClasses.Property;

            if (curProp != null)
            {
                if (curProp.Values != null && curProp.Values.Any())
                    return ComboBoxTemplate;
            }
            return TextBoxTemplate;
        }
    }
}
