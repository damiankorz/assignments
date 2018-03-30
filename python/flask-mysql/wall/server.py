from flask import Flask, session, request, render_template, flash, redirect
from mysqlconnection import MySQLConnector
from flask.ext.bcrypt import Bcrypt 
import re 
app = Flask(__name__)
app.secret_key = 'SpeakFriendAndEnter'
mysql = MySQLConnector(app, 'walldb')
bcrypt = Bcrypt(app)
email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/')
def index():
    if 'logged_id' not in session:
        return render_template('index.html')
    else:
        return redirect('/wall')

@app.route('/wall')
def wall():
    if "logged_id" not in session: 
        return redirect('/')
    query = "SELECT * FROM users WHERE id = :logged_id"
    data = {
        'logged_id': session['logged_id']
    }
    logged_user = mysql.query_db(query, data)
    messages_query = "SELECT users.first_name, users.last_name, messages.id, messages.message, messages.created_at FROM messages JOIN users ON messages.user_id = users.id ORDER BY created_at DESC"
    messages = mysql.query_db(messages_query)
    comments_query = "SELECT users.first_name, users.last_name, messages.id AS message_id, messages.message, comments.comment, comments.created_at FROM comments JOIN messages ON comments.message_id = messages.id JOIN users ON comments.user_id = users.id"
    comments = mysql.query_db(comments_query)
    return render_template('wall.html', current_user=logged_user, all_messages=messages, all_comments=comments)

@app.route('/register', methods=['POST'])
def register():
    error = False
    first_name = request.form['first_name']
    last_name = request.form['last_name']
    email = request.form['email']
    password = request.form['password']
    confirm_pass = request.form['confirm_pass']
    if len(first_name) < 1 and len(last_name) < 1:
        flash('Error: Name cannot be blank')
        error = True 
    if not (first_name.isalpha() and last_name.isalpha()) :
        flash('Error: Name cannot contain numbers or special characters')
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
        crypt_pw = bcrypt.generate_password_hash(password)
        query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES(:first_name, :last_name, :email, :crypt_pw, NOW(), NOW())"
        data = {
            'first_name': first_name,
            'last_name': last_name,
            'email': email,
            'crypt_pw': crypt_pw,
        }
        mysql.query_db(query, data)
        flash('You have successfully registered!')
        return redirect('/')

@app.route('/login', methods=['POST'])
def login():
    error = False 
    password = request.form['password']
    if len(password) < 1:
        flash('Must enter password')
        error = True 
    if len(request.form['email']) < 1:
        flash('Must enter email')
        error = True
    if error == True: 
        return redirect('/')
    query = "SELECT * FROM users WHERE email = :email"
    data = {
        'email': request.form['email']
    }
    users = mysql.query_db(query, data)
    if len(users) > 0: 
        user = users[0]
        if bcrypt.check_password_hash(user['password'], password):
            session['logged_id'] = user['id']
            return redirect('/wall')
        else:
            flash('Unsuccessful login - Incorrect password')
            return redirect('/')
    else: 
        flash('Unsuccessful login - Email address does not exist')
        return redirect('/')

@app.route('/messages', methods=['POST'])
def messages():
    if len(request.form['messages']) < 1:
        flash('Error: Cannot submit an empty message')
        return redirect('/wall')
    query = "INSERT INTO messages (user_id, message, created_at, updated_at) VALUES (:user, :message, NOW(), NOW())"
    data = {
        'user': session['logged_id'],
        'message': request.form['messages']
    }
    mysql.query_db(query, data)
    return redirect('/wall')

@app.route('/comments', methods=['POST'])
def comment():
    if len(request.form['comments']) < 1:
        flash('Error: Cannot sumbit an empty comment')
        return redirect('/wall')
    query = "INSERT INTO comments (message_id, user_id, comment, created_at, updated_at) VALUES(:message_id, :user, :comment, NOW(), NOW())"
    data = {
        'message_id': request.form['hidden'],
        'user': session['logged_id'],
        'comment': request.form['comments']
    }
    mysql.query_db(query, data)
    return redirect('/wall')

@app.route('/logout', methods=['POST'])
def logout():
    session.clear()
    return redirect('/')

app.run(debug=True)
