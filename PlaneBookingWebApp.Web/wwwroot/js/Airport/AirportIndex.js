(function (ns) {
    function InitAirportDatatable() {
        $("#airport-datatable").DataTable();
    }

    function OnSuccess() {
        InitAirportDatatable();
        HideModal();
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#success-alert").slideUp(500);
        });
    }

    function HideModal() {
        $("#airport-modal").modal("hide");
    }

    function ShowModal() {
        $("#airport-modal").modal("show");
    }

    function OnFailure(result) {
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#danger-alert").slideUp(500);
        });
    }

    function OnClickEdit(Id) {
        $("#airportModalLabel").text("Update Airport");
        $.ajax({
            type: 'GET',
            url: "../ajax/Airport/UpdateAirportModal",
            data: { Id: Id },
            async: true,
            success: function (data) {
                $("#airport-modal-body").html(data);
            },
            error: function () {

            }
        })
    }

    function OnClickDelete(Id) {
        if (confirm("Are you sure you want to continue?") === true) {
            $.ajax({
                type: 'POST',
                url: "../ajax/Airport/DeleteAirport",
                data: { Id: Id },
                success: function (data) {
                    $("#airport-table-container").html(data);
                    OnSuccess();
                },
                error: function () {

                }
            });
        }
    }

    function AddUpdateModal() {
        $("#airportModalLabel").text("Add Airport");
        $.ajax({
            type: 'GET',
            url: "../ajax/Airport/AddAirportModal",
            success: function (data) {
                $("#airport-modal-body").html(data);
                ShowModal();
            },
            error: function () {

            }
        });
    }

    ns.InitAirportDatatable = InitAirportDatatable;
    ns.OnSuccess = OnSuccess;
    ns.OnFailure = OnFailure;
    ns.OnClickEdit = OnClickEdit;
    ns.AddUpdateModal = AddUpdateModal;
    ns.OnClickDelete = OnClickDelete;

})(window.Airport = window.Airport || {});


$(document).ready(function () {
    Airport.InitAirportDatatable();
});