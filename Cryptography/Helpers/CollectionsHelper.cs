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

        public static bool CompareMultidimensionArrays<TKey>(TKey[,] first, TKey[,] second)
        {
            bool isEqual = true;

            if(first.Length != second.Length)
            {
                return false;
            }

            if(first.GetLength(0) != second.GetLength(0) && first.GetLength(1) != second.GetLength(1))
            {
                return false;
            }

            for(int i = 0; i<first.GetLength(0); i++)
            {
                for(int j=0; j<first.GetLength(1); j++)
                {
                    if(!EqualityComparer<TKey>.Default.Equals(first[i,j], second[i,j]))
                    {
                        return false;
                    }
                }
            }

            return isEqual;
        }
    }
}