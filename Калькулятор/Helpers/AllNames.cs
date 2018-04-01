using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public static  class AllNames
    {
        public static class Frames
        {
            /// <summary>В обхват</summary>
            public const string embraceFrame = "В обхват";
            /// <summary>Угловая</summary>
            public const string cornerFrame = "Угловая";
            /// <summary>Внутрь проёма</summary>
            public const string p_typeFrame = "Внутрь проёма";
        }

        public  static class WallMaterials
        {
            /// <summary>Панели обрамления</summary>
            public const string framePanels = "Панели обрамления";
            /// <summary>Пустотелый кирпич</summary>
            public const string emptyBricks = "Пустотелый кирпич";
            /// <summary>Газосиликатный блок</summary>
            public const string gasBlocks = "Газосиликатный блок";
            /// <summary>Металлоконструкция</summary>
            public const string metallConstruct = "Металлоконструкция";
            /// <summary>Пустотелый кирпич + внутренняя рама</summary>
            public const string emptyBrickAndInnerFrame = "Пустотелый кирпич + внутренняя рама";
            /// <summary>Сэндвич-панель</summary>
            public const string sandwichPanel = "Сэндвич-панель";
            /// <summary>Сэндвич-панель + металл</summary>
            public const string sandwichPanelAndMetal = "Сэндвич-панель + металл";
            /// <summary>Бетон</summary>
            public const string concrate = "Бетон";
            /// <summary>Полнотелый кирпич</summary>
            public const string fullBrick = "Полнотелый кирпич";
            /// <summary>Гипсокартон</summary>
            public const string dryWall = "Гипсокартон";
            /// <summary>Без крепежа</summary>
            public const string noType = "Без крепежа";
        }

        public static class FasteningTypes
        {
            public const string techFastenT1 = "Комплект Т1";
            public const string techFastenT2 = "Комплект Т2";
            public const string techFastenT3 = "Комплект Т3";
            public const string techFastenT4 = "Комплект Т4";
            public const string techFastenT5 = "Комплект Т5";
            public const string techFastenT6 = "Комплект Т6";
            public const string techFastenT7 = "Комплект Т7";
            public const string techFastenT8 = "Комплект Т8";
            public const string techFastenT9 = "Комплект Т9";
            public const string techFastenT10 = "Комплект Т10";
        }

        public static class AllDoorTypes
        {
            public static class MDDoorTypes
            {
                /// <summary>МДО(Оф) - офисная</summary>
                public const string MDOOF = "МДО(Оф) - офисная";
                /// <summary>МДД(Оф) - офисная</summary>
                public const string MDDOF = "МДД(Оф) - офисная";
                /// <summary>МДО(Ф) - с фиксацией полотна</summary>
                public const string MDOFix = "МДО(Ф) - с фиксацией полотна";
                /// <summary>МДД(Ф) - с фиксацией полотна</summary>
                public const string MDDFix = "МДД(Ф) - с фиксацией полотна";
            }
        }

        public static class DoorOpenSides
        {
            public const string leftSide = "Левое";
            public const string rightSide = "Правое";
        }

        public static class Materials
        {
            public const string ral9003 = "RAL 9003";
            public const string ral9016 = "RAL 9016";
            public const string ral7035 = "RAL 7035";
            public const string ral = "RAL ";
            public const string aisi304 = "AISI 304";
            public const string aisi430 = "AISI 430";
            public const string al = "Алюминий";
            public const string plastic = "ПНД";
            public const string formPlastic = "Пластик формованный";
            public const string riflAl = "Рифл. алюм.";
        }

        public static class MDLockTypes
        {
            /// <summary>Навесной замок</summary>
            public const string hingedLock = "Навесной замок";
            /// <summary>Врезной замок снизу полотна</summary>
            public const string mortiseDownLock = "Врезной замок снизу полотна";
            /// <summary>Врезной замок сверху полотна</summary>
            public const string mortiseUpLock = "Врезной замок сверху полотна";
            /// <summary>Шпингалет снизу полотна</summary>
            public const string boltDownLock = "Шпингалет снизу полотна";
            /// <summary>Шпингалет сверху полотна</summary>
            public const string boltUpLock = "Шпингалет сверху полотна";
        }

    }
}
