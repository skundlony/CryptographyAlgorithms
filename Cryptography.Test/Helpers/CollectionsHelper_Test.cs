using Cryptography.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Test.Helpers
{
    public class CollectionsHelper_Test
    {
        private const int _ExpectedValue_1 = 2;
        private const int _ExpectedValue_2 = 4;

        private readonly Dictionary<int, string> _Values = new Dictionary<int, string>
        {
            { 1, "TEST" },
            { 2, "CAT" },
            { 3, "BURGER" },
            { 4, "CHICKEN" }
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetKeyByValue()
        {
            var value_1 = "CAT";
            Assert.IsTrue(CollectionsHelper.GetKeyByValue(value_1, _Values) == _ExpectedValue_1);

            var value_2 = "CHICKEN";
            Assert.IsTrue(CollectionsHelper.GetKeyByValue(value_2, _Values) == _ExpectedValue_2);

            var value_3 = "DOG";
            Assert.IsTrue(CollectionsHelper.GetKeyByValue(value_3, _Values) == default);
        }
    }
}