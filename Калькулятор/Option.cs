using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Калькулятор
{
    // Базовый класс опций
    class Option: INotifyPropertyChanged
    {
        // Свойства
        public bool Nalich { get; set; } // Наличие опции

        private string name;
        public string Name { get { return name; } } // Имя опции

        public double Price { get; set; } // Стоимость

        // Конструктор
        public Option(string _name)
        {
            Nalich = false;
            name=_name;
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Метод, вызываемый при изменениии свойства
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }


    //// Класс, реализующий INotifyPropertyChanged
    //public class OpReal : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //} // Может потом пригодиться


    // Опция направление открывания двери
    public class DoorOpenDirection: INotifyPropertyChanged
    {
        public string Title
        {
            get { return this.ToString(); }
        }

        private bool nalich; // Определяет, активна ли опция
        public bool Nalich
        {
            get { return nalich; }
            set
            {
                if (nalich != value)
                {
                    nalich = value;
                    //if (!nalich) { OpenSide = OpenSidesEnum.kNone; }
                    //else { OpenSide = OpenSidesEnum.kLeftSide; }
                    this.OnPropertyChanged("Nalich");
                    this.OnPropertyChanged("OpenSideName");
                }
            }
        }

        public string OpenSideName // Строковое представление выбранного направления
        {
            get
            {
                if (Nalich) { return EnumWork.GetEnumDescription(OpenSide); }
                else { return ""; }
            }
            set
            {
                OpenSide = (OpenSidesEnum)EnumWork.GetVal(typeof(OpenSidesEnum), value);
            }
        }


        private OpenSidesEnum openSide; // Выбранное открывание
        public OpenSidesEnum OpenSide
        {
            get { return openSide; }
            set
            {
                if (openSide != value)
                {
                    openSide = value;
                    this.OnPropertyChanged("OpenSideName");
                }
            }
        }

        // Список возможных вариантов
        private string[] openSides=new string[] { EnumWork.GetEnumDescription(OpenSidesEnum.kLeftSide), EnumWork.GetEnumDescription(OpenSidesEnum.kRightSide) }; //В случае, когда дверь одностворчатая 
        public string[] OpenSides
        {
            get
            {
                return openSides;
                //if (Nalich) { return openSides; }
                //else { return null; }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Метод, вызываемый при изменениии свойства
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        // Конструктор
        public DoorOpenDirection()
        {
            Nalich = true;
            OpenSide = OpenSidesEnum.kLeftSide;
        }

        public override string ToString()
        {
            if (Nalich)
            {
                switch (OpenSide)
                {
                    case OpenSidesEnum.kLeftSide:
                        return "-Лв";
                    case OpenSidesEnum.kRightSide:
                        return "-Пр";
                    default: return "";
                }
            }
            else { return ""; }
        }
    }

    // Опция тип рамы для маятниковой двери
    public class MDRamaType: INotifyPropertyChanged
    {
        // Тип рамы
        private RamaTypeEnum type;
        public RamaTypeEnum Type
        {
            get { return type; }
            set
            {
                if(type!=value)
                {
                    type = value;
                    this.OnPropertyChanged("TypeName");
                }
            }
        }

        // Строковое представление типа рамы
        public string TypeName
        {
            get { return EnumWork.GetEnumDescription(Type);}
            set
            {
                Type = (RamaTypeEnum)EnumWork.GetVal(typeof(RamaTypeEnum), value);
            }
        }

        // Список возможных значений
        private string[] allTypes = EnumWork.GetValuesList(typeof(RamaTypeEnum)).ToArray(); // Варианты под типов двери
        public string[] AllTypes { get { return allTypes; } }

        // Конструктор
        //public MDRamaType() { type = RamaTypeEnum.kObchvatType; }

        public event PropertyChangedEventHandler PropertyChanged;
        // Метод, вызываемый при изменениии свойства
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    // Опция крепления двери
    public class DoorCrepOpc : INotifyPropertyChanged
    {
        // Вариант рамы, для которой подбирается крепёж
        private RamaTypeEnum ramaType;
        public RamaTypeEnum RamaType
        {
            get { return ramaType; }
            set
            {
                if(ramaType!=value)
                {
                    ramaType = value;
                    OnPropertyChanged("AllWallTypes");
                    if (!AllWallTypes.Contains(WallTypeName)) { WallTypeName = AllWallTypes[0]; }
                }
            }
        }

        // Стена крепления двери
        private WallTypeEnum wallType;
        public WallTypeEnum WallType
        {
            get { return wallType; }
            set
            {
                if( wallType!=value)
                {
                    wallType = value;
                    this.OnPropertyChanged("WallTypeName");
                }
            }
        }

        // Текстовое отображение типа стены
        public string WallTypeName
        {
            get { return EnumWork.GetEnumDescription(WallType); }
            set
            {
                WallType = (WallTypeEnum)EnumWork.GetVal(typeof(WallTypeEnum), value);
            }
        }

        // Список возможных значений
        private string[] allObchvatTypes = EnumWork.GetValuesList(typeof(WallTypeEnum)).ToArray(); // Варианты стены для рамы в обхват
        private string[] allCornerTypes = EnumWork.GetMassValues(new Enum[] 
            { WallTypeEnum.kEmptyBrick, WallTypeEnum.kMetallDesign, WallTypeEnum.kConcrete, WallTypeEnum.kFullBrick }); // Варианты стены для угловой рамы
        private string[] allPRamaTypes = EnumWork.GetMassValues(new Enum[]
            { WallTypeEnum.kMetallDesign, WallTypeEnum.kConcrete, WallTypeEnum.kFullBrick, WallTypeEnum.kSenPan_Metall }); // Варианты стены для П-образной рамы

        // Вывод списка
        public string[] AllWallTypes
        {
            get
            {
                switch(RamaType)
                {
                    case RamaTypeEnum.kObchvatType:
                        return allObchvatTypes;
                    case RamaTypeEnum.kConerType:
                        return allCornerTypes;
                    default:
                        return allPRamaTypes;
                }
            }
        }

        // Толщина стены крепления
        public int WallWidth { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        // Метод, вызываемый при изменениии свойства
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }


    // Базовый класс для простых опций
    //public class SimpleOption<T> where T : struct, IConvertible, IComparable, IFormattable
    //{
    //    // Значение опции
    //    private T _value;
    //    public T Value
    //    {
    //        get { return _value; }
    //        set
    //        {
    //            if (_value != value)
    //            {
    //                _value = value;
    //            }
    //        }
    //    }

    //    private string valueName;
    //    public string ValueName
    //    {
    //        get { return EnumWork.GetEnumDescription(Value); }
    //        set { Value = (T)EnumWork.GetVal(typeof(T), value); }
    //    }
    //}


    // Опция бампер
    class BampOpc : Option
    {
        public BampOpc(string _name) : base(_name)
        {
        }
        
        // Материал бампера
        private MaterialsEnum material;
        public MaterialsEnum Material
        {
            get { return material; }
            set
            {
                if(material!=value)
                {
                    material = value;
                    base.OnPropertyChanged("MaterialName");
                }
            }
        }

        // Текстовое отображение материала
        public string MaterialName
        {
            get { return EnumWork.GetEnumDescription(Material);}
            set { Material = (MaterialsEnum)EnumWork.GetVal(typeof(MaterialsEnum), value);}
        }

        // Варианты материалов
        private string[] allMaterials= EnumWork.GetMassValues(new Enum[]
            { MaterialsEnum.kFormedPlast, MaterialsEnum.kFlatPlast, MaterialsEnum.kAISI304, MaterialsEnum.kAISI430, MaterialsEnum.kRifAl }); // Варианты стены для угловой рамы

        public string[] AllMaterials { get { return allMaterials; } }

        public int Height { get; set; } // Высота бампера
    }

    // Опция порог
    class PorogOpc: Option
    {
        public PorogOpc(string _name) : base(_name)
        {
        }

        public string Mater { get; set; } // Материал порога
        public string Type { get; set; } // Тип порога
    }

    // Опция материал
    class MaterOpc: Option
    {
        public MaterOpc(string _name) : base(_name)
        {
        }

        public string Mater { get; set; }
        public string Color { get; set; }
    }

    // Класс список опций
    class Options
    {
        private List<Option> options; //
    }
}
