
$("#addproduct-form").submit(function (e) {
    $("input[type='submit']", this)
        .val("Please Wait...")
        .attr('disabled', 'disabled');

    actionMethod = "POST"
    actionUrl = "/user/addproduct"

    sendData = {
        "Name": $('#prName').val(),
        "Description": $('#Description').val(),
        "Price": $('#Price').val(),
        "Category": $('#Category').val(),
        "Quantity": $('#Quantity').val()
    }


    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html("Your Product Added Succesfully <br> Add a new one or return Home ");
            setTimeout(function () {
                window.location.href = "/HOME/AddProduct"
            }, 2000);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
    e.preventDefault();
});
