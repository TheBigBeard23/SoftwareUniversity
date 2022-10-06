function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector('#inputs textarea').value);
      let avgSalary = 0;
      let totalSalary = 0;
      let currentSalary = 0;
      let bestName = '';
      let output = {};

      for (let element of input) {
         let restaurantInfo = element.split(' - ');
         let restaurantName = restaurantInfo.shift();
         let workersInfo = restaurantInfo[0].split(', ');

         for (let worker of workersInfo) {

            let [name, salary] = worker.split(' ');

            if (!output.hasOwnProperty(restaurantName)) {
               output[restaurantName] = {};
            }

            output[restaurantName][name] = Number(salary);

         }
      }

      let entries = Object.entries(output);

      for (let entry of entries) {

         let key = entry[0];
         let values = Object.entries(entry[1]);

         for (let [name, salary] of values) {
            totalSalary += salary;
         }
         currentSalary = totalSalary / values.length;

         if (currentSalary > avgSalary) {
            avgSalary = currentSalary;
            bestName = key;
         }
         totalSalary = 0;
      }

      let print = ' ';
      let result = Object.entries(output[bestName]);
      result.sort((a, b) => b[1] - a[1]);

      result.forEach(x => print += `Name: ${x[0]} With Salary: ${x[1]} `);

      document.querySelector('#bestRestaurant p')
         .textContent = `Name: ${bestName} Average Salary: ${avgSalary.toFixed(2)} Best Salary: ${result[0][1].toFixed(2)}`;

      document.querySelector('#workers p').textContent = print;
   }
}