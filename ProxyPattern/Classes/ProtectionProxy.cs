using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Classes
{

	public interface ICar {
		void Drive();
	}


	public class Car : ICar {
		public void Drive() {
			Console.WriteLine("Car is being driven");
		}
	}

	public class Driver {
		public int Age { get; set; }

		public Driver (int age)
		{
			Age = age;
		}
		
	}

	public class ProxyProtectorCar : ICar
	{
		private Driver driver;
		private Car car = new Car();

		public ProxyProtectorCar(Driver driver)
		{
			this.driver = driver;
		}

		public void Drive()
		{
			switch (driver.Age)
			{
				case <= 16:
					Console.WriteLine("Driver too young to drive");
					break;
				case >= 80:
					Console.WriteLine("Driver too old to drive");
					break;
				default:
					Console.WriteLine("Proxy-Ok");
					car.Drive();
					break;

			}
		}
	}




}
