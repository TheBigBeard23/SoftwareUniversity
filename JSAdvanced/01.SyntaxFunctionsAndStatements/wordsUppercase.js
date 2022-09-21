function printWords(text) {
    let words = text.match(/\w+/g);
    console.log(words.map(x => x.toUpperCase()).join(", "));

}
printWords('Hi, how\'s are you?');