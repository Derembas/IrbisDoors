using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MDDoors
{
    public class FootBamperOption: IOption
    {
        public string Name { get { return "Отбойник (бампер) для ног"; } }
        public bool Checked { get; set; }

        public double Price { get; set; }

        #region Свойства

        // Материал бампера
        public Property Material { get; private set; }

        // Высота бампера
        public Property Height { get; private set; }

        #endregion

        // Список всех свойств
        public Property[] Properties { get; private set; }

        #region Конструктор

        public FootBamperOption()
        {
            var BamperMeterials = new object[] 
            {
                Helpers.AllNames.Materials.plastic,
                Helpers.AllNames.Materials.formPlastic,
                Helpers.AllNames.Materials.aisi304,
                Helpers.AllNames.Materials.aisi430,
                Helpers.AllNames.Materials.riflAl
            };

            Material = new Property("Материал", BamperMeterials);
            Height = new Property("Высота", new object[] { 400, 600, 800, 1000});

            Properties = new Property[] { Material, Height };
        }

        #endregion
    }
}
