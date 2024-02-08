using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {

      IEnumerable<DateTime>  GetFlightDates(String destination);
        void GetFlights(string filterType, string filterValue);
    }
}
