/* Setting and Swapping: Set my myNumber to 42. Set myName to
your name. Now swap myNumber into myName & vice versa */

var myNumber = 42;
var myName = "Damian";
var temp = myNumber;{
    myNumber = myName;
    myName = temp;
    console.log('myName:', myName, "myNumber:", myNumber);
}

/* Print -52 to 1066: Print intergers -52 to 1066 using a FOR loop. */

for (var i= -52; i<1067; i++){
    console.log(i);
}

/* Dont Worry, Be Happy: Create beCheerful(). Within it, console.log
string "good morning!" Call it 98 times. */

function BeCheerful (i){
    for (var i=1; i<99; i++){
        console.log("good morning!");
    }
}
BeCheerful(98);

/* Multiples of Three - but Not All: Using FOR, print multiples of 3
from -300 to 0. Skip -3 and -6. */

for (var i = -300; i<=0; i++){
    if (i % 3 ===0 && i != -6 && i != -3){
        console.log(i);
    }
}

/* Printing Integers with While: Print intergers from 2000 to 5280,
using a WHILE */

var num = 2000;
while (num<5281){
    console.log("The number is:", num);
    num++;
}

/* You Say It's Your Birthday: If 2 given numbers represent your birth
month and day in either order, log "How did you know?", else log "Just
another day..." */ 

for (var i=0; i<31; i++){
    if (i === 10 || i === 28){
        console.log("How did you know?");
    }else {
        console.log("Just another day...")
    }
}           // might be wrong logic

/* Leap Year: Write a function that determines whether a given
year is a leap year. If a year is divisible by four, it is a leap year,
unless it is divisible by 100. However, if it is divisble by 400, then
it is. */

function TestYear (year){
    if (year % 4 === 0 && (year % 100 != 0 || year % 400 === 0)){
        console.log("It's a leap year")
    }else {
        console.log("It's not a leap year")
    }
}
TestYear(2000);

/* Print and Count: Print all integer multipes of 5, from 512 to 
4096. Afterward, also log many there wre. */

var count = 0;

for (var i =515; i <= 4095; i+=5){
    if (i % 5 ===0 ){
        console.log(i);
        count += 1;
    }
}
console.log("The count is:", count);

/* Multiples of Six: Print multiples of 6 up to 60001 using a WHILE */

var num1 = 0;

while (num1 < 60001 && num1 % 6 === 0){
    console.log(num1);
    num1+=6;
}

/* Counting, the Dojo Way: Print integers 1 to 100. If divisible by 5,
print "Coding" instead. If by 10, also print Dojo. */

for (var i = 1; i < 101; i++){
    if (i % 5 === 0){
        console.log("Coding");
        if (i % 10 === 0){
            console.log("Dojo");
        }
    }else {
        console.log(i);
    }
}