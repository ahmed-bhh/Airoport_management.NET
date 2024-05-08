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
    public class ServiceFlight : Service<Flight>, IserviceFlight// theni haja nzid service flight bech njib el crud lkol
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
