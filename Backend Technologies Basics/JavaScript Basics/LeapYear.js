function solveLeapYear(num) {
    const year = Number(num);
    
    if((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {

        console.log("yes");
    } else {
        console.log("no");
    }
}

solveLeapYear(1984);
solveLeapYear(2003);
solveLeapYear(4);
solveLeapYear(1900);
solveLeapYear(2000);