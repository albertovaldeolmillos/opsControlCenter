function pieEnCabeceraGrid() {
    if ($("thead").length > 0 && $("tfoot").length > 0) {
        var tfoot = $("tfoot")[0].innerHTML;
        var thead = $("thead")[0].innerHTML;
        //var search = "<tr>" + $("#searchBarId")[0].innerHTML + "</tr>";
        $("thead")[0].innerHTML = tfoot + thead;
        $("tfoot")[0].innerHTML = "";
    //$("#searchBarId")[0].innerHTML = "";

    //$("thead").append("<tr>" + tfoot + "</tr>");
    }
}
function iconosOrdenGrid() {
    var dir = $('#dir').val();
    var col = $('#col').val();
    if (col != "") {
        var header = $("th a[href*=" + col + "]")[0];
        if (dir == "Ascending") {
            header.text = header.text + " ▲";
        }
        if (dir == "Descending") {
            header.text = header.text + " ▼";
        }
    }
}
function esteticaGrid() {
    $("tfoot a").addClass('btn btn-default'); // add bootstrap buttons
    // add active bootstrap button
    $("tfoot td")
        .contents()
        .filter(function () {
            if (this.nodeType === 3 && this.length > 1) {
                return this.nodeType
            }
        })
        .wrap('<span class="btn btn-primary" />');
    $('tbody tr').hover(function () {
        $(this).toggleClass('hovercs');  //hover change highlight style
    }).on('click', function () {
        $('tbody tr').not($(this)).removeClass('clickable');  //remove other row click highlight style
        $(this).addClass('clickable');  // add style to current row
    });
}