# Write the following functions.

# Part I
# Create a function called draw_stars() that takes a list of numbers and prints out *.

# For example:

# x = [4, 6, 1, 3, 5, 7, 25]
# draw_stars(x) should print the following when invoked:

# ****
# ******
# *
# ***
# *****
# *******
# *************************
# Part II
# Modify the function above. Allow a list containing integers and strings to be passed to the draw_stars() function. 
# When a string is passed, instead of displaying *, display the first letter of the string according 
# to the example below. You may use the .lower() string method for this part.

# For example:

# x = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
# draw_stars(x) should print the following in the terminal:

# ****
# ttt
# *
# mmmmmmm
# *****
# *******
# jjjjjjjjjjj

#Part I

x = [4, 6, 1, 3, 5, 7, 25]

def drawStars(arr):                                     #define function
    for i in arr:                                       #interate through array and print each index
        print "*" * i
drawStars(x)

y = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]

#Part II

def drawAll(arr):                                       #declare function
    for i in arr:                                       #iterate through array
        if isinstance(i, int):                          #if i is an integer, print i times the integer
            print "*" * i
        elif isinstance(i, str):                        #else if i is a string, extract the first letter, change to lower case,  and multipy by lenght of string
            print i[0].lower() * len(i)
drawAll(y)