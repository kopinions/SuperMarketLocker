using System.Linq;

namespace SuperMarketLocker
{
    public class SmartStrategy : IStrategy
    {
        public Locker GetLocker(Locker[] lockers1)
        {
            return lockers1.OrderByDescending(l => l.AvailableCount).FirstOrDefault(l => l.AvailableCount > 0);
        }
    }
}