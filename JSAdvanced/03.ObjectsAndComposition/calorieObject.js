function getObject(arr) {
    let result = {};

    for (let i = 0; i < arr.length; i += 2) {
        let name = arr[i];
        let calories = arr[i + 1];
        result.name = name;
        result.calories = calories;
    }

   console.log(result);
}
getObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
