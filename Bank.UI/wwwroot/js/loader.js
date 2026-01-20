window.Loader = {
    show: function () {
        const loader = document.getElementById("globalLoader");
        if (loader) loader.classList.remove("d-none");
    },
    hide: function () {
        const loader = document.getElementById("globalLoader");
        if (loader) loader.classList.add("d-none");
    }
};

// Show loader on any form submit
document.addEventListener("submit", function (e) {

    // prevent double submit
    const btn = e.target.querySelector("button[type='submit']");
    if (btn) btn.disabled = true;

    Loader.show();

    // Force loader visible for demo UX (2 seconds)
    setTimeout(() => {
        // let MVC redirect happen naturally
    }, 2000);
});

// Hide loader when page loads (after redirect)
window.addEventListener("load", function () {
    Loader.hide();
});
