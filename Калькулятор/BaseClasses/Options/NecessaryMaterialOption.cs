using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.BaseClasses.Options
{
    public class NecessaryMaterialOption : SimpleMaterialOption
    {
        object[] standarValues;
        object[] notStandarValues;

        #region Свойства

        // Нестандартный материал
        public Property NotStandart { get; private set; }

        #endregion


        #region Конструктор

        public NecessaryMaterialOption(string name, object[] _standartMaterials, object[] _notStandartMaterials) : base(name, _standartMaterials, true)
        {
            standarValues = _standartMaterials;
            notStandarValues = _notStandartMaterials;

            NotStandart = new Property("Не стандартный материал", Helpers.PropertyTypes.BoolType, defVal: false);

            NotStandart.PropertyChanged += NotStandart_PropertyChanged;

            base.properties.Insert(0,NotStandart);
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
    }
}
