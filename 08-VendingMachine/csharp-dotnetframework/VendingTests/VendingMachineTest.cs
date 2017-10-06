using NUnit.Framework;
using Vending;

namespace VendingTests
{
    [TestFixture]
    public class VendingMachineTest
    {
        private VendingMachine _vendingMachine;
        private IDisplay _mockDisplay;

        [SetUp]
        public void SetUp()
        {
            _mockDisplay = null;
            _vendingMachine = new VendingMachine(new FaceValueCoinAppraiser(), _mockDisplay);
        }

        [Test]
        public void StartsWithZeroCentsCredit()
        {
            Assert.AreEqual(0, _vendingMachine.CurrentTotalDeposited);
        }
        
        [Test]
        public void CreditGoesUpByTenCentsWhenYouInsertADime()
        {
            _vendingMachine.InsertCoin(Coin.Dime);
            Assert.AreEqual(10, _vendingMachine.CurrentTotalDeposited);
        }

        [Test]
        public void CreditAccumulatesAsYouInsertMoreCoins()
        {
            _vendingMachine.InsertCoin(Coin.Nickel);
            _vendingMachine.InsertCoin(Coin.Nickel);
            _vendingMachine.InsertCoin(Coin.Quarter);
            _vendingMachine.InsertCoin(Coin.Dime);

            Assert.AreEqual(45, _vendingMachine.CurrentTotalDeposited);
        }

        [Test]
        [Ignore("Remove this line when you're ready to run the test")]
        public void CurrentTotalIsDisplayedWhenYouInsertCoins()
        {
            _vendingMachine.InsertCoin(Coin.Nickel);
            _vendingMachine.InsertCoin(Coin.Dime);
            Assert.AreEqual("15 cents", null /* TODO: use _mockDisplay here */);
        }
    }
}
