using System.Linq;

namespace SuperMarketLocker.Test
{
    public class BalanceSmartRobot
    {
        private Locker[] _lockers;

        public BalanceSmartRobot(Locker[] lockers)
        {
            _lockers = lockers;
        }

        public Ticket Receive(Bag bag)
        {
            foreach (var locker in _lockers.OrderByDescending(l => l.getBalence()))
            {
                return locker.Store(bag);

            }
            throw new LockerFullException();

        }
    }
}