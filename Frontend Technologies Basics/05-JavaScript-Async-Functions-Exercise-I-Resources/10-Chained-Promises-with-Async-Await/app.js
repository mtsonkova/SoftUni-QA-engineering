async function chainedPromisesAsync() {
    let promise1 = new Promise(function(resolve, reject) {
        setTimeout(function() {
            resolve('1')
        }, 1000
    )});

    let promise2 = new Promise(function(resolve, reject) {
        setTimeout(function() {
            resolve('2')
        }, 2000
    )});

    let promise3 = new Promise(function(resolve, reject) {
        setTimeout(function() {
            resolve('3')
        }, 3000
    )});

    await Promise.all([promise1, promise2, promise3])
    .then(function(result) {
        console.log(result);
    });   
}

let button = document.querySelector("button");
button.addEventListener("click", chainedPromisesAsync());