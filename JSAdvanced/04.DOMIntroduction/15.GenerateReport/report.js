function generateReport() {
    let headCols = document.querySelectorAll('thead tr th');
    let tableRows = document.querySelectorAll('tbody tr');
    let result = [];
    
    for (let r = 0; r < tableRows.length; r++) {
        let tableRowInfo = tableRows[r].cells;
        let crnObj = {};

        for (let c = 0; c < tableRowInfo.length; c++) {
            let infoHeader = headCols[c].childNodes;
            if (infoHeader[1].checked) {
                crnObj[infoHeader[0].textContent.trim().toLocaleLowerCase()] = tableRowInfo[c].textContent;
            }

        }
        result.push(crnObj);
    }

    let jsonResult = JSON.stringify(result);
    document.getElementById('output').textContent = jsonResult;
}