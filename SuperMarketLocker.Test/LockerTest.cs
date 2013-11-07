using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SuperMarketLocker.Test
{
    public class LockerTest
    {
        [Fact]
        public void should_get_a_ticket_when_store_a_bag()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(1);
            var ticket = locker.Store(bag);

            Assert.IsType(typeof(Ticket), ticket);
        }

        [Fact]
        public void shoule_store_fail_when_locker_is_full()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(1);
            var ticket = locker.Store(bag);
            Bag anotherBag = new Bag();
            Assert.Throws<LockerFullException>(() => locker.Store(anotherBag));
        }

//        [Fact]
//        public void should_return_a_bag_when_pick_with_ticket()
//        {
//            Bag bag = new Bag();
//            Locker locker = new Locker(1);
//            var ticket = locker.Store(bag);
//            var pickedBag = locker.Pick(ticket);
//            Assert.IsType<Bag>(pickedBag);
//        }

        [Fact]
        public void should_return_the_same_bag_when_pick_with_ticket()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(2);
            var ticket = locker.Store(bag);
            
            Bag anotherBag = new Bag();
            var anotherTicket = locker.Store(anotherBag);

            var pickedBag = locker.Pick(ticket);
            var anotherPickedBag = locker.Pick(anotherTicket);
            
            Assert.Same(bag, pickedBag);
            Assert.Same(anotherBag, anotherPickedBag);

        }

        [Fact]
        public void should_pick_fail_when_ticket_is_already_used()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(2);
            var ticket = locker.Store(bag);
            var pickedBag = locker.Pick(ticket);
            Assert.Same(bag, pickedBag);
            Assert.Throws<TicketInvalidException>(() => locker.Pick(ticket));
        }

        [Fact]
        public void should_get_a_valid_ticket_when_give_bag_to_robot()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(1);
            Robot robot = new Robot(new[]{locker});
            var ticket = robot.Receive(bag);
            Bag bag2 = locker.Pick(ticket);
            Assert.Same(bag, bag2);
        }

        [Fact]
        public void should_fail_when_give_a_bag_to_robot_and_locker_is_full()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(0);
            Robot robot = new Robot(new[]{locker});
            Assert.Throws<LockerFullException>(() => robot.Receive(bag));
        }

        [Fact]
        public void should_store_bag_into_multiple_lockers_in_order()
        {
            Locker locker1 = new Locker(1);
            Locker locker2 = new Locker(1);
            Robot robot = new Robot(new[] {locker1, locker2});
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
            Robot robot = new Robot(new[]{new Locker(1)});
            var ticket = robot.Receive(bag);
            Assert.Same(bag, robot.Pick(ticket));
        }
    }

    public class TicketInvalidException : Exception
    {
    }

    public class LockerFullException : Exception
    {
    }

    public class Ticket
    {
    }

    public class Locker
    {
        private readonly int _capacity;
        private int _count;
        private Dictionary<Ticket, Bag> _bags; 

        public Locker(int capacity)
        {
            _capacity = capacity;
            _count = 0;
            _bags = new Dictionary<Ticket, Bag>();
        }

        public Ticket Store(Bag bag)
        {
            if (_count >= _capacity)
            {
                throw new LockerFullException();
            }
            _count++;
            var ticket = new Ticket();
            _bags.Add(ticket, bag);
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            Bag bag;
            if (_bags.ContainsKey(ticket))
            {
                bag = _bags[ticket];
                _bags.Remove(ticket);
                return bag;
            }
            throw new TicketInvalidException();
        }
    }

    public class Bag
    {
    }
}
