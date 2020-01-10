$(function () {
    $("#nav").button().hover(function () {
        openNav();
    });
});

function openNav() {
    //document.getElementById("mySidebar").style.width = "250px";
    //document.getElementById("main").style.marginLeft = "250px";
}

function closeNav() {
    //document.getElementById("mySidebar").style.width = "0";
    //document.getElementById("main").style.marginLeft = "0";
}
$(function () {
    $(".radiobutton").click(
        
        function () {
            SetTypeValue("#postType", $(this).data("post"));
        }
    );
});
function SetTypeValue(typeId, typePost) {
    $(typeId).val(typePost);
}




$(document).ready(function () {
    var s = '';
    for (var i = 0; i < 1000; i++) {
        s += '<option>option ' + i + '</option>';
    }

    $('#combobox1').combobox();

    $('#combobox2').html(s);
    $('#combobox2').combobox();
});