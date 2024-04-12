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
            { "data": "tramite.numeroPlaca", "width": "10%" },
            { "data": "organismosDeTransito.municipio", "width": "15%" },
            { "data": "impronta.tipificacionImpronta", "width": "20%" },
            { "data": "tipoCasuistica.descripcion", "width": "20%" },
            { "data": "recepcion.fechaRecepcion", "width": "5%" },
            {
                "data": "impronta.improntaId",
                "data": "tramite.numeroPlaca",
                "render": function (data) {
                    if (data > 0) {
                        return `<div class="text-center">
                                <a href="/Operativo/GestionImpronta/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                          </div>
                         `;

                    }
                    else
                    {
                        return `<div class="text-center">
                                <a href="/Operativo/GestionImpronta/Create/${data}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
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


