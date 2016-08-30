
$(document).ready(function () {

    LoadGridData();

    $('#btnAddHammer').click(function () {
       // $('#PopUpDialog .modal-body').html('<h3>Entered Amount to Perfom Transaction cannot be more than Transaction Amount ' + $('#spnAmount').text() + ' </h3>');
        $('#PopUpDialog').modal('show');
    });

    $('#btnNewSave').click(function () {
        SaveHammer();
    });


    $('#tdDeleteAction').click(function () {
        if((DeleteHammer(this.data('hammerid')) == true)){
            $(this).closest('.tr').remove();
        }
    });

    $('#tdeditAction').click(function () {
        UpdateHammer(this.data('hammerid'));
    });

});


function SaveHammer() {
    //$('#divDataTable').showLoader(true);
    var param = {
        hammerName: $("#txtHammerName").text(),
        category: $("#txtCategory").text(),
        dscription: $("#txtdesciption").text(),
    };
    $.ajax({
        url: "/Home/SaveHammers",
        type: 'POST',
        data: param , 
        dataType: 'json',
        success: function (output) {
            //$('#divDataTable').hideLoader();
            if (output.success == true) {

                $.each(output.serverData, function (index) {
                    var str =
                      // "<tr class='rows'><td></td><td><div><a onclick=homedetails(" + output.serverData[index].TransactionId + ")>" + output.serverData[index].TransactionId + "</a></div></td><td>"
                       "<tr class='rows'><td></td><td>" + output.serverData[index].HammerName + "</td><td>"
                        + output.serverData[index].HammerDescription + "</td><td>"
                        + output.serverData[index].Category + "</td><td> "
                        + "<img id='tdEditAction' data-hammerid=" + output.serverData[index].HammerId + " src='/Content/Images/Edit.png' />"
                        + "<img id='tdDeleteAction' data-hammerid=" + output.serverData[index].HammerId + " src='/Content/Images/delete.png' /></td></tr>";
                    $("#tblHammers").append(str);
                });
            }
            else {
                $("#tblHammers").append('No Records Found');
            }

        },
        error: function (error) {
            //$('#divDataTable').hideLoader();
        }
    });


}

function UpdateHammer(hammerid) {
    //$('#divDataTable').showLoader(true);
    var param = {
        HammerId : hammerid,
        hammerName: $("#txtHammerName").text(),
        category: $("#txtCategory").text(),
        dscription: $("#txtdesciption").text(),
    };
    $.ajax({
        url: "/Home/UpdateHammers",
        type: 'POST',
        data: param,
        dataType: 'json',
        success: function (output) {
            //$('#divDataTable').hideLoader();
            if (output.success == true) {

                $.each(output.serverData, function (index) {
                    var str =
                      // "<tr class='rows'><td></td><td><div><a onclick=homedetails(" + output.serverData[index].TransactionId + ")>" + output.serverData[index].TransactionId + "</a></div></td><td>"
                       "<tr class='rows'><td></td><td>" + output.serverData[index].HammerName + "</td><td>"
                        + output.serverData[index].HammerDescription + "</td><td>"
                        + output.serverData[index].Category + "</td><td> "
                        + "<img id='tdEditAction' data-hammerid=" + output.serverData[index].HammerId + " src='/Content/Images/Edit.png' />"
                        + "<img id='tdDeleteAction' data-hammerid=" + output.serverData[index].HammerId + " src='/Content/Images/delete.png' /></td></tr>";
                    $("#tblHammers").append(str);
                });
            }
            else {
                $("#tblHammers").append('No Records Found');
            }

        },
        error: function (error) {
            //$('#divDataTable').hideLoader();
        }
    });


}

function DeleteHammer(hammerid) {
    //$('#divDataTable').showLoader(true);

    $.ajax({
        url: "/Home/DeleteHammers",
        type: 'POST',
        data: { HammerId : hammerid },
        dataType: 'json',
        success: function (output) {
            return output.success;
        },
        error: function (error) {
            return false;
            //$('#divDataTable').hideLoader();
        }
    });


}

    //Load Data to the Grid
function LoadGridData() {
        //$('#divDataTable').showLoader(true);
        $.ajax({
            url: "/Home/GetHammersInventory",
            type: 'POST',
            dataType: 'json',
            success: function (output) {
                $('#tblHammers tbody > tr').remove();
                //$('#divDataTable').hideLoader();
                if (output.success == true) {

                        $.each(output.serverData, function (index) {
                            var str =
                              // "<tr class='rows'><td></td><td><div><a onclick=homedetails(" + output.serverData[index].TransactionId + ")>" + output.serverData[index].TransactionId + "</a></div></td><td>"
                               "<tr class='rows'><td></td><td>" + output.serverData[index].HammerName + "</td><td>"
                                + output.serverData[index].HammerDescription + "</td><td>"
                                + output.serverData[index].Category + "</td><td> "
                                + "<img id='thEditAction' src='/Content/Images/Edit.png' /><img src='/Content/Images/delete.png' /></td></tr>";
                            $("#tblHammers").append(str);
                        });
                }
                else {
                    $("#tblHammers").append('No Records Found');
                }

            },
            error: function (error) {
                //$('#divDataTable').hideLoader();
            }
        });


    }


function LoadHammerCategories() {
    $("#ddltrnxtype").html("<option value=''>Loading...</option>");
    $.ajax({
        url: 'Home/FetchTransactionStatus',
        type: 'post',
        data: {
            paytypeid: selectedpaytype
        }
    }).done(function (response) {
        $("#ddltrnxtype").html(response);
        if ($('#spanIsPreviousPage').text() == "TRUE") {
            $("#ddltrnxtype").val($("#spantrnxtype").text()).prop('selected', true);
            LoadGridData('goto');
            $('#spanIsPreviousPage').text("FALSE");
        }
    });
}
  