using Xunit;

namespace SuperMarketLocker.Test
{
    public class RobotManagerFacts
    {
        [Fact]
        public void should_get_a_valid_ticket_when_give_bag_to_robot_manager()
        {
            var bag = new Bag();
            var locker = new Locker(1);
            var robot = Robot.CreateRobot(new[] { new Locker(1) });
            var robotManager = new RobotManager(new[] { locker }, new[] { robot});
            var ticket = robotManager.Receive(bag);
            Bag bag2 = locker.Pick(ticket);
            Assert.Same(bag, bag2);
        }

        [Fact]
        public void should_store_to_robot_when_locker_is_full()
        {
            var bag = new Bag();
            var locker = new Locker(0);
            var robot = Robot.CreateRobot(new[] { new Locker(1) });
            var robotManager = new RobotManager(new[] { locker }, new[] { robot });
            var ticket = robotManager.Receive(bag);
            Bag bag2 = robot.Pick(ticket);
            Assert.Same(bag, bag2);
        }

        [Fact]
        public void should_fail_when_give_a_bag_to_robot_manager_and_all_lockers_and_robots_are_full()
        {
            var bag = new Bag();
            var locker = new Locker(0);
            var robot = Robot.CreateRobot(new[] { new Locker(0) });
            var smartRobot = Robot.CreateSmartRobot(new[] { new Locker(0) });
            var balanceSmartRobot = Robot.CreateBalanceSmartRobot(new[] { new Locker(0) });
            var robotManager = new RobotManager(new[] { locker }, new[] { robot, smartRobot, balanceSmartRobot });
            Assert.Null(robotManager.Receive(bag));
        }

        [Fact]
        public void should_get_the_bag_when_given_the_ticket()
        {
            var bag = new Bag();
            var locker = new Locker(1);
            var robot = Robot.CreateRobot(new[] { new Locker(1) });
            var robotManager = new RobotManager(new[] { locker }, new[] { robot });
            var ticket = robotManager.Receive(bag);
            Assert.Same(bag, robotManager.Pick(ticket));
        }

        [Fact]
        public void should_get_the_bag_when_given_the_ticket_and_no_locker_available()
        {
            var bag = new Bag();
            var locker = new Locker(0);
            var robot = Robot.CreateSmartRobot(new[] { new Locker(1) });
            var smartRobot = Robot.CreateSmartRobot(new[] { new Locker(1) });
            var balanceSmartRobot = Robot.CreateBalanceSmartRobot(new[] { new Locker(1) });
            var robotManager = new RobotManager(new[] { locker }, new[] { robot, smartRobot, balanceSmartRobot });
            var ticket = robotManager.Receive(bag);
            Assert.Same(bag, robotManager.Pick(ticket));
        }
    }
}