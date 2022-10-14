function listProcessor(commands) {

    let result = [];
    let operator = processor();

    commands.forEach(x => {
        [operation, element] = x.split(' ');
        operator[operation](element);
    });

    function processor() {
        add = (element) => result.push(element);
        remove = (element) => result = result.filter(x => x != element);
        print = () => console.log(result.join(','));

        return {
            add: add,
            remove: remove,
            print: print
        };
    }

}
listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);