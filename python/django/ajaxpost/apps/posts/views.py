from django.shortcuts import render, redirect, HttpResponse
from django.core import serializers 
from models import Post 

def index(request):
    context = {
        'posts': Post.objects.all()
    }
    return render(request, 'posts/index.html', context)

def create(request):
    Post.objects.create(content=request.POST['posts'])
    context = {
        'post': Post.objects.last()
    }
    return render(request, 'posts/all.html', context)