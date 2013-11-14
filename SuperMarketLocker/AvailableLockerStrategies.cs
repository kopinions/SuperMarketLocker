using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLocker
{
    public static class AvailableLockerStrategies
    {
        public static Func<List<Locker>, Locker> None = lockers => lockers.FirstOrDefault(l => l.AvailableCapacity > 0);

        public static Func<List<Locker>, Locker> MoreAvailableCapacity =
                lockers => lockers.OrderByDescending(l => l.AvailableCapacity).FirstOrDefault();

        public static Func<List<Locker>, Locker> MoreVacancyRate =
                lockers => lockers.OrderByDescending(l => l.VacancyRate).FirstOrDefault();
    }
}