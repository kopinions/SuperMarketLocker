using System.Linq;

namespace SuperMarketLocker.Test
{
    public class SmartRobot
    {
        private readonly Locker[] _lockers;

        public SmartRobot(Locker[] lockers)
        {
            _lockers = lockers;
        }

        public Ticket Receive(Bag bag)
        {
            foreach (var locker in _lockers.OrderByDescending(l=>l.AvailableCount))
            {
                return locker.Store(bag);
                
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