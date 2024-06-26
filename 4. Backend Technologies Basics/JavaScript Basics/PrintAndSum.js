function solvePrintAndSum(firstNum, secondNum) {
    const startNum = Number(firstNum);
    const endNum = Number(secondNum);
    let output = [];
    let sum = 0;
    

    for(let i = startNum; i <= endNum; i++) {
        output.push(i);
        sum += i;        
    }
  
    console.log(output.join(' '));
    console.log(`Sum: ${sum}`);
}

solvePrintAndSum(5, 10);
solvePrintAndSum(0, 26);
solvePrintAndSum(50, 60);