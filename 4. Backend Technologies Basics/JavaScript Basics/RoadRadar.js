function solveRoadRadar(speed, area) {
    const motorwayLimit = 130;
    const interstateLimit = 90;
    const cityLimit = 50;
    const residentialLimit = 20;
    let output = '';
    let status = '';
    let speedDifference = 0;

    if (area === 'motorway' && speed <= motorwayLimit) {
        output = `Driving ${speed} km/h in a ${motorwayLimit} zone`
    } else if (area === 'interstate' && speed <= interstateLimit) {
        output = `Driving ${speed} km/h in a ${interstateLimit} zone`
    } else if (area === 'city' && speed <= cityLimit) {
        output = `Driving ${speed} km/h in a ${cityLimit} zone`
    } else if (area === 'residential' && speed <= residentialLimit) {
        output = `Driving ${speed} km/h in a ${residentialLimit} zone`
    }

    if (area === 'motorway' && speed > motorwayLimit) {
        speedDifference = Math.abs(motorwayLimit - speed);
        output = `The speed is ${speedDifference} km/h faster than the allowed speed of ${motorwayLimit} - `;
    } else if (area === 'interstate' && speed > interstateLimit) {
        speedDifference = Math.abs(interstateLimit - speed);
        output = `The speed is ${speedDifference} km/h faster than the allowed speed of ${interstateLimit} - `;
    } else if (area === 'city' && speed > cityLimit) {
        speedDifference = Math.abs(cityLimit - speed);
        output = `The speed is ${speedDifference} km/h faster than the allowed speed of ${cityLimit} - `;
    } else if (area === 'residential' && speed > residentialLimit) {
        speedDifference = Math.abs(residentialLimit - speed);
        output = `The speed is ${speedDifference} km/h faster than the allowed speed of ${residentialLimit} - `;
    }

    if (speedDifference <= 20) {
        status = 'speeding';
    } else if (speedDifference > 20 && speedDifference <= 40) {
        status = 'excessive speeding';
    } else if (speedDifference > 40) {
        status = 'reckless driving';
    }

    if(speedDifference > 0) {
       console.log(output + status);
    } else {
    console.log(output);
    }
}


solveRoadRadar(40, 'city');
solveRoadRadar(21, 'residential');