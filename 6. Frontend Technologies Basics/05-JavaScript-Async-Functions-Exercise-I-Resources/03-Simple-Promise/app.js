async function simplePromise() {
    let promise = new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve('Success!');
        }, 2000);
    });


    let result = await promise;
    console.log(result);
}

