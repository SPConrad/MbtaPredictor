using MbtaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbtaPredictor.Services
{
    public interface ITripData
    {
        IEnumerable<Trip> GetAll();

        Trip Get(int id);

        Trip Add(Trip newTrip);

        void Commit();
    }

    public class SqlTripData : ITripData
    {
        private MbtaDbContext _context;

        public SqlTripData(MbtaDbContext context)
        {
            _context = context;
        }

        public Trip Add(Trip newTrip)
        {
            _context.Add(newTrip);
            //may not want SaveChanges() to be here, want to be sure all changes
            //are read to be saved before doing so
            _context.SaveChanges();
            return newTrip;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Trip Get(int id)
        {
            return _context.Trips.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Trip> GetAll()
        {
            return _context.Trips;
        }
    }

    public class InMemoryTripData : ITripData
    {
        static List<Trip> _trips;



        static InMemoryTripData()
        {
            List<string> _lon = new List<string>() { "42.11111", "42.88888" };
            List<string> _lat = new List<string>() { "-71.01317", "-71.30001" };
            List<int> _bearing = new List<int>() { 101, 202 };
            List<string> _timestamp = new List<string>() { "1484690000" , "1484695555" };

            List<string> _lon1 = new List<string>() { "42.22222", "42.99999" };
            List<string> _lat1 = new List<string>() { "-71.00000", "-71.333333" };
            List<int> _bearing1 = new List<int>() { 117, 188 };
            List<string> _timestamp1 = new List<string>() { "1484689999", "1484692222" };
            _trips = new List<Trip>
            {
                new Trip { Id = 1, trip_id = 100,
                    tripHeadSign = "Braintree", tripName = "4:43 PM to Braintree",
                    vehicle = new Vehicle { id = "100", bearing = _bearing, label=1745,
                    lat = _lat, lon = _lon, timestamp = _timestamp} },
                new Trip { Id = 2, trip_id = 200,
                    tripHeadSign = "Braintree", tripName = "4:43 PM to Braintree",
                    vehicle = new Vehicle { id = "200", bearing = _bearing, label=1745,
                    lat = _lat, lon = _lon, timestamp = _timestamp} }
            };
        }

        public IEnumerable<Trip> GetAll()
        {
            return _trips;
        }

        public Trip Get(int id)
        {
            return _trips.FirstOrDefault(r => r.Id == id); 
        }

        public Trip Add(Trip newTrip)
        {
            newTrip.Id = _trips.Max(r => r.Id) + 1;
            _trips.Add(newTrip);

            return newTrip;
        }

        public void Commit()
        {
            ///... no op
        }
    }
}
