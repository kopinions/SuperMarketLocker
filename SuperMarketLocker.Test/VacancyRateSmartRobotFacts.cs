using System.Collections.Generic;
using Xunit;

namespace SuperMarketLocker.Test
{
    public class VacancyRateSmartRobotFacts
    {
        [Fact]
        public void should_pick_the_right_bag()
        {
            Locker locker1 = new Locker(2);
            Locker locker2 = new Locker(2);
            VacancyRateSmartRobot robot = new VacancyRateSmartRobot(new List<Locker> { locker1, locker2 });
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            robot.Receive(bag1);
            var ticket = robot.Receive(bag2);
            Assert.Same(bag2, robot.Pick(ticket));
        }

        [Fact]
        public void should_store_bag_to_locker_which_has_most_balance_rate()
        {
            Locker locker1 = new Locker(1);
            Locker locker2 = new Locker(2);
            VacancyRateSmartRobot robot = new VacancyRateSmartRobot(new List<Locker> { locker1, locker2 });
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            locker2.Store(bag1);
            var ticket = robot.Receive(bag2);
            Assert.Same(bag2, locker1.Pick(ticket));
        }
    }
}