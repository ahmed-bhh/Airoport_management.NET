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
    public class ServiceFlight : IserviceFlight
    {
        DbContext ctx;

        public ServiceFlight(DbContext ctx)
        {
         //   this.ctx = ctx;//min 16:28
        }

        public void Add(Flight f)
        {
            throw new NotImplementedException();
        }

        public void Delete(Flight f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
