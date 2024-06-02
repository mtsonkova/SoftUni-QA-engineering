async function chainedPromisesAsync() {
   let promise = new Promise(function(resolve, reject) {
    setTimeout(function() {
        resolve('1');
        setTimeout(function() {
            resolve('2');
            setTimeout(function(){
                resolve('3');
            }, 1000)
        }, 1000)
    }, 1000)
   })

    await promise.then(function(result) {
        console.log(result);
    });    
}

let button = document.querySelector("button");
button.addEventListener('click', chainedPromisesAsync());