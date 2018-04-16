from django.shortcuts import render, redirect 
from models import *
from django.contrib import messages 
import bcrypt 
import re 
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

def index(request):
    if 'logged_id' not in request.session:
        return render(request, 'users/index.html')
    else: 
        return redirect('/success')

def success(request):
    context = {
        'first_name': User.objects.get(id = request.session['logged_id']).first_name,
        'last_name': User.objects.get(id = request.session['logged_id']).last_name
    }
    return render(request, 'users/success.html', context)
    
def register(request):
    errors = User.objects.validator(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
           messages.error(request, error, extra_tags=tag)
        return redirect('/')
    else:
        hashed_password = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt())
        User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=hashed_password)
        request.session['logged_id'] = User.objects.last().id
        return redirect('/success')

def login(request):
    errors = False
    if not email_regex.match(request.POST['email']):
        messages.error(request, "Invalid email")
        errors = True
    if len(request.POST['password']) < 1:
        messages.error(request, "Password cannot be blank")
        errors = True
    if errors == True:
        return redirect('/')
    users = User.objects.filter(email = request.POST['email'])
    if len(users) > 0:
        user = users[0]
        if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
            request.session['logged_id'] = user.id
            return redirect('/success')
        else:
            messages.error(request, "Unsuccessful login - incorrect password")
            return redirect('/')
    else:
        messages.error(request, "Unsuccessful login - Email does not exist")
        return redirect('/')

def logout(request):
    request.session.clear()
    return redirect('/')