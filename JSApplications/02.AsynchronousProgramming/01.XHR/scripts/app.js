function loadRepos() {
   const url = 'https://api.github.com/users/testnakov/repos';
   const httpRequest = new XMLHttpRequest();

   httpRequest.addEventListener('readystatechange', () => {
      if (httpRequest.readyState == 4) {
         let data = JSON.parse(httpRequest.responseText);
         document.getElementById('res').textContent = data.map(x => x.name).join(', ');
      }
   });
   
   httpRequest.open('GET', url);
   httpRequest.send();
}