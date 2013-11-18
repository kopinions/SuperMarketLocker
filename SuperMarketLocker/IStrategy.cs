namespace SuperMarketLocker
{
    public interface IStrategy
    {
        Locker GetLocker(Locker[] lockers);
    }
}