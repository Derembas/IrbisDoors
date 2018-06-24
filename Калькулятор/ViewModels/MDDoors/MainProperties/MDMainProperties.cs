using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.MDDoors
{
    public class MDMainProperties: BaseClasses.Option
    {

        ///<summary> Тип двери</summary>
        public BaseClasses.Property DoorType { get; private set; }

        ///<summary> Ширина двери</summary>
        public BaseClasses.Property Width { get; private set; }

        ///<summary> Высота двери</summary>
        public BaseClasses.Property Height { get; private set; }

        ///<summary>Направление откывания двери</summary>
        public BaseClasses.Property OpenSide { get; private set; }

        #region Конструктор

        public MDMainProperties():base("Основные свойства")
        {
            DoorType = new BaseClasses.Property("Тип двери", Helpers.PropertyTypes.StringType, true)
            {
                Values = new object[]
                {
                    Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDOOF,
                    Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDOFix,
                    Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDDOF,
                    Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDDFix
                },
            };

            Width = new BaseClasses.Property("Ширина двери", Helpers.PropertyTypes.IntegerType, defVal:900);
            Height = new BaseClasses.Property("Высота двери", Helpers.PropertyTypes.IntegerType, defVal:1800);
            OpenSide = new BaseClasses.Property("Открывание двери", Helpers.PropertyTypes.StringType, true)
            {
                Values= new object[]
                {
                    Helpers.AllNames.DoorOpenSides.leftSide,
                    Helpers.AllNames.DoorOpenSides.rightSide
                }
            };

            base.properties.AddRange(new BaseClasses.Property[] { DoorType, Width, Height, OpenSide });
        }

        #endregion

        public override string ToString()
        {
            return $"{DoorType.Value} - {Width.Value}.{Height.Value} ({OpenSide.Value})";
        }

    }
}
