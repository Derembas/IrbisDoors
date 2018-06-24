using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.BaseClasses
{
    ///<summary>
    ///Базовый класс для свойств
    /// </summary> 
    public class Property : INotifyPropertyChanged
    {

        private object defultValue;

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
                if(MyType== Helpers.PropertyTypes.IntegerType) setNewValue<int?>(value, _value); 
                else if(MyType== Helpers.PropertyTypes.BoolType) setNewValue<bool?>(value, _value);
                else if(MyType== Helpers.PropertyTypes.DateType) setNewValue<DateTime?>(value, _value);
                else if (MyType == Helpers.PropertyTypes.StringType) setNewValue<string>(value, _value);
            }
        }

        // Преобразование Object к типу значения
        private void setNewValue<T>(object newValue, object oldValue)
        {
            if (newValue == null) return;

            object outValue;
            if (newValue is T) outValue = newValue;
            else
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    if (!converter.IsValid(newValue)) return;
                    outValue = converter.ConvertFrom(newValue);
                }
                else
                    return;
            }
            if (((T)outValue).Equals((T)oldValue)) return;

            _value = outValue;
            OnPropertyChanged("Value");
        }

        private object[] values;
        /// <summary>Список значений</summary>
        public object[] Values
        {
            get { return values; }
            set
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

        private bool useValueList;
        /// <summary>Использовать список значений</summary>
        public bool UseValueList
        {
            get { return useValueList; }
            set
            {
                if(useValueList!=value)
                {
                    useValueList = value;
                    OnPropertyChanged("UseValueList");
                }
            }
        }


        /// <summary>Тип значения</summary>
        public Helpers.PropertyTypes MyType { get; private set; }

        #endregion

        #region Конструктор

        public Property(string _name, Helpers.PropertyTypes valueType, bool _useValueList=false, object defVal=null)
        {
            isEnabled = true;
            Name = _name;
            MyType = valueType;
            useValueList = _useValueList;
            _value = defVal;
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
