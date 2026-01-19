window.Loader = {
    show: function () {
        document.getElementById("globalLoader")
            ?.classList.remove("d-none");
    },
    hide: function () {
        document.getElementById("globalLoader")
            ?.classList.add("d-none");
    }
};
document.addEventListener("submit", function (e) {
    const btn = e.target.querySelector("button[type='submit']");
    if (btn) btn.disabled = true;
});
