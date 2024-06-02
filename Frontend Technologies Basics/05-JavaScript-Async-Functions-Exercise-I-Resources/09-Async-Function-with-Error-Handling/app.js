async function promiseRejectionAsync() {
   let promise = new Promise(function (resolve, reject) {
      setTimeout(function () {
         reject('Error msg');
      }, 2000)
   });

   await promise.catch(function (error) {
      console.log(error)
   });

}

let button = document.querySelector("button");
button.addEventListener("click", promiseRejectionAsync());

