using System.Linq;

namespace SuperMarketLocker
{
    public class SmartStrategy : IStragegy
    {
        public Locker GetLocker(Locker[] lockers)
        {
            var locker = lockers.OrderByDescending(l => l.AvailableCount).FirstOrDefault();
            if (locker == null)
            {
                throw new LockerFullException();
            }
            return locker;
        }
    }
}