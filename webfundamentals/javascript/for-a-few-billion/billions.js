/* There is an old tale about a king who offered a servant $10,000 as a reward. 
The servant instead asked that for 30 days he be given an amount that would double, 
starting with a penny. (1 penny for the first day, 2 for the second, 4 for the third, 
then 8, 16, 32 pennies, and so on). */

// Use for loops to answer the following:

// How much was the reward after 30 days?
// remember, a penny isn't 1, but 0.01

function myBillions (days){
    var payment = 0.01;
    for (var i = 2; i <= days; i++){
        payment = (payment * 2);
    }
    console.log(`On day ${days}, the servant's reward is $${payment}`)
}
myBillions(30);

// Bonus (Only If You Have Time):

// How many days would it take the servant to make $10,000?
// How about 1 billion?
// In JavaScript, there is a value Infinity . How many days until the servant has infinite money?

function daysTill (dollars){
    var payment = 0.01;
    for (var i = 2; i > 0; i++){
        payment = (payment *2);
        if (payment >= dollars){
            console.log(`It would take ${i} days for the servant to make $${dollars}`)
            return;
        }
    }
}
daysTill(Infinity); //Test also $10,000 & $1,000,000,000


