function monthDays(month, year) {
    let daysCount = new Date(year, month, 0).getDate();
    console.log(daysCount);
}

monthDays(1,2012)