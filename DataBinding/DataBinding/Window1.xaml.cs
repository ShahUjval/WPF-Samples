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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DataRepository.EntityModel _modelState;

        public Window1()
        {
            InitializeComponent();
        }

        private void OnEntityGetState_click(object sender, RoutedEventArgs e)
        {
            _modelState = new DataRepository.EntityModel() { State = "Default State"};
            this.DataContext = _modelState;
        }

        private void OnEntitySetState_click(object sender, RoutedEventArgs e)
        {
            _modelState.State = "New State";
            MessageBox.Show(_modelState.State);
        }

        private void OnEntityUpdateState_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_modelState.State);
        }
    }
}
