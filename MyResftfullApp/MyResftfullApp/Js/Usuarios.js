var uri = 'api/usuarios';

$(document).ready(function () {
    $.getJSON(uri)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatItem(item) }).appendTo($('#usuarios'));
            });
        });
});

function formatItem(item) {
    return 'Id: ' + item.Id + ' Nombre: ' + item.Nombre + ' - Apellido: ' + item.Apellido + ' - Email: ' + item.Email + ' - Password: ' + item.Password;
}

function find() {
    var id = $('#usuarioId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#usuario').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#usuario').text('Error: ' + err);
        });
}