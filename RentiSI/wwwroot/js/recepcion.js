var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblRecepcion").DataTable({
        "ajax": {
            "url": "/Coordinador/Recepcion/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "fechaRecepcion", "width": "15%" },
            { "data": "numeroPlaca", "width": "15%" },
            { "data": "usuarioRecibe", "width": "15%" },
            { "data": "organismosDeTransito.municipio", "width": "20%" },
            { "data": "fechaAsignacion", "width": "20%" },
            { "data": "esImpronta", "width": "5%" },
            {
                "data": "recepcion.recepcionId",
                "tramiteId": "tramiteId",
                "render": function (data, type, row) {
                    if (data > 0) {
                        return `<div class="text-center">
                                <a href="/Coordinador/Recepcion/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                          </div>
                         `;
                    }
                    else {
                        return `<div class="text-center">
                                <a href="/Coordinador/Recepcion/Create/${row.tramiteId}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Gestionar
                                </a>
                                &nbsp;
                          </div>
                         `;
                    }
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


