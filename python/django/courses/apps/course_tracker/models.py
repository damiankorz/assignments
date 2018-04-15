from __future__ import unicode_literals

from django.db import models

class CourseManager(models.Manager):
    def validator(self, postData):
        errors = {}
        if len(postData['course_name']) < 5:
            errors['course_name'] = 'Course name must be at least 5 characters long'
        if len(postData['desc']) < 15:
            errors['desc'] = 'Course description must be at least 15 characters long'
        return errors

class Course(models.Model):
    name = models.CharField(max_length=255)
    desc = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = CourseManager()
