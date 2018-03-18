from flask import Flask, request, redirect, render_template, flash
import re 

email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = "SuperSecretKey"

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=['POST'])
def process():
    error = False
    email = request.form['email']
    first = request.form['first_name']
    last = request.form['last_name']
    password = request.form['password']
    confirm = request.form['confirm_pass']
    #Check if user entered email, set error if no
    if len(email) < 1:
        flash("Error: Must enter email")
        error = True
    #Check if email is valid, set error if no
    elif not email_regex.match(email):
        flash("Error: Invalid email")
        error = True
    #Check if user entered first name, set error if no
    if len(first) < 1:
        flash("Error: Must enter first name")
        error = True
    #Check if first name contains only letters, set error if no
    elif not first.isalpha() and len(first) > 1:
        flash("Error: First name may only contain letters")
        error = True
    #Check is user entered last name, set error if no
    if len(last) < 1:
        flash("Error: Must enter last name")
        error = True
    #Check if last name only contains letters, set error if no
    elif not last.isalpha() and len(last) > 1:
        flash("Error: Last name may only contain letters")
        error = True
    #Check if user entered password, set error if no
    if len(password) < 1:
        flash("Error: Must enter password")
        error = True
    #Check if user confirmed password, set error if no
    if len(confirm) < 1:
        flash("Error: Must confirm password")
        error = True
    #Check if passwords are less than 9 characters, set error if yes
    if len(password) and len(confirm) <= 8:
        flash("Error: Password should be more than eight characters")
        error = True
    #check if passwords dont match, set error if yes
    elif password != confirm:
        flash("Error: Passwords did not match")
        error = True
    #check if password does not contain a number and a capital letter, set error if yes
    elif not (any(ch.isdigit() for ch in password and confirm) and any(ch.isupper() for ch in password and confirm)):
        flash("Error: Password must have at least one upper case letter and one number")
        error = True
    #check if there if is an error (error = True), redirect to root ('/') and display error
    if error: 
        return redirect('/')
    #else if there is no error (error = False), process the form
    else:
        flash("Thank you for submitting your registration!")
        return redirect('/')

app.run(debug=True)
