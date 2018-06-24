using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.BaseClasses.Options
{
    public class MaterialOption : Option
    {
        object[] standarValues;
        object[] notStandarValues;

        #region Свойства

        // Нестандартный материал
        public Property NotStandart { get; private set; }

        // Обрамление окна
        public BaseClasses.Property Material { get; private set; }

        // Форма окна
        public BaseClasses.Property MaterialColor { get; private set; }

        #endregion


        #region Конструктор

        public MaterialOption(string name, object[] _standartMaterials, object[] _notStandartMaterials) : base(name, isNecessary: true)
        {
            standarValues = _standartMaterials;
            notStandarValues = _notStandartMaterials;

            NotStandart = new Property("Не стандартный материал", Helpers.PropertyTypes.BoolType, defVal: false);
            Material = new Property("Материал", Helpers.PropertyTypes.StringType, true) { Values= standarValues };
            MaterialColor = new Property("Цвет", Helpers.PropertyTypes.StringType) { IsEnabled = false };

            NotStandart.PropertyChanged += NotStandart_PropertyChanged;
            Material.PropertyChanged += Material_PropertyChanged;

            base.properties.Add(NotStandart);
            base.properties.Add(Material);
            base.properties.Add(MaterialColor);
        }

        #endregion

        // Изменение значения свойства Нестандартный материал
        private void NotStandart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                if ((bool)NotStandart.Value)
                    Material.Values = notStandarValues;
                else
                    Material.Values = standarValues;

            }
        }

        // Изменение значения свойства Материал
        private void Material_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                if (Material.Value.Equals(Helpers.AllNames.Materials.ral))
                {
                    MaterialColor.IsEnabled = true;
                }
                else
                {
                    MaterialColor.Value = "";
                    MaterialColor.IsEnabled = false;
                }
            }
        }
    }
}
