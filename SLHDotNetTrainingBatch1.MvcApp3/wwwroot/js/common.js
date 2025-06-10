function successMessage(message, link) {
    //Swal.fire({
    //    title: title == null ? "Success" : title,
    //    text: message,
    //    icon: "success"
    //});

    //Swal.fire({
    //    title: "Success",
    //    text: message,
    //    icon: "success",
    //}).then((result) => {
    //    if (result.isConfirmed) {
    //        if (!(link === undefined || link === null || link === ''))
    //            window.location.href = link;
    //    }
    //});

    Notiflix.Notify.success(message);

    Notiflix.Report.success(
        "Success",
        message,
        'Ok',
        function cb() {
            if (!(link === undefined || link === null || link === ''))
                window.location.href = link;
        },
    );
}

function confirmMessage(message) {
    //let result = new Promise((resolve, reject) => {
    //    var isTrue = confirm(message);
    //    resolve(isTrue);
    //});
    //return result;

    return new Promise((resolve, reject) => {
        Notiflix.Confirm.show(
            'Confirm',
            message,
            'Yes',
            'No',
            function okCb() {
                resolve(true);
            },
            function cancelCb() {
                resolve(false);
            }
        );
    });
}

function enableLoading() {
    //Notiflix.Loading.dots();

    Notiflix.Block.circle('.modal-body');
}

function disableLoading() {
    //Notiflix.Loading.remove();

    Notiflix.Block.remove('.modal-body');
}

function setDatePicker() {
    $('.date-picker').datepicker({
        format: 'dd-mm-yyyy',
        autoHide: true
    });
}