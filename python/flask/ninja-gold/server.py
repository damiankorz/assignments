from flask import Flask, session, request, render_template, redirect
import random
import datetime 

app = Flask(__name__)

app.secret_key = "11-2222-33334444"

@app.route('/')
def index():
    if 'count' not in session: #set session count if doesn't exist
        session['count'] = 0
    if 'activities' not in session: #set session activities if doesn't exist
        session['activities'] = []
    return render_template('index.html')

@app.route('/process', methods=['POST'])
def process():
    time_stamp = datetime.datetime.utcnow().replace(microsecond=0) #set time stamp
    chance = random.uniform(0.0,1.0) 
    building = request.form['building']
    if building == 'farm': #if returned value is farm, update count , set message, append message to session list
        gold = random.randrange(10,21)
        session['count'] += gold
        message = "You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
        session['activities'].append(message)
    elif building == 'cave': #if returned value is cave, update count, set message, append message to session list
        gold = random.randrange(5,11)
        session['count'] += gold
        message = "You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
        session['activities'].append(message)
    elif building == 'dojo': #if returned value is dojo, update count, set message, append message to session list
        gold = random.randrange(2, 6)
        session['count'] += gold
        message = "You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
        session['activities'].append(message)
    elif building == 'casino': 
        if chance > 0.5: #if returned value is casino and chance is greater than 0.5, update count, set message, append message to session list
            gold = random.randrange(0, 51)
            session['count'] += gold
            message = "Winner! Winner! Chicken Dinner! You have earned" + " "+ str(gold) + " "+ "gold from the" + " " + building + "!" + " " + "(" + str(time_stamp) + ")"
            session['activities'].append(message)
        else: #if returned value is casino and chance is less than or equal to 0.5, update count (subtract), set message, append message to session list
            gold = random.randrange(0, 51)
            session['count'] -= gold
            message = "You entered the" + " " + building + " " + "and lost" + " " + str(gold) + " " + "gold." + " " + "(" + str(time_stamp) + ")"
            session['activities'].append(message)
    return redirect('/')

@app.route('/reset')
def reset(): #reset session 
    session.clear()
    return redirect('/')

app.run(debug=True)