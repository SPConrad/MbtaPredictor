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
            return _context.Trips.FirstOrDefault(r => r.Trip_Id == id);
        }

        public IEnumerable<Trip> GetAll()
        {
            return _context.Trips;
        }
    }

    public class InMemoryTripData : ITripData
    {
        private static List<Trip> _trips;
        private static List<Vehicle> _vehicles;

        static InMemoryTripData()
        {
            /*_trips = new List<Trip>
            {
                new Trip { Id = "100",
                    TripHeadSign = "Braintree", TripName = "4:43 PM to Braintree",
                    Vehicle = "1" },
                new Trip { Id = "200",
                    TripHeadSign = "Braintree", TripName = "4:53 PM to Braintree",
                    Vehicle = "2" }
            };

            _vehicles = new List<Vehicle>
            {
                new Vehicle { Vehicle_Id = "1", Lat = "42.11111", Lon = "-71.00000", Bearing = 117, Timestamp = "1484689979", Label = "1745" },
                new Vehicle { Vehicle_Id = "2", Lat = "42.21111", Lon = "-71.10000", Bearing = 119, Timestamp = "1484689979", Label = "1845" },
                new Vehicle { Vehicle_Id = "1", Lat = "42.51111", Lon = "-71.20000", Bearing = 127, Timestamp = "1484689989", Label = "1945" },
                new Vehicle { Vehicle_Id = "2", Lat = "42.31111", Lon = "-71.30000", Bearing = 107, Timestamp = "1484689989", Label = "2045" },
                new Vehicle { Vehicle_Id = "3", Lat = "42.41111", Lon = "-71.40000", Bearing = 157, Timestamp = "1484689999", Label = "2145" },
            };*/
        }

        public IEnumerable<Trip> GetAll()
        {
            return _trips;
        }

        public Trip Get(int id)
        {
            return _trips.FirstOrDefault(r => r.Trip_Id == id); 
        }

        public Trip Add(Trip newTrip)
        {
            
            _trips.Add(newTrip);

            return newTrip;
        }

        public void Commit()
        {
            ///... no op
        }
    }
}
