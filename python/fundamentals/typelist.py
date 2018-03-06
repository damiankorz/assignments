# Write a program that takes a list and prints a message for each element in the list, based on that element's data type.

# Your program input will always be a list. For each item in the list, test its data type. If the item is a string, concatenate 
# it onto a new string. If it is a number, add it to a running sum. At the end of your program print the string, the number 
# and an analysis of what the list contains. If it contains only one type, print that type, otherwise, print 'mixed'.

# Here are a couple of test cases. Think of some of your own, too. What kind of unexpected input could you get?

#input
a = ['magical unicorns',19,'hello',98.98,'world']
#output
"The list you entered is of mixed type"
"String: magical unicorns hello world"
"Sum: 117.98"

# input
b = [2,3,1,7,4,12]
#output
"The list you entered is of integer type"
"Sum: 29"

# input
c = ['magical','unicorns']
#output
"The list you entered is of string type"
"String: magical unicorns"

input = a                                                   #declare input variable
lsum = 0                                                    #declare sum variable
lstr = ""                                                   #delcare string variable

if all(isinstance(x, int) for x in input):                  #if all elements in the list are of type integer
    print "The list you entered is of integer type"         #<-- print
    for x in input:                                         #AND for each element in the list
        lsum += x                                           #add the element to lsum
    print "Sum:", lsum                                      #print sum
elif all(isinstance(x, str) for x in input):                #else if all elements in the list are of type string
    print "The list you entered is of string type"          #<-- print
    for x in input:                                         #AND for each element in the list
        lstr += (x + " ")                                   #concatenate element with a space to lstr
    print "String:", lstr                                   #print string
else:                                                       #else if the elements are not all string or not all integer
    print "The list you entered is of mixed type"           #<-- print
    for x in input:                                         #AND for each element in the list
        if isinstance(x, (int,float)):                      #if the element is an integer or a decimal
            lsum += x                                       #add the element to lsum
        elif isinstance(x, str):                            #else if the element is a string
            lstr += (x + " ")                               #concatenate element with a space to lstr
    print "Sum:", lsum                                      #print sum
    print "String:", lstr                                   #print string
   
