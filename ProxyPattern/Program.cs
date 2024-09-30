/**
The problem solved by the proxy pattern is easy to identify. This pattern should be used:

	-When it’s necessary one class will be affect another one and you don't want/able to modify
	 your code.
**/


using ProxyPattern.Classes;
using System;

namespace ProxyPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("** Example for protected proxy! **");
			Driver driver = new Driver(16);
			Driver driver2 = new Driver(24);
			ICar proxyProtector = new ProxyProtectorCar(driver);
			proxyProtector.Drive();
			proxyProtector = new ProxyProtectorCar(driver2);
			proxyProtector.Drive();

			Console.WriteLine("--------------------------------");




		}
	}
}
