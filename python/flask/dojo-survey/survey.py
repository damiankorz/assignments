from flask import Flask, render_template, request, redirect

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/results', methods=['POST'])
def results():
    name = request.form.get('name')
    rank = request.form.get('rank')
    mode = request.form.get('mode')
    comment = request.form.get('comment')
    return render_template('results.html', name=name, rank=rank, mode=mode, comment=comment)
    return redirect('/')
    
app.run(debug=True)