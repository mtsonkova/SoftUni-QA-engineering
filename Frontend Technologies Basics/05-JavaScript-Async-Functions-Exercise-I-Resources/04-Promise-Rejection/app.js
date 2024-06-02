function promiseRejection() {
    new Promise(function(resolve, reject) {
                setTimeout(function() {
        reject('Something went wrong!');

        }, 1000);
        })
        .catch(function(reject) {
        console.log(reject);
        });
}