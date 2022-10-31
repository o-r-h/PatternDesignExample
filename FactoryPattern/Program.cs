// See https://aka.ms/new-console-template for more information
using FactoryPattern.FactoryMethod;
using FactoryPattern.FactoryAbstract;


//Example for Factory Method
var point = PointSystem.Factory.NewCartesianPointSystem(1.0, 32.12);
var point2 = PointSystem.Factory.NewPolarPointSystem(3, 1.12);
var origin = PointSystem.Origin;
Console.WriteLine(point);
Console.WriteLine(point2);
Console.WriteLine(origin);


//Example for Abstract Method
var machine = new TransportMachineSelector();
ITransport transport = machine.MakeTravel();
transport.DoTravel();
