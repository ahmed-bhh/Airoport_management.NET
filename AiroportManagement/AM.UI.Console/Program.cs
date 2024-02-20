// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

Passenger p1 = new Passenger() { FirstName="amina",LastName="Aoun",EmailAdress="ahmed@esprit.tn"};

Plane plane = new Plane();
plane.Capacity = 100;
Console.WriteLine(plane.Capacity);
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boeing;

Plane plane2 = new Plane { Capacity=200,PlaneType=PlaneType.Airbus,ManufactureDate=DateTime.Now};

Console.WriteLine(plane);

Console.WriteLine("*********partie2*********");
FlightMethods fm=new FlightMethods();
fm.Flights = TestData.listFlights;
/*fm.GetFlightDates("Madrid");
fm.GetFlights("destination", "Paris");
*/

//fm.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2021, 12, 31)));
p1.UpperFullName();
Console.WriteLine(p1.FirstName+"/t"+p1.LastName);
