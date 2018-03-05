# Assignment: Multiples, Sum, Average

# Multiples
# Part I - Write code that prints all the odd numbers from 1 to 1000. Use the for loop and don't use a list to do this exercise.

# Part II - Create another program that prints all the multiples of 5 from 5 to 1,000,000.

# Sum List
# Create a program that prints the sum of all the values in the list: a = [1, 2, 5, 10, 255, 3]

# Average List
# Create a program that prints the average of the values in the list: a = [1, 2, 5, 10, 255, 3]

#Part I

for count in range (1, 1000):       #take numbers from 1 to 1,000
    if (count % 2 != 0):            #if the current number divided by two does not return a remainder of zero, do the following: 
        print count                 #print the number
        count += 1                  #inrease the count by 1 for the next iteration

#Part II

for count in range (5, 1000000):    #take numbes from 5 to 1,000,000 
    if (count % 5 == 0):            #if the current number divided by 5 returns a remainder of zero, do the following:
        print count                 #print the number
        count += 1                  #increase the count by 1 for the next iteration

#Sum List

a = [1, 2, 5, 10, 255, 3]
asum = 0                            #set variable asum to zero
for index in a:                     #for each index in list a 
    asum += index                   #add the value to asum 
print "Sum of list a:", asum        #indent out to not include the sum of each iteration/print the sum list a 

#Average List

a = [1, 2, 5, 10, 255, 3]
asum = 0                            #set variable asum to zero 
for index in a:                     #for each index in list a    
    asum += index                   #add the value to asum     
avg = asum/len(a)                   #creat new variable avg that takes asum and divdes it by the length of list a
print "Average of list a:", avg     #print the avg of list a
