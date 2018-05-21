$(document).ready(function(){
    // change color of any link on hover 
    $("a").mouseenter(function(){
        $(this).css("color", "navy")
    })
    $("a").mouseout(function(){
        $(this).css("color", "grey")
    })
    // change color of nav links on hover in nav bar
    $(".nav_links").mouseenter(function(){
        $(this).css("color", "white")
    })
    $(".nav_links").mouseout(function(){
        $(this).css("color", "black")
    })
});