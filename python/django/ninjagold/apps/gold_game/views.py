from django.shortcuts import render, redirect, HttpResponse
import random
import datetime

def index(request):
    if 'count' not in request.session:
        request.session['count'] = 0
    if 'activities' not in request.session:
        request.session['activities'] = []
    return render (request, 'gold_game/index.html')

def process(request):
    time_stamp = datetime.datetime.utcnow().replace(microsecond=0) #set time stamp
    chance = random.uniform(0.0,1.0) 
    building = request.POST['building']
    if building == 'farm': #if returned value is farm, update count , set message, append message to request.session list
        gold = random.randrange(10,21)
        request.session['count'] += gold
        message = "You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
        request.session['activities'].append(message)
    elif building == 'cave': #if returned value is cave, update count, set message, append message to request.session list
        gold = random.randrange(5,11)
        request.session['count'] += gold
        message = "You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
        request.session['activities'].append(message)
    elif building == 'dojo': #if returned value is dojo, update count, set message, append message to request.session list
        gold = random.randrange(2, 6)
        request.session['count'] += gold
        message = "You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
        request.session['activities'].append(message)
    elif building == 'casino': 
        if chance > 0.5: #if returned value is casino and chance is greater than 0.5, update count, set message, append message to request.session list
            gold = random.randrange(0, 51)
            request.session['count'] += gold
            message = "Winner! Winner! Chicken Dinner! You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
            request.session['activities'].append(message)
        else: #if returned value is casino and chance is less than or equal to 0.5, update count (subtract), set message, append message to request.session list
            gold = random.randrange(0, 51)
            request.session['count'] -= gold
            message = "You entered the" + " " + building + " " + "and lost" + " " + str(gold) + " " + "gold." + " " + "(" + str(time_stamp) + ")"
            request.session['activities'].append(message)
    return redirect('/')

def reset(request):
    request.session.clear()
    return redirect('/')


