from django.shortcuts import render, redirect, HttpResponse
from time import localtime, strftime 

def route(request):
    return redirect('/session_words')

def index(request):
    if 'words' not in request.session: 
        request.session['words'] = []
    else:
        request.session['words'] = request.session['words']
    return render(request, 'session_words/index.html')

def add(request):
    time = strftime('%H:%M %p %B-%d-%Y', localtime())
    if request.method == 'POST':
        request.session['color'] = request.POST.get('color')
        request.session['size'] = request.POST.get('size')
        if len(request.POST['word']) < 1:
            request.session['word'] = '?'
        else:
            request.session['word'] = request.POST['word']
        context = {
            'word': request.session['word'],
            'color': request.session['color'],
            'size': request.session['size'],
            'time': time
        }
        request.session['words'].append(context)
        print context
        return redirect('/session_words')

def clear(request):
    request.session.clear()
    return redirect('/session_words')
