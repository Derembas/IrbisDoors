using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    // Класс "Заказ" содержит информацию по всему заказу
    public class Order
    {
        public IDoor SelectedDoor { get; set; }
        
        public ObservableCollection<BaseClasses.Door> Doors { get; set; }
        public Order()
        {
            Doors = new ObservableCollection<BaseClasses.Door>();
        }

        #region Команды

        #region Добавление новой двери

        private ICommand addNewDoorCommand;

        public ICommand AddNewDoorCommand
        {
            get
            {
                if (addNewDoorCommand == null)
                    addNewDoorCommand = new Helpers.RelayCommand(param => AddNewDoor());

                return addNewDoorCommand;
            }
        }

        private void AddNewDoor()
        {
            var curSelectWindow = new SelectWindow();
            var typeToAdd= curSelectWindow.SelectProductType();
            switch (typeToAdd)
            {
                case Helpers.AllNames.ProductTypes.k1MDType:
                    var doorToAdd = new ViewModels.MDDoors.MDDoor();
                    doorToAdd.Edit();
                    Doors.Add(doorToAdd);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #endregion
    }
}
