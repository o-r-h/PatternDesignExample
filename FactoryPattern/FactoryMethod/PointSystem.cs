using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.FactoryMethod
{
	/// <summary>
	/// The Factory Method  is a creational design pattern that provides an interface for creating objects but allows subclasses to alter
	/// the type of an object that will be created.
	/// </summary>
	public class PointSystem
	{
		private double x;
		private double y;

		private PointSystem(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public static class Factory
		{
			public static PointSystem NewCartesianPointSystem(double x, double y)
			{
				return new PointSystem(x, y);
			}

			public static PointSystem NewPolarPointSystem(double rho, double theta)
			{
				return new PointSystem(rho * Math.Cos(theta), rho * Math.Sin(theta));
			}

		}

		public static PointSystem Origin = new PointSystem(0, 0);

		public override string ToString()
		{
			return $"{nameof(x)}: {x}, {nameof(y)} : {y} ";
		}

	}
}
