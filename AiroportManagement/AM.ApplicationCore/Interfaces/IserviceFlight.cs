using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IserviceFlight:IService<Flight>//awel haja nasna3 l interface flight w naamel heritage bil interface Iservice
    {
        //houni nzid les services spécifique
        IEnumerable<Flight> SortFlights(); 
    }
}
