function racePromise() {
    let promise1 = new Promise(function(resolve, reject) {
        setTimeout(function() {
            resolve('1')
        }, 2000
    )});

    let promise2 = new Promise(function(resolve, reject) {
        setTimeout(function() {
            resolve('2')
        }, 3000
    )});

    let promise3 = new Promise(function(resolve, reject) {
        setTimeout(function() {
            resolve('3')
        }, 1000
    )});

    Promise.race([promise1, promise2, promise3]).then(function(result) {
        console.log(result);
    }) 
}