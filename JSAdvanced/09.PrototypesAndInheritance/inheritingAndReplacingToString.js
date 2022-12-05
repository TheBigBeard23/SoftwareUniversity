function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
        toString() {
            let result = `${this.constructor.name} (`

            let arr = [];

            Object.entries(this)
                .forEach(x => {
                    arr.push(`${x[0]}: ${x[1]}`)
                });

            result += arr.join(', ') + ')';

            return result;
            //"Teacher (name: {name}, email: {email}, subject: {subject})"
        }
    }
    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    }
    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

let obj = toStringExtension();
let student = new obj.Student('Pesho', 'poesho@anv.bg', 'jsAdvanced');
console.log(student.toString());
