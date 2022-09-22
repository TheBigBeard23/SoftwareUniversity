function slicePies(pies, firstPie, secondPie) {
    let start = pies.indexOf(firstPie);
    let end = pies.indexOf(secondPie);
    return pies.slice(start, end + 1);
}

console.log(slicePies([
    'Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'));