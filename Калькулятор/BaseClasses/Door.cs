using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Calculator.BaseClasses
{
    public class Door: INotifyPropertyChanged
    {
        public Option MainProperties { get; protected set; }
        protected ObservableCollection<Option> Options { get; }

        public ICollectionView EnabledOptions { get; private set; }

        public Option SelectedOption { get; set; }
        public int OptionsCount
        {
            get
            {
                return Options.Where(t => t.IsNecessary || t.IsIncluded).Count();
            }
        }

        #region Конструктор

        public Door(Option mainProperties)
        {
            MainProperties = mainProperties;
            Options = new ObservableCollection<Option>();

            var enabledOptions = new CollectionViewSource();
            enabledOptions.Source = Options;
            //enabledOptions.View.SortDescriptions.Add(new SortDescription("IsNecessary", ListSortDirection.Descending));
            enabledOptions.View.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            enabledOptions.View.Filter = OptoinsFilter;
            EnabledOptions = enabledOptions.View;
        }

        #endregion

        // Редактирование списка опций
        private bool OptoinsFilter(object item)
        {
            var customer = item as Option;
            if (customer.IsNecessary) return true;
            return customer.IsIncluded;
        }
        // Редактирование списка не вклюсченных опций
        private bool DisebledOptoinsFilter(object item)
        {
            var customer = item as Option;
            if (customer.IsNecessary) return false;
            return !customer.IsIncluded;
        }

        // Редактирование
        public void Edit()
        {
            var myWindow = new Windows.DoorWindow();
            myWindow.DataContext = this;
            myWindow.ShowDialog();
        }

        #region Интерфейс

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Команды кнопок

        #region Добавление новой опции
        
        private ICommand addNewOptionCommand;

        public ICommand AddNewOptionCommand
        {
            get
            {
                if (addNewOptionCommand == null)
                    addNewOptionCommand = new Helpers.RelayCommand(param => addNewOption(), param=>canAddOption());

                return addNewOptionCommand;
            }
        }
        private bool canAddOption()
        {
            return Options.Where(t => !t.IsNecessary && !t.IsIncluded).Count()>0;
        }
        private void addNewOption()
        {
            var addWindow = new Windows.Door.AddOptionWindow();
            addWindow.Select(Options.Where(t => !t.IsNecessary && !t.IsIncluded));
            EnabledOptions.Refresh();
            OnPropertyChanged("OptionsCount");
        }

        #endregion

        #region Удаление опции

        private ICommand delOptionCommand;
        public ICommand DelOptionCommand
        {
            get
            {
                if (delOptionCommand == null)
                    delOptionCommand = new Helpers.RelayCommand(param => deleteOption(), param=>canDelOption());

                return delOptionCommand;
            }
        }
        private bool canDelOption()
        {
            if (SelectedOption == null) return false;
            if (SelectedOption.IsNecessary) return false;
            return true;
        }
        private void deleteOption()
        {
            SelectedOption.IsIncluded = false;
            EnabledOptions.Refresh();
            OnPropertyChanged("OptionsCount");
        }

        #endregion

        #endregion

    }
}
