function helloWorld() {
    console.log('Hello');
    setTimeout(function(){
        console.log('World'), 2000
    });    
}

helloWorld();