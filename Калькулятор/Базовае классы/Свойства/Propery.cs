using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    ///<summary>
    ///Базовый класс для свойств
    /// </summary> 
    public class Property : INotifyPropertyChanged
    {

        #region Свойства

        /// <summary>Доступность редактирования</summary>
        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if(isEnabled!=value)
                {
                    isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }

        /// <summary>Имя свойства</summary>
        public string Name { get; private set; }

        private object _value;
        /// <summary>Значение</summary>
        public object Value
        {
            get { return _value; }
            set
            {
                if(value.GetType() == type && Convert.ChangeType(_value, type)!= Convert.ChangeType(value, type))
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        private object[] values;
        /// <summary>Список значений</summary>
        public object[] Values
        {
            get { return values; }
            protected set
            {
                if(values!=value)
                {
                    values = value;
                    OnPropertyChanged("Values");
                    if (values != null && !values.Contains(Value))
                        Value = values.First();
                }
            }
        }

        /// <summary>Тип значения</summary>
        public Type type { get; private set; }

        #endregion

        #region Конструктор

        public Property(string _name, object[] _values)
        {
            Name = _name;
            Values = _values;
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
