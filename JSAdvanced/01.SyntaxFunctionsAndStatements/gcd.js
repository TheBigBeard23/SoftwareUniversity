function greatestDevisor(a, b) {
    if (b) {
        return greatestDevisor(b, a % b);
    }
    else {
        console.log(a)
    }
}
greatestDevisor(2154, 458)