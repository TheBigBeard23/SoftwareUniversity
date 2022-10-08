function create(words) {
   let content = document.getElementById('content');

   for (let word of words) {
      let div = document.createElement('div');
      div.classList.add('content');

      let p = document.createElement('p');
      p.textContent = word;
      p.style = 'display: none';

      div.appendChild(p);
      content.appendChild(div);
      div.addEventListener('click', showUpContent);
   }

   function showUpContent(event) {
      event.target.children[0].style = 'display: block';
   }
}