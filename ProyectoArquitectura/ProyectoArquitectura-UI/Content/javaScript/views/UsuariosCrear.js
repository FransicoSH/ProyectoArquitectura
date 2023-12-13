$('.table-container tbody tr').click(function (e) {
    if ($(this).hasClass('row-selected')) {
        $(this).addClass('other-clic');
    } else {
        cleanTr();
        $(this).addClass('row-selected');
    }
});

function cleanTr() {
    $('.row-selected').each(function (index, element) {
        $(element).removeClass('row-selected');
        $(element).removeClass('other-clic');
    });
}
function getSelectedRowData() {
    var selectedRow = $('.row-selected');
    var rowData = {};

    if (selectedRow.length === 0) {
        return null;
    }
    rowData.clienteID = selectedRow.find('td').eq(0).text();
    rowData.nombre = selectedRow.find('td').eq(1).text();
    rowData.primerApellido = selectedRow.find('td').eq(2).text();
    rowData.segundoApellido = selectedRow.find('td').eq(3).text();
    rowData.correoElectronico = selectedRow.find('td').eq(4).text();
    rowData.numeroTelefono = selectedRow.find('td').eq(5).text();
    return rowData;
}


function GenerarUsuario(idCliente) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "get",
            url: "/GestionUsuarios/ObtenerUsuario",
            data: { id: idCliente },
            success: function (data) {
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}



$('#AgregarCliente').click(function () {
    var rowData = getSelectedRowData();
    if (rowData == null) {
        alert("Debe seleccionar una fila");
    }
    else {
        var Nombre = document.getElementById("Nombre");
        var UserName = document.getElementById("UserName");
        var ID = document.getElementById("Idpersona");
        ID.value = `${rowData.clienteID}`
        Nombre.value = `${rowData.nombre} ${rowData.primerApellido}  ${rowData.segundoApellido}`
        GenerarUsuario(rowData.clienteID).then(function (data) {
            UserName.value = data;
        })
            .catch(function (error) {
                console.error("Error al obtener usuario:", error);
            });
        $('#ClienteUsuariosModal').modal('hide');
    }
});