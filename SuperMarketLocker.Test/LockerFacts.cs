using System;

using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuperMarketLocker.Test
{
    public class LockerFacts
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
        public void shoule_return_null_when_locker_is_full()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(1);
            var ticket = locker.Store(bag);
            Bag anotherBag = new Bag();
            Assert.Null(locker.Store(anotherBag));
        }

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
        public void should_return_null_when_ticket_is_already_used()
        {
            Bag bag = new Bag();
            Locker locker = new Locker(2);
            var ticket = locker.Store(bag);
            var pickedBag = locker.Pick(ticket);
            Assert.Same(bag, pickedBag);
            Assert.Null(locker.Pick(ticket));
        }

        
    }
}
