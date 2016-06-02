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