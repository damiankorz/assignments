from __future__ import unicode_literals
from django.db import models
import bcrypt
import re 
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

class UserManager(models.Manager):
    #validate registration
    def validator(self, data):
        errors = {}
        if len(data['name']) < 2:
            errors['name'] = "Name must contain at least two characters"
        if len(data['alias']) < 2:
            errors['alias'] = "Alias must contain at least two characters"
        if not email_regex.match(data['email']):
            errors['email'] = "Invalid email"
        if len(data['password']) < 8:
            errors['password'] = "Password must be at least eight characters long"        
        if data['confirm_password'] != data['password']:
            errors['confirm_passwrod'] = "Passwords did not match"
        return errors
    #validate login 
    def login(self, request):
        users = User.objects.filter(email = request.POST['email'])
        return users
    #create user
    def create_user(self, request):
        hashed_password = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt())
        User.objects.create(name=request.POST['name'], alias=request.POST['alias'], email=request.POST['email'], password=hashed_password)
        return 
    #grab current user
    def current_user(self, logged_id):
        user = User.objects.get(id = logged_id)
        return user

class User(models.Model):
    name = models.CharField(max_length=255)
    alias = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()