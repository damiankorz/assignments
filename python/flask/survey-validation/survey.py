from flask import Flask, render_template, request, redirect, flash

app = Flask(__name__)
app.secret_key = "SuperSecretKey"

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/results', methods=['POST'])
def results():
    name = request.form['name']
    rank = request.form['rank']
    mode = request.form['mode']
    comment = request.form['comment']
    error = False
    if len(name) < 1:
        flash("Error: Gamer Tag cannot be empty")
        error = True
    if len(comment) < 1:
        flash("Error: Comment field cannot be empty")
        error = True
    if len(comment) > 120:
        flash("Error: Comment field cannot exceed 120 characters")
        error = True
    if error:
        return redirect('/')
    else: 
        return render_template('results.html', name=name, rank=rank, mode=mode, comment=comment)
   
app.run(debug=True)