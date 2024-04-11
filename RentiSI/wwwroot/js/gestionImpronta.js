var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblGestionImpronta").DataTable({
        "ajax": {
            "url": "/Operativo/GestionImpronta/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "gestionId", "width": "5%" },
            { "data": "numeroPlaca", "width": "15%" },
            { "data": "organismoTransito", "width": "15%" },
            { "data": "numeroPlaca", "width": "15%" },
            { "data": "numeroPlaca", "width": "15%" },
            { "data": "fechaRecepcion", "width": "5%" },
            {
                "data": "gestionId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Operativo/GestionImpronta/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
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


