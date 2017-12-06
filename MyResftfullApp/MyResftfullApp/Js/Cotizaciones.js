var uri = 'api/cotizacion';

function formatItem(item) {
    return item.Nombre + ': [Precio Compra: $' + item.CotizacionCompra + '] - [Precio Venta: $' + item.CotizacionVenta + '] - [' + item.LeyendaActualizacion + ']';
}

function find() {
    var id = $('#monedaId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            debugger;

            if (id.toUpperCase() == "DOLAR")
            {
                arrDolar = data.replace("[", "").replace("]", "").split(",");
                var itemDolar = {
                    Nombre: "Dolar",
                    CotizacionCompra: arrDolar[0].replace(/['"]+/g, ''),
                    CotizacionVenta: arrDolar[1].replace(/['"]+/g, ''),
                    LeyendaActualizacion: arrDolar[2].replace(/['"]+/g, '')
                }

                $('#moneda').text(formatItem(itemDolar));
            }
            else
            {
                $('#moneda').text(formatItem(data));
            }
            
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#moneda').text('Error: ' + err.replace(/['"]+/g, ''));
        });
}

function getCotDol() {
    $.ajax({
        type: "POST",
        url: "https://www.bancoprovincia.com.ar/Principal/Dolar",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response)
        }
    });
}