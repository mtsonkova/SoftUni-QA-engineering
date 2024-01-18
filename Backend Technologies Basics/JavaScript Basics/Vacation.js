function solveVacation(people, groupType, day) {

    const numOfPeople = Number(people);
    const typeOfGroup = groupType.toLowerCase();
    const dayOfWeek = day.toLowerCase();
    let pricePerOnePerson = 0;

    let totalPrice = 0;

    if (typeOfGroup == 'students' && dayOfWeek == 'friday') {
        pricePerOnePerson = 8.45;
    } else if (typeOfGroup == 'students' && dayOfWeek == 'saturday') {
        pricePerOnePerson = 9.8;
    } else if (typeOfGroup == 'students' && dayOfWeek == 'sunday') {
        pricePerOnePerson = 10.46;
    }

    if (typeOfGroup == 'business' && dayOfWeek == 'friday') {
        pricePerOnePerson = 10.9;
    } else if (typeOfGroup == 'business' && dayOfWeek == 'saturday') {
        pricePerOnePerson = 15.6;
    } else if (typeOfGroup == 'business' && dayOfWeek == 'sunday') {
        pricePerOnePerson = 16;
    }

    if (typeOfGroup == 'regular' && dayOfWeek == 'friday') {
        pricePerOnePerson = 15;
    } else if (typeOfGroup == 'regular' && dayOfWeek == 'saturday') {
        pricePerOnePerson = 20;
    } else if (typeOfGroup == 'regular' && dayOfWeek == 'sunday') {
        pricePerOnePerson = 22.5;
    }

    totalPrice = numOfPeople * pricePerOnePerson;

    if(typeOfGroup == 'students' && numOfPeople >= 30) {
        totalPrice *= 0.85;
    } else if (typeOfGroup == 'business' && numOfPeople >= 100) {
        totalPrice = (numOfPeople - 10) * pricePerOnePerson;
    } else if(typeOfGroup == 'reguar' && (numOfPeople >= 10 && numOfPeople <= 20)) {
        totalPrice *= 0.95;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

solveVacation(30,
    "Students",
    "Sunday"
    );

solveVacation(40,
    "Regular",
    "Saturday"
    );