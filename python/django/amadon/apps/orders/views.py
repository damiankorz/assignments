from django.shortcuts import render, redirect

def route(request):
    return redirect('/amadon')

def amadon(request):
    return render(request, 'orders/index.html')

def process(request):
    if 'quantity' not in request.session:
        request.session['quantity'] = 0 
    if 'cost' not in request.session:
        request.session['cost'] = 0
    if 'total_cost' not in request.session:
        request.session['total_cost'] = 0
    if request.method == 'POST':
        price = 0
        if request.POST.get('product_id') == '101':
            price = 19.99
        elif request.POST.get('product_id') == '102':
            price = 29.99
        elif request.POST.get('product_id') == '103':
            price = 4.99
        elif request.POST.get('product_id') == '104':
            price = 49.99
        request.session['quantity'] += int(request.POST.get('quantity'))
        request.session['cost'] = (price * int(request.POST.get('quantity'))) 
        request.session['total_cost'] += (price * int(request.POST.get('quantity'))) 
    return redirect('/checkout')

def checkout(request):
    return render(request, 'orders/checkout.html')

def reset(request):
    request.session.clear()
    return redirect('/amadon')
