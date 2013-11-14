using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SuperMarketLocker.Test
{
    public class StrategyRobotFacts
    {
        [Fact]
        public void should_get_a_valid_ticket_when_give_bag_to_strategy_robot()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(1);

            StrategyRobot robot = new StrategyRobot(new List<Locker> { locker });

            var ticket = robot.Receive(bag);
            Bag bag2 = locker.Pick(ticket);
            Assert.Same(bag, bag2);
        }

        [Fact]
        public void should_return_null_when_give_a_bag_to_robot_and_locker_is_full()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(0);
            StrategyRobot robot = new StrategyRobot(new List<Locker> { locker });
            Assert.Null(robot.Receive(bag));
        }

        [Fact]
        public void should_store_bag_into_multiple_lockers_in_order()
        {
            Locker locker1 = new Locker(1);
            Locker locker2 = new Locker(1);
            StrategyRobot robot = new StrategyRobot(new List<Locker> { locker1, locker2 });
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            var ticket1 = robot.Receive(bag1);
            var ticket2 = robot.Receive(bag2);
            Assert.Same(bag1, locker1.Pick(ticket1));
            Assert.Same(bag2, locker2.Pick(ticket2));
        }

        [Fact]
        public void should_pick_bag_from_robot()
        {
            Bag bag = new Bag();
            StrategyRobot robot = new StrategyRobot(new List<Locker> { new Locker(1) });
            var ticket = robot.Receive(bag);
            Assert.Same(bag, robot.Pick(ticket));
        }

        [Fact]
        public void should_store_bag_using_available_count_strategy()
        {
            Locker locker1 = new Locker(2);
            Locker locker2 = new Locker(2);
            var strategyRobot = new StrategyRobot(new List<Locker> { locker2, locker1 }, AvailableLockerStrategies.MoreAvailableCapacity);
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            strategyRobot.Receive(bag1);
            var ticket = strategyRobot.Receive(bag2);
            Assert.Same(bag2, locker1.Pick(ticket));
        }
        
        [Fact]
        public void should_store_bag_using_vacancy_rate_strategy()
        {
            Locker locker1 = new Locker(2);
            Locker locker2 = new Locker(2);
            StrategyRobot robot = new StrategyRobot(new List<Locker> { locker2, locker1 }, AvailableLockerStrategies.MoreVacancyRate);
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            robot.Receive(bag1);
            var ticket = robot.Receive(bag2);
            Assert.Same(bag2, locker1.Pick(ticket));
        }
    }
}