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
    /// Interaction logic for CollectionViewDemo.xaml
    /// </summary>
    public partial class CollectionViewDemo : Window
    {
        CustomerRepo _repo = new CustomerRepo();

        public CollectionViewDemo()
        {
            InitializeComponent();
            this.DataContext = _repo;
        }

        private void OnNewAddEmp_Click(object sender, RoutedEventArgs e)
        {
            _repo.AddNewCustomer();
        }
    }
}
