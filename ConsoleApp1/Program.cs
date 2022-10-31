/**
The problem solved by the builder pattern is easy to identify. This pattern should be used:

	-When it’s necessary to use a constructor with a long parameter list or when there’s a long list of constructors
	 with different parameters.

	-When it’s necessary to build different representations of the same object. That is, when objects of
	 the same class with different characteristics are needed.
**/



HouseBuilder hb = new HouseBuilder();
House house1 = hb
	.BasicFeatureBuilder
		.SetName("House Confort")
		.SetFloors(1)
		.SetRooms(2)
	.OptionalFeatureBuilder
		.SetPool(false)
		.SetBasement(false)
		.SetSauna(false);
 Console.WriteLine(house1);
Console.WriteLine("--------------------");
House house2 = hb
	.BasicFeatureBuilder
		.SetName("House Luxury")
		.SetColor("Soft Blue")
		.SetFloors(2)
		.SetRooms(4)
	.OptionalFeatureBuilder
		.SetSauna(true)
		.SetBasement(true)
		.SetPool(true)
		.SetSauna(true);
Console.WriteLine(house2);


public class House{
	//basic feature
	public string Name { get; set; } = "";
	public string Color { get; set; } = "White";
	public int  Rooms { get; set; } = 1;
	public int Floors { get; set; } = 1;
	//optionals features
	public bool Pool { get; set; }
	public bool Sauna { get; set; }
	public bool Basement { get; set; }
	public bool Gym { get; set; }

	public override string ToString()
	{
		return $"Name: {Name}  - Color: {Color}   -Rooms:{Rooms}  -Floors:{Floors} " + Environment.NewLine +
		$" Features: " + Environment.NewLine +
		$" *Pool: {Pool}   *Sauna: {Sauna}  *Basement {Basement}  *Gym {Gym} ";
	}

}

public class HouseBuilder{   //the constructor is a separate component whose sole purpose in life is to build an object.
		protected House house = new House();

		//You can now give the constructor a constructor there by allowing it to exist as a separate standalone component that someone else
		public HouseBasicFeatureBuilder BasicFeatureBuilder => new HouseBasicFeatureBuilder(house);
		public HouseOptionalFeatureBuilder OptionalFeatureBuilder => new HouseOptionalFeatureBuilder(house);

		//important part to return the class on api
		public static implicit operator House (HouseBuilder hb ){
			return hb.house;	
		}
	}

	#region BasicFeature
	public class HouseBasicFeatureBuilder : HouseBuilder{  
		public HouseBasicFeatureBuilder(House house)
		{
		 this.house = house;
		}

		public HouseBasicFeatureBuilder SetName(string name)
		{
			house.Name = name;
			return this;
		}
		public HouseBasicFeatureBuilder SetColor(string color)
		{
			house.Color = color;
			return this;  //to make a builder fluid just return this
		}
		public HouseBasicFeatureBuilder SetRooms(int rooms)
		{
			house.Rooms = rooms;
			return this;
		}
		public HouseBasicFeatureBuilder SetFloors(int floors)
		{
			house.Floors = floors;
			return this;
		}

	}
	#endregion


	#region OptionalFeature
	public class HouseOptionalFeatureBuilder : HouseBuilder
	{
		public HouseOptionalFeatureBuilder(House house)
		{
			this.house = house;
		}

		public HouseOptionalFeatureBuilder SetPool(bool pool){
			house.Pool = pool;
			return this;
		}

		public HouseOptionalFeatureBuilder SetSauna(bool sauna)
		{
			house.Sauna = sauna;
			return this;
		}

		public HouseOptionalFeatureBuilder SetBasement(bool basement)
		{
			house.Basement = basement;
			return this;
		}

		public HouseOptionalFeatureBuilder SetGym(bool gym)
		{
		house.Gym = gym;
		return this;
		}




}
#endregion








