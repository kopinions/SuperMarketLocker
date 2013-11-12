using System.Collections.Generic;
using SuperMarketLocker.Test;

namespace SuperMarketLocker
{
    public class Locker
    {
        private readonly int _capacity;
        private Dictionary<Ticket, Bag> _bags; 

        public Locker(int capacity)
        {
            _capacity = capacity;
            _bags = new Dictionary<Ticket, Bag>();
        }

        public int AvailableCount
        {
            get { return _capacity - _bags.Count; }
        }

        public Ticket Store(Bag bag)
        {
            if (_capacity == 0) throw new LockerFullException();
            if (_bags.Count >= _capacity)
            {
                throw new LockerFullException();
            }
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

        public double getBalence()
        {
            return (AvailableCount/_capacity);
        }
    }
}