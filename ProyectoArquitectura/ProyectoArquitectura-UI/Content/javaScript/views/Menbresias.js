$(document).ready(function () {
        $('.btn-delete').on('click', function () {
            var tipoMembresiaID = $(this).data('id');
            $('#idMembresia').text(tipoMembresiaID);
            $('#confirmModal').modal('show');
         
        });
  });

$(document).ready(function () {
    $('.btn-edit').on('click', function () {
        var tipoMembresiaID = $(this).data('id');
        ObtenerMenbresia(tipoMembresiaID).then(function (data) {

            console.info(data)
            $('#nombreInput').val(data.Nombre);
            $('#tipoMembresiaIDInput').val(data.TipoMembresiaID);
            $('#precioInput').val(data.Precio);
            $('#descripcionInput').val(data.Descripcion);

        })
            .catch(function (error) {
                console.error("Error al obtener usuario:", error);
            });
    });
});


$('#confirmDelete').click(function () {
    var id = $('#idMembresia').text();
    window.location.href = "EliminarMenbresia?id=" + id
    $('#confirmModal').modal('hide');
  
});



function ObtenerMenbresia(tipoMembresiaID) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "get",
            url: "/GestionMenbresias/ObtieneMenbresia",
            data: { id: tipoMembresiaID },
            success: function (data) {
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}
