// Create a birthday countdown.
// For every day, print how many days left.
// If it's more than 30 days, print a sad message.
// If it's less than 30 days, print a message that sounds excited!
// // If it's less than 5 days, SCREAM IT!
// // ONCE IT'S YOUR BIRTHDAY, HAVE A PARTY!
// 2 DAYS UNTIL MY BIRTHDAY!!!
// // 1 DAY UNTIL MY BIRTHDAY!!!
// 60 days until my birthday. Such a long time... :(
// 59 days until my birthday. Such a long time... :(
// 58 days until my birthday. Such a long time... :(
// ♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪ღ♪¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•*
// ♪ღ♪░H░A░P░P░Y░ B░I░R░T░H░D░A░Y░░♪ღ♪
// *•♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•«


var daysUntilMyBirthday = 60;

for (var i = daysUntilMyBirthday; i>=0; i--){
    if (i > 30){
        console.log(`${i} days until my birthday. Such a long time... :(`);
    }else if (i <= 30 && i >5){
        console.log(`${i} days until my birthday. It's getting closer!! :)`);
    }else if (i <= 5 && i > 1){
        console.log(`${i} DAYS UNTIL MY BIRTHDAY!!!!`);
    }else if (i === 1){
        console.log(`${i} DAY UNTIL MY BIRTHDAY!!!!`)
    }else if (i === 0){
        console.log(`♪ღ♪░H░A░P░P░Y░ B░I░R░T░H░D░A░Y░░♪ღ♪`)
    }
}