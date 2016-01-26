$(document).ready(function(){
$("#topnav li").hover(function(){
$(this).find('ul:first').css({visibility: "visible",display: "none"}).show(500);
},function(){
$(this).find('ul:first').css({visibility: "hidden"});
})
});