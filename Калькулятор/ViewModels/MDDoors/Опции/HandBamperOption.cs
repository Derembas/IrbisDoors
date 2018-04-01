using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MDDoors
{
    public class HandBamperOption: IOption
    {
        public string Name { get { return "Отбойник (бампер) для рук"; } }
        public bool Checked { get; set; }

        public Property Material { get; private set; }
        public Property Height { get; private set; }

        public Property[] Properties { get; private set; }

        #region Конструктор

        public HandBamperOption()
        {
            object[] BamperMeterials = new object[] 
            {
                Helpers.AllNames.Materials.plastic,
                Helpers.AllNames.Materials.formPlastic,
                Helpers.AllNames.Materials.aisi304,
                Helpers.AllNames.Materials.aisi430,
                Helpers.AllNames.Materials.riflAl
            };

            Material = new Property("Материал", BamperMeterials);
            Height = new Property("Высота", new object[] { 100, 150 });

            Properties = new Property[] { Material, Height} ;
        }

        #endregion

        public double Price { get; set; }

    }
}
