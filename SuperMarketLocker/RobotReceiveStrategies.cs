using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLocker
{
    public static class RobotReceiveStrategies
    {
        public static Func<List<Locker>, Locker> None = lockers => lockers.FirstOrDefault(l => l.AvailableCount > 0);

        public static Func<List<Locker>, Locker> MoreAvailableCount =
                lockers => lockers.OrderByDescending(l => l.AvailableCount).FirstOrDefault();

        public static Func<List<Locker>, Locker> MoreVacancyRate =
                lockers => lockers.OrderByDescending(l => l.VacancyRate).FirstOrDefault();
    }
}