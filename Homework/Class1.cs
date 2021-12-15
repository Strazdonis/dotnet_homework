using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class BreedCache
    {
        private Dictionary<string, IList<string>> known_subbreeds = null;
        public IList<string> GetSubBreeds(string breedname)
        {
            if (known_subbreeds.ContainsKey("breedname"))
            {
                return known_subbreeds[breedname];
            }
            return null;
        }
        public Boolean addSubBreeds(string breedname, IList<string> subbreeds)
        {
            if (known_subbreeds.ContainsKey(breedname))
            {
                return false;
            }
            known_subbreeds[breedname] = subbreeds;
            return true;
        }
    }
}
