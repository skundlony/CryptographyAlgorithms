using Cryptography.Algorithms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Test.Algorithms
{
    public class PolybiusSquare_Test
    {
        private PolybiusSquare _Instance;

        private const string _EncryptKey_0 = "LONGENCRYPTIONKEY";
        private const string _EncryptKey_1 = "SHORT";

        private readonly char[,] _ExpectedScheme_0 = new char[,]
        {
            { 'L', 'O', 'N', 'G', 'E' },
            { 'C', 'R', 'Y', 'P', 'T' },
            { 'I', 'K', 'A', 'B', 'D' },
            { 'F', 'H', 'M', 'Q', 'S' },
            { 'U', 'V', 'W', 'X', 'Z' }
        };

        private readonly char[,] _ExpectedScheme_1 = new char[,]
        {
            { 'S', 'H', 'O', 'R', 'T' },
            { 'A', 'B', 'C', 'D', 'E' },
            { 'F', 'G', 'I', 'K', 'L' },
            { 'M', 'N', 'P', 'Q', 'U' },
            { 'V', 'W', 'X', 'Y', 'Z' }
        };

        [SetUp]
        public void Setup()
        {
            _Instance = new PolybiusSquare();
        }

        [Test]
        public void PolybiousKeywordUpdate()
        {
            _Instance.SetKey(_EncryptKey_0);
            var scheme_0 = _Instance.Get();
            CollectionAssert.AreEqual(scheme_0, _ExpectedScheme_0);

            _Instance.SetKey(_EncryptKey_1);
            var scheme_1 = _Instance.Get();
            CollectionAssert.AreEqual(scheme_1, _ExpectedScheme_1);
        }
    }
}
