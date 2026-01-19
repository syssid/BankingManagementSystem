document.addEventListener("DOMContentLoaded", function () {

    const form = document.querySelector("form");
    const loader = document.getElementById("loader");
    const submitBtn = document.getElementById("submitBtn");

    if (!form) return;

    form.addEventListener("submit", function () {

        // Disable button
        submitBtn.disabled = true;

        // Show loader
        loader.classList.remove("d-none");

        // Optional: change button text
        submitBtn.innerHTML =
            '<span class="spinner-border spinner-border-sm me-2"></span>Processing...';
    });
});