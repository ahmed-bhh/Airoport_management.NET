using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boeing,
        Airbus
    }
    public class Plane
    {

        public int PlaneId { get; set; }
        [Range(0,int.MaxValue)] //valeur positif
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }
        [NotMapped]

        public string Information { get { return PlaneId + " " + ManufactureDate + " " + Capacity; } }
        public PlaneType PlaneType { get; set; }

        public virtual
            List<Flight> Flights { get; set;}

        public override string ToString()
        {
            return "Capacity="+Capacity+"  manufacturedate="+ManufactureDate
                ;
        }





    }
}
