$('#list_form button').click(function()
{
	string_list=$('input#list_calc_input').val().split(',')
	var list = string_list.map(function(i,e) {return (parseFloat(i))})
	var list_calc = new ListCalc(list);
	console.log(list_calc.sorted());
	$("#avg_val").text(list_calc.avg());
	$("#max_val").text(list_calc.max());
	$("#min_val").text(list_calc.min());
	$("#sorted_val").text(list_calc.sorted());
	return false;
});
