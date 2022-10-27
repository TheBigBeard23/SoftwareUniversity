class Company {
    constructor() {
        this.departments = {};
    }
    addEmployee(name, salary, position, department) {

        if (!name
            || !salary
            || !position
            || !department
            || salary < 0) {
            throw new Error("Invalid input!");
        }

        if (this.departments[department] == undefined) {
            this.departments[department] = [];
        }

        this.departments[department].push({ name, salary, position });
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }
    bestDepartment() {
        let bestDept;
        let bestAvgSalary = 0;

        for (let [department, data] of Object.entries(this.departments)) {
            let crnAvgSalary = data.reduce((x, b) => x + Number(b.salary), 0) / data.length;

            if (bestAvgSalary < crnAvgSalary) {
                bestAvgSalary = crnAvgSalary;
                bestDept = department;
            }
        }
        return `Best Department is: ${bestDept}\n` +
            `Average salary: ${bestAvgSalary.toFixed(2)}\n` +
            `${this.departments[bestDept]
                .sort((a, b) => b.salary - a.salary
                    || a.name.localeCompare(b.name))
                .map(x => `${x.name} ${x.salary} ${x.position}`)
                .join('\n')}`;
    }

}
let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
