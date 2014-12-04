$(document).on("ready", function () {
    $('#btnSearch').on('click', function () {
        GetPedidoById($('#txtIdSearch').val());
    });
    $('#btnDelete').on('click', function () {
        DeletePedidoById($('#txtIdSearch').val());
    });
    $('#btnUpdate').on('click', function () {
        var pedido = new Object();
        pedido.Ped_Registro = $('#txtIdSearch').val();
        pedido.Ped_Nombre = $('#txtName').val();
        pedido.Ped_Total = $('#txtTotal').val();
        pedido.Ped_Completado = "Completado";
        UpdatePedido(pedido.Ped_Registro, JSON.stringify(pedido));
    });
    $('#btnCreate').on('click', function () {
        var pedido = new Object();
        pedido.Ped_Nombre = $('#txtName').val();
        pedido.Ped_Descripcion = $('#txtDescripcion').val();
        pedido.Ped_Total = $('#txtTotal').val();
        CreatePedido(JSON.stringify(pedido));
    });
    GetAll();
}); //Get all pedidos
function GetAll() {
    var item = "";
    $('#tblList tbody').html('');
    $.getJSON('/api/Pedido', function (data) {
        $.each(data, function (key, value) {

          
            item += "<tr><td>" + value.Ped_Registro + "</td><td>" + value.Ped_Nombre + "</td><td>" + value.Ped_Total + "</td><td>" + value.Ped_Completado + "</td></tr>";
            
        });
        $('#tblList tbody').append(item);
    });
};


//Get pedido by id
function GetPedidoById(idPedido) {
    var url = '/api/Pedido/' + idPedido;
    $.getJSON(url).done(function (data) {
            $('#txtName').val(data.Ped_Nombre);
            //$('#txtDescripcion').val(data.Ped_Descripcion);
            $('#txtTotal').val(data.Ped_Total);
        })
        .fail(function (erro) {
        alert(erro);
            ClearForm();
        });
};

//Delete pedido by id
function DeletePedidoById(idPedido) {
    var url = '/api/pedido/' + idPedido;
    $.ajax({
        url: url,
        type: 'DELETE',
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
                ClearForm();
                alert('Pedido ' + idPedido + ' fue borrado');
            },
            404: function () {
                alert('Pedido ' + idPedido + ' no se encontro');
            }
        }
    });
}

//Update pedido
function UpdatePedido(idPedido, pedido) {
    var url = '/api/pedido/' + idPedido;
    $.ajax({
        url: url,
        type: 'PUT',
        data: pedido,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
                alert('Pedido: ' + idPedido + ' fue completado');
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


//Create a new pedido
function CreatePedido(pedido) {
    debugger;
    var url = '/api/Pedido/';
    $.ajax({
        url: url,
        type: 'POST',
        data: pedido,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            201: function () {
                GetAll();
                ClearForm();
                alert('Pedido with id: ' + idPedido + ' was updated');
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