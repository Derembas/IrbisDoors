using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        private bool okPressed; // Флаг, была ли нажата кнопка применить

        public SelectWindow()
        {
            InitializeComponent();

            ProductList = Helpers.AllNames.ProductClasses.ProductTypeList;
            DataContext = this;
        }

        // Выбранные тип продукта
        public string SelectedProduct { get; set; }

        // Список всех возможных продуктов
        public string[] ProductList { get; private set; }

        // Выбор нового оборудования
        public string SelectProductType()
        {
            okPressed = false;
            ShowDialog();
            if (okPressed)
                return SelectedProduct;
            else
                return null;
        }

        // Команда принятия решения
        private ICommand okPressCommand;
        public ICommand OkPressCommand
        {
            get
            {
                if (okPressCommand == null)
                    okPressCommand = new Helpers.RelayCommand(param => OkPress(), param=> CanPressOk());

                return okPressCommand;
            }
        }

        private bool CanPressOk()
        {
            return SelectedProduct != null;
        }

        private void OkPress()
        {
            okPressed = true;
            Close();
        }

    }
}
