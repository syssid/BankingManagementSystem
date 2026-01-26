 function enableEdit() {
        // Enable all editable fields
        document.querySelectorAll('.profile-field').forEach(el => {
            el.disabled = false;
        });

    // Toggle buttons
    document.getElementById('editBtn').classList.add('d-none');
    document.getElementById('saveBtn').classList.remove('d-none');
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
    console.log(flag);
    Loader.show();

    const form = document.getElementById("profileForm");
    const data = new FormData(form);
    if (flag) {
        fetch("/Profile/AddUserDetails", {
            method: "POST",
            body: data
        })
            .then(res => {
                if (!res.ok) throw new Error();
                return res.text();
            })
            .then(msg => {
                const alert = document.getElementById("profileMsg");
                alert.className = "alert alert-success";
                alert.innerText = msg;
                alert.classList.remove("d-none");
            })
            .catch(() => {
                alert("Failed to add profile details");
            })
            .finally(() => Loader.hide());
    }
    else {
        fetch("/Profile/UpdateUserDetails", {
            method: "PUT",
            body: data
        })
            .then(res => {
                if (!res.ok) throw new Error();
                return res.text();
            })
            .then(msg => {
                const alert = document.getElementById("profileMsg");
                alert.className = "alert alert-success";
                alert.innerText = msg;
                alert.classList.remove("d-none");
            })
            .catch(() => {
                alert("Failed to update profile details");
            })
            .finally(() => Loader.hide());
    }
}
