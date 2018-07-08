using Calculator.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.RDDoors.Options
{
    public class StepVariantOption : BaseClasses.Option
    {
        object[] standarValues;
        object[] notStandarValues;

        #region Свойства

        // Нестандартный материал
        public Property NotStandart { get; private set; }

        // Нестандартный материал
        public Property StepTtype { get; private set; }

        #endregion

        #region Конструктор

        public StepVariantOption() :base("Вариант порога", true)
        {
            NotStandart = new Property("Не стандартный порог", Helpers.PropertyTypes.BoolType, defVal: false);
            StepTtype = new Property("Тип порога", Helpers.PropertyTypes.StringType, true);

            NotStandart.PropertyChanged += NotStandart_PropertyChanged;
        }

        #endregion
    }
}
