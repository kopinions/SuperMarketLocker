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

        public static Robot CreateSmartRobot(Locker[] lockers, IStragegy smartStrategy)
        {
            return new Robot(lockers, smartStrategy);
        }

        public static Robot CreateBalanceSmartRobot(Locker[] lockers, IStragegy balanceSmartRobotStrategy)
        {
            return new Robot(lockers, balanceSmartRobotStrategy);
        }
    }
}