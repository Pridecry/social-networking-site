// Bootstrap color styles
var style = getComputedStyle(document.body);
var theme = {};

theme.primary = style.getPropertyValue('--primary');
theme.secondary = style.getPropertyValue('--secondary');
theme.success = style.getPropertyValue('--success');
theme.info = style.getPropertyValue('--info');
theme.warning = style.getPropertyValue('--warning');
theme.danger = style.getPropertyValue('--danger');
theme.light = style.getPropertyValue('--light');
theme.dark = style.getPropertyValue('--dark');

// Admin-navigation activ state change
$(document).ready(function () {
    $('.navbar-nav ').find('a[href="' + location.pathname + '"]')
        .closest('a').addClass('active');
});

//Flash of unstyled content fix
$(document).ready(function () {
    $("body").css('opacity', 1);
});

function toggleDiv(id) {
    var div = document.getElementById(id);
    div.style.display = div.style.display == "none" ? "block" : "none";
}