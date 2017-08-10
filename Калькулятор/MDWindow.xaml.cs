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
    /// Логика взаимодействия для MDWindow.xaml
    /// </summary>
    public partial class MDWindow : Window
    {
        public MDWindow()
        {
            InitializeComponent();
            // Регистрация события выделения текстового блока
            EventManager.RegisterClassHandler(typeof(TextBox),
                                  UIElement.PreviewMouseLeftButtonDownEvent,
                                  new MouseButtonEventHandler(StopTextBoxClick),
                                  true);
            EventManager.RegisterClassHandler(typeof(TextBox),
                                  UIElement.GotFocusEvent,
                                  new RoutedEventHandler(text_GotFocus),
                                  true);
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        // Методы остановки выделения на текстовых блоках
        private void text_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text != null) text.SelectAll();
        }
        private void StopTextBoxClick(object sender, MouseButtonEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text != null && !text.IsKeyboardFocusWithin)
            {
                e.Handled = true;
                text.Focus();
            }
        }

        private void OptionSelect_Selected(object sender, RoutedEventArgs e)
        {
            ListBox MyLB = (ListBox)sender;
            if (MyLB != null && presenter != null)
                presenter.Content = MyLB.SelectedValue;
        }

        private void OptionSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox MyLB = (ListBox)sender;
            if (MyLB != null && presenter != null)
                presenter.Content = MyLB.SelectedValue;
        }
    }

    public class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //получаем вызывающий контейнер
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                Type ItemType = item.GetType();

                if (ItemType == typeof(BampOpt)) { return element.FindResource("BamperTemplate") as DataTemplate; }
                else if (ItemType == typeof(MDWindowOpt)) { return element.FindResource("WindowTemplate") as DataTemplate; }
                else { return null; }
            }
            return null;
        }
    }
}
