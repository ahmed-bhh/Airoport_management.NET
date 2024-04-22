// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");

Passenger p1 = new Passenger() { FullName = new FullName { FirstName = "amina", LastName = "Aoun" },EmailAdress="ahmed@esprit.tn"};

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
Console.WriteLine(p1.FullName.FirstName+"/t"+p1.FullName.LastName);

//insertion dans la bade de donnees

AMContext ctx=new AMContext();
/*
ctx.Planes.Add(TestData.Airbusplane);
ctx.Planes.Add(TestData.BoingPlane);
ctx.FLights.Add(TestData.flight1);
ctx.FLights.Add(TestData.flight2);

ctx.SaveChanges();//mouhema hedhi
*/
IUnitOfWork uow = new UnitOfWork(ctx);
IServicePlane sp = new ServicePlane(uow);
IserviceFlight sf = new ServiceFlight(uow);
//ctx.Set<Plane>().Add(TestData.BoingPlane);
sp.Add(TestData.BoingPlane);
sp.Add(TestData.Airbusplane);
sf.Add(TestData.flight1);
sf.Add(TestData.flight2);
sf.Commit();





Console.WriteLine("ajout avec succés");

//afficher le contenu

foreach (Flight fl in sf.GetMany())
{
   Console.WriteLine(fl.FlightDate + " destination " + fl.Destination + " plance capacity " + fl.Plane.Capacity);
   // Console.WriteLine(fl.FlightDate + " destination " + fl.Destination );

}




