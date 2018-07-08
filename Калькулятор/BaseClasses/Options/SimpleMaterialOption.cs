using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.BaseClasses.Options
{
    public class SimpleMaterialOption : Option
    {
        #region Свойства

        // Материал
        public BaseClasses.Property Material { get; private set; }

        // Цвет материала
        public BaseClasses.Property MaterialColor { get; private set; }

        #endregion

        #region Конструктор

        public SimpleMaterialOption(string name, object[] _standartMaterials, bool _isNecessary=false) : base(name, _isNecessary)
        {
            Material = new Property("Материал", Helpers.PropertyTypes.StringType, true) { Values = _standartMaterials };
            MaterialColor = new Property("Цвет", Helpers.PropertyTypes.StringType) { IsEnabled = false };

            Material.PropertyChanged += Material_PropertyChanged;

            base.properties.Add(Material);
            base.properties.Add(MaterialColor);
        }

        #endregion

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
