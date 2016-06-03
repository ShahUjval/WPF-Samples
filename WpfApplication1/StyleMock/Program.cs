using System;
using System.Windows;

namespace StyleMock
{

    // Valur Provider 
    // Property Representer ----> static , public , Datatype of CLR Property 
    //public class Style
    //{
    //    // style can has collection of setters
    //    List<setter> setters;

    //    public List<setter> Setters
    //    {
    //        get { return setters; }
    //        set { setters = value; }
    //    }


    //    public Style()
    //    {
    //        setters = new List<setter>();
    //    }
    //}

    //public class setter
    //{
    //    public DependencyProperty property { get; set; }
    //    public object Value { get; set; }
    //}

    ///// <summary>
    ///// for assigning default values - Value Providers..!!
    ///// </summary>
    //public class PropertyMetaData
    //{
    //    object defaulValue;

    //    public object DefaultValue
    //    {
    //        get { return defaulValue; }
    //        set { defaulValue = value; }
    //    }

    //    public PropertyMetaData(object defaultValue)
    //    {
    //        this.defaulValue = defaultValue;
    //    }

    //}

    // value determiner , store and resolute..!!

   // public class DependencyObject
   // {
   //     Dictionary<DependencyProperty, object> _localstore = new Dictionary<DependencyProperty, object>();

   //     public void setValue(DependencyProperty property, object value)
   //     {
   //         _localstore[property] = value;
   //     }

   //     public object GetValue(DependencyProperty property)
   //     {
   //         object effectiveValueOfProperty = null;
   //         // Value Providers

   //         if (_localstore.ContainsKey(property))
   //         {
   //             effectiveValueOfProperty = _localstore[property];
   //             return effectiveValueOfProperty;
   //         }

   //         FrameworkElement _source = this as FrameworkElement;
   //         Style _valueProvider_style = _source.style;

   //         if (_valueProvider_style != null)
   //         {

   //             effectiveValueOfProperty = _valueProvider_style.Setters.FirstOrDefault(s => s.property == property).Value;

   //             return effectiveValueOfProperty;
   //         }

   //         return property.MetaData.DefaultValue;
   //     }
   // }

   // // property representer
   //public  class DependencyProperty
   // {
   //     System.Type propertyDataType;
   //     PropertyMetaData metadata;
   //     string name; // part of key
   //     System.Type ownertype; // partkey

   //    public PropertyMetaData MetaData
   //     {
   //         get { return metadata; }
   //         set { metadata = value; }
   //     }

   //     DependencyProperty() { } 

   //     // factory to get the Representer object
   //     public static DependencyProperty Register(string name,System.Type propertyDataType,Type ownertype)
   //     {
   //         //Generate Key

   //         return new DependencyProperty() { propertyDataType = propertyDataType };
   //     }

   //     // factory to get the Representer object
   //     public static DependencyProperty Register(string name, System.Type propertyDataType ,Type ownertype, PropertyMetaData metadata)
   //     {
   //         return new DependencyProperty() { propertyDataType = propertyDataType , metadata = metadata};
   //     }

   // }

   // public class FrameworkElement : DependencyObject
   // {

   //     public Style style { get; set; }
   // }

   public class P : FrameworkElement  // is-a relationship with adaption
    {
       // Animation , Style , DataBinding , Triggers - only use DP where
        public static DependencyProperty WidthProperty = DependencyProperty.Register("Width",typeof(double) , typeof(P),new PropertyMetadata(50d,null,new CoerceValueCallback(OnWidthSet)));

        //backing field (Memory)
        //double width;

       static object OnWidthSet(DependencyObject source , object effectivaeValue)
       {
           double value = System.Convert.ToDouble(effectivaeValue);
           if(value < 10 || value > 400)
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

            _pstyle.Setters.Add(new Setter{Property = P.WidthProperty,Value = 100d});

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
