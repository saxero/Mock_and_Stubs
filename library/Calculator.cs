namespace library
{
    public class Calculator
    {
        private IDiscountProvider _provider;
                        
        public void SetProvider(IDiscountProvider provider)
        {
            this._provider = provider;
        }

        public double CalculateTotal(double ammount, string code)
        {
            var desc = this._provider.GetDiscountByCode(code);
            return (ammount-(ammount*desc/100));
        }
    }
}