from django.shortcuts import render, redirect, HttpResponse

def index(request):
    if 'count' not in request.session:
        request.session['count'] = 0
    return render(request, 'survey_app/index.html')

def results(request):
    return render(request, 'survey_app/results.html')

def process(request):
    request.session['count'] += 1
    if request.method == 'POST':
        request.session['name'] = request.POST['name']
        request.session['location'] = request.POST['location']
        request.session['language'] = request.POST['language']
        request.session['comments'] = request.POST['comments']
        return redirect('/results')

def reset(request):
    request.session.clear()
    return redirect('/')