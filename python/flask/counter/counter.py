from flask import Flask, render_template, request, session, redirect

app = Flask(__name__)
app.secret_key = "bl3nd3dsm00th13"

@app.route('/')
def index():
    if 'count' in session:
        session['count'] += 1 #update session value by 1
    else: 
        session['count'] = 1 #set session value to 1
    return render_template('index.html', count=session['count'])

@app.route('/double', methods=['POST'])
def double():
    session['count'] += 1 #update session value by 1 plus 1 from root '/'
    return redirect('/')

@app.route('/reset', methods=['POST'])
def reset():
    session['count'] = 0 #reset session value to 1 by setting to 0 plus 1 from root '/'
    return redirect('/')

app.run(debug=True)