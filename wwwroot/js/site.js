$(document).ready(function () {
    getDatatable('#Tabela-Locais');
    getDatatable('#Tabela-Evento');

    $(document).on('click', '.btn-Modal-Editar-Local', function () {
        var locaisid = $(this).attr('locais-id');

        $.ajax({
            type: 'GET',
            url: '/Locais/Deletar/' + locaisid,
            success: function (result) {
                $('#ApagarLocais').html(result);
                $('#ModalApagarLocais').modal('show'); // Adicionei 'show' para garantir que o modal seja exibido
            },
            error: function (xhr, status, error) {
                console.error('Erro na requisição AJAX:', error);
            }
        });
    });

    $(document).on('click', '.btn-Modal-Editar-Evento', function () {
        var eventossi = $(this).attr('eventos-id');

        $.ajax({
            type: 'GET',
            url: '/Eventos/Deletar/' + eventossi,
            success: function (result) {
                $('#ApagarEventos').html(result);
                $('#ModalApagarEventos').modal('show'); // Adicionei 'show' para garantir que o modal seja exibido
            },
            error: function (xhr, status, error) {
                console.error('Erro na requisição AJAX:', error);
            }
        });
    });
})


function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        },
        "lengthMenu": [
            [10, 25, 50, 100, -1], // Número de registros por página
            ["10", "25", "50", "100", "Mostrar todos"] // Texto para o menu de seleção
        ],
        "pageLength": 10 // Quantidade de registros por página inicial
    });
}

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});