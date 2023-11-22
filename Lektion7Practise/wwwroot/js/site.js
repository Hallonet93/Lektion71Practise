document.addEventListener("DOMContentLoaded", () => {
    var navBox = document.getElementById("nav-item");
    navBox.addEventListener("click", hideNavItem);

}

function hideNavItem() {
    var navBox = document.getElementById("nav-item");
    navBox.style.display = "none";
}