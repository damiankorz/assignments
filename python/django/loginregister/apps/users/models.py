from __future__ import unicode_literals
from django.db import models
import re 
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

class UserManager(models.Manager):
    def validator(self, postData):
        errors = {}
        if len(postData['first_name']) < 2:
            errors['len_first_name'] = "First name must contain at least two characters"
        if not postData['first_name'].isalpha():
            errors['first_name'] = "First name must contain only letters"
        if len(postData['last_name']) < 2:
            errors['len_last_name'] = "Last name must contain at least two characters"
        if not postData['last_name'].isalpha():
            errors['last_name'] = "Last name must contain only letters"
        if not email_regex.match(postData['email']):
            errors['email'] = "Invalid email"
        if len(postData['password']) < 8:
            errors['password'] = "Password must be at least eight characters long"        
        if postData['confirm_password'] != postData['password']:
            errors['confirm_passwrod'] = "Passwords did not match"
        return errors

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()



