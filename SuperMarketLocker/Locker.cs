using System;
using System.Collections.Generic;

namespace SuperMarketLocker
{
    public class Locker
    {
        private readonly int _capacity;
        private readonly Dictionary<Ticket, Bag> _bags; 

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
            if (_bags.Count >= _capacity)
            {
                return null;
            }
            var ticket = new Ticket();
            _bags.Add(ticket, bag);
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (ticket == null) return null;

            if (_bags.ContainsKey(ticket))
            {
                Bag bag = _bags[ticket];
                _bags.Remove(ticket);
                return bag;
            }
            return null;
        }

        public double GetBalence()
        {
            return _capacity == 0 ? 0 : AvailableCount/_capacity;
        }
    }
}