using System.Linq;

namespace SuperMarketLocker
{
    public class SmartStrategy : IStrategy
    {
        public Locker GetLocker(Locker[] lockers1)
        {
            var lockers = lockers1.OrderByDescending(l => l.AvailableCount);
            var first = lockers.FirstOrDefault(l => l.AvailableCount > 0);
            if (first == null)
            {
                throw new LockerFullException();
            }
            return first;
        }
    }
}