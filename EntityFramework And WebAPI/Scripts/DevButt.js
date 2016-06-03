function Action(key) {
    $("#" + key + "-onFr").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "api/fridge/on/" + key,
            type: "PUT",
            success: function (data) {
                $("#" + key + "-status").html(data);
            }

        });
    });

}
$(function () {
    $(".number").click(function () {
        addDigit($(this).val());
    });
});
$(function () {
    $(".switchOffFr").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "api/fridge/on/1",
            type: "PUT",
            success: function (data) {
                aler("ololo");
                //$("#" + key + "-status").html(data);
            }
        });
    });
});
$("#devicePanel").on("click", ".switchOffFr", function (event) {
    event.preventDefault();
    var dev = $(this).parentsUntil("#devicePanel").last();
    var id = dev.prop("id");
    var type = dev.attr("devType");
    $.ajax({
        url: "api/fridge/" + type + "/" + id + "/on",
        type: "PUT",
        success: function (data) {
            $("#" + id + "-status").html(data);
        }
    });
});