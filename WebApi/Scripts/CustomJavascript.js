$(function () {
    $("#btnSubmit").mouseover(function () {
        $("#btnSubmit").css("background-color", "red");
    });

    $("#btnSubmit").mouseout(function () {
        $("#btnSubmit").css("background-color", "#d3dce0");
    });
});