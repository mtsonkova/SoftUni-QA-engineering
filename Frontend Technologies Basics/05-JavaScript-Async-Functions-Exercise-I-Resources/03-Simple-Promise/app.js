function simplePromise() {
    new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve('Success!');
        }, 2000);
    })
        .then(function (res) {
            console.log(res);
        });
}

simplePromise();