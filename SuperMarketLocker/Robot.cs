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
            return (from locker in _lockers let ticket = locker.Store(bag) where ticket != null select ticket).FirstOrDefault();
        }

        public virtual Bag Pick(Ticket ticket)
        {
            return (from locker in _lockers let bag = locker.Pick(ticket) where bag != null select bag).FirstOrDefault();
        }
    }
}