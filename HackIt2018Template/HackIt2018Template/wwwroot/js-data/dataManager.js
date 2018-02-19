
$(document).ready(function () {

    var datatable = $('#dataSearch').DataTable({
        
        "columns": [{
            "data": "CityName"
        }, {
            "data": "Location"
        }, {
            "data": "StartTime"
        }, {
            "data": "SportName"
        }]
    });

    $("#testButton").click(function () {
        $.ajax({
            type: "GET",
            url: "/Home/GetAllEvents",
            dataType: 'json',
            success: function (data) {
                datatable.clear();
                datatable.rows.add(data);
                datatable.draw();
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }

        });
    }); 

});


