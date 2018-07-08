using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.MDDoors
{
    public class MDDoor : BaseClasses.Door
    {
        #region Опции

        // Тип креплния на стену
        public CommonClasses.TechDoorWallType WallType { get; private set; }

        // Бампер для рук
        public HandBamperOption HandBamper { get; private set; }

        // Бампер для ног
        public FootBamperOption FootBamper { get; private set; }

        // Смотровое окно
        public Options.WindowOption WindowOption { get; private set; }

        // Запорное устройство
        public LockOption Lock { get; private set; }

        // Монорельс
        public BaseClasses.Options.MonorelsOption Monorels { get; private set; }

        // Доп крепёж
        public CommonClasses.TechDoorWallType AdditionalFestening { get; set; }

        // Материал полотна
        public BaseClasses.Options.NecessaryMaterialOption DoorMaterial { get; private set; }

        // Материал рамы
        public BaseClasses.Options.NecessaryMaterialOption RamaMaterial { get; private set; }

        // Внутренняя рама
        public BaseClasses.Options.NecessaryMaterialOption InnerFrame { get; private set; }

        #endregion

        #region Конструктор

        public MDDoor(): base(new MDMainProperties())
        {
            // Основной крепёж
            WallType = new CommonClasses.TechDoorWallType("Основной крепёж", true);
            Options.Add(WallType);

            // Бампер для рук
            HandBamper = new HandBamperOption();
            Options.Add(HandBamper);

            // Бампер для ног
            FootBamper = new FootBamperOption();
            Options.Add(FootBamper);

            // Смотровое окно
            WindowOption = new MDDoors.Options.WindowOption();
            Options.Add(WindowOption);

            // Запорное устройство
            Lock = new LockOption();
            Options.Add(Lock);

            // Монорельс
            Monorels = new BaseClasses.Options.MonorelsOption();
            Options.Add(Monorels);

            // Доп крепёж
            AdditionalFestening = new CommonClasses.TechDoorWallType("Дополнительный крепёж");
            Options.Add(AdditionalFestening);

            // Материал полотна
            DoorMaterial = new BaseClasses.Options.NecessaryMaterialOption("Материал полотна",
                new object[]
                {
                    Helpers.AllNames.Materials.ral9003,
                    Helpers.AllNames.Materials.ral7035
                },
                new object[]
                {
                    Helpers.AllNames.Materials.aisi304,
                    Helpers.AllNames.Materials.ral
                });
            Options.Add(DoorMaterial);

            // Материал рамы
            RamaMaterial = new BaseClasses.Options.NecessaryMaterialOption("Материал рамы", 
                new object[] { Helpers.AllNames.Materials.ral9016 }, 
                new object[]
                {
                    Helpers.AllNames.Materials.aisi304,
                    Helpers.AllNames.Materials.ral
                });
            Options.Add(RamaMaterial);
        }

        #endregion
    }
}
