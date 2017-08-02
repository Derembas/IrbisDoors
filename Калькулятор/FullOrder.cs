using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace Калькулятор
{
    // Класс "Заказ" содержит информацию по всему заказу
    public class FullOrder
    {
        public Door SelectedDoor { get; set; }
        
        public ObservableCollection<Door> Order { get; set; }
        public FullOrder()
        {
            Order = new ObservableCollection<Door>();
        }
        public void DelDoor(Door delDoor) // Функция удаления двери из ззаказа
        {
            Order.Remove(delDoor);
        }

        public void AddDoor()
        {
            SelectWindow SelectDoorToAdd = new SelectWindow();
            Door NewDoor = SelectDoorToAdd.CreateDoor();
            NewDoor.Open();
            Order.Add(NewDoor);
        }

        public void AddDoor(Door Dver)
        {
            Order.Add(Dver);
        }
    }

    // Класс "Дверь" - общий класс для всех дверей
    public class Door
    {
        public string Title
        {
            get { return this.ToString(); }
        }

        // Свойства
        public int Width { get; set; } // Ширина дверного проема. Свойство   
        public int Height { get; set; } // Высота дверного проема. Свойство
        public byte Count { get; set; } // Количество дверей в заказе

        public Door() { }
        public Door(int width, int height, byte count)
        {
            Width = width;
            Height = height;
            Count = count;
        }

        public virtual void Open() { }

        public override string ToString() // Строковое отображение двери
        {
            return string.Format("{0}x{1} - {2} шт.", Width, Height, Count);
        }
    }

   
    // Список всех типов дверей
    public enum DoorTypes{kRDType, kMDType}

    // Список открывания двери
    public enum OpenSide{kLeftSide, kRightSide}

    // Список типов рам маятниковых дверей
    public enum MDRamaTypes { kObchvatType, kPType, kConerType}

    // Список подтипов распашных дверей
    public enum RDSubTypes { kRDO_ON, kRDD_ON, kRDO_SN, kRDD_SN}

    // Список подтипов маятниковой двера
    public enum MDSubTypes{kMDO_ON, kMDD_ON, kMDO_SN, kMDD_SN}

}
