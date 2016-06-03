
using MarkUpExtensions.Repository;
using System;

namespace MarkUpExtensions.MarkUpExtensions
{
    public class ButtonContentProviderExtension : System.Windows.Markup.MarkupExtension
    {
        private Culture _culRef;

        public Culture CulRef
        {
            get { return _culRef; }
            set { _culRef = value; }
        }

        public ButtonContentProviderExtension()
        {

        }

        public ButtonContentProviderExtension(Repository.Culture _cult)
        {
            _culRef = _cult;
        }


        public override object ProvideValue(System.IServiceProvider serviceProvider)
        {
            return Repository.CultureRepository.RepInst.getCultureValue(this._culRef.Lang + "-" + this._culRef.Region);
        }
    }
}
