from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string

def home(request):
    return redirect('/random_word')

def index(request):
    if 'count' not in request.session:
        request.session['count'] = 0
    if request.method == 'POST':
        request.session['rand_word'] = get_random_string(length=10)
        request.session['count'] += 1
        return redirect('/random_word')
    else:
        return render(request, 'word_gen/index.html')

def reset(request):
    request.session.clear()
    return redirect('/random_word')