from __future__ import unicode_literals
from django.db import models

class NoteManager(models.Manager):
    def create_note(self, request):
        if request.method == 'POST':
            Note.objects.create(title=request.POST['title'], content=request.POST['content'])
    def update_note(self, request, id):
        if request.method == 'POST':
            note = Note.objects.get(id = id)
            note.content = request.POST['content']
            note.save()
    def delete_note(self, request, id):
        if request.method == 'POST':
            note = Note.objects.get(id=id)
            note.delete()

class Note(models.Model):
    title = models.CharField(max_length=255)
    content = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = NoteManager()


