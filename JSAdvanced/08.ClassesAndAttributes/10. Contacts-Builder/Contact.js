class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.online = false;
    }
    get online() {
        return this._online;
    }

    set online(value) {
        this._online = value;

        if (this.divTitle) {
            this.divTitle.className = this._online ? 'title online' : 'title';
        }
    }

    render(id) {
        let article = this.createElement('article');

        this.divTitle =
            this.createElement('div', `${this.firstName} ${this.lastName}`,
                this.online ? 'title online' : 'title');

        this.infoBtn = this.createElement('button', '&#8505;');
        this.divTitle.appendChild(this.infoBtn);

        this.divInfo = this.createElement('div', '', 'info');
        this.divInfo.style.display = 'none';
        this.divInfo.appendChild(this.createElement('span', `&phone; ${this.phone}`));
        this.divInfo.appendChild(this.createElement('span', `&#9993;  ${this.email}`));

        article.appendChild(this.divTitle);
        article.appendChild(this.divInfo);

        this.infoBtn.addEventListener('click', () => {
            this.divInfo.style.display == 'none'
                ? this.divInfo.style.display = 'block'
                : this.divInfo.style.display = 'none';
        });

        document.getElementById(id).appendChild(article);
    }

    createElement(name, textContent, className) {
        let element = document.createElement(name);
        textContent ? element.innerHTML = textContent : null;
        className ? element.className = className : null;
        return element;
    }
}

let contacts = [
    new Contact('Ivan', 'Ivanov', '0888 123 456', 'i.ivanov@gmail.com'),
    new Contact('Maria', 'Petrova', '0899 987 654', 'mar4eto@abv.bg'),
    new Contact('Jordan', 'Kirov', '0988 456 789', 'jordk@gmail.com')
];
contacts.forEach(c => c.render('main'));
// After 1 second, change the online status to true
setTimeout(() => contacts[1].online = true, 2000);
