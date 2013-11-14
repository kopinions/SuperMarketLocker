
using System.Collections.Generic;
using Xunit;

namespace SuperMarketLocker.Test
{
    public class RobotFacts
    {
        [Fact]
        public void should_get_a_valid_ticket_when_give_bag_to_robot()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(1);

            Robot robot = new Robot(new List<Locker> { locker });

            var ticket = robot.Receive(bag);
            Bag bag2 = locker.Pick(ticket);
            Assert.Same(bag, bag2);
        }

        [Fact]
        public void should_return_null_when_give_a_bag_to_robot_and_locker_is_full()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(0);
            Robot robot = new Robot(new List<Locker> { locker });
            Assert.Null(robot.Receive(bag));
        }

        [Fact]
        public void should_store_bag_into_multiple_lockers_in_order()
        {
            Locker locker1 = new Locker(1);
            Locker locker2 = new Locker(1);
            Robot robot = new Robot(new List<Locker> { locker1, locker2 });
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
            Robot robot = new Robot(new List<Locker> { new Locker(1) });
            var ticket = robot.Receive(bag);
            Assert.Same(bag, robot.Pick(ticket));
        }
    }
}