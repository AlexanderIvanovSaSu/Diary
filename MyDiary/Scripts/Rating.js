$(document).ready(function () {
    var $starButtons = $(".bookrating");
    $("#Likes").val($starButtons.par().find(".glyphicon-star").length);

    $starButtons.on("click", function (clicedEl) {
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
                $("#Likes").val(elId + 1);
                found = true;
            }
        })
    })
});