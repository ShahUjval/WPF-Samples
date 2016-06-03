using System;

namespace WpfApplication1.MarkupExtensions
{
    public class ButtonContentProviderExtension : System.Windows.Markup.MarkupExtension
    {
        /*
        // Private setter

        // getter / setter for the Private variable
        private string Cult;

        public string CultKey
        {
            get { return Cult; }
            set { Cult = value;}
        }
        */
        public ButtonContentProviderExtension()
        { }

        public ButtonContentProviderExtension(Repository.Culture _cult)
        {
            _culRef = _cult;
        } 

        //// overloaded constructor
        //public ButtonContentProviderExtension(string cult)
        //{
        //    this.CultKey = cult;
        //}

        //*/


        private Repository.Culture _culRef;

        public Repository.Culture CulRef
        {
            get { return this._culRef; }
            set { this._culRef = value;  }
        }


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Repository.CultureRepository.RepInst.getCultureValue(this._culRef.Lang+"-"+this._culRef.Region);

            // get the value from the culture
        }
    }
}
