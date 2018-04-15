from django.shortcuts import render, redirect
from django.contrib import messages
from models import *

def index(request):
    context = {
        'courses': Course.objects.all()
    }
    return render(request, 'course_tracker/index.html', context)

def create(request):
    errors = Course.objects.validator(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/')
    else: 
        Course.objects.create(name=request.POST['course_name'], desc=request.POST['desc'])
        return redirect('/')

def destroy(request, id):
    context = {
        'id': Course.objects.get(id=id).id,
        'name': Course.objects.get(id=id).name,
        'desc': Course.objects.get(id=id).desc
    }
    return render(request, 'course_tracker/destroy.html', context)

def confirm(request, id):
    rem_course = Course.objects.get(id=id)
    rem_course.delete()
    return redirect('/')
