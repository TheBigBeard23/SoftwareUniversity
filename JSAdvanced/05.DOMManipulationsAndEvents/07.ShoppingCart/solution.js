function solve() {
   let addButtons = document.querySelectorAll('.add-product');
   let area = document.querySelectorAll('textarea')[0];
   let payButton = document.querySelector('.checkout');
   let uniqueElements = [];
   let sum = 0;

   for (let crnButton of addButtons) {
      crnButton.addEventListener('click', (event) => {
         let productElement = event.target.parentElement.parentElement;
         let productName = productElement.querySelector('.product-title').textContent;
         let price = productElement.querySelector('.product-line-price').textContent;

         area.textContent += `Added ${productName} for ${price} to the cart.\n`
         sum += Number(price);

         if (uniqueElements.indexOf(productName) < 0) {
            uniqueElements.push(productName);
         }

      })
   }

   payButton.addEventListener('click', () => {
      
      let buttons = document.querySelectorAll('button')

      for (let button of buttons) {
         button.disabled = true;
      }

      area.textContent += `You bought ${uniqueElements.join(', ')} for ${sum.toFixed(2)}.`;
   })
}