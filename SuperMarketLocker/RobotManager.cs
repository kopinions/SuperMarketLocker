using System.Linq;

namespace SuperMarketLocker
{
    public class RobotManager
    {
        private readonly Locker[] _lockers;
        private readonly Robot[] _robots;

        public RobotManager(Locker[] lockers, Robot[] robots)
        {
            _robots = robots;
            _lockers = lockers;
        }

        public Ticket Receive(Bag bag)
        {
            return _lockers.Select(l => l.Store(bag)).FirstOrDefault(t => t != null) ??
                   _robots.Select(r => r.Store(bag)).FirstOrDefault(t => t != null);
        }

        public Bag Pick(Ticket ticket)
        {
            return _lockers.Select(l => l.Pick(ticket)).FirstOrDefault(bag => bag != null) ??
                   _robots.Select(r => r.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}