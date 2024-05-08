var dataTable;

$(document).ready(function () {
    cargarDatatable();
    EsForaneo();


    $('#SelectedCasuisticasIds').change(function () {
      
        if ($('#SelectedCasuisticasIds').val() != null && $('#SelectedCasuisticasIds').val().length > 0) {
            $('#revisionSwitch').prop('checked', false); 
            $('#revisionSwitch').prop('disabled', true); 
        } else {
            $('#revisionSwitch').prop('disabled', false);
        }
    });

    $('#tramiteRevision').change(function () {
        EsForaneo();
    });


});

function EsForaneo() {
    if ($('#tramiteRevision').val() === "Foranea") {
        $('#numeroGuia').prop('disabled', false);
    }
    else {
        $('#numeroGuia').prop('disabled', true);
    }
}

function cargarDatatable() {
    dataTable = $("#tblRevision").DataTable({
        "ajax": {
            "url": "/Operativo/Revision/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "tramite.numeroPlaca", "width": "14%" },
            { "data": "revision.tipificacionTramiteRevision", "width": "14%" },
            { "data": "nombreCasuisticas", "width": "20%" },
            { "data": "organismosDeTransito.municipio", "width": "17%" },
            { "data": "fechaRecepcion", "width": "15%" },
            { "data": "fechaImpronta", "width": "30%" },
            {
                "data": { revisionId: "revision.revisionId", tramiteId: "tramite.id" },
                "render": function (data) {
                    if (data.revision.revisionId > 0) {
                        return `<div class="text-center">
                                <a href="/Operativo/Revision/Edit/${data.revision.revisionId}" class="btn btn-success" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Editar
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


