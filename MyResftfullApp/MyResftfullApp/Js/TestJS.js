var empleado = {
    firstName: 'Fede',
    lastName: 'Urrutia',
    salary: 9999,
    Employee: function (firstName, lastName, salary) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
    },
    increasing: function () { this.salary = this.salary + 1000; },
    displaying: function () { return 'First Name: ' + this.firstName + ' Last Name: ' + this.lastName + ' Salary: ' + this.salary; }
};

function MultiplyBy(num1, num2, num3) {
    return num1 * num2 * num3;
}

function Longest_Country_Name(list) {
    paisMasGrande = ""
    list.forEach(function (pais) {
        if (pais.length > paisMasGrande.length) {
            paisMasGrande = pais
        };
    });
    return paisMasGrande;
}

function multiplicar() {
    var parametroA = $('#parametroA').val();
    var parametroB = $('#parametroB').val();
    var parametroC = $('#parametroC').val();

    $('#resultadoMultiplicar').text(MultiplyBy(parametroA, parametroB, parametroC));
}

function obtenerPaisMasLargo() {
    var paises = $('#txtPaises').val().split(" ");
    $('#resultadoPaisMasLargo').text(Longest_Country_Name(paises));
}

function removeColor() {
    $("#colorSelect option:selected").remove();
}

function insert_Row() {
    var table = document.getElementById('sampleTable').getElementsByTagName('tbody')[0];
    var newRow = table.insertRow(table.rows.length);

    var newCell1 = newRow.insertCell(0);
    var newCell2 = newRow.insertCell(1);

    var cellText1 = document.createTextNode('New row Cell 1');
    var cellText2 = document.createTextNode('New row Cell 2');

    newCell1.appendChild(cellText1);
    newCell2.appendChild(cellText2);
}
