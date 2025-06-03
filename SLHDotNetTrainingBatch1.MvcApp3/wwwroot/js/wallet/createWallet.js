$('#btnSave').click(function () {
    let item = {
        WalletUserName: $('#txtWalletUserName').val(),
        FullName: $('#txtFullName').val(),
        MobileNo: $('#txtMobileNo').val(),
        Balance: $('#txtBalance').val()
    };

    $.ajax({
        url: "/Wallet/Save",
        type: "POST",
        data: { requestModel: item },
        success: function (response) {
            console.log({ response });
            if (!response.IsSuccess) {
                alert("Error: " + response.Message);
                return;
            }

            alert(response.Message);
            window.location.href = "/Wallet/Index";

            //$("#createModal").modal("hide");
            //loadData();
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
})