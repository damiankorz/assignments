#find and replace 

words = "It's thanksgiving day. It's my birthday, too!"

print words.find("day")

print words.replace("day", "month")

#min and max

x = [2,54,-2,7,12,98]

print min(x)
print max(x)

#first and last

list1 = ["hello",2,54,-2,7,12,98,"world"]

print list1[0::len(list1)-1]

list2 = list1[0::len(list1)-1]

print list2

#new list
list3 = [19,2,54,-2,7,12,98,32,10,-3,6]

list3.sort()

print list3

list3a = list3[:len(list3)/2]

print list3a

list3b = list3[len(list3)/2:]

list3b.insert(0, list3a)

print list3b



