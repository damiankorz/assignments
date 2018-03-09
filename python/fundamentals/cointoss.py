
# Write a function that simulates tossing a coin 5,000 times. Your function should print how many times the head/tail appears.

# Sample output should be like the following:

# Starting the program...
# Attempt #1: Throwing a coin... It's a head! ... Got 1 head(s) so far and 0 tail(s) so far
# Attempt #2: Throwing a coin... It's a head! ... Got 2 head(s) so far and 0 tail(s) so far
# Attempt #3: Throwing a coin... It's a tail! ... Got 2 head(s) so far and 1 tail(s) so far
# Attempt #4: Throwing a coin... It's a head! ... Got 3 head(s) so far and 1 tail(s) so far
# ...
# Attempt #5000: Throwing a coin... It's a head! ... Got 2412 head(s) so far and 2588 tail(s) so far
# Ending the program, thank you!
# Hint: Use the python built-in round function to convert that floating point number into an integer

# x = .23945593
# y = .798839238
# x_rounded = round(x)
# # x_rounded will be rounded down to 0
# y_rounded = round(y)
# # y_rounded will be rounded up to 1

def coinToss():                                             #define function
    heads = 0                                               #declare variable heads to keep sum of heads
    tails = 0                                               #declare variable tails to keep sum of tails
    print "Starting coin toss program..."
    import random                               
    for i in range (0, 5000):                               #iterate through range 0 to 5000
        num = round(random.random())                        #for each iteration, create a float between 0 and 1 and round it
        if num == 1:                                        
            result = "heads"                                #set variable result to heads if the number generates 1
            heads += 1                                      #add one to heads total each time number is 1
        else:
            result = "tails"                                #if the number is not 1, it must be 0 and therefore the result is tails
            tails += 1                                      #add 1 to tails total
        print "Attempt", i + 1, ": Throwing a coin... It's", result, "... Got", heads, "head(s) so far and", tails, "tail(s) so far"
    print "Ending the program. Thank you!"
coinToss()

