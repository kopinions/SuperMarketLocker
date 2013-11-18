using Xunit;

namespace SuperMarketLocker.Test
{
    public class SmartRobotFacts
    {
        [Fact]
        public void should_get_a_valid_ticket_when_give_bag_to_smart_robot()
        {
            var bag = new Bag();
            var locker = new Locker(1);
            Robot robot = Robot.CreateSmartRobot(new[] { locker }, new SmartStrategy());
            var ticket = robot.Receive(bag);
            Bag bag2 = locker.Pick(ticket);
            Assert.Same(bag, bag2);
        }

        [Fact]
        public void should_fail_when_give_a_bag_to_smart_robot_and_locker_is_full()
        {
            var bag = new Bag();
            var locker = new Locker(0);
            Robot robot = Robot.CreateSmartRobot(new[] { locker }, new SmartStrategy());
            Assert.Throws<LockerFullException>(() => robot.Receive(bag));
        }

        [Fact]
        public void should_store_to_locker_which_has_more_capacity()
        {
            var locker1 = new Locker(2);
            var locker2 = new Locker(2);
            var robot = Robot.CreateSmartRobot(new[] { locker1, locker2 }, new SmartStrategy());
            var bag1 = new Bag();
            var bag2 = new Bag();
            robot.Receive(bag1);
            var ticket = robot.Receive(bag2);
            Assert.Same(bag2, locker2.Pick(ticket));
        }

        [Fact]
        public void should_pick_the_right_bag()
        {
            var locker1 = new Locker(2);
            var locker2 = new Locker(2);
            Robot robot = Robot.CreateSmartRobot(new[] { locker1, locker2 }, new SmartStrategy());
            var bag1 = new Bag();
            var bag2 = new Bag();
            robot.Receive(bag1);
            var ticket = robot.Receive(bag2);
            Assert.Same(bag2, robot.Pick(ticket));
        }

       [Fact]
       public void should_throw_exception_when_ticket_invalid()
       {
           var locker1 = new Locker(2);
           var locker2 = new Locker(2);
           Robot robot = Robot.CreateSmartRobot(new[] { locker1, locker2 }, new SmartStrategy());
           var bag1 = new Bag();
           var bag2 = new Bag();
           robot.Receive(bag1);
           robot.Receive(bag2);
           Assert.Throws<TicketInvalidException>(() => robot.Pick(new Ticket()));
       }
    }
}