var ConversionCalc = Class.extend(
{
  init: function( )
  {
	//constructor
 

  },
  handleKeyPress: function(e)
  {
	el=$(this)
	val=el.val();
	
	id=el.attr('id')
	unit = id.substring(0,id.indexOf("_"));
	switch(unit)
	{
		case "feet":
		$("#meters_input").val(new LengthStrategy().feet_to_meters(val));
		$("#miles_input").val(new LengthStrategy().feet_to_miles(val));
		break;
		case "meters":
		$("#feet_input").val(new LengthStrategy().meters_to_feet(val));
		$("#miles_input").val(new LengthStrategy().meters_to_miles(val));
		break;
		case "miles":
		$("#meters_input").val(new LengthStrategy().miles_to_meters(val));
		$("#feet_input").val(new LengthStrategy().miles_to_feet(val));
		break;
		
		case "ounces":
		$("#quarts_input").val(new VolumeStrategy().ounces_to_quarts(val));
		$("#litres_input").val(new VolumeStrategy() .ounces_to_liters(val));
		break;
		case "quarts":
		$("#ounces_input").val(new VolumeStrategy(). quarts_to_ounces(val));
		$("#litres_input").val(new VolumeStrategy().quarts_to_liters(val));
		break;
		case "litres":
		$("#ounces_input").val(new VolumeStrategy().liters_to_ounces(val));
		$("#quarts_input").val(new VolumeStrategy().  liters_to_quarts(val));
		break;
		
		case "square-feet":
		$("#square-miles_input").val(new AreaStrategy().sqfeet_to_sqmiles(val));
		$("#acres_input").val(new AreaStrategy() .sqfeet_to_acres(val));
		break;
		case "square-miles":
		$("#square-feet_input").val(new AreaStrategy(). sqmiles_to_sqfeet(val));
		$("#acres_input").val(new AreaStrategy().sqmiles_to_acres(val));
		break;
		case "acres":
		$("#square-feet_input").val(new AreaStrategy().acres_to_sqfeet(val));
		$("#square-miles_input").val(new AreaStrategy().  acres_to_sqmiles(val));
		break;
	}
  },
  ValueAt: function(t)
  {
	return (this.p+ (this.m*t))*(1+this.r);
  }
});

var LengthStrategy = Class.extend(
{
  feet_to_meters: function(feet)
	{
		return feet /  3.28084;

	},
	feet_to_miles :function( feet)
	{
		return feet /  5280;
	},
	meters_to_feet: function( meters)
	{
		return meters *  3.28084;
	},
	meters_to_miles: function( meters)
	{
		return meters /  1609.34;
	},
	miles_to_feet: function( miles)
	{
		return miles *  5280;
	},
	miles_to_meters: function( miles)
	{
		return miles *  1609.34;
	}
});

var VolumeStrategy = Class.extend(
{
	ounces_to_liters :function(ounces)
	{
		return ounces /  33.814;
	}	,	

	ounces_to_quarts :function(ounces)
	{
		return ounces /  32;
	}	,	

	quarts_to_ounces :function(quarts)
	{
		return quarts *  32;
	},		

	quarts_to_liters :function(quarts)
	{
		return quarts /  1.05669;
	}	,	

	liters_to_ounces :function(liters)
	{
		return liters *  33.814;
	},		

	liters_to_quarts :function(liters)
	{
		return liters *  1.05669;
	}
});

var AreaStrategy = Class.extend(
{
	 sqfeet_to_sqmiles :function ( sqfeet)
	{
		return sqfeet /  27878400;
	}		,

	 sqfeet_to_acres :function ( sqfeet)
	{
		return sqfeet *  0.00002296;
	}	,	

	 sqmiles_to_sqfeet :function ( sqmiles)
	{
		return sqmiles *  27878400;
	},		

	 sqmiles_to_acres :function ( sqmile)
	{
		return sqmile *  640;
	},		

	 acres_to_sqfeet  :function( acre)
	{
		return acre *  43560;
	},		

	 acres_to_sqmiles :function ( acres)
	{
		return acres *  0.0015625;
	}		
});
 
var convert_calc = new ConversionCalc();

$("#length_form input").on("keyup", convert_calc.handleKeyPress);
$("#volume_form input").on("keyup", convert_calc.handleKeyPress);
$("#area_form input").on("keyup", convert_calc.handleKeyPress);
