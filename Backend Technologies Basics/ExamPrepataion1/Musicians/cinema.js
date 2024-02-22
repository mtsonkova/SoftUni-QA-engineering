function cinema(input) {
    let arr = input.slice(0);
    const numberOfMovies = Number(arr.shift());

    let moviesArr = [];
    for(let i = 0; i < numberOfMovies; i++) {
        moviesArr.push(arr.shift());        
    }

    let commandLine = arr.shift();

    while(commandLine !== 'End') {
        
        if(commandLine.includes('Add')) {
            let stringTitle = commandLine.slice(4);
            addMovie(stringTitle);
        } 

        if(commandLine.includes('Sell')) {
            sellMovie(moviesArr);
        }

        if(commandLine.includes('Swap')) {
            const[command, startIndex, endIndex] = commandLine;
            swapMovies
        }
    }

    // declare functions

    function addMovie(title) {
        moviesArr.push(title);
    }

    function sellMovie(moviesArr) {
        const movieTitle = moviesArr.shift();
        console.log(`${movieTitle} ticket sold!`);
    }

    //Sell
    //Add {movie title}
    // Swap { start, end indexes}
    
}

//cinema(['3','Avatar', 'Titanic', 'Joker', 'Sell', 'End', 'Swap 0 1']);
cinema(['5', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'The Dark Knight', 'Inception', 'Add The Lord of the Rings', 'Swap 1 4', 'End']);
//cinema(['3', 'Star Wars', 'Harry Potter', 'The Hunger Games', 'Sell', 'Sell', 'Sell', 'End']); 

