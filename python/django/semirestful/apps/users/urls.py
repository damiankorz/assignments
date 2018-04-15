from django.conf.urls import url 
import views

urlpatterns = [
    url(r'^$', views.home),
    url(r'^users$', views.index),
    url(r'^users/new$', views.new),
    url(r'^users/update$', views.update),
    url(r'^users/create$', views.create),
    url(r'^users/(?P<id>\d+)/edit$', views.edit),
    url(r'^users/(?P<id>\d+)$', views.show),
    url(r'^users/(?P<id>\d+)/destroy$', views.destroy),
]