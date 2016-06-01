function Action(key) {
    $("#" + key + "-on").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "api/fridge/on/" + key,
            type: "PUT",
            success: function (data) {
                $("#" + key + "-status").html(data);
            }
        });
    })
    //-------
    $("#" + key + "-off").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "api/fridge/off/" + key,
            type: "PUT",
            success: function (data) {
                $("#" + key + "-status").html(data);
            }
        });
    })
}