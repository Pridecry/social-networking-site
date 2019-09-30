$('.datatable').DataTable(
{
    pagingType: 'full_numbers',
    "columnDefs": [ 
        { "orderable": false, "targets": -1 },
        { "width": "170px", "targets": -1 }
        //{ "width": "15%", "targets": -1 } if actions column size has changed
    ]
});
