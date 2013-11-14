using System;
using System.Collections.Generic;

namespace SuperMarketLocker
{
    public class StrategyRobot
    {
        private readonly List<Locker> lockers;
        private readonly Func<List<Locker>, Locker> availableLockerStrategy = AvailableLockerStrategies.None;

        public StrategyRobot(List<Locker> lockers)
        {
            this.lockers = lockers;
            availableLockerStrategy = AvailableLockerStrategies.None;
        }

        public StrategyRobot(List<Locker> lockers, Func<List<Locker>, Locker> availableLockerStrategy)
        {
            this.lockers = lockers;
            if (availableLockerStrategy != null)
                this.availableLockerStrategy = availableLockerStrategy;
        }

        public Ticket Receive(Bag bag)
        {
            var availableLocker = availableLockerStrategy(lockers);
            return availableLocker!= null ? availableLocker.Store(bag) : null;
        }

        public Bag Pick(Ticket ticket)
        {
            Bag bag = null;
            foreach (var locker in lockers)
            {
                bag = locker.Pick(ticket);
                if (bag != null) break;
            }
            return bag;
        }
    }
}