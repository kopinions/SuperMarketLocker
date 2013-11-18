using System.Linq;

namespace SuperMarketLocker
{
    public class PlainStrategy : IStrategy
    {
        public Locker GetLocker(Locker[] lockers)
        {
            return lockers.FirstOrDefault(l => l.AvailableCount > 0);
        }
    }
}