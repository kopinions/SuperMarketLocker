using System.Linq;

namespace SuperMarketLocker
{
    public class BalanceSmartRobotStrategy : IStragegy
    {
        public Locker GetLocker(Locker[] lockers1)
        {
            var locker = lockers1.OrderByDescending(l => l.getBalence()).FirstOrDefault();

            if (locker == null)
            {
                throw new LockerFullException();
            }
            return locker;
        }
    }
}