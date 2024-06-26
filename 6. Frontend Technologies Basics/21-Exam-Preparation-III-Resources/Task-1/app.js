window.addEventListener('load', solve);

function solve() {

    let eventObj = {
        time: '',
        date: '',
        palce: '',
        eventName: '',
        email: ''

    }

    //Add Autumn Event
    const time = document.getElementById('time');
    const date = document.getElementById('date');
    const place = document.getElementById('place');
    const event = document.getElementById('event-name');
    const email = document.getElementById('email');
    const btnAdd = document.getElementById('add-btn');

    // Upcoming
    const ulUpcoming = document.getElementById('upcoming-list');

    //Last Chesk
    const ulLastCheck = document.getElementById('check-list');

    //Finished
    const ulFinished = document.getElementById('finished-list');

    const btnClear = document.getElementById('clear');

    // Logic

    btnAdd.addEventListener('click', btnAddFunction);

    function btnAddFunction() {
        if (time.value === '' || date.value === '' || place.value === '' ||
            event.value === '' || email.value === '') {
            return;
        }

        eventObj.time = time.value;
        eventObj.date = date.value;
        eventObj.place = place.value;
        eventObj.eventName = event.value;
        eventObj.email = email.value;

        let checkListLi = document.createElement('li');
        checkListLi.setAttribute('class', 'event-content');

        let checkListArticle = document.createElement('article');
        let timeParagraph = document.createElement('p');
        timeParagraph.textContent = `Begins: ${eventObj.date} at: ${eventObj.time}`;

        let placeParagraph = document.createElement('p');
        placeParagraph.textContent = `In: ${eventObj.place}`;

        let eventNameParagraph = document.createElement('p');
        eventNameParagraph.textContent = `Event: ${eventObj.eventName}`;

        let emailParagraph = document.createElement('p');
        emailParagraph.textContent = `Contact: ${eventObj.email}`;

        checkListArticle.appendChild(timeParagraph);
        checkListArticle.appendChild(placeParagraph);
        checkListArticle.appendChild(eventNameParagraph);
        checkListArticle.appendChild(emailParagraph);

        let btnEdit = document.createElement('button');
        btnEdit.setAttribute('class', 'edit-btn');
        btnEdit.textContent = 'Edit';

        let btnContinue = document.createElement('button');
        btnContinue.setAttribute('class', 'continue-btn');
        btnContinue.textContent = 'Continue';

        checkListLi.appendChild(checkListArticle);
        checkListLi.appendChild(btnEdit);
        checkListLi.appendChild(btnContinue);

        console.log(checkListLi);
        ulLastCheck.appendChild(checkListLi);


        time.value = '';
        date.value = '';
        place.value = '';
        event.value = '';
        email.value = '';

        btnAdd.disabled = true;


        //btnEdit click event function

        btnEdit.addEventListener('click', btnEditFunction);


        function btnEditFunction() {
            time.value = eventObj.time;
            date.value = eventObj.date;
            place.value = eventObj.place;
            event.value = eventObj.eventName;
            email.value = eventObj.email;

            btnAdd.disabled = false;

            checkListLi.remove();

        }

        // Continue btn logic

        btnContinue.addEventListener('click', btnContinueFunction);

        function btnContinueFunction() {
            btnEdit.remove();
            btnContinue.remove();
            let btnMoveToFinished = document.createElement('button');
            btnMoveToFinished.setAttribute('class', 'finished-btn');
            btnMoveToFinished.textContent = 'Move to Finished';
            checkListLi.appendChild(btnMoveToFinished);
            ulUpcoming.appendChild(checkListLi);
            btnAdd.disabled = false;

            // Move to finished btn logic

            btnMoveToFinished.addEventListener('click', btnMoveToFinishedFunction);

            function btnMoveToFinishedFunction() {
                btnMoveToFinished.remove();
                ulFinished.appendChild(checkListLi);               
            }

            // clear btn logic
            btnClear.addEventListener('click', btnClearFunction);

            function btnClearFunction() {
                checkListLi.remove();
            }
        }
    }

}




