function toggleDropdown(e) {
    const _d = $(e.target).closest('.dropdown'),
        _m = $('.dropdown-menu', _d);
    setTimeout(function () {
        const shouldOpen = e.type !== 'click' && _d.is(':hover');
        _m.toggleClass('show', shouldOpen);
        _d.toggleClass('show', shouldOpen);
        $('[data-toggle="dropdown"]', _d).attr('aria-expanded', shouldOpen);
    }, e.type === 'mouseleave' ? 100 : 0);
}

$('body')
    .on('mouseenter mouseleave', '.dropdown', toggleDropdown)
    .on('click', '.dropdown-menu a', toggleDropdown);

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

