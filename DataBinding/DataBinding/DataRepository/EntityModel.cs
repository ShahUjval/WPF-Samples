using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding.DataRepository
{
    class EntityModel : System.ComponentModel.INotifyPropertyChanged
    {
        string _state;

        int intState;

        public int IntState
        {
            get { return intState; }
            set { intState = value; }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged; 

        void OnPropertyChanged(string propertyname)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
