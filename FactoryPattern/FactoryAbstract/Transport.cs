using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.FactoryAbstract
{

	public interface ITransport
	{
		void DoTravel();
	}

	internal class Airplane :ITransport
	{
		public void DoTravel()
		{
			Console.WriteLine("Finish Check Airplane mail");
		}
	}

	internal class Truck : ITransport
	{
		public void DoTravel()
		{
			Console.WriteLine("Finish Check Truck mail");
		}
	}

	internal class Train : ITransport
	{
		public void DoTravel()
		{
			Console.WriteLine("Finish Check Train mail");
		}
	}



	public interface ITransportFactory
	{
		ITransport SetEmailForTravel(decimal weight);
	}

	internal class TruckFactory : ITransportFactory
	{
		public ITransport SetEmailForTravel(decimal weight)
		{
			Console.WriteLine($"..Checking weight");
			Console.WriteLine($"..Prepare truck mail sticker");
			Console.WriteLine($"..Sent mail");
			return new Truck();
		}	
	}

	internal class AirplaneFactory: ITransportFactory
	{
		public ITransport SetEmailForTravel(decimal weight)
		{
			Console.WriteLine($"..Checking weight");
			if (weight > 50){
				Console.WriteLine($"..Maximum weight is (50) exceeded> Actual weight: {weight} ");
				Console.WriteLine($"..Mail Rejected>");
				return new Airplane();
			}
			Console.WriteLine($"..Prepare airplane mail sticker >");
			Console.WriteLine($"..Sent mail");
			return new Airplane();
		}
	}

	internal class TrainFactory: ITransportFactory
	{
		public ITransport SetEmailForTravel(decimal weight)
		{
			Console.WriteLine($"..Checking weight");
			Console.WriteLine($"..Prepare Train mail sticker >");
			Console.WriteLine($"..Sent mail");
			return new Train();
		}
	}

	public class TransportMachineSelector
	{
		private List<Tuple<string, ITransportFactory>> namedFactories = 
		new List<Tuple<string, ITransportFactory>>();
		
		public TransportMachineSelector()
		{
			foreach (var t in typeof(TransportMachineSelector).Assembly.GetTypes())
			{
				if (typeof(ITransportFactory).IsAssignableFrom(t) && !t.IsInterface)
				{
					namedFactories.Add(Tuple.Create(
					  t.Name.Replace("Factory", string.Empty), (ITransportFactory)Activator.CreateInstance(t)));
				}
			}


		}

		public ITransport MakeTravel()
		{
			Console.WriteLine("Available travels options");
			for (var index = 0; index < namedFactories.Count; index++)
			{
				var tuple = namedFactories[index];
				Console.WriteLine($"{index}: {tuple.Item1}");
			}

			while (true)
			{
				string s;
				if ((s = Console.ReadLine()) != null && int.TryParse(s, out int i) 	&& i >= 0
					&& i < namedFactories.Count)
				{
					Console.Write("Specify weight: ");
					s = Console.ReadLine();
					if (s != null	&& int.TryParse(s, out int weight) && weight > 0)
					{
						return namedFactories[i].Item2.SetEmailForTravel(weight);
					}
				}
				Console.WriteLine("Incorrect input, try again.");
			}

		}


	}

	

}
