"use strict";

var $clients = $("select#ClientId"),
    $sources = $("select#SourceId");

$clients.on("change", function () {
    $sources.html("<option selected>-- SELECT --</option>");    
    if ($clients.prop("selectedIndex") > 0) {
        $.getJSON('/Metrics/Sources_List/' + $('#ClientId').val(), { ClientId: $('#ClientId').val() }, function (data) {
            var html = "<option selected>-- SELECT --</option>";

            for (var i = 0; i < data.length; i++) {                
                html += "<option value='" + data[i].Value + "'>" + data[i].Text + "</option>";
            }
            $sources.html(html);
                        
            if (data.length == 1) {
                selectOne($sources);
            }
        });
    }
});

function selectOne(selector, name) {    
    $(selector).prop('selectedIndex', 1);
    $(selector).trigger("change");
}