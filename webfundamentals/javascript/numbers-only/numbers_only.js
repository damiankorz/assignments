// Numbers Only
// Make a function that copies an array, ONLY accepting the items that are numbers.

// IT SHOULD RETURN A NEW ARRAY

// ex:

// var newArray = numbersOnly([1, "apple", -3, "orange", 0.5]);
// // newArray is [1, -3, 0.5]
// HINT

// Use typeof to determine type (ex: typeof 24 === "number" would be true)

var numbersOnly = function(arr){
    var temp = [];
    for (var i = 0; i < arr.length; i++){
        if (typeof arr[i] === "number"){
            temp.push(arr[i]);
        }
    }return temp;
}

var newArray = numbersOnly([1, "apple", -3, "orange", 0.5,]);
console.log(newArray);

