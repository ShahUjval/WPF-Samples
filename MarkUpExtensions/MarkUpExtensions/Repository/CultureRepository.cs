using System.Collections.Generic;

namespace MarkUpExtensions.Repository
{
    public class CultureRepository
    {
        private Dictionary<string, string> _cultureRep = null;

        // Lazy Singleton - Not worried about Double Check Locking
        public static readonly CultureRepository RepInst;

        static CultureRepository()
        {
            RepInst = new CultureRepository();
        }

        private CultureRepository()
        {
            _cultureRep = new Dictionary<string, string>();
            _cultureRep.Add("en-IN", "Indian");
            _cultureRep.Add("en-US","American");
            _cultureRep.Add("en-GB","UK");
        }

        public string getCultureValue(string cul)
        {
            if (string.IsNullOrEmpty(cul))
            {
                cul = "en-IN";
            }

            return _cultureRep[cul];
        }

    }
}
