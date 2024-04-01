using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods 
    {
        public List<Flight> Flights { get; set; }= new List<Flight>();

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> dates = new List<DateTime>();
            /*
            for(int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                   // Console.WriteLine(Flights[i].FlightDate);
                    dates.Add(Flights[i].FlightDate);

                }
            }
            return dates;*/
            /*
                        foreach (var flight in Flights)
                        {
                            if(flight.Destination == destination)
                            { dates.Add(flight.FlightDate);
                                Console.WriteLine(flight.FlightDate);
                            }
                        }
                        return dates;
            */

            dates = from f in Flights where f.Destination == destination
                    select f.FlightDate;

            dates=Flights.Where(f=>f.Destination == destination)
                         .Select(f=>f.FlightDate)
                         .ToList();
            return dates;
        }

        public void GetFlights(string filterType,string filterValue)
        {
           
               switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    break;
                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure.Equals(filterValue))
                            Console.WriteLine(f);
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                        if (f.FlightDate.Equals(DateTime.Parse(filterValue)))
                            Console.WriteLine(f);
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration.Equals(int.Parse(filterValue)))
                            Console.WriteLine(f);
                    break;
                default:
                    Console.WriteLine("Filtre introuvable");
                    break;
            }

        }

        public void ShowFlightDetails(Plane plane)
        {
            var details=from f in Flights
                        where f.Plane == plane
                        select new { f.FlightDate, f.Destination };

            var req2 = Flights.Where(f => f.Plane == plane)
                              .Select(f=>new { f.FlightDate, f.Destination });
            foreach(var f in details)
            {
                Console.WriteLine(f.ToString());
            }


        }


        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //  var week=from f in Flights where f.FlightDate>=startDate && f.FlightDate<startDate.AddDays(7) select f;

            var res = from f in Flights
                      where (f.FlightDate - startDate).TotalDays <= 7 && (f.FlightDate - startDate).TotalDays > 0
                      select f;
            var res2 = Flights.Where(f => DateTime.Compare(startDate, f.FlightDate)<0 && (f.FlightDate-startDate).TotalDays<7);

            return res.Count() ;
        }

        public double DurationAverage(string destination)
        {
            var des = from f in Flights
                      where f.Destination == destination
                      select f.EstimatedDuration;

            var req2 = Flights.Where(f => f.Destination == destination)
                              .Average(f => f.EstimatedDuration);
           return des.Average();
        }
       public IEnumerable<Flight> OrderedDurationFligh()
        {

           var flights = from f in Flights orderby f.EstimatedDuration  select f;
            var flights2=Flights.OrderByDescending(f => f.EstimatedDuration);
            return flights;
        }
      /*  public IEnumerable<Passenger> SenarioTravellers(Flight flight) {

            var res = from t in flight.Passengers.OfType<Traveller>()
                      orderby t.BirthDate
                      select t;
            var res2 = flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate);

            return res.Take(3);

        }*/
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            var req2 = Flights.GroupBy(f => f.Destination);

            return req;
        }
        public void afficherGroupedFlights(IEnumerable<IGrouping<string, Flight>> g)
        {
            foreach (var group in g)
            {
                Console.WriteLine("Destination " + group.Key);
                foreach (var flight in group)
                {
                    Console.WriteLine("Décollage :" + flight.FlightDate);
                }
            }
        }

    }
}
