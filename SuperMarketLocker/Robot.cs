namespace SuperMarketLocker
{
    public class Robot
    {
        private readonly Locker[] _lockers;
        private readonly IStragegy _strategy;

        public Robot(Locker[] lockers, IStragegy strategy)
        {
            _lockers = lockers;
            _strategy = strategy;
        }

        public virtual Ticket Receive(Bag bag)
        {
            var locker1 = _strategy.GetLocker(_lockers);
            return locker1.Store(bag);
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

        public static Robot CreateSmartRobot(Locker[] lockers)
        {
            return new Robot(lockers, new SmartStrategy());
        }

        public static Robot CreateBalanceSmartRobot(Locker[] lockers)
        {
            return new Robot(lockers, new BalanceSmartRobotStrategy());
        }
    }
}