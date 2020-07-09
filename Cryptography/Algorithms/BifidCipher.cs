using System;
using System.Collections.Generic;
using System.Text;
using Cryptography.Interface;

namespace Cryptography.Algorithms
{
    public class BifidCipher : ICipher
    {
        private readonly char[,] PolybiusSquare = new char[5, 5]
        {
            { 'B', 'G', 'W', 'K', 'Z' },
            { 'Q', 'P', 'N', 'D', 'S' },
            { 'I', 'O', 'A', 'X', 'E' },
            { 'F', 'C', 'L', 'U', 'M' },
            { 'T', 'H', 'Y', 'V', 'R' }
        };

        public string Decode(string value)
        {
            throw new NotImplementedException();
        }

        public string Encode(string value)
        {
            throw new NotImplementedException();
        }
    }
}