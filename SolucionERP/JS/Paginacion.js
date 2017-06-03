$(document).ready(function () {
    Paginacion();
});

Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
function endReq(sender, args) {
    Paginacion();
}

function Paginacion() {
    try {
        $(document).ready(function () {
            // Setup Metadata plugin
            $.metadata.setType("class");

            // table.Nombre del gridview 
            $("table.grid").each(function () {
                var jTbl = $(this);

                if (jTbl.find("tbody>tr>th").length > 0) {
                    jTbl.find("tbody").before("<thead><tr></tr></thead>");
                    jTbl.find("thead:first tr").append(jTbl.find("th"));
                    jTbl.find("tbody tr:first").remove();
                }

                // If GridView has the 'sortable' class and has more than 10 rows
                if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 10 && jTbl.find("tbody:first > tr").length <= 10000) {

                    // Run DataTable on the GridView
                    jTbl.dataTable({
                        sPaginationType: "full_numbers",
                        sDom: '<"top"lf>rt<"bottom"ip>',
                        //oLanguage: {
                        //    sInfoFiltered: "(from _MAX_ entries)",
                        //    sSearch: ""
                        //},
                        aoColumnDefs: [
                            { bSortable: false, aTargets: jTbl.metadata().disableSortCols }
                        ]
                    });
                }
            });
        });
    }
    catch (err) {
        alert(err.message)
    }
}