using System.Collections.Generic;
using System.Linq;


namespace SuperMarketLocker
{
    public class Robot
    {
        private readonly List<Locker> _lockers;

        public Robot(List<Locker> lockers)
        {
            _lockers = lockers;
        }

        public virtual Ticket Receive(Bag bag)
        {
            Ticket ticket = null;
            foreach (var locker in _lockers)
            {
                ticket = locker.Store(bag);
                if (ticket != null) break;
            }
            return ticket;
        }

        public virtual Bag Pick(Ticket ticket)
        {
            Bag bag = null;
            foreach (var locker in _lockers)
            {
                bag = locker.Pick(ticket);
                if (bag != null) break;
            }
            return bag;
        }
    }
}