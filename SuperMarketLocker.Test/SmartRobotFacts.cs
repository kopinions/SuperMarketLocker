using Xunit;

namespace SuperMarketLocker.Test
{
    public class SmartRobotFacts
    {
        private readonly BalanceSmartRobotFacts _balanceSmartRobotFacts = new BalanceSmartRobotFacts();

        [Fact]
        public void should_get_a_valid_ticket_when_give_bag_to_smart_robot()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(1);
            SmartRobot robot = new SmartRobot(new[] { locker });
            var ticket = robot.Receive(bag);
            Bag bag2 = locker.Pick(ticket);
            Assert.Same(bag, bag2);
        }

        [Fact]
        public void should_fail_when_give_a_bag_to_smart_robot_and_locker_is_full()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(0);
            SmartRobot robot = new SmartRobot(new[] { locker });
            Assert.Throws<LockerFullException>(() => robot.Receive(bag));
        }

        [Fact]
        public void should_store_to_locker_which_has_more_capacity()
        {
            Locker locker1 = new Locker(2);
            Locker locker2 = new Locker(2);
            SmartRobot robot = new SmartRobot(new[] { locker1, locker2 });
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            robot.Receive(bag1);
            var ticket = robot.Receive(bag2);
            Assert.Same(bag2, locker2.Pick(ticket));
        }

        [Fact]
        public void should_pick_the_right_bag()
        {
            Locker locker1 = new Locker(2);
            Locker locker2 = new Locker(2);
            SmartRobot robot = new SmartRobot(new[] { locker1, locker2 });
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            robot.Receive(bag1);
            var ticket = robot.Receive(bag2);
            Assert.Same(bag2, robot.Pick(ticket));
        }

//       [Fact]
//       public void should_throw_exception_when_ticket_invalid()
//       {
//           Locker locker1 = new Locker(2);
//           Locker locker2 = new Locker(2);
//           SmartRobot robot = new SmartRobot(new[] { locker1, locker2 });
//           Bag bag1 = new Bag();
//           Bag bag2 = new Bag();
//           robot.Receive(bag1);
//           var ticket = robot.Receive(bag2);
//           Assert.Same(bag2, robot.Pick(ticket));
//       }
    }
}