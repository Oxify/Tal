﻿using NUnit.Framework;
using TalBrody.Util;

namespace TalBrodyTests
{
    [TestFixture]
    public class CryptoTest
    {
        [Test]
        public void Sign()
        {
            var str =
                "The way I see it, every life is a pile of good things and bad things. The good things don’t always soften the bad things, but vice versa, the bad things don’t always spoil the good things and make them unimportant.";

            var crypto = new Crypto();
            var signed = crypto.SignSymmetric(str);
            Assert.IsTrue(crypto.VerifySignatureSymmetric(signed));
            Assert.IsFalse(crypto.VerifySignatureSymmetric(str));
        }
    }
}
