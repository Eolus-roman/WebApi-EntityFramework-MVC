$('button').click(function (e) {
    idDev = $(this).attr('id');
    typeDev = $(this).attr('devtype');
    csscl = $(this).attr('class');
    event.preventDefault();

    if (csscl == "switchOnHO") {
        $.ajax({
            url: "/api/hoover/on/" + idDev,
            type: "PUT",
            success: function (data) {
                $("#status-" + idDev).html(data);
            }
        });
    } else if (csscl == "switchOffHO") {
        $.ajax({
            url: "/api/hoover/off/" + idDev,
            type: "PUT",
            success: function (data) {
                $("#status-" + idDev).html(data);
            }
        });
    } else if (csscl == "leftBtHO") {
        $.ajax({
            url: "/api/hoover/previous/" + idDev,
            type: "PUT",
            success: function (data) {
                $("#status-" + idDev).html(data);
            }
        });
    } else if (csscl == "rightBtHO") {
        $.ajax({
            url: "/api/hoover/next/" + idDev,
            type: "PUT",
            success: function (data) {
                $("#status-" + idDev).html(data);
            }
        });
    }    else if (csscl == "resetDustBag") {
        $.ajax({
            url: "/api/hoover/rfp/" + idDev,
            type: "PUT",
            success: function (data) {
                $("#status-" + idDev).html(data);
            }
        });
    }    else if (csscl == "resetAccum") {
        $.ajax({
            url: "/api/hoover/rsp/" + idDev,
            type: "PUT",
            success: function (data) {
                $("#status-" + idDev).html(data);
            }
        });
    }
    else if (csscl == "btbUseHO") {
        $.ajax({
            url: "/api/hoover/app/" + idDev,
            type: "PUT",
            success: function (data) {
                $("#status-" + idDev).html(data);
            }
        });
    }
    else if (csscl = "deleteHO") {
        $.ajax({
            url: "/api/hoover/" + idDev,
            type: "DELETE",
            success: function (data) {
                $("#" + idDev + "-devicePanel").remove();
                
            }
        });
    }
    else {
        alert("omg что то пошло не так(");
    }

});

//$("button").bind("click", ".ResetDustBag", function (event) {
//    idDev = $(this).attr('id');
//    typeDev = $(this).attr('devtype');
//    event.preventDefault();
//    $.ajax({
//        url: "/api/hoover/rfp/" + idDev,
//        type: "PUT",
//        success: function (data) {
//            $("#status-" + idDev).html(data);
//        }
//    });
//});
//$("button").bind("click", ".ResetAccum", function (event) {
//    idDev = $(this).attr('id');
//    typeDev = $(this).attr('devtype');
//    event.preventDefault();
//    $.ajax({
//        url: "/api/hoover/rsp/" + idDev,
//        type: "PUT",
//        success: function (data) {
//            $("#status-" + idDev).html(data);
//        }
//    });
//});







//$("input").bind("click", ".switchOffHO", function (event) {
//    idClick = $(this).attr('id');
//    typeID = $(this).attr('devtype');
//        event.preventDefault();
//    $.ajax({
//        url: "/api/hoover/on/" + idClick,
//        type: "PUT",
//        success: function (data) {
//            $("#status-" + idClick).html(data);
//        }
//    });
//});
//$("input").bind("click", ".leftBtHO", function (event) {
//    idClick = $(this).attr('id');
//    typeID = $(this).attr('devtype');
//        event.preventDefault();
//    $.ajax({
//        url: "/api/hoover/left/" + idClick,
//        type: "PUT",
//        success: function (data) {
//            $("#status-" + idClick).html(data);
//        }
//    });
//});
//$("input").bind("click", ".rightBtHO", function (event) {
//    idClick = $(this).attr('id');
//    typeID = $(this).attr('devtype');
//    event.preventDefault();
//    $.ajax({
//        url: "/api/hoover/right/" + idClick,
//        type: "PUT",
//        success: function (data) {
//            $("#status-" + idClick).html(data);
//        }
//    });
//});




