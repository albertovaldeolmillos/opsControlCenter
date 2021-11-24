function pieEnCabeceraGrid() {
    if ($("#grid thead").length > 0 && $("#grid tfoot").length > 0) {
        var tfoot = $("#grid tfoot")[0].innerHTML;
        var thead = $("#grid thead")[0].innerHTML;
        //var search = "<tr>" + $("#searchBarId")[0].innerHTML + "</tr>";
        $("#grid thead")[0].innerHTML = tfoot + thead;
        $("#grid tfoot")[0].innerHTML = "";
    //$("#searchBarId")[0].innerHTML = "";

    //$("thead").append("<tr>" + tfoot + "</tr>");
    }
}
function iconosOrdenGrid() {
    var dir = $('#dir').val();
    var col = $('#col').val();
    if (col != "") {
        var header = $("#grid thead th a[href*=" + col + "]")[0];
        if ((dir == "ASC") && (header != undefined)) {
            header.text = header.text + " ▲";
        }
        if ((dir == "DESC") && (header != undefined)) {
            header.text = header.text + " ▼";
        }
    }
}
function esteticaGrid() {
    $("#grid tfoot a").addClass('btn btn-default'); // add bootstrap buttons
    // add active bootstrap button
    $("#grid tfoot td")
        .contents()
        .filter(function () {
            if (this.nodeType === 3 && this.length > 1) {
                return this.nodeType
            }
        })
        .wrap('<span class="btn btn-primary" />');
    //$('tbody tr').hover(function () {
    //    $(this).toggleClass('hovercs');  //hover change highlight style
    //}).on('click', function () {
    //    $('tbody tr').not($(this)).removeClass('clickable');  //remove other row click highlight style
    //    $('tbody tr').not($(this)).removeClass('hovercs');
    //    $(this).addClass('clickable');  // add style to current row
    //});
}
