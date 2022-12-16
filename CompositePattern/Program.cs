// See https://aka.ms/new-console-template for more information


using CompositePattern.Classes;

var car = new MachinePartGroup { Name = "Toyota" };
car.Children.Add(new MotorGroupPart { PartName = "Piston" , PartSerial ="540821" });
car.Children.Add(new MotorGroupPart { PartName = "Block",  PartSerial = "988001" });
car.Children.Add(new TransmissionGroupPart { PartName = "Gear" ,PartSerial = "514875"});
car.Children.Add(new TransmissionGroupPart { PartName = "Clutch", PartSerial = "514800" });

var group = new MachinePartGroup { Name = "Ford" };
group.Children.Add(new MotorGroupPart { PartName = "Blue" });
group.Children.Add(new TransmissionGroupPart { PartName = "Red" });
car.Children.Add(group);

Console.WriteLine(car);