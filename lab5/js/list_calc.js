

var ListCalc = Class.extend({
  init: function(list){
	//constructor
	this.list=list.map(function(i){return parseFloat(i)});
	// console.log(this.list)
  },
  sorted: function(){
    return this.list.sort(function(a,b){ return a-b; });
  },
  avg: function(){
    return this.sum()/this.list.length;
  },
  max: function(){
     return this.sorted()[this.list.length-1]
  },
  min: function(){
    return this.sorted()[0]
  },
  sum: function()
 {
	var n   = this.list.length;
	var sum = 0;
	while(n--)
	   sum += this.list[n] || 0
	
	return sum;
 }
});
 

 
// var list_calc = new ListCalc(true);
// console.log(list_calc.avg());
 