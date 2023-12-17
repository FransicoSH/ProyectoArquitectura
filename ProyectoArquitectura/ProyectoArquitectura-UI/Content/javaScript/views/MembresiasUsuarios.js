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
    rowData.MenbresiaID = selectedRow.find('td').eq(0).text();

    return rowData;
}


$('#EditarMembresiaUsuario').click(function () {
    var rowData = getSelectedRowData();
    if (rowData == null) {
        alert("Debe seleccionar una fila");
    }
    else {
        window.location.href = "EditarMembresiaUsuario?id=" + rowData.MenbresiaID;
    }
});


$('#CrearMembresiaUsuario').click(function () {
    console.log('test')

    window.location.href = "CrearMembresiaUsuario"
});


$('#EliminarMembresiaUsuario').click(function () {
    var rowData = getSelectedRowData();
    if (rowData) {
        $('#confirmModal').modal('show');
    } else {
        alert("Debe seleccionar una fila");
    }
});

$('#confirmDelete').click(function () {
    var rowData = getSelectedRowData();
    window.location.href = "EiminarCliente?IdCliente=" + rowData.clienteID;
    $('#confirmModal').modal('hide');
});