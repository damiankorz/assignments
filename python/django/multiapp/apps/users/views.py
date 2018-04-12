from django.shortcuts import render, redirect, HttpResponse

def register(request):
    return HttpResponse('placeholder for users to create a new user record')

def login(request):
    return HttpResponse('placeholder for users to login')

def new(request):
    return redirect('/register')

def users(request):
    return HttpResponse('placeholder to later display all the lists of users')