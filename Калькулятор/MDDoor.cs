using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                base.OnPropertyChanged("Title");
            }
        }
        private MDSubTypes subType;// Тип двери. Свойство
        public MDSubTypes SubType
        {
            get { return subType; }
            set
            {
                if(subType!=value)
                {
                    subType = value;
                    if(subType==MDSubTypes.kMDD_ON || subType == MDSubTypes.kMDD_SN) { openSide.Nalich = false; }
                    else { openSide.Nalich = true; }
                }
            }
        }  
       
        // Выпадающие списки
        private string[] AllSubTypes = EnumWork.GetValuesList(typeof(MDSubTypes)).ToArray(); // Варианты под типов двери
        public string[] SubTypes { get { return AllSubTypes; } }

        // Сторона открывания двери
        private DoorOpenDirection openSide=new DoorOpenDirection();
        public DoorOpenDirection OpenSide
        {
            get { return openSide; }
        }

        // Тип рамы
        private MDRamaType rama =new MDRamaType();
        public MDRamaType Rama { get { return rama; } }

        // Стена крепления
        private DoorCrepOpc wall=new DoorCrepOpc();
        public DoorCrepOpc Wall { get { return wall; } }

        // Опции
        private MDOptions options = new MDOptions();
        public MDOptions Options { get { return options; } }

        // Конструктор
        public MDDoor() : base(){
            openSide = new DoorOpenDirection();
            openSide.PropertyChanged += OpenSide_PropertyChanged;
            rama.PropertyChanged += Rama_PropertyChanged;
        }
        
        public MDDoor(MDSubTypes subType, int width, int height, byte count):base(width, height, count)
        {
            SubType = subType;

            // Сторона открывания
            openSide.PropertyChanged += OpenSide_PropertyChanged;
            rama.PropertyChanged += Rama_PropertyChanged;
        }

        

        public override void Open()
        {
            MDWindow NewWindow = new MDWindow();
            NewWindow.DataContext = this;
            NewWindow.ShowDialog();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}{2} - {3} шт.", AllSubTypes[(int)SubType], base.ToString(), OpenSide.Title, Count);
        }

        // Функция вызывается при изменении стороны открывания
        private void OpenSide_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged("Title");
        }
        // Функция вызывается при изменении типа рамы крепления
        private void Rama_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            wall.RamaType = Rama.Type;
        }
    }
}
