
function solve(dayOfWeek) {
    let daysOfWeek = ['Monday',
        'Tuesday',
        'Wednesday',
        'Thursday',
        'Friday',
        'Saturday',
        'Sunday']

    if (daysOfWeek.includes(dayOfWeek)) {
        console.log(daysOfWeek.indexOf(dayOfWeek) + 1);
    }
    else{
        console.log('error')
    }
}

solve("Sunda")