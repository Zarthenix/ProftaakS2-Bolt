cdn.datatables.net / 1.10.20 / js / jquery.dataTables.min.js

$(document).ready(function() {
    $('#Uitzend').DataTable();
});

$(function() {
    $("#nav").button().hover(function() {
        openNav();
    });
});

function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}

