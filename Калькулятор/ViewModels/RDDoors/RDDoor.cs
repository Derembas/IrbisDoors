using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.RDDoors
{
    public class RDDoor : BaseClasses.Door
    {
        #region Опции

        // Тип креплния на стену
        public CommonClasses.CoolDoorWallType WallType { get; private set; }

        // Обрамление проёма
        public BaseClasses.Option DoorFrame { get; private set; }

        // Внутреннее открывание
        public BaseClasses.Option InversOpening { get; private set; }

        // Клапанвыравнивания давления
        public BaseClasses.Option PressureValve { get; private set; }

        // Доп крепёж
        public CommonClasses.CoolDoorWallType AdditionalFestening { get; set; }

        // Монорельс
        public BaseClasses.Options.MonorelsOption Monorels { get; private set; }

        // Материал внешней обшивки
        public BaseClasses.Options.NecessaryMaterialOption OuterDoorMaterial { get; private set; }

        // Материал внутренней обшивки
        public BaseClasses.Options.NecessaryMaterialOption InnerDoorMaterial { get; private set; }

        // Материал рамы
        public BaseClasses.Options.NecessaryMaterialOption RamaMaterial { get; private set; }

        // Внутренняя рама
        public BaseClasses.Options.SimpleMaterialOption InnerFrame { get; private set; }

        #endregion

        #region Конструктор

        public RDDoor() : base(new RDMainProperties())
        {
            // Основной крепёж
            WallType = new CommonClasses.CoolDoorWallType("Основной крепёж", true);
            Options.Add(WallType);

            // Обрамление проёма
            DoorFrame = new BaseClasses.Option("Обрамление проёма");
            Options.Add(DoorFrame);

            // Внутреннее открывание
            InversOpening = new BaseClasses.Option("Внутреннее открывание");
            Options.Add(InversOpening);

            // Клапанвыравнивания давления
            PressureValve = new BaseClasses.Option("Клапан выравнивания давления");
            Options.Add(PressureValve);

            // Монорельс
            Monorels = new BaseClasses.Options.MonorelsOption();
            Options.Add(Monorels);

            // Доп крепёж
            AdditionalFestening = new CommonClasses.CoolDoorWallType("Дополнительный крепёж");
            Options.Add(AdditionalFestening);

            // Материал внешней обшивки
            OuterDoorMaterial = new BaseClasses.Options.NecessaryMaterialOption("Материал внешней обшивки",
                new object[]
                {
                    Helpers.AllNames.Materials.ral9003
                },
                new object[]
                {
                    Helpers.AllNames.Materials.aisi304,
                    Helpers.AllNames.Materials.ral
                });
            Options.Add(OuterDoorMaterial);

            // Материал внутренней обшивки
            InnerDoorMaterial = new BaseClasses.Options.NecessaryMaterialOption("Материал внутренней обшивки",
                new object[]
                {
                    Helpers.AllNames.Materials.ral9003
                },
                new object[]
                {
                    Helpers.AllNames.Materials.aisi304,
                    Helpers.AllNames.Materials.ral
                });
            Options.Add(InnerDoorMaterial);

            // Материал рамы
            RamaMaterial = new BaseClasses.Options.NecessaryMaterialOption("Материал рамы",
                new object[]
                {
                    Helpers.AllNames.Materials.ral9016
                },
                new object[]
                {
                    Helpers.AllNames.Materials.aisi304,
                    Helpers.AllNames.Materials.al,
                    Helpers.AllNames.Materials.ral
                });
            Options.Add(RamaMaterial);

            // Внутренняя рама
            InnerFrame= new BaseClasses.Options.SimpleMaterialOption("Внутренняя рама",
                new object[]
                {
                    Helpers.AllNames.Materials.ral9016,
                    Helpers.AllNames.Materials.aisi304,
                    Helpers.AllNames.Materials.ral
                });
            Options.Add(InnerFrame);
        }

        #endregion

    }
}
