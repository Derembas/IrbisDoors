using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.MDDoors
{
    public class FootBamperOption: BaseClasses.Option
    {
        public double Price { get; set; }

        #region Свойства

        // Материал бампера
        public BaseClasses.Property Material { get; private set; }

        // Высота бампера
        public BaseClasses.Property Height { get; private set; }

        #endregion

        #region Конструктор

        public FootBamperOption() : base("Отбойник (бампер) для ног")
        {
            var BamperMeterials = new object[] 
            {
                Helpers.AllNames.Materials.plastic,
                Helpers.AllNames.Materials.formPlastic,
                Helpers.AllNames.Materials.aisi304,
                Helpers.AllNames.Materials.aisi430,
                Helpers.AllNames.Materials.riflAl
            };

            Material = new BaseClasses.Property("Материал", Helpers.PropertyTypes.StringType, true) { Values= BamperMeterials };
            Height = new BaseClasses.Property("Высота", Helpers.PropertyTypes.IntegerType) {Values= new object[] { 400, 600, 800, 1000 } };

            Material.PropertyChanged += Material_PropertyChanged;

            base.properties.Add(Material);
            base.properties.Add(Height);
        }

        private void Material_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName=="Value")
            {
                if(Material.Value.ToString() == Helpers.AllNames.Materials.formPlastic)
                    Height.UseValueList = true;
                else
                    Height.UseValueList = false;
            }
        }

        #endregion
    }
}
