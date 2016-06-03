using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.MarkupExtensions
{
    public class TextContentMarkupExtensions : System.Windows.Markup.MarkupExtension
    {
        public TextContentMarkupExtensions()
        { }

        public TextContentMarkupExtensions(Repository.Culture _cu)
        {
            
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
           
        }
    }
}
