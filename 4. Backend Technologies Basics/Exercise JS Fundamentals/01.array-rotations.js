function solveArrayRotations(arr, num) {
for(let i = 1; i <= num; i++) {
    let firstNum = arr.shift();
   arr.push(firstNum);
}
console.log(arr.join(" "));
}

solveArrayRotations([51, 47, 32, 61, 21], 2);