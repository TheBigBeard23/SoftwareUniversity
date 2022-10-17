function getArticleGenerator(articles) {
    let div = document.querySelector('#content');
    let index = 0;

    function showNext() {
        if (articles.length > index){
            let article = document.createElement('article');
            article.textContent = articles[index++];
            div.appendChild(article); 
        }
    }
    return showNext;
}
