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
    $('.navbar-nav').find('a[href="' + location.pathname + '"]')
        .closest('a').addClass('active');
});

//Flash of unstyled content fix
$(document).ready(function () {
    document.body.classList.add('loaded');
});

function toggleDiv(id) {
    var div = document.getElementById(id);
    div.style.display = div.style.display == "none" ? "block" : "none";
}

//Counters
function increment(id) {
    let counterValue = parseInt($(id).text());
    $(id).html(counterValue + 1);
};

function decrement(id) {
    let counterValue = parseInt($(id).text());
    $(id).html(counterValue - 1);
};

////SignalR

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();

connection.on("ReceiveNotification", function (userId, createdAt, firstName, lastName, avatarPath) {
    var notificationCounter = parseInt($("#notificationCounter").text());
    increment("#notificationCounter");
    increment("#notificationBadge");

    $('#notificationBadge').removeClass('d-none');

    if (notificationCounter == 1) {
        $("#notificationPlural").text('');
    }
    else {
        $("#notificationPlural").text('s');
    }

    var html = `
        <div class="list-group-item py-2 px-2">
            <div class="d-flex w-100 justify-content-start">
                <img class="rounded-circle img-fluid border border-dark" style="height: 3.5rem; width: 3.5rem" src="${avatarPath}" alt="Avatar">
                <div class="d-flex flex-column justify-content-between ml-2">
                    <div>
                        <h6 class="mb-2 d-inline">
                            <a class="no-link" href="/Users/GetProfile/${userId}">
                                ${firstName} ${lastName}
                            </a>
                        </h6>
                        <span class="d-inline">is now following you.</span>
                    </div>
                    <small>${createdAt}</small>
                </div>
            </div>
        </div>
    `;

    $(`#notificationContainer > div:first`).before(html);
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});
