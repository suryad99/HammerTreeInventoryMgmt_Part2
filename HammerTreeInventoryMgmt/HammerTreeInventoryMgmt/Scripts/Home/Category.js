
$(document).ready(function () {

    LoadGridDataCat();

    $('#btnAddCategory').click(function () {
       // $('#PopUpDialog .modal-body').html('<h3>Entered Amount to Perfom Transaction cannot be more than Transaction Amount ' + $('#spnAmount').text() + ' </h3>');
        $('#PopUpNewCatDialog').modal('show');
    });

    $('#btnNewSaveCat').click(function () {
        SaveCategory();
    });


    $('#tdDeleteActionCat').click(function () {
        if ((DeleteCategory(this.data('categoryid')) == true)) {
            $(this).closest('.tr').remove();
        }
    });

    $('#tdeditActionCat').click(function () {
        UpdateCategory(this.data('categoryid'));
    });

});


function SaveCategory() {
    //$('#divDataTable').showLoader(true);
    var param = {
        category: $("#txtCategory").text(),
        description: $("#txtdesciption").text(),
    };
    $.ajax({
        url: "/Category/SaveCategories",
        type: 'POST',
        data: param , 
        dataType: 'json',
        success: function (output) {
            //$('#divDataTable').hideLoader();
            if (output.success == true) {

                $.each(output.serverData, function (index) {
                    var str =
                      // "<tr class='rows'><td></td><td><div><a onclick=homedetails(" + output.serverData[index].TransactionId + ")>" + output.serverData[index].TransactionId + "</a></div></td><td>"
                       "<tr class='rows'><td></td><td>" + output.serverData[index].CategoryName + "</td><td>"
                        + output.serverData[index].CategoryDescription + "</td><td>"
                        + "<img id='tdEditActionCat' data-hammerid=" + output.serverData[index].CategoryId + " src='/Content/Images/Edit.png' />"
                        + "<img id='tdDeleteActionCat' data-hammerid=" + output.serverData[index].CategoryId + " src='/Content/Images/delete.png' /></td></tr>";
                    $("#tblHammersCat").append(str);
                });
            }
            else {
                $("#tblHammersCat").append('No Records Found');
            }

        },
        error: function (error) {
            //$('#divDataTable').hideLoader();
        }
    });


}

function UpdateCategory(categoryid) {
    //$('#divDataTable').showLoader(true);
    var param = {
        categoryid : categoryid,
        category: $("#txtCategory").text(),
        description: $("#txtdesciption").text(),
    };
    $.ajax({
        url: "/Category/UpdateHammers",
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
                    $("#tblHammersCat").append(str);
                });
            }
            else {
                $("#tblHammersCat").append('No Records Found');
            }

        },
        error: function (error) {
            //$('#divDataTable').hideLoader();
        }
    });


}

function DeleteCategory(categoryid) {
    //$('#divDataTable').showLoader(true);

    $.ajax({
        url: "/Category/DeleteCategory",
        type: 'POST',
        data: { categoryid: categoryid },
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
function LoadGridDataCat() {
        //$('#divDataTable').showLoader(true);
        $.ajax({
            url: "/Category/GetCategoryInventory",
            type: 'POST',
            dataType: 'json',
            success: function (output) {
                $('#tblHammersCat tbody > tr').remove();
                //$('#divDataTable').hideLoader();
                if (output.success == true) {

                        $.each(output.serverData, function (index) {
                            var str =
                               "<tr class='rows'><td></td><td>" + output.serverData[index].CategoryId + "</td><td>"
                                + output.serverData[index].CategoryName + "</td><td>"
                                + output.serverData[index].CategoryDescription + "</td><td> "
                                + "<img id='tdEditAction' data-hammerid=" + output.serverData[index].HammerId + " src='/Content/Images/Edit.png' />"
                                + "<img id='tdDeleteAction' data-hammerid=" + output.serverData[index].HammerId + " src='/Content/Images/delete.png' /></td></tr>";
                            $("#tblHammersCat").append(str);
                        });
                }
                else {
                    $("#tblHammersCat").append('No Records Found');
                }

            },
            error: function (error) {
                //$('#divDataTable').hideLoader();
            }
        });


    }
