async function fetchSequential() {
      const firstResponse = await fetch('https://swapi.dev/api/people/1').then(res => res.json());
      console.log(firstResponse);
      const secondResponse = await fetch('https://swapi.dev/api/people/2').then(res => res.json());
      console.log(secondResponse);
}