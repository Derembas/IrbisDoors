using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.BaseClasses
{
    public class Option : INotifyPropertyChanged
    {
        /// <summary> Включена ли опция в дверь</summary>
        public bool IsIncluded { get; set; }

        /// <summary> Обязательна ли опция для двери</summary>
        public bool IsNecessary { get; private set; }

        /// <summary> Имя опции</summary>
        public string Name { get; private set; }

        /// <summary> Перечень свойств опции</summary>
        protected List<Property> properties { get; private set; }
        public ReadOnlyCollection<Property> Properties { get; private set; }

        public int PropertyCount
        {
            get
            {
                return Properties.Count();
            }
        }

        #region Конструктор

        public Option(string name, bool isNecessary=false)
        {
            IsNecessary = isNecessary;
            Name = name;
            properties = new List<Property>();
            Properties = new ReadOnlyCollection<Property>(properties);
        }

        #endregion

        #region Интерфейс

        public event PropertyChangedEventHandler PropertyChanged;
        // Метод, вызываемый при изменениии свойства
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
