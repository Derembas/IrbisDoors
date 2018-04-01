using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MDDoors
{
    public class MDDoor : IDoor, INotifyPropertyChanged
    {
        

        #region Основные свойства

        // Тип двери
        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                if(type!=value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public string[] DoorTypes { get; private set; }

        // Ширина двери
        private int width;
        public int Width
        {
            get { return width; }
            set
            {
                if(width!=value)
                {
                    width = value;
                    OnPropertyChanged("Width");
                }
            }
        }

        // Высота двери
        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        // Направление откывания двери
        public string OpenSide { get; set; }
        public string[] OpenSides { get; private set; }

        // Количество дверей
        public  int Count { get; set; }

        #endregion

        // Тип креплния на стену
        public TechDoorWallType WallType { get; private set; }

        #region Опции

        public HandBamperOption HandBamper { get; private set; }
        public FootBamperOption FootBamper { get; private set; }
        public LockOption Lock { get; private set; }

        public IOption[] Options { get; private set; }

        #endregion

        #region Конструктор

        public MDDoor()
        {
            // Основные параметры
            DoorTypes = new string[]
            {
                Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDOOF,
                Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDOFix,
                Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDDOF,
                Helpers.AllNames.AllDoorTypes.MDDoorTypes.MDDFix
            };

            OpenSides = new string[]
            {
                Helpers.AllNames.DoorOpenSides.leftSide,
                Helpers.AllNames.DoorOpenSides.rightSide
            };

            WallType = new TechDoorWallType();

            // Опции
            HandBamper = new HandBamperOption();
            FootBamper = new FootBamperOption();
            Lock = new LockOption();

            Options = new IOption[] {HandBamper, FootBamper, Lock };
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
