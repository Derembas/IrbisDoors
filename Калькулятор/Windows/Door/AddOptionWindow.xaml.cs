using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Calculator.Windows.Door
{
    /// <summary>
    /// Логика взаимодействия для AddOptionWindow.xaml
    /// </summary>
    public partial class AddOptionWindow : Window
    {
        public AddOptionWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public IEnumerable<BaseClasses.Option> Options { get; private set; }

        public void Select(IEnumerable<BaseClasses.Option> options)
        {
            Options = options;
            ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var curItem in OptionList.SelectedItems)
            {
                var curOption = curItem as BaseClasses.Option;
                if(curOption!=null)
                    curOption.IsIncluded = true;
            }

            Close();
        }
    }
}
