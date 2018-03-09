# Create a series of functions based on the below descriptions.

# Odd/Even:
# Create a function called odd_even that counts from 1 to 2000. As your loop executes have your program print the number of that iteration and specify whether it's an odd or even number.

# Your program output should look like below:

# Number is 1.  This is an odd number.
# Number is 2.  This is an even number.
# Number is 3.  This is an odd number.
# ...
# Number is 2000.  This is an even number.
# Multiply:
# Create a function called 'multiply' that iterates through each value in a list (e.g. a = [2, 4, 10, 16]) and returns a list where each value has been multiplied by 5.

# The function should multiply each value in the list by the second argument. For example, let's say:

# a = [2,4,10,16]
# Then:

# b = multiply(a, 5)
# print b
# Should print [10, 20, 50, 80 ].

# Hacker Challenge:
# Write a function that takes the multiply function call as an argument. Your new function should return the multiplied list as a two-dimensional list. Each internal list should contain the 1's times the number in the original list. Here's an example:

# def layered_multiples(arr):
#   # your code here
#   return new_array
# x = layered_multiples(multiply([2,4,5],3))
# print x
# # output
# >>>[[1,1,1,1,1,1],[1,1,1,1,1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1,1,1,1,1,1,1,1]]


def oddEven():                                                      #define function
    for i in range (1, 2001):                                       #iterate 2000 times
        if i % 2 == 0:                                              #if the number is even do this...    
            print "Number is", i, "-", "This is an even number"
        else:                                                       #otherwise its odd, do this..
            print "Number is", i, "-", "This is an odd number"
oddEven()                                                           #callback function

a = [2, 4, 10, 16]

def multiply(arr, num):                                             #define function
    for i in range(len(arr)):                                       #iterate through length of array
        arr[i] *= num                                               #each iteration, replace the current index by that number times num
    return arr                                                      #return array - return will be used for layMult
y = multiply(a, 5)                                                  #define variable to store returned result from function mulitpy
print y

b =[2,4,5]  

def layMult(arr):                                                   #define function
    new_arr = []                                                    #declare a new empty array                     
    for i in arr:                                                   #for each index in the old array
        new_arr.append([1]*i)                                       #append 1 i amount of times to the new array
    return new_arr                                                  #return array to use later
x = layMult(multiply(b ,3))                                         #define variable to store return result from function with multiply function as argument
print x

