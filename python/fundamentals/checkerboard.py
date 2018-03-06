# Write a program that prints a 'checkerboard' pattern to the console.

# Your program should require no input and produce console output that looks like so:

# * * * *
#  * * * *
# * * * *
#  * * * *
# * * * *
#  * * * *
# * * * *
#  * * * *
# Each star or space represents a square. On a traditional checkerboard you'll see alternating squares of red or black. In our case we will alternate stars and spaces. The goal is to repeat a process several times. This should make you think of looping.


for x in range (0,8):                  #target elements 0 through 8  
    if x % 2 == 0:                     #test for even parent elements, if even...
        for y in range (0,8):          #target child elements inside of even parent elements 0 through 8 
            if y % 2 == 0:             #test for even child elements, if even... 
                print "*",             #print * and use comma to print horizontally 
            else:                      #if the child elements is odd
                print " ",             #print space and use comma to print horizontally
    else:                              #if the parent elements is odd this will be the alternating row
        for y in range (0,8):          #target child elements inside odd parent elements
            if y % 2 == 0:             #test for even child elements, if even...
                print " ",             #print space and use comma to print horizontally
            else:                      #if the child element is odd  
                print "*",             #print * and use comma to print horizontally  
    print                              #print to display parent elements which will display child elements

    