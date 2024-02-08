// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");


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
fm.GetFlightDates("Madrid");
fm.GetFlights("destination", "Paris");