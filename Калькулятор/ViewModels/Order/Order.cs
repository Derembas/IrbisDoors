using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace Calculator
{
    // Класс "Заказ" содержит информацию по всему заказу
    public class Order
    {
        public IDoor SelectedDoor { get; set; }
        
        public ObservableCollection<IDoor> Doors { get; set; }
        public Order()
        {
            Doors = new ObservableCollection<IDoor>();
        }

        #region Команды

        #region Добавление новой двери



        #endregion

        #endregion
    }
}
