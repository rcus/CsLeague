var tbodyData;

$("#playerButton").click(function () {
    var pId = $("#playerId").val(),
        pPoints = parseInt($("#playerPoints").val()),
        pData = { "Score": pPoints };

    $.ajax({
        url: "/api/Players/" + pId,
        type: "PATCH",
        contentType:"application/json",
        data: JSON.stringify(pData),
        success: function() {
            $("#tableBody").load("/Home/ClanTable/" + pId, function () {
                $("#tableBody #" + pId).find("td").effect("highlight", 1500);
            });
        }
    });

});
