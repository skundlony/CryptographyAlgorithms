using Cryptography.Algorithms;
using NUnit.Framework;

namespace Cryptography.Test
{
    public class BaconCipher_Test
    {
        private const string _ExpectedEncoded_1 = "AABAA ABBAA AAABA ABBAB AAABB AABAA BAABA AABAA BAAAB BAABA"; // ENCODE TEST
        private const string _ExpectedEncoded_2 = "BAABA BAAAA BABBA BAABA ABBAB AABAA ABBAA AAABA ABBAB AAABB AABAA BAABA AABBB ABAAA BAAAB"; // TRY TO ENCODE THIS

        private const string _ExpectedDecoded_1 = "BACONCIPHER";
        private const string _ExpectedDecoded_2 = "TRYTODECODETHIS";

        private BaconCipher _Instance;

        [SetUp]
        public void Setup()
        {
            _Instance = new BaconCipher();
        }

        [Test]
        public void Encoding()
        {
            var value_1 = "ENCODE TEST";
            Assert.IsTrue(_Instance.Encode(value_1) == _ExpectedEncoded_1);

            var value_2 = "TRY TO ENCODE THIS";
            Assert.IsTrue(_Instance.Encode(value_2) == _ExpectedEncoded_2);
        }

        [Test]
        public void Decoding()
        {
            var value_1 = "AAAAB AAAAA AAABA ABBAB ABBAA AAABA ABAAA ABBBA AABBB AABAA BAAAA";
            Assert.IsTrue(_Instance.Decode(value_1) == _ExpectedDecoded_1);

            var value_2 = "BAABA BAAAA BABBA BAABA ABBAB AAABB AABAA AAABA ABBAB AAABB AABAA BAABA AABBB ABAAA BAAAB";
            Assert.IsTrue(_Instance.Decode(value_2) == _ExpectedDecoded_2);
        }
    }
}