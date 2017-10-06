namespace Vending
{
    public class VendingMachine
    {
        public int CurrentTotalDeposited { get; private set; } = 0;
        private readonly IAppraiser<Coin> _coinAppraiser;
        private readonly IDisplay _display;

        public VendingMachine(IAppraiser<Coin> coinAppraiser, IDisplay display)
        {
            _coinAppraiser = coinAppraiser;
            _display = display;
        }

        public void InsertCoin(Coin coin)
        {   
            CurrentTotalDeposited += _coinAppraiser.Appraise(coin);
        }


    }
}
