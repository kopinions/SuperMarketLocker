namespace SuperMarketLocker
{
    public class Robot
    {
        private readonly Locker[] _lockers;

        public Robot(Locker[] lockers)
        {
            _lockers = lockers;
        }

        public Ticket Receive(Bag bag)
        {
            foreach (var locker in _lockers)
            {
                try
                {
                    return locker.Store(bag);
                }
                catch (LockerFullException)
                {
                }
            }
            throw new LockerFullException();
        }

        public Bag Pick(Ticket ticket)
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
    }
}