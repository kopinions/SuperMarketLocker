using System.Linq;

namespace SuperMarketLocker
{
    public class PlainStrategy : IStragegy
    {
        public Locker GetLocker(Locker[] lockers)
        {
            var locker = lockers.FirstOrDefault(l => l.AvailableCount > 0);
            if (locker == null)
            {
                throw new LockerFullException();
            }
            return locker;
        }
    }
}