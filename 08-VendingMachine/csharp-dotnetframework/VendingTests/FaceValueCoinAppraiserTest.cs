using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Vending;

namespace VendingTests
{
    [TestFixture]
    class FaceValueCoinAppraiserTest
    {
        [Test]
        [TestCase(Coin.Dime, ExpectedResult = 10)]
        [TestCase(Coin.Nickel, ExpectedResult = 5)]
        [TestCase(Coin.Quarter, ExpectedResult = 25)]
        public int CoinsHaveTheCorrectValue(Coin coin)
        {
            return new FaceValueCoinAppraiser().Appraise(coin);
        }

    }
}
