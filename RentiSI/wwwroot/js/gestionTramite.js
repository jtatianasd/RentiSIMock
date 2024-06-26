﻿var dataTable;

$(document).ready(function () {
    cargarDatatable();

    $('#SelectedCasuisticasIds').change(function () {

        if ($('#SelectedCasuisticasIds').val() != null && $('#SelectedCasuisticasIds').val().length > 0) {
            $('#esGestionTramiteSwitch').prop('checked', false);
            $('#esGestionTramiteSwitch').prop('disabled', true);
        } else {
            $('#esGestionTramiteSwitch').prop('disabled', false);
        }
    });

    $('#GestionTramite_IdDetalleEstado').change(function () {

        if ($('#GestionTramite_IdDetalleEstado').val() != 13) {
            $('#esGestionTramiteSwitch').prop('checked', false);
            $('#esGestionTramiteSwitch').prop('disabled', true);
        } else {
            $('#esGestionTramiteSwitch').prop('disabled', false);
        }
    });
            
});


function cargarDatatable() {
    dataTable = $("#tblGestionTramite").DataTable({
        "ajax": {
            "url": "/Coordinador/GestionTramite/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "tramite.numeroPlaca", "width": "13%" },
            { "data": "usuarioTramite", "width": "13%" },
            { "data": "organismosDeTransito.municipio", "width": "15%" },
            { "data": "detalleEstado.descripcionDetalle", "width": "15%" },
            { "data": "nombreCasuisticas", "width": "15%" },
            { "data": "tiempoGestionTramite", "width": "15%" },
            {
                "data": { gestionId: "gestionTramite.gestionId", tramiteId: "tramite.id" },
                "render": function (data) {
                    if (data.gestionTramite.gestionId > 0) {

                        return `<div class="text-center">
                                <a href="/Coordinador/GestionTramite/Edit/${data.gestionTramite.gestionId}" class="btn btn-success" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                          </div>
                         `;
                    } else {
                        return `<div class="text-center">
                                <a href="/Coordinador/GestionTramite/Create/${data.tramite.id}" class="btn btn-success" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Gestionar
                                </a>
                                &nbsp;
                          </div>
                         `;
                    }
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


