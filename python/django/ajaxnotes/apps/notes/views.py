from django.shortcuts import render, redirect, HttpResponse
from models import Note

def index(request):
    return render(request, 'notes/index.html')

def create(request):
    Note.objects.create_note(request)
    context = {
        'notes': Note.objects.all()
    }
    return render(request, 'notes/notes.html', context)

def update(request, id):
    Note.objects.update_note(request, id)
    context = {
        'note': Note.objects.get(id = id)
    }
    return render(request, 'notes/update.html', context)

def delete(request, id):
    Note.objects.delete_note(request, id)
    return render(request, 'notes/notes.html')
    