$(function () {
    // Controlador de eventos para las filas de la tabla
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
});


