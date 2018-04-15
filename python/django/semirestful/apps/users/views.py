from django.shortcuts import render, redirect, HttpResponse
from models import *
from django.contrib import messages

def home(request):
    return redirect('/users')

def index(request):
    context = {
        'users': User.objects.all(),
    }
    return render(request, 'users/index.html', context)

def new(request):
    return render(request, 'users/new.html')

def edit(request, id):
    context = {
        'user_id': id,  
        'first_name': User.objects.get(id=id).first_name,
        'last_name': User.objects.get(id=id).last_name,
        'email': User.objects.get(id=id).email,
    }
    return render(request, 'users/edit.html', context)

def show(request, id):
    context = {
        'user_id': id,  
        'first_name': User.objects.get(id=id).first_name,
        'last_name': User.objects.get(id=id).last_name,
        'email': User.objects.get(id=id).email,
        'created_at': User.objects.get(id=id).created_at
    }
    return render(request, 'users/show.html', context)

def create(request):
    errors = User.objects.validator(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/users/new')
    else:
        User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'])
        user = User.objects.last()
        user_id = user.id
        return redirect('/users/' + str(user_id))

def destroy(request, id):
    del_user = User.objects.get(id=id)
    del_user.delete()
    return redirect('/users')

def update(request):
    errors = User.objects.validator(request.POST)
    user_id = request.POST.get('hidden')
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/users/' + user_id + '/edit')
    else:
        user = User.objects.get(id = user_id)
        user.first_name = request.POST['first_name']
        user.last_name = request.POST['last_name']
        user.email = request.POST['email']
        user.save()
        return redirect('/users/' + user_id)
