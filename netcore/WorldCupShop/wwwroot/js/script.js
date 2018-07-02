$(document).ready(function(){
    $('.nav_links').mouseenter(function(){
        $(this).css("color", "black")
        $(this).parent().css("background-color", "white")
    })
    $('.nav_links').mouseout(function(){
        $(this).css("color", "white")
        $(this).parent().css("background-color", "#2626a0")
    })
    $('.form_button').mouseenter(function(){
        $(this).css("color", "black")
        $(this).css("background-color", "white")
    })
    $('.form_button').mouseout(function(){
        $(this).css("color", "white")
        $(this).css("background-color", "red")
    })
    $('.links').mouseenter(function(){
        $(this).css("text-decoration", "underline")
    })
    $('.links').mouseout(function(){
        $(this).css("text-decoration", "none")
    })
});
