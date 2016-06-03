using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Common
{
    // OCP 
    // Independent of View Model
    // one command class for entire View Model

    public class DelegateCommand : ICommand
    {
        // Command Validation - you want to check
        //Command Parameter


        Func<object, bool> _canExecuteAddress;
        Action<object> _executeAddress;

        public DelegateCommand(Action<object> _executeAddress , Func<object,bool> _canExecuteAddress)
        {
            this._canExecuteAddress = _canExecuteAddress;
            this._executeAddress = _executeAddress;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAddress.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
           _executeAddress.Invoke(parameter);
        }
    }
}
