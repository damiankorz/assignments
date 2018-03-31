from flask import Flask, redirect, render_template, request, flash
from mysqlconnection import MySQLConnector
import re 
app = Flask(__name__)
mysql = MySQLConnector(app, 'usersdb')
app.secret_key = "secretkey"
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/access', methods=['POST'])
def access():
    return redirect('/users')

@app.route('/users')
def users():
    query = 'SELECT id, first_name, last_name, email, created_at FROM users'
    users = mysql.query_db(query)
    return render_template('users.html', all_users=users)

@app.route('/users/new')
def new():
    return render_template('new.html')

@app.route('/users/<id>', methods=['GET'])
def show(id):
    query = "SELECT * FROM users WHERE id = :id"
    data = {
        'id': id
    }
    users = mysql.query_db(query, data)
    return render_template('show.html', all_users=users)

@app.route('/users/<id>/edit', methods=['GET'])
def edit(id):
    query = "SELECT * FROM users WHERE id = :id"
    data = {
        'id': id
    }
    users = mysql.query_db(query, data)
    return render_template('edit.html', all_users=users)

@app.route('/create', methods=['POST'])
def create():
    error = False
    email = request.form['email']
    first_name = request.form['first_name']
    last_name = request.form['last_name']
    if not email_regex.match(email):
        flash('Error: Invalid email was entered')
        error = True 
    if len(first_name) < 1 or len(last_name) < 1:
        flash('Error: Name cannot be empty')
        error = True
    if not (first_name.isalpha() or last_name.isalpha()):
        flash('Error: Name may not contain numbers or special characters')
        error = True 
    if error == True: 
        return redirect('/users/new')
    else:
        query = "INSERT INTO users (first_name, last_name, email, created_at, updated_at) VALUES(:first_name, :last_name, :email, NOW(), NOW())"
        data = {
            'first_name': first_name,
            'last_name': last_name,
            'email': email
        }
        mysql.query_db(query, data)
        flash('User successfully added!')
        return redirect('/users')

@app.route('/users/<id>/update', methods=['POST', 'GET'])
def update(id):
    error = False
    email = request.form['email']
    first_name = request.form['first_name']
    last_name = request.form['last_name']
    id = request.form['hidden']
    if not email_regex.match(email):
        flash('Error: Invalid email was entered')
        error = True 
    if len(first_name) < 1 or len(last_name) < 1:
        flash('Error: Name cannot be empty')
        error = True
    if not (first_name.isalpha() or last_name.isalpha()):
        flash('Error: Name may not contain numbers or special characters')
        error = True 
    if error == True: 
        return redirect('/users/'+id+'/edit')
    else: 
        query = "UPDATE users SET first_name = :first_name, last_name = :last_name, email = :email, updated_at = NOW() WHERE id = :id"
        data = {
            'first_name': first_name,
            'last_name': last_name,
            'email': email,
            'id': id
        }
        mysql.query_db(query, data)
        flash('Successfully updated user!')
        return redirect('/users/'+id)

@app.route('/users/<id>/delete', methods=['GET'])
def delete(id):
    query = 'DELETE FROM users WHERE id = :id'
    data = {
        'id': id
    }
    mysql.query_db(query, data)
    flash("User deleted!")
    return redirect('/users')

app.run(debug=True)