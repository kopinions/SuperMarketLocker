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
            var first = _strategy.GetLocker(_lockers);
            return first.Store(bag);
        }

        public virtual Bag Pick(Ticket ticket)
        {
            foreach (var locker in _lockers)
            {
                try
                {
                    return locker.Pick(ticket);
                }
                catch (TicketInvalidException)
                {
                }
            }
            throw new TicketInvalidException();
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