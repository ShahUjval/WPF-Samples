using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DependecyTest
{

    public class P : FrameworkElement
    {

        // Animation , Style , DataBinding , Triggers - only use DP where
        public static DependencyProperty WidthProperty = 
            DependencyProperty.Register("Width", typeof(double), typeof(P), 
            new PropertyMetadata(50d, null, new CoerceValueCallback(OnWidthSet)));

        //backing field (Memory)
        //double width;

        static object OnWidthSet(DependencyObject source, object effectivaeValue)
        {
            double value = System.Convert.ToDouble(effectivaeValue);
            if (value < 10 || value > 400)
            {
                value = 10;
            }

            return value;
        }

        // Mutator - CLR Property
        public double Width
        {
            get { return Convert.ToDouble(GetValue(WidthProperty)); }
            set { SetValue(WidthProperty, value); }
        }

    }

    class Program
    {
          [STAThread]
        static void Main(string[] args)
        {
            Style _pstyle = new Style();

            _pstyle.Setters.Add(new Setter { Property = P.WidthProperty, Value = 100d });

            P p1 = new P();
            p1.Style = _pstyle;

            P p2 = new P();
            p2.Width = 500d; // local value
            p2.Style = _pstyle;

            P p3 = new P();
            //p3.style = _pstyle;

            Console.WriteLine("{0} {1} {2} ", p1.Width, p2.Width, p3.Width);

            Console.ReadLine();
        }
    }
}
