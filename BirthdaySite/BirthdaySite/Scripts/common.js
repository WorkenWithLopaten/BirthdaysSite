$(document).ready(function () {
    $(document).on("click", ".close", function () {
        $("#myModal").hide();
    });

    $(document).on("click", "#upcoming-birthdays", function () {
        $("#myModal").show();
    });
});