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

    return rowData;
}


$('#AgregarCliente').click(function () {
    var rowData = getSelectedRowData();
    if (rowData == null) {
        alert("Debe seleccionar una fila");
    }
    else {   
        var UserName = document.getElementById("UserName");
        var ID = document.getElementById("UsuarioID");
        UserName.value = rowData.UserName
        ID.value = rowData.UsuarioID
        console.log(rowData)
        $('#ClienteUsuariosModal').modal('hide');
    }
});