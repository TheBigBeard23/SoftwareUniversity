function solve(obj) {
    if (obj.dizziness) {
        let waterAmount = 0.1 * obj.weight * obj.experience;
        obj.levelOfHydrated += waterAmount;
        obj.dizziness = false;
    }
    return obj;
}
console.log(solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}));