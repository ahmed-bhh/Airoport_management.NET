﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public PlaneType PlaneType { get; set; }

        public List<Flight> Flights { get; set;}

        public override string ToString()
        {
            return "Capacity="+Capacity+"  manufacturedate="+ManufactureDate
                ;
        }





    }
}
