function solveAges(input) {
    const num = Number(input);
    let result = '';

    if (num >= 0 && num <= 2) {
        result = 'baby';
    } else if (num > 3 && num <= 13) {
        result = 'child';
    } else if (num >= 14 && num <= 19) {
        result = 'teenager';
    } else if (num >= 20 && num <= 65) {
        result = 'adult';
    } else if (num >= 66) {
        result = 'elder';
    } else {
        result = 'out of boundaries';
    }

    console.log(result);
}

solveAges(20);
solveAges(1);
solveAges(100);
solveAges(-1);