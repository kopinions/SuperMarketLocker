using System.Linq;

namespace SuperMarketLocker
{
    public class BalanceSmartStrategy : IStrategy
    {
        public Locker GetLocker(Locker[] lockers1)
        {
            return lockers1.OrderByDescending(l => l.GetBalence()).FirstOrDefault(l => l.AvailableCount > 0);
        }
    }
}