using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLocker
{
    public class VacancyRateSmartRobot : SmartRobot
    {
        private readonly List<Locker> _lockers;


        public VacancyRateSmartRobot(List<Locker> lockers) : base(lockers)
        {
            _lockers = lockers;
        }

        public override Ticket Receive(Bag bag)
        {
            var availableLocker = _lockers.OrderByDescending(l => l.VacancyRate).FirstOrDefault();
            return availableLocker != null ? availableLocker.Store(bag) : null;
        }
    }
}