using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public static  class AllNames
    {
        // Рамы технологических дверей
        public static class Frames
        {
            /// <summary>В обхват</summary>
            public const string embraceFrame = "В обхват";
            /// <summary>Угловая</summary>
            public const string cornerFrame = "Угловая";
            /// <summary>Внутрь проёма</summary>
            public const string p_typeFrame = "Внутрь проёма";
        }

        // Материалы стен
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

        // Обозначения крепёжного набора
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

        // Типы всех дверей
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
            public static class RDDoorTypes
            {
                /// <summary>РДО(ОН)</summary>
                public const string RDOON = "РДО(ОН)";
                /// <summary>РДД(ОН)</summary>
                public const string RDDON = "РДД(ОН)";
                /// <summary>РДО(СН)</summary>
                public const string RDOSN = "РДО(СН)";
                /// <summary>РДД(СН)</summary>
                public const string RDDSN = "РДД(СН)";
                /// <summary>РДО(Пром)</summary>
                public const string RDOProm = "РДО(Пром)";
                /// <summary>РДД(Пром)</summary>
                public const string RDDProm = "РДД(Пром)";
                /// <summary>РДО(КС)</summary>
                public const string RDOKS = "РДО(КС)";
                /// <summary>РДД(КС)</summary>
                public const string RDDKS = "РДД(КС)";
            }

        }

        // Направление открывания двери
        public static class DoorOpenSides
        {
            public const string leftSide = "Левое";
            public const string rightSide = "Правое";
        }

        // Все материалы
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

        // Замки для маятниковой двери
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

        // Обрамления окна маятниковой двери
        public static class MDWindowFrames
        {
            public const string rubberFrame = "Резиновое";
            public const string metalFrame = "Металлическое";
            public const string noFrame = "Без окна";
        }

        // Формы окна маятниковой двери
        public static class MDWindowForms
        {
            public const string ellipse200x580 = "Овальное 200х580";
            public const string ellipse300x580 = "Овальное 300х580";
            public const string circle300 = "Круглое 300";
            public const string circle350 = "Круглое 350";
            public const string circle400 = "Круглое 400";
            public const string circle450 = "Круглое 450";
            public const string rectangle300x600 = "Прямоугольное 300х600";
            public const string rectangle400x600 = "Прямоугольное 400х600";
            public const string rectangle500x700 = "Прямоугольное 500х700";
            public const string square400 = "Квадратное 400х400";
            public const string square600 = "Квадратное 600х600";
            public const string square700 = "Квадратное 700х700";
            public const string rhomb200 = "Ромб 200х200";
            public const string rhomb300 = "Ромб 300х300";
        }

        // Типы монорельсов
        public static class MonorelsTypes
        {
            public const string Type1 = "Тип 1";
            public const string Type2 = "Тип 2";
            public const string Type3 = "Тип 3";
        }

        // Толщина холодирьных дверей
        public static class CoolDoorThickness
        {
            /// <summary>80 среднетемпературная</summary>
            public const string M80="80/С";

            /// <summary>80 низкотемпературная</summary>
            public const string L80 = "80/Н";

            /// <summary>100 низкотемпературная</summary>
            public const string L100 = "100/Н";

            /// <summary>120 низкотемпературная</summary>
            public const string L120 = "120/Н";

            /// <summary>150 низкотемпературная</summary>
            public const string L150 = "150/Н";
        }

        // Пороговое исполнение
        public static class StepTypes
        {
            public const string NoStep = "безпороговое";
            public const string WithStep = "пороговое";
        }
        
        // Все классы даерей
        public static class ProductClasses
        {
            /// <summary>Перечень выпускаемой продукции</summary>
            public static string[] ProductTypeList = new string[]
            {
                k1MDType,
                k2MDPstType,
                k3ODType,
                k4RDType
            };


            /// <summary>1. МД(Оф) и МД(Ф) - маятниковая офисная и с фиксацией полотна</summary>
            public const string k1MDType = "1. МД(Оф) и МД(Ф) - маятниковая офисная и с фиксацией полотна";

            /// <summary>2. МД(Пст) - маятниковая пластиковая</summary>
            public const string k2MDPstType = "2. МД(Пст) - маятниковая пластиковая";

            /// <summary>3. ОД(ОН) и ОД(СН) - откатная основного и специального назначения</summary>
            public const string k3ODType = "3. ОД(ОН) и ОД(СН) - откатная основного и специального назначения";

            /// <summary>4. РД(ОН) и РД(СН) - распашная основного и специального назначения</summary>
            public const string k4RDType = "4. РД(ОН) и РД(СН) - распашная основного и специального назначения";
        }

    }

    public enum PropertyTypes
    {
        BoolType,
        StringType,
        IntegerType,
        DateType
    }
}
