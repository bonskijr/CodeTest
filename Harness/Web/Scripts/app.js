$(function () {
    $("#patternStringTextBox").on("keyup", function (evtobj) {
        if (!(evtobj.altKey || evtobj.ctrlKey || evtobj.shiftKey)) {
            if ((evtobj.keyCode == 16) || (evtobj.keyCode == 17) || (evtobj.keyCode == 17))
                evtobj.preventDefault();
        };
        var _theString = $("#inputLabelString").text();
        var _thePattern = this.value;
        var _params = { "theString": _theString, "thePattern": _thePattern };

        $.ajax({
            url: "/Home/HighlightMatchingText",
            type: 'POST',
            data: _params,
            success: function (result) {

                 $("#inputLabelString").replaceWith(result);

            },
            error: function (xhr, status) { console.error(status) }
        });

    });
});