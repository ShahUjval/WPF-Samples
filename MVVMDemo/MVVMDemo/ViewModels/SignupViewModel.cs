using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MVVMDemo.ViewModels
{
    public class SignupViewModel
    {
        #region Private Fields

        string[] countryList = { "A", "B", "C", "D" };

        Dictionary<string, List<string>> _stateList = new Dictionary<string, List<string>>();

                #endregion
        #region Initlizer

        public SignupViewModel()
        {
            _stateList.Add("A", new List<string>() { "AA", "AAA", "AAAA" });
            _stateList.Add("B", new List<string>() { "BB", "BBB", "BBBB" });
            _stateList.Add("C", new List<string>() { "CC", "CCC", "CCCC" });
            _stateList.Add("D", new List<string>() { "DD", "DDD", "DDDD" });

            StateNames = new ObservableCollection<string>();

            SelectCountryCommand = new Common.DelegateCommand((obj) => { SelectStateNamesByCountryName(); }, (obj) => { return true; });
        }

        #endregion 

        #region ViewModel Properties

        public string[] CountryNames
        {
            get { return this.countryList; }
        }

        public string SelectedCountryName
        {
            get;
            set;
        }

        public ObservableCollection<string> StateNames { get; set; }

        #endregion

        #region ViewModel Logic

        public void SelectStateNamesByCountryName()
        {

            var stateNames = _stateList[SelectedCountryName];
            StateNames.Clear();

            foreach (string name in stateNames)
            {
                StateNames.Add(name);
            }
        }


        #endregion



        #region ViewModel Command Properties

        public Common.DelegateCommand SelectCountryCommand { get; set; }


        #endregion

    }
}
