from __future__ import unicode_literals
from django.db import models
from ..users.models import User

class BookManager(models.Manager):
    #Valid adding a new book
    def book_validator(self, request):
        errors = {}
        if len(request.POST['title']) < 1: 
            errors['title'] = "Book title cannot be blank"
        if len(request.POST['author']) < 1 and request.POST.get('authors') == "":
            errors['author'] = "Must specify author"
        if len(request.POST['author']) > 1 and request.POST.get('authors') != "":
            errors['author'] = "Only one author field maybe specified"
        if len(request.POST['review']) < 1:
            errors['review'] = "Review cannot be blank"
        return errors
    #Handle new entry, check to see if book title already exists
    def new_entry(self, request):
        book_list = []
        books = Book.objects.all()
        for book in books:
            if book.title not in book_list:
                book_list.append(book.title)
        if request.POST['title'] not in book_list:  
            Book.objects.create(title=request.POST['title'], author=request.POST['author'] or request.POST.get('authors'), user_id=request.session['logged_id'])
            Review.objects.create(content=request.POST['review'], rating=request.POST.get('rating'), user_id=request.session['logged_id'], book_id=Book.objects.last().id)
            book_id = Book.objects.last().id 
            return book_id 
        else: 
            Review.objects.create(content=request.POST['review'], rating=request.POST.get('rating'), user_id=request.session['logged_id'], book_id=Book.objects.get(title = request.POST['title']).id)
            book_id = Book.objects.get(title = request.POST['title']).id
            return book_id
    #Method to display book by book id 
    def display_book(self, id):
        book = Book.objects.get(id = id)
        return book
    #Method to create list of authors for dropdown selection
    def authors(self):
        books = Book.objects.all()
        authors_list = []
        for book in books:
            if book.author not in authors_list:
                authors_list.append(book.author)
        return authors_list

class Book(models.Model):
    title = models.CharField(max_length=255)
    author = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    user = models.ForeignKey(User, related_name="books")
    objects = BookManager()

class ReviewManager(models.Manager):
    #Validate seperate review submission 
    def review_validator(self, request):
        errors = {}
        if len(request.POST['review']) < 1:
            errors['review'] = "Review cannot be blank"
        return errors
    #Method to display reviews by book id 
    def display_reviews(self, id):
        reviews = Review.objects.filter(book_id = id)
        return reviews
    #Method to handle a new review 
    def new_review(self, request, id):
        Review.objects.create(content=request.POST['review'], rating=request.POST.get('rating'), user_id=request.session['logged_id'], book_id= id)
    #Method to delete review
    def delete_review(self, request, review_id):
        review = Review.objects.get(id = review_id)
        review.delete()
    #Method to grab all reviews by user id 
    def users_reviews(self, id):
        reviews = Review.objects.filter(user_id = id)
        return reviews
    #Mehtod to display last three reviews
    def recent(self):
        last_three = Review.objects.filter().order_by('-created_at')[:3]
        return last_three
    #Method to display the reviews count per user
    def count(seld, id):
        user_reviews = Review.objects.filter(user_id = id)
        return user_reviews.count()

class Review(models.Model):
    content = models.TextField()
    rating = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    user = models.ForeignKey(User, related_name="reviews")
    book = models.ForeignKey(Book, related_name="reviews")
    objects = ReviewManager()
