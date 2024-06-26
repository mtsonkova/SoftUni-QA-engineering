class Contact{
    constructor(firstName, lastName, phoneNumber, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.online = false;
    }
}

let contact = new Contact('Ivan', 'Ivanov', '0800008825', 'ivanov@test.qa');

let fullName = `${contact.firstName} ${contact.lastName}`;
let titleElement = document.querySelector('.title');
titleElement.innerHTML = `${fullName}<button>ℹ</button>`
let button = document.querySelector('button');

//fill details in contactTitle

let contactInfo = document.querySelector('.info');
//fill in details in contact form
let spanElements = document.querySelectorAll('.info span');
let phoneElement = spanElements[0].textContent.split("{phone}");
phoneElement[1] = contact.phoneNumber;
spanElements[0].textContent = phoneElement.join(' ');


let emailElement = spanElements[1].textContent.split('{email}');
emailElement[1] = contact.email;
spanElements[1].textContent = emailElement.join(' ');

//hide and show contact form
contactInfo.setAttribute('style', 'display:none');
let displayAttribiute;
 

button.addEventListener('click', () => {
    console.log('clicked');
    displayAttribiute = contactInfo.style.display;

    if(displayAttribiute === 'none') {
        contactInfo.setAttribute('style','display:block');
    } else if (displayAttribiute === 'block') {
        contactInfo.setAttribute('style', 'display:none');        
    }    
});  

//change title class to online
contact.online = true;
if(contact.online === true) {     
    titleElement.classList.add("online");
    cobsole.log(`status set to online`);
}





             
