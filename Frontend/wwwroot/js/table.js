var dataTable;

$(document).ready(function () {
    loadDataTable();
    
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": { url: '/home/getall' },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "name", "width": "20%" },
            { "data": "description", "width": "40%" },
            { "data": "date", "width": "15%" },
            {data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/Home/Details/${data}"" class="btn btn-primary">Start?</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
    $('#searchName').on('keyup', function () {
        dataTable.column(1).search(this.value).draw();
    });
}
