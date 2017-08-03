using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калькулятор
{
    class MDDoor: Door
    {
        // Свойства
        public string SubTypeName
        {
            get{return EnumWork.GetEnumDescription(SubType); }
            set
            {
                SubType = (MDSubTypes)EnumWork.GetVal(typeof(MDSubTypes), value);

                if ((SubType==MDSubTypes.kMDD_ON || SubType==MDSubTypes.kMDD_SN )&& OpenSide!= OpenSides.kNone) { OpenSide = OpenSides.kNone; }
                else if ((SubType==MDSubTypes.kMDO_ON || SubType==MDSubTypes.kMDO_SN) && OpenSide == OpenSides.kNone) { OpenSide = OpenSides.kLeftSide; }
                base.OnPropertyChanged("OpenSides");
                base.OnPropertyChanged("OpenSideName");
                base.OnPropertyChanged("Title");
            }
        }
        public MDSubTypes SubType { get; set; }  // Тип двери. Свойство

        public string OpenSideName
        {
            get { return EnumWork.GetEnumDescription(OpenSide); }
            set
            {
                OpenSide = (OpenSides)EnumWork.GetVal(typeof(OpenSides), value);
                base.OnPropertyChanged("Title");
            }
        }
        public OpenSides OpenSide { get; set; } // Сторона открывания

        // Выпадающие списки
        private string[] AllSubTypes = EnumWork.GetValuesList(typeof(MDSubTypes)).ToArray(); // Варианты под типов двери
        public string[] SubTypes { get { return AllSubTypes; } } 

        // Сторона открывания
        private string[] OpenSidesCase1=new string[] {EnumWork.GetEnumDescription(OpenSides.kLeftSide), EnumWork.GetEnumDescription(OpenSides.kRightSide) }; //В случае, когда дверь одностворчатая
        private string[] OpenSidesCase2=new string[] { EnumWork.GetEnumDescription(OpenSides.kNone) }; // В случае, когда дверь двухстворчатая
        public string[] openSides
        {
            get
            {
                if (SubType == MDSubTypes.kMDO_ON || SubType == MDSubTypes.kMDO_SN)
                    return OpenSidesCase1;
                else
                    return OpenSidesCase2;
            }
        }

        // Конструктор
        public MDDoor() : base() { }

        public MDDoor(MDSubTypes subType, int width, int height, byte count):base(width, height, count)
        {
            SubType = subType;
        }

        public override void Open()
        {
            MDWindow NewWindow = new MDWindow();
            NewWindow.DataContext = this;
            NewWindow.ShowDialog();
        }

        public override string ToString()
        {
            switch(OpenSide)
            {
                case OpenSides.kRightSide:
                    return string.Format("{0} - {1}-Пр", AllSubTypes[(int)SubType], base.ToString());
                case OpenSides.kLeftSide:
                    return string.Format("{0} - {1}-Лв", AllSubTypes[(int)SubType], base.ToString());
                default:
                    return string.Format("{0} - {1}", AllSubTypes[(int)SubType], base.ToString());
            }
        }
    }
}
