# Write a function that generates ten scores between 60 and 100. Each time a score is generated, your function should display what the grade is for a particular score. Here is the grade table:

# Score: 60 - 69; Grade - D
# Score: 70 - 79; Grade - C
# Score: 80 - 89; Grade - B
# Score: 90 - 100; Grade - A
# The result should be like this:

# Scores and Grades
# Score: 87; Your grade is B
# Score: 67; Your grade is D
# Score: 95; Your grade is A
# Score: 100; Your grade is A
# Score: 75; Your grade is C
# Score: 90; Your grade is A
# Score: 89; Your grade is B
# Score: 72; Your grade is C
# Score: 60; Your grade is D
# Score: 98; Your grade is A
# End of the program. Bye!
# Hint: Use the python random module to generate a random number

# import random
# random_num = random.random()
# # the random function will return a floating point number, that is 0.0 <= random_num < 1.0
# #or use...
# random_num = random.randint()

def scoresGrades():                                            #define function
    print "Scores and Grades"
    import random
    for x in range (0, 10):                                    #iterate 10 times and each time... 
        score = random.randint(60,100)                         #generate random integer 60-100
        if score < 70:
             grade = "D"                                       #if random number less than 70, grade is D 
        elif score < 80: 
            grade = "C"                                        #if random number less than 80, grade is C 
        elif score < 90:
            grade = "B"                                        #if random number less than 90, grade is B 
        else: 
            grade = "A"                                        #else the number must be >= 90, grade is A 
        print "Score:", score, "-", "Your grade is", grade
    print "End of program. Bye!"
scoresGrades()