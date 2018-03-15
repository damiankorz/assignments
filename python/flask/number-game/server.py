from flask import Flask, redirect, request, session, render_template
import random

app = Flask(__name__)
app.secret_key = "numb3rz"   

def genNum():
    session['num'] = random.randrange(1,101)
    
@app.route('/')
def index():
    if 'num' not in session:
        genNum()
    return render_template('index.html')

@app.route('/guess', methods=['POST'])
def guess():
    guess = int(request.form['guess'])
    if guess < session['num']:
        session['guess'] = "low"
    elif guess > session['num']:
        session['guess'] = "high"
    else: 
        session['guess'] = "correct"
    return redirect('/')

@app.route('/reset', methods=['POST'])
def reset():
    session.clear()
    return redirect('/')

app.run(debug=True)