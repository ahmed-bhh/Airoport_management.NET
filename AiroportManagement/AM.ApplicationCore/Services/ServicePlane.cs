using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        /* //DbContext ctx;
         IUnitOfWork unitOfWork;
        // IGenericRepository<Plane> repo;

         public ServicePlane(DbContext ctx,IGenericRepository<Plane> repo)
         {
            // this.ctx = ctx;//min 16:28
            // this.repo = repo;
         }

         public void Add(Plane f)
         {
           //  repo.Add(f);
                 }

         public void Delete(Plane f)
         {
            // ctx.Set<Plane>().Remove(f);
         }

         public IEnumerable<Plane> GetAll()
         {
             return ctx.Set<Plane>();
         }*/
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlanes()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
             return GetMany().OrderByDescending(p => p.PlaneType).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate);//min 31
        }

        public IEnumerable<Traveller> GetPassengers(Plane p)//min 27:40 video 9
        {
           return p.Flights.SelectMany(f=>f.Tickets)//selectmany akhater tableau de tickets 
                           .Select(t=>t.Passenger).OfType<Traveller>();//select khater passenger wehed
        }

        public bool ISAvailableFlight(int n, Flight flight)
        {
            if (flight.Plane.Capacity >= flight.Tickets.Count + n) {
                return true;            
            }
            return false;
        }
    }
}
