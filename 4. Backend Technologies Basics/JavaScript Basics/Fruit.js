function solveFruit(fruit, weightInGrams, pricePerKilograms) {
let weightInKilograms = weightInGrams / 1000;
let totalPrice = weightInKilograms * pricePerKilograms;

//I need ${money} to buy {weight} kilograms {fruit}."
console.log(`I need \$${totalPrice.toFixed(2)} to buy ${weightInKilograms.toFixed(2)} kilograms ${fruit}.`);
}

solveFruit('orange', 2500, 1.80);
solveFruit('apple', 1563, 2.35);
