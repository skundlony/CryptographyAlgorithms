using Cryptography.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cryptography.Interface;

namespace Cryptography.Algorithms
{
    public class BaconCipher : ICipher
    {
        // I = J, U = V
        private static Dictionary<char, string> Scheme = new Dictionary<char, string>
        {
            { 'A', "AAAAA" },
            { 'B', "AAAAB" },
            { 'C', "AAABA" },
            { 'D', "AAABB" },
            { 'E', "AABAA" },
            { 'F', "AABAB" },
            { 'G', "AABBA" },
            { 'H', "AABBB" },
            { 'I', "ABAAA" },
            { 'J', "ABAAA" },
            { 'K', "ABAAB" },
            { 'L', "ABABA" },
            { 'M', "ABABB" },
            { 'N', "ABBAA" },
            { 'O', "ABBAB" },
            { 'P', "ABBBA" },
            { 'Q', "ABBBB" },
            { 'R', "BAAAA" },
            { 'S', "BAAAB" },
            { 'T', "BAABA" },
            { 'U', "BAABB" },
            { 'V', "BAABB" },
            { 'W', "BABAA" },
            { 'X', "BABAB" },
            { 'Y', "BABBA" },
            { 'Z', "BABBB" }
        };

        public BaconCipher()
        {

        }

        //TODO: Add 0/1 switch

        public string Decode(string value)
        {
            var decodedChars = new char[value.Split(" ").Length];
            var splittedValue = value.ToUpper().Split(" ");

            for(int i=0; i<splittedValue.Length; i++)
            {
                decodedChars[i] = DictionaryHelper.GetKeyByValue(splittedValue[i], Scheme);
            }

            return string.Join("", decodedChars).Trim();
        }

        public string Encode(string value)
        {
            var encodedChars = new string[value.Length];
            int linesSkipped = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (Scheme.ContainsKey(value[i]))
                {
                    encodedChars[i-linesSkipped] = Scheme[value[i]];
                }
                else
                {
                    linesSkipped++;
                }
            }

            return string.Join(" ", encodedChars).Trim();
        }
    }
}
