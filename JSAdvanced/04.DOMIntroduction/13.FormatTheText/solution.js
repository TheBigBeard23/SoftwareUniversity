function solve() {
  let input = document.getElementById('input').value;
  let output = document.getElementById('output');

  let sentences = input
    .split('.')
    .map(x => x.trim())
    .filter(x => x.length != 0);

  output.innerHTML = '';

  while (sentences.length > 0) {
    let arr = sentences.splice(0, 3);
    let crnParagraph = arr.join('. ') + '.';
    let p = document.createElement('p');
    p.textContent = crnParagraph;
    output.appendChild(p);
  }
}