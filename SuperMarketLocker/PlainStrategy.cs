using System.Linq;

namespace SuperMarketLocker
{
    public class PlainStrategy : IStragegy
    {
        public Locker GetLocker(Locker[] lockers)
        {
            var locker1 = lockers.FirstOrDefault(l => l.AvailableCount>0);
            if (locker1 == null)
            {
                throw new LockerFullException();
            }
            return locker1;
        }
    }
}