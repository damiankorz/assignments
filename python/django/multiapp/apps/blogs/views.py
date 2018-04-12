from django.shortcuts import render, HttpResponse, redirect

def index(request):
    return redirect('/blogs')

def blogs(request):
    return HttpResponse("placeholder to later display all the list of blogs")

def new(request):
    return HttpResponse("placeholder to display a new form to create a new blog")

def create(request):
    return redirect('/blogs')

def show(request, number):
    return HttpResponse("placeholder to display to display blog" + " " + number)

def edit(request, number):
    return HttpResponse("placeholder to edit blog number" + " " + number)

def destroy(request, number):
    return redirect('/blogs')