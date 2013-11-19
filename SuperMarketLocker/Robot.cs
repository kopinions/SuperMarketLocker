using System;
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

        public virtual Ticket Store(Bag bag)
        {
            var locker = _strategy.GetLocker(_lockers);
            return locker == null ? null : locker.Store(bag);
        }

        public virtual Bag Pick(Ticket ticket)
        {
            return _lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(pick => pick != null);
        }

        public static Robot CreateRobot(Locker[] lockers)
        {
            return new Robot(lockers, new PlainStrategy());
        }

        public static Robot CreateSmartRobot(Locker[] lockers)
        {
            return new Robot(lockers, new SmartStrategy());
        }

        public static Robot CreateBalanceSmartRobot(Locker[] lockers)
        {
            return new Robot(lockers, new BalanceSmartStrategy());
        }
    }
}