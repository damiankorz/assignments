// // //Create a program that will tell you the time.

/* If minutes less than 30, "just after" the hour, more than 30, "almost" the next hour
AM / PM, "in the morning", "in the evening", */

// // Add functionality for "quarter after", "half past", "5 after" ...
// // Distinguish between "in the afternoon", "at night", "noon", "midnight" ...

var hour = 8;
var minute = 50;                        
var period = "am";                      

var logString = "It's";

if (minute < 30 && minute != 15 && minute !=5 && minute != 0){
    logString += " just after " + hour;                        //outputs just after
}else if (minute === 30){                                      
    logString += " half past " + hour;                         //outputs half past
}else if (minute === 15){                                      
    logString += " a quarter after " + hour;                   //outputs a quarter after
}else if (minute === 5){                                       
    logString += " five after " + hour;                        //outputs 5 after
}else if (minute === 0 && hour != 12){
    logString +=  " exactly " + hour;                          //outputs exaclty hour
}else if (minute > 30 && minute != 0){
    logString += " almost ";
    if (hour === 12){
        logString += 1;                                        //outputs almost 1
        }else {
        logString += (hour+1);                                 //outputs almost next hour
    }
}
if (period === "pm" && hour >= 1 && hour <= 4 || hour === 12 && period != "am" && minute != 0){
    logString += " in the afternoon";                          //outputs in the afternoon
}else if (hour === 12 && minute === 0){
    if (period === "pm"){
        logString += " noon";                                  //outputs noon
    }else {
        logString += " midnight";                              //outputs midnight
    }
}else if (period === "pm" && hour > 4 && hour <= 7){            
    logString += " in the evening";                            //outputs in the evening 
}else if (period === "pm" && hour > 7 && hour < 12){
    if (hour === 11 && minute > 30){
        logString = "It's almost midnight";                    //outs its almost midnight
    }else {
        logString += " at night";                              //outputs at night
    }                                        
}else if (period === "am"){
    if (hour === 11 && minute > 30){
        logString = "It's almost noon";                        //outputs its almost noon
    }else {
        logString += " in the morning";                        //outputs in the morning
    }                          
}
console.log(logString);