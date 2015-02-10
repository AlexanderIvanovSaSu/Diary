/// <reference path="../jquery-1.10.2.js" />
$(document).ready(function () {
    var $starButtons = $(".bookrating");
    $("#Rating").val(3);

    $starButtons.on("click", function (evt) {
        var found = false;
        $starButtons.each(function (elId, el) {
            if (!found) {
                $(el).removeClass("glyphicon-star-empty");
                $(el).addClass("glyphicon-star");
            } else {
                $(el).removeClass("glyphicon-star");
                $(el).addClass("glyphicon-star-empty");

            }

            if (evt.currentTarget == el) {
                $("#Rating").val(elId + 1);
                found = true;
            }
        })
    })
});