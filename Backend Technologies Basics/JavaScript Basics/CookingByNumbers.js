function solveCookingByNumbers(str1, str2, str3, str4, str5, str6) {
    let num = Number(str1);
    num = changeNumber(str2);
    console.log(num);
    num = changeNumber(str3);
    console.log(num);
    num = changeNumber(str4);
    console.log(num);
    num = changeNumber(str5);
    console.log(num);
    num = changeNumber(str6);
    console.log(num);

    //declare functions

    function changeNumber(command) {

        if(command === 'chop') {
            return num / 2;
        } else if(command === 'dice') {
            return Math.sqrt(num);
        } else if(command === 'spice') {
            return num + 1;
        } else if(command === 'bake') {
            return num * 3;
        } else if(command === 'fillet') {
            return num - (num * 0.2);
        }

    }
}

solveCookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
solveCookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
