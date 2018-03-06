# Write a program that compares two lists and prints a message depending on if the inputs are identical or not.

# Your program should be able to accept and compare two lists: list_one and list_two. If both lists are 
# identical print "The lists are the same". If they are not identical print "The lists are not the same." 
# Try the following test cases for lists one and two:

# list_one = [1,2,5,6,2]
# list_two = [1,2,5,6,2]

# list_one = [1,2,5,6,5]
# list_two = [1,2,5,6,5,3]

list_one = [1,2,5,6,5,16]
list_two = [1,2,5,6,5]

# list_one = ['celery','carrots','bread','milk']
# list_two = ['celery','carrots','bread','cream']

input1 = list_one                               #declare input variable for first list
input2 = list_two                               #declare input variable for second list

if input1 == input2:                            #if the first list is equal to the second list
    print "The lists are the samee"             #<-- print
else:                                           #else if the lists are not equal to each other
    print "The lists are not the same"          #<-- print


