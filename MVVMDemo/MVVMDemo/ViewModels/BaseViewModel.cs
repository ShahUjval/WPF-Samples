using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace MVVMDemo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    
            public event PropertyChangedEventHandler PropertyChanged;
}
}
