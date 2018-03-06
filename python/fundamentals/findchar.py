# Write a program that takes a list of strings and a string containing a single character, and prints a new list of all the strings containing that character.

# Here's an example:

# input
word_list = ['hello','world','my','name','is','Anna']
char = 'o'
# output
# new_list = ['hello','world']
# Hint: how many loops will you need to complete this task?

new_list = []                       #declare variable for an empty list

for x in word_list:                 #for every string in the list
    if any(char in i for i in x):   #if any characters in each string contain variable char (accounts for only one character in the element) 
        new_list.append(x)          #add the element to the end of a new list
print new_list                      #indent out to print string only once; print new list



