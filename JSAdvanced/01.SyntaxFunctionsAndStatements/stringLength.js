function solve(first,second,third){
    let sumOfLength = first.length + second.length + third.length;
    let averageLength = sumOfLength / 3;   
    console.log(sumOfLength);
    console.log(Math.floor(averageLength));
}

solve(`chocolate`, `ice cream`, `cake`);