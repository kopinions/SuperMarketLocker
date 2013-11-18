using System.Linq;

namespace SuperMarketLocker
{
    public class Robot
    {
        private readonly Locker[] _lockers;
        private readonly IStrategy _strategy;

        public Robot(Locker[] lockers, IStrategy strategy)
        {
            _lockers = lockers;
            _strategy = strategy;
        }

        public virtual Ticket Receive(Bag bag)
        {
            var locker = _strategy.GetLocker(_lockers);
            return locker == null ? null : locker.Store(bag);
        }

        public virtual Bag Pick(Ticket ticket)
        {
            return _lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(pick => pick != null);
        }

        public static Robot CreateSmartRobot(Locker[] lockers, IStrategy strategy)
        {
            return new Robot(lockers, strategy);
        }

        public static Robot CreateBalanceSmartRobot(Locker[] lockers, IStrategy strategy)
        {
            return new Robot(lockers, strategy);
        }
    }
}