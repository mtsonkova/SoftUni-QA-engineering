function solveMultiplicationTable(num) {
    let number = Number(num);
    let result = 0;

    for (let i = 1; i <= 10; i++) {
        result = number * i;
        console.log(`${number} X ${i} = ${result}`)
    }
}

solveMultiplicationTable(2);
solveMultiplicationTable(5);