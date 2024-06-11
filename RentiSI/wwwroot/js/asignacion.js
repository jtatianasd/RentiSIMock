var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function FormatoFecha(dateString) {
    var fecha = new Date(dateString);
    var day = ("0" + fecha.getDate()).slice(-2);
    var month = ("0" + (fecha.getMonth() + 1)).slice(-2);
    var year = fecha.getFullYear();
    return `${day}-${month}-${year}`;
}


function cargarDatatable() {
    dataTable = $("#tblAsignaciones").DataTable({
        "ajax": {
            "url": "/Cliente/Asignaciones/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "numeroPlaca", "width": "15%" },
            {
                "data": "fechaCreacion", "width": "10%", render: function (data) {
                    return data ? FormatoFecha(data) : '';
                }
            },
            {
                "data": "financiacion", "width": "10%", "render": function (data) {
                    if (data) {
                        return "Sí";
                    } else {
                        return "No";
                    }
                }
            },
            {
                "data": "impronta", "width": "10%", "render": function (data) {
                    if (data) {
                        return "Sí";
                    } else {
                        return "No";
                    }
                }
            },
            {
                "data": "fechaNegocio", "width": "10%", render: function (data) {
                    return data ? FormatoFecha(data) : '';
                }
            },
            { "data": "organismosDeTransito.municipio", "width": "15%" },
            { "data": "observaciones", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Cliente/Asignaciones/Edit/${data}" class="btn btn-success" style="cursor:pointer; width:120px;">
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


