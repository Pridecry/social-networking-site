$('.datatable').DataTable(
{
    pagingType: 'full_numbers',
    "columnDefs": [ 
        { "orderable": false, "targets": -1 },
        { "width": "170px", "targets": -1 }
        //{ "width": "15%", "targets": -1 } if actions column size has changed
    ]
});

$('.datatable-user').DataTable(
{
    pagingType: 'full_numbers',
    "columnDefs": [
        { "orderable": false, "targets": -1 },
        { "width": "453px", "targets": -1 }
    ]
});

$('.datatable-post_report').DataTable(
{
    pagingType: 'full_numbers',
    "order": [[0, "desc"]],
    "columnDefs": [
        { "orderable": false, "targets": -1 },
        { "width": "388px", "targets": -1 },
        { "width": "105px", "targets": 0 },
        { "width": "155px", "targets": 1 }
    ]
});

$('.datatable-comment_report').DataTable(
{
    pagingType: 'full_numbers',
    "order": [[0, "desc"]],
    "columnDefs": [
        { "orderable": false, "targets": -1 },
        { "width": "420px", "targets": -1 },
        { "width": "105px", "targets": 0 },
        { "width": "155px", "targets": 1 }
    ]
    });

$('.datatable-post_list_minified').DataTable(
{
    pagingType: 'full_numbers',
    "order": [[0, "desc"]],
    "columnDefs": [
        { "orderable": false, "targets": -1 },
        { "width": "205px", "targets": -1 },
        { "width": "50px", "targets": 0 }
    ]
    });

$('.datatable-user_list_minified').DataTable(
    {
        pagingType: 'full_numbers',
        "columnDefs": [
            { "orderable": false, "targets": -1 },
            { "width": "236px", "targets": -1 }
        ]
    });
