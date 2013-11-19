using Xunit;

namespace SuperMarketLocker.Test
{
    public class BalanceSmartRobotFacts
    {
        [Fact]
        public void should_store_bag_to_locker_which_has_most_balance_rate()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(2);
            Robot robot = Robot.CreateBalanceSmartRobot(new[] { locker1, locker2 });
            var bag1 = new Bag();
            var bag2 = new Bag();
            locker2.Store(bag1);
            var ticket = robot.Store(bag2);
            Assert.Same(bag2, locker1.Pick(ticket));
        }
    }
}