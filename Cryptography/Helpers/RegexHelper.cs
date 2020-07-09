using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cryptography.Helpers
{
    public static class RegexHelper
    {
        public static string RemoveSpecialMarks(string value)
        {
            var result = Regex.Replace(value, @"[^0-9a-zA-Z]+", "");
            return result;
        }
    }
}
