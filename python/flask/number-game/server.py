from flask import Flask, redirect, request, session, render_template
import random

app = Flask(__name__)
app.secret_key = "numb3rz"   

# def genNum():
#     session['num'] = random.randrange(1,101)
    
@app.route('/')
def index():
    # if 'num' in session:
    #     session['num'] = random.randrange(1,101)
    #     genNum() 
    # else: 
    #     pass 
    session['num'] = random.randrange(1,101)
    return render_template('index.html')

@app.route('/guess', methods=['POST'])
def guess():
    session['guess'] = int(request.form['guess'])
    return redirect('/')

@app.route('/reset', methods=['POST'])
def reset():
    genNum()
    return redirect('/')

app.run(debug=True)