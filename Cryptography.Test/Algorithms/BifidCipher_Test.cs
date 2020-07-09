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
        private const string _ExpectedDecodedValue_0 = "";
        private const string _ExpectedDecodedValue_1 = "POOR BEAR";
        private const string _ExpectedDecodedValue_2 = "PULL THE WIRE";

        private const string _ExpectedEncodedValue_0 = "NFVLLCUYXOU";
        private const string _ExpectedEncodedValue_1 = "AHDURFFIEEREDXIHUY";
        private const string _ExpectedEncodedValue_2 = "YNMLEXRFMKBD";

        private BifidCipher _Instance;

        [SetUp]
        public void Setup()
        {
            _Instance = new BifidCipher();
        }

        [Test]
        public void Encoding()
        {
            // empty encryptionKey.
            var value_0 = "NOKEYENCODE";
            Assert.IsTrue(_Instance.Encode(value_0) == _ExpectedEncodedValue_0);
            
            var value_1 = "ENCODEWITHFIRSTKEY";
            var keyword_1 = "FIRSTKEY";
            _Instance.ChangeEnrcryptionKey(keyword_1);
            var actualValue_1 = _Instance.Encode(value_1);
            Assert.IsTrue(actualValue_1 == _ExpectedEncodedValue_1);

            var value_2 = "RUNFORESTRUN";
            var keyword_2 = "LETSSEEHARDESKEYEVER";
            _Instance.ChangeEnrcryptionKey(keyword_2);
            var actualValue_2 = _Instance.Encode(value_2);
            Assert.IsTrue(actualValue_2 == _ExpectedEncodedValue_2);
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
