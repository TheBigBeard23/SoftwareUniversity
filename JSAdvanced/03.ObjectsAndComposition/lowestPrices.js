function lowestPrices(input) {
    let products = [];
    for (let i = 0; i < input.length; i++) {

        let [townName, productName, productLowestPrice] = input[i].split(" | ");

        let index = products.findIndex((obj => obj.productName == productName));

        if (index < 0) {
            products.push({
                productName,
                productLowestPrice,
                townName
            });
        }
        else if (products[index].productLowestPrice > productLowestPrice) {
            products[index] = {
                productName,
                productLowestPrice,
                townName
            };
        }
    }


    for (let product of products) {
        console.log(`${product.productName} -> ${product.productLowestPrice} (${product.townName})`)
    }
}
lowestPrices([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Sample Product | 100'
]);