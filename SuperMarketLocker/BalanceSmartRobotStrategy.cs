using System.Linq;

namespace SuperMarketLocker
{
    public class BalanceSmartRobotStrategy : IStragegy
    {
        public Locker GetLocker(Locker[] lockers)
        {
            var locker = lockers.OrderByDescending(l => l.Balance).FirstOrDefault();

            if (locker == null)
            {
                throw new LockerFullException();
            }
            return locker;
        }
    }
}