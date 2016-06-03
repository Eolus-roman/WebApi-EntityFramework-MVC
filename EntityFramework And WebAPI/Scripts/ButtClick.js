$("input").bind("click", ".switchOffFr", function (event) {
    idClick = $(this).attr('id');
    typeID = $(this).attr('devtype');
    //alert("id = " + idClick);
    //if (typeID == "Fridge") {
    //    alert("url: /api/fridge/on/" + idClick);
    //    alert("devtype = " + typeID);
    //}
    //alert("#" + idClick +"-"+ typeID + "-status");
    event.preventDefault();
    $.ajax({
        url: "/api/fridge/on/" + idClick,
        type: "PUT",
        success: function (data) {
            $("#status-" + idClick).html(data);
        }
    });
    alert("вкл");
});



