from django.conf.urls import url 
import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^create', views.create),
    url(r'^courses/destroy/(?P<id>\d+)$', views.destroy),
    url(r'^courses/destroy/(?P<id>\d+)/confirm$', views.confirm),
]