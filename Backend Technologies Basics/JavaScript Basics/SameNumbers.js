function solveSameNumbers(input){
    let sum = 0;
    let isSameDigit = true;
    let numAsString = input.toString();
   
    for(let i = 0; i < numAsString.length - 1; i++) {
        let first = Number(numAsString[i]);
        let second = Number(numAsString[i + 1]);
        if(first !== second) {
        isSameDigit = false;
        break;
        }
    }

    while(input > 0) {
        let num = input % 10;
        sum += num;
       input = Math.floor(input / 10);
    }

    console.log(isSameDigit);
    console.log(sum);

}

solveSameNumbers(2222222);
solveSameNumbers(2222223);
solveSameNumbers(1234);
