using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.BaseClasses.Options
{
    public class MonorelsOption: Option
    {

        #region Свойства

        // Тип монорельса
        public BaseClasses.Property Type { get; private set; }

        // Ширина монорельса
        public BaseClasses.Property Width { get; private set; }

        // Высота монорельса
        public BaseClasses.Property Height { get; private set; }

        // Смещение монорельса
        public BaseClasses.Property Bias { get; private set; }

        #endregion

        #region Конструктор

        public MonorelsOption() : base("Монорельс")
        {
            Type = new Property("Тип монорельса", Helpers.PropertyTypes.StringType, true)
            {
                Values =new object[] 
                {
                    Helpers.AllNames.MonorelsTypes.Type1,
                    Helpers.AllNames.MonorelsTypes.Type2,
                    Helpers.AllNames.MonorelsTypes.Type3
                }
            };

            Width = new Property("Ширина монорельса", Helpers.PropertyTypes.IntegerType);
            Height = new Property("Высота монорельса", Helpers.PropertyTypes.IntegerType);
            Bias = new Property("Смещение", Helpers.PropertyTypes.IntegerType);

            base.properties.AddRange( new Property[] { Type, Width, Height, Bias });
        }

        #endregion

    }
}
