
//if ($("#manualRef").attr("checked") == "checked") {
//    alert("checked")
//} else {
//    $("#manualRef").attr("checked") == "";
//    alert("not checked")
//}
//$("#manualRef").click(function () {
//    $("#manualRef").attr("checked") == "";
//});

$('#manualRef').click(function () {
    if ($(this).is(":checked")) {
        $("#Reference").attr("disabled","disabled");
    } else {
        $("#Reference").removeAttr("disabled");
    }
});

