# Assignment: Dictionary in, tuples out
# Write a function that takes in a dictionary and returns a list of tuples where the first tuple item is the key and the second is the value. Here's an example:

# # function input
my_dict = {
  "Speros": "(555) 555-5555",
  "Michael": "(999) 999-9999",
  "Jay": "(777) 777-7777"
}
# #function output
# [("Speros", "(555) 555-5555"), ("Michael", "(999) 999-9999"), ("Jay", "(777) 777-7777")]


def makeTuples(input):              #define function
    arr = []                        #create array variable to output tuples in a list
    for i in input.items():         #for each key value pair in the dictionary
        arr.append(i)               #append the tuple to a list
    print arr                       
makeTuples(my_dict)