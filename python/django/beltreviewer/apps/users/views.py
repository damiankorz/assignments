from django.shortcuts import render, redirect
from models import User 
from ..books.models import *
from django.contrib import messages
import bcrypt

def index(request):
    if 'logged_id' not in request.session:
        return render(request, 'users/index.html')
    else: 
        return redirect('/books')

def login(request):
    if request.method == 'POST':
        users = User.objects.login(request)
        if len(users) > 0:
            user = users[0]
            if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
                request.session['logged_id'] = user.id
                return redirect('/books')
            else:
                messages.error(request, "Unsuccessful login - incorrect password")
                return redirect('/')
        else:
            messages.error(request, "Unsuccessful login - Email does not exist")
            return redirect('/')

def register(request):
    if request.method == 'POST':
        errors = User.objects.validator(request.POST)
        if len(errors):
            for tag, error in errors.iteritems():
                messages.error(request, error, extra_tags=tag)
            return redirect('/')
        else: 
            User.objects.create_user(request)
            request.session['logged_id'] = User.objects.last().id
            return redirect('/books')

def logout(request):
    request.session.clear()
    return redirect('/')

def display_user(request, id):
    context = {
        'user': User.objects.current_user(id),
        'reviews': Review.objects.users_reviews(id),
        'count': Review.objects.count(id)
    }
    return render(request, 'users/users.html', context)
