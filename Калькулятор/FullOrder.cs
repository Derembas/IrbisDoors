using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Reflection;

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
    public class Door : INotifyPropertyChanged
    {
        public string Title
        {
            get { return this.ToString(); }
        }

        // Свойства
        private int width;
        public int Width // Ширина дверного проема. Свойство   
        {
            get{return width;}
            set{width = value; OnPropertyChanged("Title");}
        }
        private int height;
        public int Height // Высота дверного проема. Свойство
        {
            get { return height; }
            set { height = value; OnPropertyChanged("Title"); }
        }
        private byte count;
        public byte Count // Количество дверей в заказе
        {
            get { return count; }
            set { count = value; OnPropertyChanged("Title"); }
        } 

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
            return string.Format("{0}x{1}", Width, Height);
        }

        public event PropertyChangedEventHandler PropertyChanged; // Событие изменения свойства
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

    // Класс атрибут
    public class StringValueAttribute : System.Attribute
    {

        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }

    // Класс получений значения из Enum
    public static class EnumWork
    {
        // Получение атрибута по энумератору
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            StringValueAttribute[] attributes =
                (StringValueAttribute[])fi.GetCustomAttributes(typeof(StringValueAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Value;
            else
                return value.ToString();
        }

        // Получение Энумератора по его атрибуту
        public static Enum GetVal(Type EnumType, string Value)
        {
            var RetVal = from Enum Val in Enum.GetValues(EnumType)
                         where GetEnumDescription(Val) == Value
                         select Val;

            if (RetVal!=null && RetVal.Any()) { return RetVal.First(); }
            else { return (from Enum Val in Enum.GetValues(EnumType)
                          select Val).First(); }
        }

        // Получение списка возможных значений Энумератора (Атрибутов)
        public static List<string> GetValuesList(Type EnumType)
        {
            List<string> OutArray = new List<string>();
            foreach (Enum Val in Enum.GetValues(EnumType))
            {
                OutArray.Add(GetEnumDescription(Val));
            }
            return OutArray;
        }

        // Получение списка описаний по списку значений
        public static string[] GetMassValues(Enum[] Values)
        {
            string[] OutArray = new string[Values.Length];
            for(int i=0; i<Values.Length; i++)
            {
                OutArray[i] = GetEnumDescription(Values[i]);
            }
            return OutArray;
        }
    }

    // Список всех типов дверей
    public enum DoorTypes{kRDType, kMDType}

    // Список открывания двери
    public enum OpenSidesEnum {
        [StringValue("Левое")]kLeftSide,
        [StringValue("Правое")]kRightSide,
        [StringValue("")]kNone
    }

    // Список типов рам маятниковых дверей
    public enum RamaTypeEnum {
        [StringValue("В обхват")]kObchvatType,
        [StringValue("П-образная")]kPType,
        [StringValue("Угловая")]kConerType
    }

    // Список возможных материалов
    public enum MaterialsEnum
    {
        [StringValue("Пластик плоский")]kFlatPlast,
        [StringValue("Пластик формованный")]kFormedPlast,
        [StringValue("AISI 304")]kAISI304,
        [StringValue("AISI 430")]kAISI430,
        [StringValue("Рифл. Ал.")]kRifAl
    }

    // Список типов стен
    public enum WallTypeEnum
    {
        [StringValue("сэндвич-панель")]kSendPenel,
        [StringValue("гипсокартон")]kGipsBoard,
        [StringValue("пустотелый кирпич")]kEmptyBrick,
        [StringValue("газосиликатный блок")]kGasBlock,
        [StringValue("металлоконструкция")]kMetallDesign,
        [StringValue("бетон")]kConcrete,
        [StringValue("полнотелый кирпич")]kFullBrick,
        [StringValue("сэндвич-панель + металлоконструкция")]kSenPan_Metall
    }

    // Список подтипов распашных дверей
    public enum RDSubTypes {kRDO_ON, kRDD_ON, kRDO_SN, kRDD_SN}

    // Список подтипов маятниковой двера
    public enum MDSubTypes {
        [StringValue("МДО (ОН)")] kMDO_ON,
        [StringValue("МДД (ОН)")] kMDD_ON,
        [StringValue("МДО (СН)")] kMDO_SN,
        [StringValue("МДД (СН)")] kMDD_SN 
}
}
