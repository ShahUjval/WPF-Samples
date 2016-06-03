using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMPrototype
{
    #region Model
    public class ItemRepository
    {
        List<ItemModel> _itemList = new List<ItemModel>();

        public void AddNewItem(ItemModel newItem)
        {
            _itemList.Add(newItem);
        }
        
        public ItemModel GetItemByType(string itemType)
        {
            ItemModel _temp = _itemList.FirstOrDefault(item => item.ItemType == itemType);
            return _temp;
        }
    }

    public class ItemModel
    {
        public string ItemName {get;set;}
        public string ItemType {get;set;}
        public decimal ItemCost {get; set;}
    }
    #endregion

    //#region View
    
    //public class Button : System.Windows.Controls.Button
    //{
    //    public event System.Windows.RoutedEventHandler Click;

    //    protected override void OnClick()
    //    {
    //        if(Click!= null)
    //        {
    //            Click.Invoke(this, new RoutedEventArgs());
    //        }

    //        //Hooking

    //        if(Command != null)
    //        {
    //            Command.Execute();
    //        }
    //    }

    //    public static DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(Button));

    //    public ICommand Command
    //    {
    //        get
    //        {
    //            return GetValue(CommandProperty) as ICommand;
    //        }
    //        set
    //        {
    //            SetValue(CommandProperty, value);
    //        }
    //    }
    //}
    //#endregion

    #region Independet
    public class DelegateCommand : System.Windows.Input.ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public DelegateCommand(Action<object> execute,Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
 
    #endregion

    #region ViewModel
    public class ViewModel
    {
        //Add
        //Select

        public ViewModel()
        {
            AddItemCommand = new DelegateCommand(
                (obj) => { AddNewItem();},(obj) => { return true;}
                );
        }

        public ICommand AddItemCommand { get; set; }

        ItemRepository _repo = new ItemRepository();
        ItemModel _itemModel = new ItemModel();

        public string ItemName { 
            get
            { 
                return _itemModel.ItemName;
            }
            set
            {
                _itemModel.ItemName = value;
            }
        }
        public string ItemType
        {
            get
            {
                return _itemModel.ItemType;
            }
            set
            {
                _itemModel.ItemType = value;
            }
        }
        public decimal ItemCost
        {
            get
            {
                return _itemModel.ItemCost;
            }
            set
            {
                _itemModel.ItemCost = value;
            }
        }
    
        public void AddNewItem()
        {
            ItemModel _modelobj = new ItemModel()
            {
                ItemName = ItemName,
                ItemType = ItemType,
                ItemCost = ItemCost
            };
            _repo.AddNewItem(_modelobj);
        }
    }
    #endregion

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //view _viewObj = new view();
            //_viewObj.DataContext = new ViewModel();

            System.Windows.Application _app = new Application();
            //_app.Run(_viewObj);

            _app.StartupUri = new Uri("view.xaml", UriKind.RelativeOrAbsolute);
            _app.Run();


            //_viewObj.SimulateAddNewItemButtonClick();
            //_viewObj.SimulateAddNewItemButtonClick();
            //_viewObj.SimulateAddNewItemButtonClick();
        }
    }
}
