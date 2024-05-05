var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblReasignacion").DataTable({
        "ajax": {
            "url": "/Coordinador/Reasignacion/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "tramite.numeroPlaca", "width": "10%" },
            { "data": "usuarioGestion", "width": "15%" },
            { "data": "organismosDeTransito.municipio", "width": "20%" },
            { "data": "detalleEstado.descripcionDetalle", "width": "20%" },
            { "data": "nombreCasuisticas", "width": "15%" },
            { "data": "tiempoGestionReasignacion", "width": "15%" },
            {
                "data": { reasignacionId: "reasignacion.reasignacionId", tramiteId: "tramite.id" },
                "render": function (data) {

                    return `<div class="text-center">
                                <a href="/Coordinador/Reasignacion/Create/${data.tramite.id}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Gestionar
                                </a>
                                &nbsp;
                          </div>
                         `;

                }, "width": "25%"
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


