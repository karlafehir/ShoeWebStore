﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

//https://datatables.net/
function loadDataTable() {
    //tblData id iz company index.cshtml
    dataTable = $("#tblData").DataTable({
        "ajax": {
            url: '/company/getall'
        },
        "columns": [
            { data: 'name', "width": "10%" },
            { data: 'streetAddress', "width": "10%" },
            { data: 'city', "width": "10%" },
            { data: 'state', "width": "10%" },
            { data: 'postalCode', "width": "10%" },
            { data: 'phoneNumber', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/company/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bu-pencil-square"></i>Edit</a>
                        <a onClick=Delete('/company/delete/${data}') class="btn btn-primary mx-2"><i class="bi bu-pencil-square"></i>Delete</a>
                    </div>`
                },
                "width": "20%"
            },
        ]
    })
}

//sweetAlerts2
function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                }
            })
        }
    });
}