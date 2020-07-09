using Cryptography.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Test.Helpers
{
    public class RegexHelper_Test
    {
        private const string _ExpectedValue_1 = "REMOVEDSPECIALMARKS";
        private const string _ExpectedValue_2 = "WITHOUTMARKS";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RemoveSpecialMarks()
        {
            var value_1 = "REMOVED^&@#!*&@# SPECIAL @&!^#&! MARKS@!#!@";
            Assert.IsTrue(RegexHelper.RemoveSpecialMarks(value_1) == _ExpectedValue_1);

            var value_2 = "@!@!#!@&W&*@#^&*I&*!@^#T*(&!(*&@H_)(_)!@      OUT @!*&!#*()@& (*MA (*@)!&*#()!@&)(   RKS";
            Assert.IsTrue(RegexHelper.RemoveSpecialMarks(value_2) == _ExpectedValue_2);
        }
    }
}
