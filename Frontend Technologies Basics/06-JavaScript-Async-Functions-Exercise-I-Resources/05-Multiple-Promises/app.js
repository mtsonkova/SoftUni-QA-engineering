function multiplePromises() {
      const promise1 = new Promise(function (resolve, reject) {
            setTimeout(function () {
                  resolve('Promise 1 is resolved')
            }, 1000
            )
      });

      const promise2 = new Promise(function (resolve, reject) {
            setTimeout(function () {
                  resolve('Promise 2 is resolved')
            }, 2000
            )
      });

      const promise3 = new Promise(function (resolve, reject) {
            setTimeout(function () {
                  reject('Promise 3 is rejected')
            }, 3000
            )
      });

      Promise.allSettled([promise1, promise2, promise3])
            .then(results => results.forEach(result => console.log(result.status, result.value, result.reason)));

}


async function multiplePromisesAsyncAwait() {
      const promise1 = new Promise(function (resolve, reject) {
            setTimeout(function () {
                  resolve('Promise 1 is resolved')
            }, 1000
            )
      });

      const promise2 = new Promise(function (resolve, reject) {
            setTimeout(function () {
                  resolve('Promise 2 is resolved')
            }, 2000
            )
      });

      const promise3 = new Promise(function (resolve, reject) {
            setTimeout(function () {
                  reject('Promise 3 is rejected')
            }, 3000
            )
      });

      const results = await Promise.allSettled([promise1, promise2, promise3]);

      results.forEach(result => console.log(result.status, result.value, result.reason));

}