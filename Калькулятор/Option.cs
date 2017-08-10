using System;
using System.Collections;
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
        private bool nalich; // Наличие опции
        public bool Nalich
        {
            get { return nalich; }
            set
            {
                if(nalich!=value)
                {
                    nalich = value;
                    OnPropertyChanged("Nalich");
                }
            }
        } 

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
                OpenSide = (OptionValueEnum)EnumWork.GetVal(typeof(OptionValueEnum), value);
            }
        }


        private OptionValueEnum openSide; // Выбранное открывание
        public OptionValueEnum OpenSide
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
        private string[] openSides= EnumWork.GetMassValues(new Enum[] { OptionValueEnum.kOpenLeft, OptionValueEnum.kOpenRight }); //В случае, когда дверь одностворчатая 
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
            OpenSide = OptionValueEnum.kOpenLeft;
        }

        public override string ToString()
        {
            if (Nalich)
            {
                switch (OpenSide)
                {
                    case OptionValueEnum.kOpenLeft:
                        return "-Лв";
                    case OptionValueEnum.kOpenRight:
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
        private OptionValueEnum type;
        public OptionValueEnum Type
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
                Type = (OptionValueEnum)EnumWork.GetVal(typeof(OptionValueEnum), value);
            }
        }

        // Список возможных значений
        private string[] allTypes = EnumWork.GetMassValues(new Enum[] 
                        { OptionValueEnum.kMDRamaObchvatType,
                            OptionValueEnum.kMDRamaConerType,
                            OptionValueEnum.kMDRamaPType }); // Варианты под типов двери
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
        private OptionValueEnum ramaType;
        public OptionValueEnum RamaType
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
        private OptionValueEnum wallType;
        public OptionValueEnum WallType
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
                WallType = (OptionValueEnum)EnumWork.GetVal(typeof(OptionValueEnum), value);
            }
        }

        // Список возможных значений
        private string[] allObchvatTypes = EnumWork.GetMassValues(new Enum[]
            { OptionValueEnum.kWallSendPenel, OptionValueEnum.kWallGipsBoard, OptionValueEnum.kWallEmptyBrick, OptionValueEnum.kWallGasBlock,
            OptionValueEnum.kWallMetallDesign, OptionValueEnum.kWallConcrete, OptionValueEnum.kWallFullBrick, OptionValueEnum.kWallSenPan_Metall}); // Варианты стены для рамы в обхват
        private string[] allCornerTypes = EnumWork.GetMassValues(new Enum[] 
            { OptionValueEnum.kWallEmptyBrick, OptionValueEnum.kWallMetallDesign, OptionValueEnum.kWallConcrete, OptionValueEnum.kWallFullBrick}); // Варианты стены для угловой рамы
        private string[] allPRamaTypes = EnumWork.GetMassValues(new Enum[]
            { OptionValueEnum.kWallMetallDesign, OptionValueEnum.kWallConcrete, OptionValueEnum.kWallFullBrick, OptionValueEnum.kWallSenPan_Metall }); // Варианты стены для П-образной рамы

        // Вывод списка
        public string[] AllWallTypes
        {
            get
            {
                switch(RamaType)
                {
                    case OptionValueEnum.kMDRamaObchvatType:
                        return allObchvatTypes;
                    case OptionValueEnum.kMDRamaConerType:
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

    // Опция бампер
    class BampOpt : Option
    {
        public BampOpt(string _name) : base(_name) {}

        // Материал бампера
        private OptionValueEnum material;
        public OptionValueEnum Material
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
            set { Material = (OptionValueEnum)EnumWork.GetVal(typeof(OptionValueEnum), value);}
        }

        // Варианты материалов
        private string[] allMaterials= EnumWork.GetMassValues(new Enum[]
            { OptionValueEnum.kMaterFormedPlast, OptionValueEnum.kMaterFlatPlast, OptionValueEnum.kMaterAISI304, OptionValueEnum.kMaterAISI430, OptionValueEnum.kMaterRifAl }); // Варианты стены для угловой рамы

        public string[] AllMaterials { get { return allMaterials; } }

        public int Height { get; set; } // Высота бампера
    }

    // Опция порог
    class PorogOpt: Option
    {
        public PorogOpt(string _name) : base(_name)
        {
        }

        public string Mater { get; set; } // Материал порога
        public string Type { get; set; } // Тип порога
    }

    // Опция окно для МД
    class MDWindowOpt : Option
    {
        // Конструктор
        public MDWindowOpt(string _name) : base(_name) {}

        // Обраление окна
        private OptionValueEnum obramlen;
        public OptionValueEnum Obramlen
        {
            get { return obramlen; }
            set
            {
                if (obramlen != value)
                {
                    obramlen = value;
                    base.OnPropertyChanged("ObramlenName");
                    base.OnPropertyChanged("WinForms");
                    base.OnPropertyChanged("FormEnabled");
                    if (!WinForms.Contains(WinFormName)) { WinFormName = WinForms[0]; }
                }
            }
        }

        //Варианты обрамления
        private string[] obramlenTypes = EnumWork.GetMassValues(new Enum[] {
            OptionValueEnum.kWinObrRezina,
            OptionValueEnum.kWinObrMetall,
            OptionValueEnum.kWinObrNone});
        public string[] ObramlenTypes { get { return obramlenTypes; } }

        // Текстовое представления выбранного обрамления
        public string ObramlenName
        {
            get { return EnumWork.GetEnumDescription(Obramlen); }
            set { Obramlen = (OptionValueEnum)EnumWork.GetVal(typeof(OptionValueEnum), value); }
        }

        // Форма окна
        private OptionValueEnum windowForm;
        public OptionValueEnum WindowForm
        {
            get { return windowForm; }
            set
            {
                if (windowForm != value)
                {
                    windowForm = value;
                    base.OnPropertyChanged("ObramlenName");
                    base.OnPropertyChanged("WinSizeValues");
                    if (!WinSizeValues.Contains(WinSize)) { WinSize = WinSizeValues[0]; }
                }
            }
        }

        // Варианты возможных форм окна
        private string[] winFormTypes1 = EnumWork.GetMassValues(new Enum[]
        {
            OptionValueEnum.kWinFormOval,
            OptionValueEnum.kWinFormCircule,
            OptionValueEnum.kWinFormRectang,
            OptionValueEnum.kWinFormSquare
        });
        private string[] winFormTypes2 = EnumWork.GetMassValues(new Enum[]
        {
            OptionValueEnum.kWinFormRectang,
            OptionValueEnum.kWinFormSquare,
            OptionValueEnum.kWinFormRomb
        });

        // Вывод списка значений
        public string[] WinForms
        { get
            {
                switch (Obramlen)
                {
                    case OptionValueEnum.kWinObrMetall:
                        return winFormTypes2;
                    default:
                        return winFormTypes1;
                }
            }
        }

        // Текстовое представления выбранного обрамления
        public string WinFormName
        {
            get { return EnumWork.GetEnumDescription(WindowForm); }
            set { WindowForm = (OptionValueEnum)EnumWork.GetVal(typeof(OptionValueEnum), value); }
        }
        
        // Доступность формы
        public bool FormEnabled
        {
            get
            {
                if (Obramlen == OptionValueEnum.kWinObrNone) { return false; }
                else { return Nalich; }
            }
        }

        // Размеры окна
        private string winSize;
        public string WinSize
        {
            get { return winSize; }
            set
            {
                if(winSize!=value)
                {
                    winSize = value;
                }
            }
        }

        // Варианты достыпных размеров
        private string[] winSizeValues1 = new string[] { "300x580" };
        private string[] winSizeValues2 = new string[] { "200x580", "300x580" }; // Овальное окно
        private string[] winSizeValues3 = new string[] { "300", "350", "400", "450" }; // Круглое окно
        private string[] winSizeValues4 = new string[] { "400x600", "500x700" }; // Прямоугольное окно
        private string[] winSizeValues5 = new string[] { "300x600", "400x600", "500x700" }; // Прямоугольное окно
        private string[] winSizeValues6 = new string[] { "400x400", "700x700"}; // Квадратное окно
        private string[] winSizeValues7 = new string[] { "400x400", "600x600", "700x700" }; //Квадратное окно
        private string[] winSizeValues8 = new string[] { "200x200", "300x300" }; // Окно Ромб

        // Вывод списка размеров
        public string[] WinSizeValues
        {
            get
            {
                switch (WindowForm)
                {
                    case OptionValueEnum.kWinFormOval:
                        return winSizeValues2;
                    case OptionValueEnum.kWinFormCircule:
                        return winSizeValues3;
                    case OptionValueEnum.kWinFormRectang:
                        if (Obramlen == OptionValueEnum.kWinObrMetall) { return winSizeValues5; }
                        else { return winSizeValues4; }
                    case OptionValueEnum.kWinFormSquare:
                        if (Obramlen == OptionValueEnum.kWinObrMetall) { return winSizeValues7; }
                        else { return winSizeValues6; }
                    default:
                        return winSizeValues8;
                }
            }
        }
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
        public Option[] options; //
    }

    // Класс списка опций для маятеиковой двери
    class MDOptions: IEnumerable
    {
        // Бампер для рук
        private BampOpt handBamper = new BampOpt("Бампер для рук");
        public BampOpt HandBamper { get { return handBamper; } }

        // Бампер для ног
        private BampOpt footBamper = new BampOpt("Бампер для ног");
        public BampOpt FootBamper { get { return footBamper; } }

        // Не стандартное окно
        private MDWindowOpt window = new MDWindowOpt("Не стандартное окно");
        public MDWindowOpt Window { get { return window; } }

        private Option[] MyOptions = new Option[3];

        public MDOptions()
        {
            MyOptions[0] = handBamper;
            MyOptions[1] = footBamper;
            MyOptions[2] = window;
        }
        

        public IEnumerator GetEnumerator()
        {
            return MyOptions.GetEnumerator();
        }
    }
}
