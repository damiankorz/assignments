from django.conf.urls import url 
from . import views 

urlpatterns = [
    url(r'^$', views.route),
    url(r'^session_words$', views.index),
    url(r'^add_words$', views.add),
    url(r'^clear$', views.clear)
]