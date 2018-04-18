from django.shortcuts import render, redirect
from ..users.models import User 
from models import * 
from django.contrib import messages 

def home(request):
    context = {
        'user': User.objects.current_user(request.session['logged_id']),
        'books': Book.objects.all(),
        'recent': Review.objects.recent(),
    }
    return render(request, 'books/index.html', context)

def add(request):
    context = {
        'authors_list': Book.objects.authors()
    }
    return render(request, 'books/add.html', context)

def create(request):
    if request.method == 'POST':
        errors = Book.objects.book_validator(request)
        if len(errors):
            for tag, error in errors.iteritems():
                messages.error(request, error, extra_tags=tag)
            return redirect('/books/add')
        else:
            book_id = Book.objects.new_entry(request)
            return redirect('/books/' + str(book_id))

def add_review(request, id):
    errors = Review.objects.review_validator(request)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/books/' + id)
    else: 
        Review.objects.new_review(request, id)
        return redirect('/books/' + id)
            
def delete(request, id, review_id):
    Review.objects.delete_review(request, review_id)
    return redirect('/books/' + id)

def display_book(request, id):
    context = {
        'book': Book.objects.display_book(id),
        'reviews': Review.objects.display_reviews(id),
    }
    return render(request, 'books/books.html', context)
