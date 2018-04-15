from __future__ import unicode_literals
from django.db import models
import re 
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

class UserManager(models.Manager):
    def validator(self, postData):
        errors = {}
        if len(postData['first_name']) < 1:
            errors['first_name'] = 'First name cannot be empty'
        if len(postData['last_name']) < 1:
            errors['last_name'] = 'Last name cannot be empty'
        if not email_regex.match(postData['email']):
            errors['email'] = 'Invalid email'
        return errors

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()


