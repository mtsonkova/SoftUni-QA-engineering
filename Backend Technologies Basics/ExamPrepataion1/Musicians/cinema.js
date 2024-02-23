function cinema(input) {
    let arr = input.slice(0);
    const numberOfMovies = Number(arr.shift());

    let moviesArr = [];
    for (let i = 0; i < numberOfMovies; i++) {
        moviesArr.push(arr.shift());
    }

    let commandLine = arr.shift();

    while (commandLine !== 'End') {

        if (commandLine.includes('Add')) {
            let stringTitle = commandLine.slice(4);
            addMovie(stringTitle, moviesArr);
        }

        if (commandLine.includes('Sell')) {
            sellMovie(moviesArr);
        }

        if (commandLine.includes('Swap')) {
            let tokens = commandLine.split(' ');
            startIndex = Number(tokens[1]);
            endIndex = Number(tokens[2]);
            let isValidStartIndex = checkIndex(startIndex, moviesArr);
            let isValidEndIndex = checkIndex(endIndex, moviesArr);

            if (isValidStartIndex && isValidEndIndex) {
                swapMovies(startIndex, endIndex, moviesArr);
            }
        }
       commandLine = arr.shift();
    }

    printOutput(moviesArr);
    // declare functions

    function addMovie(title, array) {
        array.push(title);
    }

    function sellMovie(array) {
        const movieTitle = array.shift();
        console.log(`${movieTitle} ticket sold!`);
    }

    function swapMovies(startIndex, endIndex, array) {
        let firstMovie = array[startIndex];
        let secondMovie = array[endIndex];

        array[startIndex] = secondMovie;
        array[endIndex] = firstMovie;
        console.log('Swapped!');
    }

    function checkIndex(index, array) {
        let isValid = false;

        if (index >= 0 && index <= array.length - 1) {
            isValid = true;
        }

        return isValid;
    }

    function printOutput(array) {
        let output = '';
        if (array.length === 0) {
            output = 'The box office is empty';
        } else {
            output = 'Tickets left: ' + array.join(', ');
        }

        console.log(output);
    }
}

//cinema(['3','Avatar', 'Titanic', 'Joker', 'Sell', 'End', 'Swap 0 1']);
//cinema(['5', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'The Dark Knight', 'Inception', 'Add The Lord of the Rings', 'Swap 1 4', 'End']);
cinema(['3', 'Star Wars', 'Harry Potter', 'The Hunger Games', 'Sell', 'Sell', 'Sell', 'End']); 

