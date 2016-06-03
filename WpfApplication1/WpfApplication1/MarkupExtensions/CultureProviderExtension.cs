using System;

namespace WpfApplication1.MarkupExtensions
{
    class CultureProviderExtension : System.Windows.Markup.MarkupExtension
    {
        private readonly string _lang;


        public CultureProviderExtension(string lang)
        {
            this._lang = lang;
        }


        public string Region { get; set; }


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new Repository.Culture { Lang = _lang, Region = Region };
        }
    }
}
