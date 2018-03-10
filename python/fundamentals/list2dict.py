# Assignment: Making Dictionaries
# Create a function that takes in two lists and creates a single dictionary. The first list contains keys and the second list contains the values. Assume the lists will be of equal length.

# Your first function will take in two lists containing some strings. Here are two example lists:

name = ["Anna", "Eli", "Pariece", "Brendan", "Amy", "Shane", "Oscar"]
favorite_animal = ["horse", "cat", "spider", "giraffe", "ticks", "dolphins", "llamas"]
# Here's some help starting your function.

# def make_dict(list1, list2):
#   new_dict = {}
#   # your code here
#   return new_dict

# Hacker Challenge:
# If the lists are of unequal length, the longer list should be used for the keys, the shorter for the values.

def makeDict(list1, list2):                                 #declare function
    new_dict = {}                                           #create new variable for empty dictionary
    for i in range(len(list1)) and range(len(list2)):       #iterate through length of each list
        new_dict[list1[i]] = list2[i]                       #for each iteration, set the key to i of list 1 and the value to i of list 2
    return new_dict                                         #return new dictionary to be able to store in variable
x = makeDict(name, favorite_animal)
print x 

#Hacker Challenge

#Test cases
students = ['Jimmy', 'John', 'Sanders']
foods = ['sandwich', 'pizza', 'chicken', 'pasta']

athletes = ['Ronaldo', 'James', 'Kane', 'Rizzo']
sports = ['soccer', 'basketball', 'hockey']


def makeAnother(list1, list2):                              #declare function  
    new_dict = {}                                           #create new variable for empty dictionary
    if len(list1) > len(list2):                             #check if length of list1 is greater than length of list2
        for i in range(len(list1)) and range(len(list2)):   #if yes, iterate through length of each list
            new_dict[list1[i]] = list2[i]                   #for each iteration, set the key to i of list1 (longer), and value to i of list2 (shorter)
        return new_dict                                     #return new dictionary to be able to store in variable
    else:                                                   #if list1 is not longer than list 2
        for i in range(len(list2)) and range(len(list1)):   #iterate through through the length of each list
            new_dict[list2[i]] = list1[i]                   #for each iteration, set the key to i of list2 (longer), and value to i of list1 (shorter)
        return new_dict                                     #return new dictionary to be able to store in variable
z = makeAnother(athletes, sports)
print z


