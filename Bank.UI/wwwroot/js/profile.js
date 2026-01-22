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

function saveProfile() {
    Loader.show();

    const form = document.getElementById("profileForm");
    const data = new FormData(form);

    fetch("/Profile/Update", {
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
            alert("Failed to update profile");
        })
        .finally(() => Loader.hide());
}
