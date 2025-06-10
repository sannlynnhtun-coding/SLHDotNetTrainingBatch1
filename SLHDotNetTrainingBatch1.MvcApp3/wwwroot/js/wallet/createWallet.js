$('#btnSave').click(function (e) {
    e.preventDefault();

    var l = Ladda.create(this);
    l.start();

    //enableLoading();

    setTimeout(() => {
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
                //disableLoading();

                l.stop();

                console.log({ response });
                if (!response.IsSuccess) {
                    alert("Error: " + response.Message);
                    return;
                }

                //alert(response.Message);

                //Swal.fire({
                //    title: "Success",
                //    text: response.Message,
                //    icon: "success"
                //});

                successMessage(response.Message, "/Wallet/Index");

                //window.location.href = "/Wallet/Index";

                //$("#createModal").modal("hide");
                //loadData();
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    }, 3000);
})