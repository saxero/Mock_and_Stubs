namespace library
{
    public interface IDiscountProvider
    {
        int GetDiscountByCode(string code);
    }
}
