function enableEdit() {
    $('#Address,#Mobile,#DateOfBirth').prop('readonly', false);
    $('.form-select').prop('disabled', false);

    // Toggle buttons
    $('#editBtn').addClass('d-none');
    $('#saveBtn').removeClass('d-none');
}

function openProfileModal() {
    Loader.show();

    fetch("/Profile/ProfilePartial")
        .then(res => res.text())
        .then(html => {
            document.getElementById("profileModalContent").innerHTML = html;
            new bootstrap.Modal(document.getElementById("profileModal")).show();
        })
        .finally(() => Loader.hide());
}

function saveProfile(flag) {
    Loader.show();
    const form = document.getElementById("profileForm");
    const data = new FormData(form);

    const url = flag
        ? "/Profile/AddUserDetails"
        : "/Profile/UpdateUserDetails";

    const errorMsg = flag
        ? "Failed to add profile details"
        : "Failed to update profile details";

    $.ajax({
        url: url,
        type: flag ? "POST" : "PUT",
        data: data,
        processData: false, // important for FormData
        contentType: false, // important for FormData
        success: function (msg) {
            debugger;
            const alertBox = $("#profileMsg");
            alertBox
                .removeClass("d-none alert-danger")
                .addClass("alert alert-success")
                .text(msg);

            swal({
                title: "Success",
                text: msg,
                icon: "success"
            }).then(function () {
                $('#profileModal').modal('hide');
            });
        },
        error: function () {
            debugger;
            swal({
                title: "Error",
                text: errorMsg,
                icon: "error"
            }).then(function () {
                $('#profileModal').modal('hide');
            });
        },
        complete: function () {
            Loader.hide();
        }
    });
}
