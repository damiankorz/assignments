from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/ninjas')
def ninjas():
    return render_template('tmnt.html')

@app.route('/ninjas/blue')
def blue():
    return render_template('leonardo.html')

@app.route('/ninjas/orange')
def orange():
    return render_template('michelangelo.html')

@app.route('/ninjas/red')
def red():
    return render_template('raphael.html')

@app.route('/ninjas/purple')
def purple():
    return render_template('donatello.html')

@app.errorhandler(404)
def notFound(e):
    return render_template('april.html')

app.run(debug=True)
