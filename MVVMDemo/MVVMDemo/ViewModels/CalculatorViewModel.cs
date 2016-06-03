using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        #region private members

        private int result;

        #endregion

        #region ViewModel Properties

        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        //public int Result { get; set; }

        public int Result
        {
            get
            {
                return result;
            }

            set
            {
                if(result != value)
                {
                    result = value;
                    OnPropertyChanged("Result");
                }
            }
        }

        #endregion

        #region ViewModel Logic
        public void Add()
            {
                Result = Operand1 + Operand2;
                
            }

        public void Sub()
        {
            Result = Operand1 - Operand2;
            
        }

        #endregion


        #region ViewModel Command Properties

        public Common.DelegateCommand AddCommand { get; set; }
        public Common.DelegateCommand SubCommand { get; set; }

        #endregion


        #region Initilizer

        // Dependency Injection - inject
        public CalculatorViewModel()
        {
            this.AddCommand = new Common.DelegateCommand((obj) => { Add(); }, (obj) => { return true; });  // annonymous method to solve our problem... can't change the method Add() TDD behaviour or test cases 
            this.SubCommand = new Common.DelegateCommand((obj) => { Sub(); }, (obj) => { return true; });
        
        }


        #endregion

    }
}
