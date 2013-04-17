var Convert= Class.extend(
	{
	  init: function()
	  {
		this.convert_strategy=null;

	  },
		Units:
		{
			Feet:0,
			Mile:1,
			Meter:2,
			Ounce:3,
			Liter:4,
			Quart:5,
			SquareMile:6,
			SquareFeet:7,
			Acre:8
			},

		ParseUnitsString: function(string_unit)
		{
			var unit;	
			switch (string_unit) {
			case "meter":
				unit = new Convert().Units.Meter;
				break;
			case "feet":
				unit = new Convert().Units.Feet;
				break;
			case "mile":
				unit = new Convert().Units.Mile;
				break;
			case "ounce":
				unit = new Convert().Units.Ounce;
				break;
			case "liter":
				unit = new Convert().Units.Liter;
				break;
			case "quart":
				unit = new Convert().Units.Quart;
				break;
			case "sqfeet":
				unit = new Convert().Units.SquareFeet;
				break;
			case "sqmile":
				unit = new Convert().Units.SquareMile;
				break;
			case "acre":
				unit = new Convert().Units.Acre;
				break;
			default:
				throw new Exception ("Could not parse: " + string_unit);
			}

			return unit;
		},
 
		SetConvertStrategy: function(convert_strategy)
		{
			this.convert_strategy = convert_strategy;
		},


		//needs generics??? just assuming double for now
		convert: function( magnitude,  from,  to)
		{
			return this.convert_strategy.convert (magnitude, from, to);
		}

	});