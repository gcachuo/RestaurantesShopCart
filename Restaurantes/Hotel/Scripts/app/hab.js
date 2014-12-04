$(document).on("ready", function () {
    $('#btnCreate').on('click', function () {
        
        var hab = new Object();
        hab.Hab_Numero = $('#txtHab').val();
        hab.Hab_Nombre = $('#txtNombre').val();
        hab.Hab_Apellido = $('#txtApellido').val();
        hab.Hab_Rfc = $('#txtRFC').val();
        CreateHab(JSON.stringify(hab));

    });
    function CreateHab(hab) {
        var url = '/api/Habitacion/';
        $.ajax({
            url: url,
            type: 'POST',
            data: hab,
            contentType: "application/json;chartset=utf-8",
            statusCode: {
                201: function () {
                    ClearForm();
                },
                400: function () {
                    ClearForm();
                    alert('Error');
                }
            }
        });
    }
});