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
        public BaseClasses.Door SelectedDoor { get; set; }
        
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
            BaseClasses.Door doorToAdd=null;
            switch (typeToAdd)
            {
                case Helpers.AllNames.ProductClasses.k1MDType:
                    doorToAdd = new ViewModels.MDDoors.MDDoor();
                    break;
                case Helpers.AllNames.ProductClasses.k4RDType:
                    doorToAdd = new ViewModels.RDDoors.RDDoor();
                    break;
                default:
                    break;
            }

            if (doorToAdd != null)
            {
                doorToAdd.Edit();
                Doors.Add(doorToAdd);
            }
        }

        #endregion

        #region Правка выбранной двери

        private ICommand editDoorCommand;

        public ICommand EditDoorCommand
        {
            get
            {
                if (editDoorCommand == null)
                    editDoorCommand = new Helpers.RelayCommand(param => EditDoor(), param=> { return SelectedDoor != null; });

                return editDoorCommand;
            }
        }
        private void EditDoor()
        {
            SelectedDoor.Edit();
        }


        #endregion

        #region Удаление выбранной двери

        private ICommand deleteDoorCommand;

        public ICommand DeleteDoorCommand
        {
            get
            {
                if (deleteDoorCommand == null)
                    deleteDoorCommand = new Helpers.RelayCommand(param => AddNewDoor(), param=> { return SelectedDoor != null; });

                return deleteDoorCommand;
            }
        }
        private void DeleteDoor()
        {
            Doors.Remove(SelectedDoor);
        }

        #endregion

        #endregion
    }
}
