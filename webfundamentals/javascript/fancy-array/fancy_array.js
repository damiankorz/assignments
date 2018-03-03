// Normally, if you print an array such as ["James", "Jill", "Jane", "Jack"], you will see the following:

// [ "James", "Jill", "Jane", "Jack" ]
// Let's make it look fancy! Write a function that will make it print like:

// 0 -> James
// 1 -> Jill
// 2 -> Jane
// 3 -> Jack
// Bonus (Only If You Have Time):

// Let the user pass in the symbol that will print (ex: "->", "=>", "::", "-----")
// Have an extra parameter reversed. If the user passes true, print the elements in reverse order

function fancyArray(arr, symbol,reversed){
    if (symbol === undefined){
        symbol = "->";
    }if (reversed === true){
        arr = arr.reverse();
    }
    for (var i = 0; i < arr.length; i++){
        console.log(`${i} ${symbol} ${arr[i]}`);
    }
}
fancyArray(["James", "Jill", "Jane", "Jack"], undefined, false);