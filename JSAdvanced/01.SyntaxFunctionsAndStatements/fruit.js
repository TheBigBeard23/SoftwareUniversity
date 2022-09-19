function calculatePrice(fruit, weight, pricePerKg) {
    let weightInKg = weight / 1000;
    let price = weightInKg * pricePerKg;
    console.log(`I need $${price} to buy 2.50 kilograms orange.`)

}
calculatePrice(`orange`, 2500, 1.80);