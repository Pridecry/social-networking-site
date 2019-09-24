function start() {
    switchAdminPanel();
}
window.onload = start;

function switchAdminPanel() {
    const row = document.getElementById("mainRow");
    const heading = document.getElementById("mainHeading");

    row.classList.remove("bg-primary");
    row.classList.add("bg-warning");

    heading.innerHTML = "Dieteticer - Admin panel";
}
