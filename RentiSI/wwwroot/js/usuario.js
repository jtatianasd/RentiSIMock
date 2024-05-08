var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblUsuarios").DataTable({
        "ajax": {
            "url": "/Admin/Usuarios/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nombre", "width": "20%"},
            { "data": "email", "width": "20%" },
            {
                "data": { id: "id", lockoutEnd:"lockoutEnd" }
,
                "render": function (data) {
                    var currentDate = new Date();
                    var formattedDate = currentDate.toISOString();
                    if (data.lockoutEnd == null || data.lockoutEnd < formattedDate) {
                        return `<div class="text-center">
                                <a href="/Admin/Usuarios/Bloquear/${data.id}" class="btn btn-success" style="cursor:pointer; width:120px;">
                                <i class="fas fa-lock"></i> Bloquear
                                </a>
                                &nbsp;
                                <a href="/Admin/Usuarios/Edit/${data.id}" class="btn btn-warning" style="cursor:pointer; width:200px;">
                                <i class="fas fa-pen-to-square"></i> Actualizar Contraseña
                                </a>
                                &nbsp;
                                <a href="/Admin/Usuarios/EditRol/${data.id}" class="btn btn-warning" style="cursor:pointer; width:200px;">
                                <i class="fa-solid fa-address-book"></i> Actualizar Rol
                                </a>
                          </div>
                         `;
                    }
                    else {
                        return `<div class="text-center">
                                <a href="/Admin/Usuarios/Desbloquear/${data.id}" class="btn btn-danger" style="cursor:pointer; width:140px;">
                                <i class="fas fa-lock-open"></i> Desbloquear
                                </a>
                                &nbsp;
                                <a href="/Admin/Usuarios/Edit/${data.id}" class="btn btn-warning" style="cursor:pointer; width:200px;">
                                <i class="fas fa-pen-to-square"></i> Actualizar Contraseña
                                </a>
                                &nbsp;
                                <a href="/Admin/Usuarios/EditRol/${data.id}" class="btn btn-warning" style="cursor:pointer; width:200px;">
                                <i class="fa-solid fa-address-book"></i> Actualizar Rol
                                </a>
                          </div>
                         `;
                    }
                   
                }, "width": "50%"
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


