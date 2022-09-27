function cityTaxes(name, population, treasury) {
    return {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += population * this.taxRate;
        },
        applyGrowth(percentage) {
            this.population += population * (percentage / 100);
        },
        applyRecession(percentage) {
            this.treasury += treasury * (percentage / 100);
        }

    }
}
const city =
  cityTaxes('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);