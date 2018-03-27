from flask import Flask, redirect, flash, session, render_template, request
from mysqlconnection import MySQLConnector
import re
app = Flask(__name__)
app.secret_key = 'sup3rs3cr3tk3y'
mysql = MySQLConnector(app, 'emaildb')
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/success')
def success():
    query = "SELECT * FROM emails"
    emails = mysql.query_db(query)
    return render_template('success.html', all_emails=emails)

@app.route('/create', methods=['POST'])
def create():
    error = False
    email = request.form['email']
    if len(email) < 1:
        flash('Error: Must enter a valid email address', 'error')
        error = True
    elif not email_regex.match(email):
        flash('Error: Not a valid email address', 'error')
        error = True 
    if error == True: 
        return redirect('/')
    else:
        flash('The email address you entered' + " " + email + " " + "is a VALID email address! Thank you!", 'success')
        query = "INSERT INTO emails (email, created_at, updated_at) VALUES (:email, NOW(), NOW())"
        data = {
            'email': request.form['email']
        }
        mysql.query_db(query, data)
        return redirect('/success')

@app.route('/delete/<email_id>', methods=['POST'])
def delete(email_id):
    query = "DELETE FROM emails WHERE id = :id"
    data = {
        'id': int(request.form['hidden'])
    }
    mysql.query_db(query, data)
    return redirect('/success')

@app.route('/home', methods=['POST'])
def home():
    return redirect('/')

app.run(debug=True)