using System.Collections.Generic;

namespace SuperMarketLocker
{
    public class Locker
    {
        private readonly int _capacity;
        private Dictionary<Ticket, Bag> _bags;
        
        public int AvailableCapacity
        {
            get { return _capacity - _bags.Count; }
        }
        
        public double VacancyRate
        {
            get { return AvailableCapacity / _capacity; }
        }

        public Locker(int capacity)
        {
            _capacity = capacity;
            _bags = new Dictionary<Ticket, Bag>();
        }

        

        public Ticket Store(Bag bag)
        {
            if (_capacity == 0) return null;
            if (_bags.Count >= _capacity) return null;
            var ticket = new Ticket();
            _bags.Add(ticket, bag);
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            Bag bag = null;
            if (_bags.ContainsKey(ticket))
            {
                bag = _bags[ticket];
                _bags.Remove(ticket);
                
            }
            return bag;
        }
    }
}