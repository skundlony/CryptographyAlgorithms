using Cryptography.Helpers;
using Cryptography.Interface;
using System.Collections.Generic;

namespace Cryptography.Algorithms
{
    public class BaconCipher : ICipher
    {
        private bool _IsDigitVersion = false;
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

        public void SwapNotation()
        {
            if (_IsDigitVersion)
            {
                _IsDigitVersion = false;
            }
            else
            {
                _IsDigitVersion = true;
            }
        }

        public BaconCipher(bool useDigitVersion = false)
        {
            _IsDigitVersion = useDigitVersion;
        }

        public string Decode(string value)
        {
            if (_IsDigitVersion)
            {
                ChangeNotation(ref value);
            }

            var decodedChars = new char[value.Split(" ").Length];
            var splittedValue = value.ToUpper().Split(" ");

            for (int i = 0; i < splittedValue.Length; i++)
            {
                decodedChars[i] = CollectionsHelper.GetKeyByValue(splittedValue[i], Scheme);
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
                    encodedChars[i - linesSkipped] = Scheme[value[i]];
                }
                else
                {
                    linesSkipped++;
                }
            }

            var result = string.Join(" ", encodedChars).Trim();

            if(_IsDigitVersion)
            {
                ChangeNotation(ref result);
            }

            return result;
        }

        private void ChangeNotation(ref string value)
        {
            if (value.Contains('A'))
            {
                value = value.Replace('A', '0').Replace('B', '1');
            } 
            else if (value.Contains('0'))
            {
                value = value.Replace('0', 'A').Replace('1', 'B');
            }
        }
    }
}