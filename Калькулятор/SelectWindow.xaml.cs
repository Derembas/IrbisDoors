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

namespace Калькулятор
{
    /// <summary>
    /// Логика взаимодействия для SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        private DoorTypes selectedType;

        public SelectWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Процедура нажатия на кнопку выбор
        {
            if (DoorType.SelectedIndex == -1) { MessageBox.Show("Выбирите знечение"); }
            else
            {
                selectedType = (DoorTypes) DoorType.SelectedIndex;
                this.Hide();
            }
        }

        public Door CreateDoor()
        {
            this.ShowDialog();
            Door OutDoor = null;
            switch (selectedType)
            {
                case DoorTypes.kRDType:
                    OutDoor = new RDDoor();
                    break;
                case DoorTypes.kMDType:
                    OutDoor = new MDDoor();
                    break;
            }
            return OutDoor;
        }
    }
}
