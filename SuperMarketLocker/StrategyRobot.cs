using System;
using System.Collections.Generic;

namespace SuperMarketLocker
{
    public class StrategyRobot
    {
        private readonly List<Locker> lockers;
        private readonly Func<List<Locker>, Locker> availableCountReceiveStrategy = RobotReceiveStrategies.None;

        public StrategyRobot(List<Locker> lockers)
        {
            this.lockers = lockers;
            availableCountReceiveStrategy = RobotReceiveStrategies.None;
        }

        public StrategyRobot(List<Locker> lockers, Func<List<Locker>, Locker> availableCountReceiveStrategy)
        {
            this.lockers = lockers;
            if (availableCountReceiveStrategy != null)
                this.availableCountReceiveStrategy = availableCountReceiveStrategy;
        }

        public Ticket Receive(Bag bag)
        {
            var availableLocker = availableCountReceiveStrategy(lockers);
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