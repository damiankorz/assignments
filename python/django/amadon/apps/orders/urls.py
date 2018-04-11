from django.conf.urls import url
import views

urlpatterns = [
    url(r'^$', views.route),
    url(r'^amadon$', views.amadon),
    url(r'^process$', views.process),
    url(r'^checkout$', views.checkout),
    url(r'^reset$', views.reset)
]