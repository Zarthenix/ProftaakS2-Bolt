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