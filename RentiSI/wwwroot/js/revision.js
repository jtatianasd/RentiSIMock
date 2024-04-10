var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblRevision").DataTable({
        "ajax": {
            "url": "/Operativo/Revision/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "revisionId", "width": "5%" },
            { "data": "numeroPlaca", "width": "14%" },
            { "data": "numeroPlaca", "width": "14%" },
            { "data": "numeroPlaca", "width": "20%" },
            { "data": "organismoTransito", "width": "17%" },
            { "data": "fechaRecepcion", "width": "15%" },
            { "data": "fechaRecepcion", "width": "30%" },
            {
                "data": "revisionId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Operativo/Revision/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                          </div>
                         `;
                }, "width": "30%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}


