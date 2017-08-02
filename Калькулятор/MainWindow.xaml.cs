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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web;

namespace Калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Глобальная переменная
        public FullOrder NewOrder;
        public MainWindow()
        {
            InitializeComponent();
            NewOrder = new FullOrder();
            DataContext = NewOrder;
        }

        private void CnslBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrder.AddDoor();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e) // { EditDoor(NewOrder.SelectedDoor); }
        {
            NewOrder.SelectedDoor.Open();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrder.DelDoor(NewOrder.SelectedDoor);
        }

        private void DonelBtn_Click(object sender, RoutedEventArgs e)
        {

            Report Win1 = new Report();
            Win1.ReportOrder = NewOrder;
            Win1.DataContext = NewOrder;
            Win1.ShowDialog();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
