using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace Cryptography.Helpers
{
    public class CollectionsHelper
    {
        public static TKey GetKeyByValue<TKey, TValue>(TValue value, Dictionary<TKey, TValue> dict)
        {
            for(int i = 0; i<dict.Count; i++)
            {
                var dictValue = dict.ElementAt(i).Value;

                if(dictValue.Equals(value))
                {
                    return dict.ElementAt(i).Key;
                }
            }

            return default;
        }

    }
}