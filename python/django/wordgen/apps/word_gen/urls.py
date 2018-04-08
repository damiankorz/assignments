from django.conf.urls import url
from . import views

urlpatterns = [
    url('^$', views.home),
    url('^random_word$', views.index),
    url('^reset$', views.reset)
]