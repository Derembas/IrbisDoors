using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.RDDoors
{
    public class RDMainProperties : BaseClasses.Option
    {
        #region Все свойства

        ///<summary> Тип двери</summary>
        public BaseClasses.Property DoorType { get; private set; }

        ///<summary> Ширина двери</summary>
        public BaseClasses.Property Width { get; private set; }

        ///<summary> Высота двери</summary>
        public BaseClasses.Property Height { get; private set; }

        ///<summary> Толщина двери</summary>
        public BaseClasses.Property Thickness { get; private set; }

        ///<summary>Направление откывания двери</summary>
        public BaseClasses.Property OpenSide { get; private set; }

        ///<summary>Исполнение (Пороговое / Безпороговое)</summary>
        public BaseClasses.Property StepType { get; private set; }

        #endregion

        #region Калькулятор

        public RDMainProperties() : base("Основные свойства")
        {
            DoorType = new BaseClasses.Property("Тип двери", Helpers.PropertyTypes.StringType, true)
            {
                Values = new object[]
                {
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDOON,
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDDON,
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDOSN,
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDDSN,
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDOProm,
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDDProm,
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDOKS,
                    Helpers.AllNames.AllDoorTypes.RDDoorTypes.RDDKS
                },
            };

            Width = new BaseClasses.Property("Ширина двери", Helpers.PropertyTypes.IntegerType, defVal: 900);
            Height = new BaseClasses.Property("Высота двери", Helpers.PropertyTypes.IntegerType, defVal: 1800);
            Thickness = new BaseClasses.Property("Толщина двери", Helpers.PropertyTypes.StringType, true)
            {
                Values = new object[]
                {
                    Helpers.AllNames.CoolDoorThickness.M80,
                    Helpers.AllNames.CoolDoorThickness.L80,
                    Helpers.AllNames.CoolDoorThickness.L100,
                    Helpers.AllNames.CoolDoorThickness.L120,
                    Helpers.AllNames.CoolDoorThickness.L150
                }
            };

            OpenSide = new BaseClasses.Property("Открывание двери", Helpers.PropertyTypes.StringType, true)
            {
                Values = new object[]
                {
                    Helpers.AllNames.DoorOpenSides.leftSide,
                    Helpers.AllNames.DoorOpenSides.rightSide
                }
            };

            StepType = new BaseClasses.Property("Пороговое исполнение", Helpers.PropertyTypes.StringType, true)
            {
                Values = new object[]
                {
                    Helpers.AllNames.StepTypes.NoStep,
                    Helpers.AllNames.StepTypes.WithStep
                }
            };

            base.properties.AddRange(new BaseClasses.Property[] { DoorType, Width, Height, Thickness, OpenSide, StepType });

        }

        #endregion

        public override string ToString()
        {
            return $"{DoorType.Value} - {Width.Value}.{Height.Value}-{Thickness.Value} ({OpenSide.Value})";
        }

    }
}
