using System;
using System.Collections.Generic;
using System.Linq;

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
            return (from locker in lockers let bag = locker.Pick(ticket) where bag != null select bag).FirstOrDefault();
        }
    }
}