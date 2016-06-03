using System.Collections.Generic;

namespace WpfApplication1.Repository
{
    public class CultureRepository
    {
        Dictionary<string, string> _cultureRep = null;

        public static readonly CultureRepository RepInst;

        // Lazy Singleton - eager


        static CultureRepository()
        {
            RepInst = new CultureRepository();
        }
        
        private CultureRepository()
        {
            _cultureRep = new Dictionary<string, string>();
            _cultureRep.Add("en-in", "indian");
            _cultureRep.Add("en-US", "American");
            _cultureRep.Add("en-GB", "UK");
        }

        public string getCultureValue(string cul)
        {
            if(string.IsNullOrEmpty(cul))
            {
                cul = "en-in";
            }
            return _cultureRep[cul];
        }
    } 
}
