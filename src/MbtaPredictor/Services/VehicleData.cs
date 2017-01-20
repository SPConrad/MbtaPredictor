using MbtaPredictor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbtaPredictor.Services
{
    public interface IVehicleData
    {
        IEnumerable<Vehicle> GetAll();

        Vehicle Get(int id);

        Vehicle Add(Vehicle newVehicle);

        void Commit();
    }

    public class sqlVehicleData : IVehicleData
    {
        private MbtaDbContext _context;

        public sqlVehicleData(MbtaDbContext context)
        {
            _context = context;
        }

        public Vehicle Add(Vehicle newVehicle)
        {
            _context.Add(newVehicle);
            _context.SaveChanges();
            return newVehicle;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Vehicle Get(int id)
        {
            return _context.Vehicles.FirstOrDefault(r => r.Vehicle_Id == id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _context.Vehicles;
        }
    }

    public class InMemoryVehicleData : IVehicleData
    {
        static List<Vehicle> _vehicles;

        public Vehicle Add(Vehicle newVehicle)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Vehicle Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
