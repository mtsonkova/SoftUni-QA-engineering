function solveSumDigits(number){
    let sum = 0;
    while(number > 0) {
        let currentNum = number % 10;
        sum += currentNum;
        number = Math.floor(number / 10);
        }
    console.log(sum);

}

solveSumDigits(245678);
solveSumDigits(97561);
solveSumDigits(543);