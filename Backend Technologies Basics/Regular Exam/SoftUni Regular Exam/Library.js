function library(array) {
    let userInput = array.slice(0);
    let num = Number(userInput.shift());
    let booksArr = [];

    for (let i = 0; i < num; i++) {
        booksArr.push(userInput.shift());
    }

    let currentLine = userInput.shift();
    // Lend, Return, Exchange
    while (currentLine.includes('Stop') == false) {
        let [command, ...rest] = currentLine.split(' ');

        if (command === 'Lend') {
            lendBook(booksArr);
        }

        if (command === 'Return') {
            returnBook(booksArr, ...rest);
        }

        if (command === 'Exchange') {
            let startIndex = Number(rest[0]);
            let endIndex = Number(rest[1]);

            let isValidStartIndex = checkIndex(booksArr, startIndex);
            let isValidEndIndex = checkIndex(booksArr, endIndex);

            if (isValidStartIndex && isValidEndIndex) {
                exchangeBooks(booksArr, startIndex, endIndex);
            }
        }

        currentLine = userInput.shift();
    }

    printResult(booksArr);

    //declare functions

    function lendBook(arr) {
        let bookTitle = arr.shift();
        console.log(`${bookTitle} book lent!`);
    }

    function returnBook(arr, ...rest) {
        let bookTitle = rest.join(' ');
        arr.unshift(bookTitle);
    }

    function exchangeBooks(arr, startIndex, endIndex) {
        let firstBook = arr[startIndex];
        let secondBook = arr[endIndex];

        arr[startIndex] = secondBook;
        arr[endIndex] = firstBook;

        console.log("Exchanged!");
    }

    function checkIndex(arr, index) {
        let isValid = false;

        if (index >= 0 && index <= arr.length - 1) {
            isValid = true;
        }

        return isValid;
    }

    function printResult(arr) {
        if (arr.length == 0) {
            console.log("The library is empty");
        }

        else {
            let booksLeft = booksArr.join(', ');

            console.log("Books left: " + booksLeft);
        }
    }
}

//library(['3', 'Harry Potter', 'The Lord of the Rings', 'The Hunger Games', 'Lend', 'Stop', 'Exchange 0 1']);
//library(['5', 'The Catcher in the Rye', 'To Kill a Mockingbird', 'The Great Gatsby', '1984', 'Animal Farm', 'Return Brave New World', 'Exchange 1 4', 'Stop']);
library(['3', 'The Da Vinci Code', 'The Girl with the Dragon Tattoo', 'The Kite Runner', 'Lend', 'Lend', 'Lend', 'Stop']);