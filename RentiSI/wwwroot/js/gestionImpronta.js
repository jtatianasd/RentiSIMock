var dataTable;

$(document).ready(function () {
    cargarDatatable();
    if ($('#SelectedCasuisticasIds').val() != null && $('#SelectedCasuisticasIds').val().length > 0) {
        $('#resueltoSwitch').prop('checked', false);
        $('#resueltoSwitch').prop('disabled', true);
    } else {
        $('#resueltoSwitch').prop('disabled', false);
    }
    $('#SelectedCasuisticasIds').change(function () {

        if ($('#SelectedCasuisticasIds').val() != null && $('#SelectedCasuisticasIds').val().length > 0) {
            $('#resueltoSwitch').prop('checked', false);
            $('#resueltoSwitch').prop('disabled', true);
        } else {
            $('#resueltoSwitch').prop('disabled', false);
        }
    });
});


function cargarDatatable() {
    dataTable = $("#tblGestionImpronta").DataTable({
        "ajax": {
            "url": "/OperativoImpronta/GestionImpronta/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "tramite.numeroPlaca", "width": "10%" },
            { "data": "organismosDeTransito.municipio", "width": "15%" },
            { "data": "impronta.tipificacionImpronta", "width": "20%" },
            { "data": "nombreCasuisticas", "width": "20%" },
            {
                "data": "recepcion.fechaRecepcion", "width": "5%", render: function (data) {
                    var fecha = new Date(data);
                    return fecha.toLocaleDateString('es-ES');
                }
            },
            {
                "data": "impronta.esResuelto", "width": "5%", render: function (data) {
                    if (data) {
                        return "Sí";
                    } else {
                        return "No";
                    }
                }
            },
            {
                "data": { improntaId: "impronta.improntaId", tramiteId: "tramite.id" },
                "render": function (data) {
                    if (data.impronta.improntaId > 0) {
                        return `<div class="text-center">
                                <a href="/OperativoImpronta/GestionImpronta/Edit/${data.impronta.improntaId}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                          </div>
                         `;
                    }
                    else
                    {
                        return `<div class="text-center">
                                <a href="/OperativoImpronta/GestionImpronta/Create/${data.tramite.id}" class="btn btn-success text-white" style="cursor:pointer; width:120px;">
                                <i class="far fa-edit"></i> Gestionar
                                </a>
                                &nbsp;
                          </div>
                         `;
                    }
                }, "width": "20%"
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


