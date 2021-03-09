function inlineEditGrid(url) {
    //para la edicion inline uso el jEditable de jquery (mirar https://jeditable.elabftw.net/)
    $(".editable-text").editable(url, {
        indicator: "<img src='/Content/Images/view-fullscreen.png' />",
        type: "text",
        // only limit to three letters example
        //pattern: "[A-Za-z]{3}",
        onedit: function () { console.log('If I return false edition will be canceled'); return true; },
        before: function () { console.log('Triggered before form appears') },
        callback: function (result, settings, submitdata) {
            console.log('Triggered after submit');
            console.log('Result: ' + result);
            console.log('Settings.width: ' + settings.width);
            console.log('Submitdata: ' + submitdata.pwet);
        },
        //cancel: 'Cancel',
        cssclass: 'custom-class',
        cancelcssclass: 'btn btn-danger',
        //submitcssclass: 'btn btn-success',
        maxlength: 200,
        // select all text
        select: true,
        //label: 'This is a label',
        onreset: function () { console.log('Triggered before reset') },
        onsubmit: function () { console.log('Triggered before submit') },
        showfn: function (elem) { elem.fadeIn('slow') },
        submit: 'OK',

        submitdata: function (revert, settings, submitdata) {
            console.log("Revert text: " + revert);
            console.log(settings);
            console.log("User submitted text: " + submitdata.value);
            return {
                id: $(this).data('id'),
                param: $(this).data('parametro')
            }
        },

        tooltip: "Click to edit...",
        width: 160
    });

    //$(".editable-select").editable(urlInlineEdit, {
    //    type: "select",
    //    // this data will be sorted by value
    //    data: '{"True":"True","False":"False", "selected":"False"}',
    //    submit: "OK",
    //    //submitcssclass: 'btn btn-success',
    //    submitdata: function () {
    //        return {
    //            id: $(this).data('id'),
    //            param: $(this).data('parametro')
    //        };
    //    },
    //    style: "inherit",
    //});
}

function inlineDatepickerGrid(url, datepickerClass) {
    $(datepickerClass).editable(url, {
        type: 'datepicker',
        submit: 'OK',
        cancel: 'cancel',
        onedit: function () { return true; },
        before: function () {  },
        datepicker: {
            format: "dd/mm/yy"
        },
        submitdata: function () {
            
            return {
                id: $(this).data('id'),
                param: $(this).data('parametro')
            };
        },
        tooltip: "Click to edit..."
    });
}


function inlineSelectEditGrid(url, selectClass,  data){
    $(selectClass).editable(url, {
        type: "select",
        // this data will be sorted by value
        data: data,
        before: function () {
            //$('select>option:eq(3)').attr('selected', true);
        },
        onedit: function () {
            //$("#detalleAlarmas")[0].innerHTML = $("#divTipo_" + $(this).data('id'))[0].innerHTML;
            //$("#detalleAlarmas")[0].innerHTML = $(this).data('id');
            //$('select>option:eq(3)').attr('selected', true);
            return true;
        },
        callback: function (result, settings, submitdata) {
            //$("#detalleAlarmas")[0].innerHTML = $("#divTipo_" + $(this).data('id'))[0].innerHTML;
            //$("#detalleAlarmas")[0].innerHTML = $(this).data('id');
            //$('select>option:eq(3)').attr('selected', true);
        },
        submit: "OK",
        //submitcssclass: 'btn btn-success',
        submitdata: function () {
            //alert("aaaa" + $("select option:selected").text());
            //$("#detalleAlarmas")[0].innerHTML = $("select option:selected").text();
            return {
                id: $(this).data('id'),
                param: $(this).data('parametro')
            };
        },
        style: "inherit",
    });
}

function ajaxDataSelect(url, urlInlineEdit, classEdit, functionTransform) {
    $.ajax({
        type: 'POST',
        url: url,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //data: { 'ID': Id },
        success: function (data) {
            data = functionTransform(data, "");
            inlineSelectEditGrid(urlInlineEdit, classEdit, data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });
}