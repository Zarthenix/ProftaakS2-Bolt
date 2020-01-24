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
})

//$(document).ready(function () {
//    var s = '';
//    for (var i = 0; i < 1000; i++) {
//        s += '<option>option ' + i + '</option>';
//    }
//    $('#combobox1').combobox();
//    $('#combobox2').html(s);
//    $('#combobox2').combobox();
//});

