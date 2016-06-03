using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GridDemo
{

    // Violation of SRP
    // More than one reason to Change 
    // OCP 

     public class UIElement : DependencyObject
     {

         // dictionary to store the key and value - Provided by DO Control's Dependency Properties 
         // Close to visitor Pattern - UIelement act as a visitor to GRID
     }
     


     public class Grid
     {
         List<UIElement> childrens;

         //Attached Property - Not in the Memory of GRID but in control's Memory
         public static DependencyProperty RowProperty = DependencyProperty.RegisterAttached("Row",typeof(int),typeof(Grid));
         public static DependencyProperty ColumnProperty = DependencyProperty.RegisterAttached("Column", typeof(int), typeof(Grid));

         public static void SetRow(UIElement child, int rowValue)
         {
             child.SetValue(RowProperty, rowValue);
         }

         public static int GetRow(UIElement child)
         {
             return  Convert.ToInt32(child.GetValue(RowProperty));
         }

         public static void SetColumn(UIElement child, int colValue)
         {
             child.SetValue(ColumnProperty, colValue);
         }

         public static int GetColumn(UIElement child)
         {
             return Convert.ToInt32(child.GetValue(ColumnProperty));
         }

         public List<UIElement> Childrens
         {
             get { return childrens; }
             set { childrens = value; }
         }

         public void arrange()
         {
             foreach( UIElement child in childrens)
             {
                 Console.WriteLine("spectator positioned at {0} {1} " ,GetRow(child) , GetColumn(child));
             }
         }
     }

    class Program
    {
        static void Main(string[] args)
        {
            UIElement _s1 = new UIElement() {};
            UIElement _s2 = new UIElement() {};
            UIElement _s3 = new UIElement() {};
            UIElement _s4 = new UIElement() {};

            Grid.SetRow(_s1, 0);
            Grid.SetColumn(_s1, 0);
            
            
            Grid.SetRow(_s2, 1);
            Grid.SetColumn(_s2, 1);
            Grid.SetRow(_s3, 2);
            Grid.SetColumn(_s3, 2);
            Grid.SetRow(_s4, 3);
            Grid.SetColumn(_s4, 3);

            Grid _grid = new Grid();
            _grid.Childrens = new List<UIElement>();

            _grid.Childrens.Add(_s1);
            _grid.Childrens.Add(_s2);
            _grid.Childrens.Add(_s3);
            _grid.Childrens.Add(_s4);

            _grid.arrange();

            Console.ReadLine();
        }
    }
}
