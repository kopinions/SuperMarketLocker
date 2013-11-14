namespace SuperMarketLocker
{
    public interface IStragegy
    {
        Locker GetLocker(Locker[] lockers);
    }
}