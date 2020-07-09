using Cryptography.Algorithms;
using NUnit.Framework;

namespace Cryptography.Test
{
    public class BaconCipher_Test
    {
        private const string ExpectedEncoded_1 = "AABAA ABBAA AAABA ABBAB AAABB AABAA BAABA AABAA BAAAB BAABA"; // ENCODE TEST
        private const string ExpectedEncoded_2 = "BAABA BAAAA BABBA BAABA ABBAB AABAA ABBAA AAABA ABBAB AAABB AABAA BAABA AABBB ABAAA BAAAB"; // TRY TO ENCODE THIS

        private const string ExpectedDecoded_1 = "BACONCIPHER";
        private const string ExpectedDecoded_2 = "TRYTODECODETHIS";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Encoding()
        {
            var value_1 = "ENCODE TEST";
            Assert.IsTrue(BaconCipher.Encode(value_1) == ExpectedEncoded_1);

            var value_2 = "TRY TO ENCODE THIS";
            Assert.IsTrue(BaconCipher.Encode(value_2) == ExpectedEncoded_2);
        }

        [Test]
        public void Decoding()
        {
            var value_1 = "AAAAB AAAAA AAABA ABBAB ABBAA AAABA ABAAA ABBBA AABBB AABAA BAAAA";
            Assert.IsTrue(BaconCipher.Decode(value_1) == ExpectedDecoded_1);

            var value_2 = "BAABA BAAAA BABBA BAABA ABBAB AAABB AABAA AAABA ABBAB AAABB AABAA BAABA AABBB ABAAA BAAAB";
            Assert.IsTrue(BaconCipher.Decode(value_2) == ExpectedDecoded_2);
        }
    }
}