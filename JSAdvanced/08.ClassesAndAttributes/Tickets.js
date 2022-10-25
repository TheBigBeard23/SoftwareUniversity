function sortTickets(tickets, criteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let result = [];

    tickets.forEach(t => result.push(new Ticket(...t.split('|'))));

    let sortNumbers = (a, b) => a - b;
    let sortStrings = (a, b) => a[criteria].localeCompare(b[criteria]);

    criteria == 'price' ? result.sort(sortNumbers) : result.sort(sortStrings);
    return result;
}

console.log(sortTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'], 'destination')
);