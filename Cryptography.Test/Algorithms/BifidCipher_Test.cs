using Cryptography.Algorithms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Test.Algorithms
{
    public class BifidCipher_Test
    {
        // based on empty keyword
        private const string _ExpectedDecodedValue_1 = "POOR BEAR";
        private const string _ExpectedDecodedValue_2 = "PULL THE WIRE";

        private const string _ExpectedEncodedValue_0 = "UAEOLWRINS";
        private const string _ExpectedEncodedValue_1 = "FQSCCALJTXOU";
        private const string _ExpectedEncodedValue_2 = "TMODTSKLRXRX";

        private const string _Keyword = "";

        private BifidCipher _Instance;

        [SetUp]
        public void Setup()
        {
            _Instance = new BifidCipher(_Keyword);
        }

        [Test]
        public void Encoding()
        {
            var value_0 = "FLEEATONCE";
            Assert.IsTrue(_Instance.Encode(value_0) == _ExpectedEncodedValue_0);
            
            var value_1 = "HARD TO ENCODE";
            Assert.IsTrue(_Instance.Encode(value_1) == _ExpectedEncodedValue_1);

            var value_2 = "RUN FOREST RUN";
            Assert.IsTrue(_Instance.Encode(value_2) == _ExpectedEncodedValue_2);
        }

        [Test]
        public void Decoding()
        {
            var value_1 = "NOADYRKB";
            Assert.IsTrue(_Instance.Decode(value_1) == _ExpectedDecodedValue_1);

            var value_2 = "ONREJEVDPJK";
            Assert.IsTrue(_Instance.Decode(value_2) == _ExpectedDecodedValue_2);
        }
    }
}
