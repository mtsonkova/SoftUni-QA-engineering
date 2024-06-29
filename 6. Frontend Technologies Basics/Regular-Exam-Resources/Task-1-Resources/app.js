window.addEventListener("load", solve);

function solve() {

    let ticket = {
        number: '',
        seating: '',
        fullName: '',
        email: '',
        phone: ''
    }


    let ticketNum = document.getElementById('num-tickets');
    let seating = document.getElementById('seating-preference');
    let fullName = document.getElementById('full-name');
    let email = document.getElementById('email');
    let phoneNum = document.getElementById('phone-number');

    let btnPurchaseTickets = document.getElementById('purchase-btn');

    let ulTicketPreview = document.getElementById('ticket-preview');

    let ulTicketPurchase = document.getElementById('ticket-purchase');

    let bottomContent = document.querySelector('.bottom-content');

    btnPurchaseTickets.addEventListener('click', purchaseTicketsFunction);

    function purchaseTicketsFunction() {
        if (ticketNum === '' || seating === '' || fullName === '' || email === '' || phoneNum === '') {
            return;
        }

        ticket.number = ticketNum.value;
        ticket.seating = seating.value;
        ticket.fullName = fullName.value;
        ticket.email = email.value;
        ticket.phone = phoneNum.value;


        //create new article 

        let liTicketPurchase = document.createElement('li');
        liTicketPurchase.setAttribute('class', 'ticket-purchase');

        let articleTicketPurchase = document.createElement('article');

        //create new p elements
        let pCount = document.createElement('p');
        pCount.textContent = `Count: ${ticket.number}`;
        let pPreference = document.createElement('p');
        pPreference.textContent = `Preference: ${ticket.seating}`;
        let pName = document.createElement('p');
        pName.textContent = `To: ${ticket.fullName}`;
        let pEmail = document.createElement('p');
        pEmail.textContent = `Email: ${ticket.email}`;
        let pPhone = document.createElement('p');
        pPhone.textContent = `Phone number: ${ticket.phone}`;

        //append p to article
        articleTicketPurchase.appendChild(pCount);
        articleTicketPurchase.appendChild(pPreference);
        articleTicketPurchase.appendChild(pName);
        articleTicketPurchase.appendChild(pEmail);
        articleTicketPurchase.appendChild(pPhone);

        //create div and buttons
        let divTicketBtnsContainer = document.createElement('div');
        divTicketBtnsContainer.setAttribute('class', 'btn-container');

        let btnEdit = document.createElement('button');
        btnEdit.setAttribute('class', 'edit-btn');
        btnEdit.textContent = 'Edit';

        let btnNext = document.createElement('button');
        btnNext.setAttribute('class', 'next-btn');
        btnNext.textContent = 'Next';

        //append buttons to div
        divTicketBtnsContainer.appendChild(btnEdit);
        divTicketBtnsContainer.appendChild(btnNext)

        //append div and article to li
        liTicketPurchase.appendChild(articleTicketPurchase);
        liTicketPurchase.appendChild(divTicketBtnsContainer);

        //append li to ul
        ulTicketPreview.appendChild(liTicketPurchase);

        //clear form
        ticketNum.value = '';
        seating.value = '';
        fullName.value = '';
        email.value = '';
        phoneNum.value = '';

        //disable PurchaseTickets btn
        btnPurchaseTickets.disabled = true;


        //Edit Btn functionality

        btnEdit.addEventListener('click', editBtnFunction);

        function editBtnFunction() {
            // transfer values
            ticketNum.value = ticket.number;
            seating.value = ticket.seating;
            fullName.value = ticket.fullName;
            email.value = ticket.email;
            phoneNum.value = ticket.phone;

            //enable btn 
            btnPurchaseTickets.disabled = false;

            //delete li
            liTicketPurchase.remove();
        }


        //Next Btn functionality
        btnNext.addEventListener('click', nextBtnFunction);

        function nextBtnFunction() {
            let btnBuy = document.createElement('button');
            btnBuy.setAttribute('class', 'buy-btn');
            btnBuy.textContent = 'Buy';
            divTicketBtnsContainer.remove();
            liTicketPurchase.appendChild(btnBuy);
            ulTicketPurchase.appendChild(liTicketPurchase);

            //Buy btn function
            btnBuy.addEventListener('click', buyBtnFunction);

            function buyBtnFunction() {
                liTicketPurchase.remove();
                let purchaseHeader = document.createElement('h2');
                purchaseHeader.textContent = 'Thank you for your purchase!';

                let btnBack = document.createElement('button');
                btnBack.setAttribute('class', 'back-btn');
                btnBack.textContent = 'Back';


                bottomContent.appendChild(purchaseHeader);
                bottomContent.appendChild(btnBack);

                //Back btn function
                btnBack.addEventListener('click', btnBackFunction);

                function btnBackFunction() {
                    location.reload();
                }

            }
        }
    }
}