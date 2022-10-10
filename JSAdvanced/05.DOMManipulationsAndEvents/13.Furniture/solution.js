function solve() {
  let [generateBtn, buyBtn] = document.querySelectorAll('button');

  generateBtn.addEventListener('click', generate);
  buyBtn.addEventListener('click', buy);

  function generate(event) {
    let items = JSON.parse(document.querySelector('textarea').value);
    let table = document.querySelector('tbody');

    for (let item of items) {
      let newItem = document.querySelector('tbody tr').cloneNode(true);

      newItem.children[0].innerHTML = `<img src="${item.img}">`;
      newItem.children[1].innerHTML = `<p>${item.name}</p>`;
      newItem.children[2].innerHTML = `<p>${item.price}</p>`;
      newItem.children[3].innerHTML = `<p>${item.decFactor}</p>`;
      newItem.children[4].innerHTML = `<input type="checkbox" />`

      table.appendChild(newItem);
    }

  }
  function buy(event) {
    let checkboxes = document.querySelectorAll('tbody input');
    let items = [];
    let totalPrice = 0;
    let DecFactor = 0;

    for (let checkbox of checkboxes) {
      if (checkbox.checked) {
        let data = checkbox.parentElement.parentElement.querySelectorAll('p');

        items.push(data[0].textContent);
        totalPrice += Number(data[1].textContent);
        DecFactor += Number(data[2].textContent);
      }
    }

    let output = document.querySelectorAll('textarea')[1];

    output.textContent += `Bought furniture: ${items.join(', ')}\n`
    output.textContent += `Total price: ${totalPrice.toFixed(2)}\n`
    output.textContent += `Average decoration factor: ${DecFactor / items.length}`
  }

}