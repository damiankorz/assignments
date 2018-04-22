from __future__ import unicode_literals
from django.db import models

class PostManager(models.Manager):
    def create_post(self, request):
        Post.objects.create(content=request.POST['posts'])

class Post(models.Model):
    content = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = PostManager()

