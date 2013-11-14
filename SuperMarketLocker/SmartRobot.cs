using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLocker
{
    public class SmartRobot : Robot
    {
        private readonly List<Locker> _lockers;

        public SmartRobot(List<Locker> lockers) : base(lockers)
        {
            _lockers = lockers;
        }

        public override Ticket Receive(Bag bag)
        {
            var availableLocker = _lockers.OrderByDescending(locker => locker.AvailableCapacity).FirstOrDefault();
            if (availableLocker != null)
            {
                return availableLocker.Store(bag);
            }
            return null;
        }
    }
}