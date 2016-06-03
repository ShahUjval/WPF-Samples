using DataBinding.DataRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    public class CustomerRepo
    {
        ObservableCollection<Customer> _customerList = null;

        public CustomerRepo()
        {
            _customerList = new ObservableCollection<Customer>();
            NewCustomer = new Customer();
        }

        public Customer NewCustomer { get; set; }

        public ObservableCollection<Customer> CustomersList
        {
            get { return _customerList; }
            set { _customerList = value; }
        }

        public void AddNewCustomer()
        {
            Customer _temp = new Customer
            {
                FirstName = NewCustomer.FirstName,
                MiddleName = NewCustomer.MiddleName,
                LastName = NewCustomer.LastName
            };

            CustomersList.Add(_temp);
        }

    }
}
