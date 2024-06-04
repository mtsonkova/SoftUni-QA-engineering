async function fetchSequential() {
      const firstResponse = await fetch('https://swapi.dev/api/people/1').then(res => res.json());
      console.log(firstResponse);
      const secondResponse = await fetch('https://swapi.dev/api/people/2').then(res => res.json());
      console.log(secondResponse);
}

async function fetchSequentialAsyncAwait() {
      const firstResponse = await fetch('https://swapi.dev/api/people/1');
      const data1 = await firstResponse.json();
      console.log(data1);

      const secondResponse = await fetch('https://swapi.dev/api/people/2');
      const data2 = await secondResponse.json();
      console.log(data2);

}