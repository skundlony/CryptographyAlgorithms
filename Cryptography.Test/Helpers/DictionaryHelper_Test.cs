using Cryptography.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Test
{
    public class DictionaryHelper_Test
    {
        private const int ExpectedValue_1 = 2;
        private const int ExpectedValue_2 = 4;

        private readonly Dictionary<int, string> Values = new Dictionary<int, string>
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
            Assert.IsTrue(DictionaryHelper.GetKeyByValue(value_1, Values) == ExpectedValue_1);

            var value_2 = "CHICKEN";
            Assert.IsTrue(DictionaryHelper.GetKeyByValue(value_2, Values) == ExpectedValue_2);

            var value_3 = "DOG";
            Assert.IsTrue(DictionaryHelper.GetKeyByValue(value_3, Values) == default);
        }
    }
}