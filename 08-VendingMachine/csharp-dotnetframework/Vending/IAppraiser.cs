namespace Vending
{
    public interface IAppraiser<T>
    {
        int Appraise(T item);
    }
}
