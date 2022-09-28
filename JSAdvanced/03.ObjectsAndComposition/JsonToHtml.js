function solve(json) {
    let parsed = JSON.parse(json);

    let columnNames = Object.keys(parsed[0]);
    let values = parsed.map(obj => Object.values(obj));

    let result = '<table>\n';
    result += '   <tr>';
    for (let column of columnNames) {
        result += `<th>${escape(column)}</th>`;
    }
    result += `</tr>\n`

    for (let value of values) {
        result += '   <tr>';
        for (let v = 0; v < value.length; v++) {
            result += `<td>${escape(value[v])}</td>`;
        }
        result += `</tr>\n`
    }
    result += '</table>';

    function escape(str) {
        let entityMap = {
            "&": "&amp;",
            "<": "&lt;",
            ">": "&gt;",
            '"': '&quot;',
            "'": '&#39;'
        };
        return str
            .toString()
            .replace(/[&<>"']/g, (s) => entityMap[s]);
    }
    console.log(result);
}
solve(
    `[{ "Name": "Stamat", "Score": 5.5 },
     { "Name": "Rumen", "Score": 6 }]`
);