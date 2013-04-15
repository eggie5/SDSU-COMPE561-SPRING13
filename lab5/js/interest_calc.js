var InterestCalc = Class.extend(
{
  init: function(initial, monthly, interest)
  {
	//constructor
	this.p=parseFloat(initial);
	this.m=parseFloat(monthly);
	this.r=parseFloat(interest)/100.0;

  },
  ValueAt: function(t)
  {
	return (this.p+ (this.m*t))*(1+this.r);
  }
});
 

$('#interest_form button').click(function()
{
	var calc = new InterestCalc($("#initial").val(), $("#monthly").val(), $("#rate").val());
	var time = parseFloat($("#time").val());

	var tbody=$("#interest_table tbody");
	tbody.empty();
	for(i=0;i<time;i++)
	{
		tbody.append("<tr><td>"+i+"</td><td>"+calc.ValueAt(i)+"</td></tr>");
	}
	
	return false;
});
