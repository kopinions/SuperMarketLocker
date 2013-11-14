using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLocker
{
    public class VacancyRateSmartRobot : SmartRobot
    {
        private List<Locker> _lockers;


        public VacancyRateSmartRobot(List<Locker> lockers) : base(lockers)
        {
            _lockers = lockers;
        }

        public override Ticket Receive(Bag bag)
        {
            var availableLocker = _lockers.OrderByDescending(l => l.VacancyRate).FirstOrDefault();
            if (availableLocker != null)
            {
                return availableLocker.Store(bag);
            }
            return null;
        }
    }
}