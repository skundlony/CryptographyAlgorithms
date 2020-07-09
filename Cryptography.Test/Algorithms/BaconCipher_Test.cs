using Cryptography.Algorithms;
using NUnit.Framework;

namespace Cryptography.Test.Algorithms
{
    public class BaconCipher_Test
    {
        private const string _ExpectedEncoded_0 = "00100 01100 00010 01101 00011 00100 10010 00100 10001 10010"; // ENCODE TEST
        private const string _ExpectedEncoded_1 = "AABAA ABBAA AAABA ABBAB AAABB AABAA BAABA AABAA BAAAB BAABA"; // ENCODE TEST
        private const string _ExpectedEncoded_2 = "BAABA BAAAA BABBA BAABA ABBAB AABAA ABBAA AAABA ABBAB AAABB AABAA BAABA AABBB ABAAA BAAAB"; // TRY TO ENCODE THIS

        private const string _ExpectedDecoded_0 = "BACONCIPHER";
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
            var value_0 = "ENCODE TEST";
            _Instance.SwapNotation();
            var actualValue_0 = _Instance.Encode(value_0);
            Assert.IsTrue(actualValue_0 == _ExpectedEncoded_0);

            _Instance.SwapNotation();

            var value_1 = "ENCODE TEST";
            var actualValue_1 = _Instance.Encode(value_1);
            Assert.IsTrue(actualValue_1 == _ExpectedEncoded_1);

            var value_2 = "TRY TO ENCODE THIS";
            var actualValue_2 = _Instance.Encode(value_2);
            Assert.IsTrue(actualValue_2 == _ExpectedEncoded_2);
        }

        [Test]
        public void Decoding()
        {
            var value_0 = "00001 00000 00010 01101 01100 00010 01000 01110 00111 00100 10000";
            _Instance.SwapNotation();
            var actualValue_0 = _Instance.Decode(value_0);
            Assert.IsTrue(actualValue_0 == _ExpectedDecoded_0);

            _Instance.SwapNotation();

            var value_1 = "AAAAB AAAAA AAABA ABBAB ABBAA AAABA ABAAA ABBBA AABBB AABAA BAAAA";
            var actualValue_1 = _Instance.Decode(value_1);
            Assert.IsTrue(actualValue_1 == _ExpectedDecoded_1);

            var value_2 = "BAABA BAAAA BABBA BAABA ABBAB AAABB AABAA AAABA ABBAB AAABB AABAA BAABA AABBB ABAAA BAAAB";
            var actualValue_2 = _Instance.Decode(value_2);
            Assert.IsTrue(actualValue_2 == _ExpectedDecoded_2);
        }
    }
}