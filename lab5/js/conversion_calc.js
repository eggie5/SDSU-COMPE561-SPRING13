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
 
var convert_calc = new ConversionCalc();

$("#length_form input").on("keyup", convert_calc.handleKeyPress);
$("#volume_form input").on("keyup", convert_calc.handleKeyPress);
$("#area_form input").on("keyup", convert_calc.handleKeyPress);
