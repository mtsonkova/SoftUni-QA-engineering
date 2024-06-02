function chainedPromises() {
    console.log('Start');
    setTimeout(() => {
        console.log('1');
        setTimeout(() => {
            console.log('2');
            setTimeout(() => {
                console.log('3');
            }, 1000);
        }, 1000);
    }, 1000);
}

function wait(ms) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve()
        }, ms)
    });
}
function chainedPromisesWithPromise() {
    console.log('Start');
    wait(1000)
        .then(function () {
            console.log('1');
            return wait(1000);
        })
        .then(function () {
            console.log('2');
            return wait(1000);
        })
        .then(function () {
            console.log('3');
        });
}

