document.addEventListener("DOMContentLoaded", function () {
    const toggleBtn = document.getElementById("darkModeToggle");
    const body = document.body;
    const icon = toggleBtn.querySelector("i");

    // Load saved mode
    if (localStorage.getItem("theme") === "dark") {
        body.classList.add("dark-mode");
        icon.classList.replace("bi-moon-fill", "bi-sun-fill");
    }

    toggleBtn.addEventListener("click", function () {
        body.classList.toggle("dark-mode");

        const isDark = body.classList.contains("dark-mode");
        localStorage.setItem("theme", isDark ? "dark" : "light");

        icon.classList.toggle("bi-moon-fill", !isDark);
        icon.classList.toggle("bi-sun-fill", isDark);
    });
});
