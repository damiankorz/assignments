from django.shortcuts import render, HttpResponse, redirect
from time import gmtime, strftime

def home(request):
    return redirect('/time_display')

def index(request):
    context = {
        'time': strftime('%Y-%m-%d %H:%M %p', gmtime())
    }
    return render(request, 'time_display/index.html', context)