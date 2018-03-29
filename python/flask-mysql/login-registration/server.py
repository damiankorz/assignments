from flask import Flask, session, flash, redirect, render_template, request
from mysqlconnection import MySQLConnector
import re 
import md5
import os, binascii 
app = Flask(__name__)
app.secret_key = 'SuperSecretString'
mysql = MySQLConnector(app, 'logindb')
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/')
def index():
    if 'logged_id' not in session:
        return render_template('index.html')
    else:
        return render_template('dashboard.html')

@app.route('/dashboard')
def dashboard():
    return render_template('dashboard.html')

@app.route('/register', methods=['POST'])
def register():
    error = False
    first_name = request.form['first_name']
    last_name = request.form['last_name']
    email = request.form['email']
    password = request.form['password']
    confirm_pass = request.form['confirm_pass']
    if len(first_name) < 2 and len(last_name) < 2:
        flash('Error: Name must have at least 2 characters')
        error = True 
    if not (first_name.isalpha() and last_name.isalpha()) :
        flash('Error: Name must not contain numbers or special characters')
        error = True
    if not email_regex.match(email):
        flash('Error: Invalid email was entered')
        error = True
    if len(password) < 8 and len(confirm_pass) < 8:
        flash('Error: Password must contain at least 8 characters')
        error = True
    if password != confirm_pass:
        flash('Error: Passwords did not match')
        error = True
    if error == True:
        return redirect('/')
    else:
        salt = binascii.b2a_hex(os.urandom(15))
        hashed_pass = md5.new(password + salt).hexdigest()
        query = "INSERT INTO users (first_name, last_name, email, password, salt, created_at, updated_at) VALUES(:first_name, :last_name, :email, :hashed_pass, :salt, NOW(), NOW())"
        data = {
            'first_name': first_name,
            'last_name': last_name,
            'email': email,
            'hashed_pass': hashed_pass,
            'salt': salt
        }
        mysql.query_db(query, data)
        flash('You have successfully registered!')
        return redirect('/')

@app.route('/login', methods=['POST'])
def login():
    password = request.form['password']
    query = "SELECT * FROM users WHERE email = :email"
    data = {
        'email': request.form['email']
    }
    users = mysql.query_db(query, data)
    if len(users) > 0: 
        user = users[0]
        hashed_pass = md5.new(password + user['salt']).hexdigest()
        if user['password'] == hashed_pass:
            session['logged_id'] = user['id']
            return redirect('/dashboard')
        else:
            flash('Unsuccessful login - Incorrect password')
            return redirect('/')
    else: 
        flash('Unsuccessful login - Email address does not exist')
        return redirect('/')

app.run(debug=True)
