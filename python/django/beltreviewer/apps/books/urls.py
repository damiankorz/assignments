from django.conf.urls import url 
from . import views

urlpatterns = [
    url(r'^books$', views.home),
    url(r'^books/add$', views.add),
    url(r'^books/create$', views.create),
    url(r'^books/(?P<id>\d+)/delete/(?P<review_id>\d+)$', views.delete),
    url(r'^books/(?P<id>\d+)$', views.display_book),
    url(r'^books/(?P<id>\d+)/add_review$', views.add_review)
]