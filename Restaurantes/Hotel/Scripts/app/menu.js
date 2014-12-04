$(document).on("ready", function () {
   
    $('#btnSearch').on('click', function () {
        UpdatePedido($('#txtHab').val());
        GetArticuloById($('#txtIdSearch').val());
    });
    $('#btnDelete').on('click', function () {
        DeletePedidoById($('#txtHab').val());
    });
    $('#btnRefresh').on('click', function () {
        GetCarro();
    });
    $('#btnUpdate').on('click', function () {
        var menu = new Object();
        menu.Ped_Registro = $('#txtIdSearch').val();
        menu.Ped_Nombre = $('#txtName').val();
        menu.Ped_Total = $('#txtTotal').val();
        menu.Ped_Completado = "Completado";
        UpdatePedido(menu.Ped_Registro, JSON.stringify(menu));
    });
    $('#btnCreate').on('click', function () {
        var suma;
        $.getJSON('/api/Carrito', function (data) {
            $.each(data, function (key, value) {
                suma += value.Carrito_Precio;
            });
        });
        var menu = new Object();
        menu.Ped_Id = $('#txtHab').val();
        menu.Ped_Nombre = $('#txtHab').val();
        menu.Ped_Total = $("#Total").text();
        CreatePedido(JSON.stringify(menu));
        DeletePedidoById($('#txtHab').val());
        window.location.href = "Habitacion";
    });
    GetAll();
    GetCarro();
}); //Get all menus
function GetAll() {
    var item = "";
    $('#tblList tbody').html('');
    $.getJSON('/api/Menu', function (data) {
        $.each(data, function (key, value) {


            item += "<tr><td>" + value.Menu_Id + "</td><td>" + value.Menu_Restaurante + "</td><td>" + value.Menu_Tipo + "</td><td>" + value.Menu_Nombre + "</td><td>" + value.Menu_Descripcion + "</td><td align='right'>" + value.Menu_Precio + "</td></tr>";

        });
        $('#tblList tbody').append(item);
    });
};

function GetCarro() {
    var item = "";
    var suma = 0;
    $('#tblCarro tbody').html('');
    $.getJSON('/api/Carrito', function (data) {
        $.each(data, function (key, value) {

            item += "<tr><td>" + value.Carrito_Id + "</td><td>" + value.Carrito_Restaurante + "</td><td>" + value.Carrito_Tipo + "</td><td>" + value.Carrito_Nombre + "</td><td>" + value.Carrito_Descripcion + "</td><td align='right'>" + value.Carrito_Precio + "</td></tr>";
            suma += value.Carrito_Precio;
        });

        $('#tblCarro tbody').append(item);

        document.getElementById("tblCarro").deleteTFoot();
        var foot = $("#tblCarro").find('tfoot');
        if (!foot.length) foot = $('<tfoot>').appendTo("#tblCarro");
        foot.append($('<td><td><td><td><td align="right"><b>Total</b></td><td align="right" id="Total">' + suma + '</td></td></td></td></td>'));
    });

};


//Get menu by id
function GetArticuloById(idPedido) {
    var url = '/api/Menu/' + idPedido;
    $.getJSON(url).done(function (data) {
    })
        .fail(function (erro) {
            alert(erro);
            ClearForm();
        });
};

//Delete menu by id
function DeletePedidoById(idPedido) {
    var url = '/api/Menu/' + idPedido;
    $.ajax({
        url: url,
        type: 'DELETE',
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetCarro();
                ClearForm();
                alert('Correcto');
            },
            404: function () {
                alert('Pedido ' + idPedido + ' no se encontro');
            }
        }
    });
}

//Update menu
function UpdatePedido(idPedido, menu) {
    var url = '/api/Menu/' + idPedido;
    $.ajax({
        url: url,
        type: 'PUT',
        data: menu,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetCarro();
                ClearForm();
            },
            404: function () {

                alert('Pedido ' + idPedido + ' no se encontro');
                ClearForm();
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}


//Create a new menu
function CreatePedido(menu) {
    var url = '/api/Pedido/';
    $.ajax({
        url: url,
        type: 'POST',
        data: menu,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            201: function () {
                GetAll();
                ClearForm();
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}

//Clear form
function ClearForm() {
    $('#txtIdSearch').val('');
    $('#txtName').val('');
    $('#txtDescripcion').val('');
    $('#txtTotal').val('');
}