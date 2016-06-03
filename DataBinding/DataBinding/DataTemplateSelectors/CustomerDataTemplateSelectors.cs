using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DataBinding.DataTemplateSelectors
{
    public class CustomerDataTemplateSelectors : DataTemplateSelector
    {
        public string TemplateType { get; set; }

        public DataTemplate BasicDataTempl { get; set; }
        public DataTemplate RichDataTempl { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if(TemplateType == "BASIC")
            {
                return BasicDataTempl;
            }

            return RichDataTempl;
        } 

    }
}
