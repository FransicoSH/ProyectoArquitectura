

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
    rowData.UsuarioID = selectedRow.find('td').eq(0).text();
    rowData.UserName = selectedRow.find('td').eq(1).text();
    rowData.Estado = selectedRow.find('td').eq(2).text();
    rowData.NombreRol = selectedRow.find('td').eq(3).text();
    rowData.Descripcion = selectedRow.find('td').eq(4).text();
    return rowData;
}




$('#EditarUsuario').click(function () {
    var rowData = getSelectedRowData();
    if (rowData == null) {
        alert("Debe seleccionar una fila");
    }
    else {
        window.location.href = "EditarUsuario?IdUsuario=" + rowData.UsuarioID;
    }
});


$('#CrearUsuario').click(function () {

    window.location.href = "CreaUsuario"
});


$('#EliminarUsuario').click(function () {
    var rowData = getSelectedRowData();
    if (rowData) {
        $('#confirmModal').modal('show');
    } else {
        alert("Debe seleccionar una fila");
    }
});

$('#confirmDelete').click(function () {
    var rowData = getSelectedRowData();
    console.info(rowData)
    window.location.href = "EiminarUsuario?userid=" + rowData.UsuarioID;
    $('#confirmModal').modal('hide');
});



