"use strict";

var $clients = $("select#ClientId"),
    $sources = $("select#SourceId"),
    $metrics = $("select#MetricId");

$clients.on("change", function () {
    $sources.html("<option selected>-- SELECT --</option>");
    $metrics.html("<option selected>-- SELECT --</option>");

    if ($clients.prop("selectedIndex") > 0) {
        $.getJSON('/Watchers/Sources_List/' + $('#ClientId').val(), { ClientId: $('#ClientId').val() }, function (data) {
            var html = "<option selected>-- SELECT --</option>";

            for (var i = 0; i < data.length; i++) {                
                html += "<option value='" + data[i].Value + "'>" + data[i].Text + "</option>";
            }
            $sources.html(html);
            
            if (data.length == 1)
            {
                selectOne($sources);
            }       
        });
    }
});

$sources.on("change", function () {
    $metrics.html("<option selected>-- SELECT --</option>");

    if ($sources.prop("selectedIndex") > 0) {        
        $.getJSON('/Watchers/Metrics_List/' + $('#SourceId').val(), { SourceId: $('#SourceId').val() }, function (data) {
            var html = "<option selected>-- SELECT --</option>";            
            for (var i = 0; i < data.length; i++) {
                html += "<option value='" + data[i].Value + "'>" + data[i].Text + "</option>";
            }

            $metrics.html(html);

            if (data.length == 1) {
                selectOne($metrics);
            }
        });
    }
});


function selectOne(selector, name) {
    //alert("got here");
        $(selector).prop('selectedIndex', 1);
        $(selector).trigger("change");    
}