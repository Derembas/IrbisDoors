using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.MDDoors
{
    public class HandBamperOption: BaseClasses.Option
    {
        public BaseClasses.Property Material { get; private set; }
        public BaseClasses.Property Height { get; private set; }

        #region Конструктор

        public HandBamperOption():base("Отбойник (бампер) для рук")
        {
            object[] BamperMeterials = new object[] 
            {
                Helpers.AllNames.Materials.plastic,
                Helpers.AllNames.Materials.formPlastic,
                Helpers.AllNames.Materials.aisi304,
                Helpers.AllNames.Materials.aisi430,
                Helpers.AllNames.Materials.riflAl
            };

            Material = new BaseClasses.Property("Материал", Helpers.PropertyTypes.StringType, true) { Values= BamperMeterials };
            Height = new BaseClasses.Property("Высота", Helpers.PropertyTypes.IntegerType, true) { Values= new object[] { 100, 150 } };

            base.properties.Add(Material);
            base.properties.Add(Height);
        }

        #endregion

        public double Price { get; set; }

    }
}
