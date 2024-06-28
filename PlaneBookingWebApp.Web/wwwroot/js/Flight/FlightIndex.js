(function (ns) {
    function InitFlightDatatable() {
        $("#flight-datatable").DataTable();
    }

    function OnSuccess() {
        InitFlightDatatable();
        HideModal();
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#success-alert").slideUp(500);
        });
    }

    function HideModal() {
        $("#flight-modal").modal("hide");
    }

    function ShowModal() {
        $("#flight-modal").modal("show");
    }

    function OnFailure(result) {
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#danger-alert").slideUp(500);
        });
    }

    function OnClickEdit(Id) {
        $("#flightModalLabel").text("Update Flight");
        $.ajax({
            type: 'GET',
            url: "../ajax/Flight/UpdateFlightModal",
            data: { Id: Id },
            async: true,
            success: function (data) {
                $("#flight-modal-body").html(data);
            },
            error: function () {
                    
            }
        })
    }

    function OnClickDelete(Id) {
        if (confirm("Are you sure you want to continue?") === true) {
            $.ajax({
                type: 'POST',
                url: "../ajax/Flight/DeleteFlight",
                data: { Id: Id },
                success: function (data) {
                    $("#flight-table-container").html(data);
                    OnSuccess();
                },
                error: function () {

                }
            });
        }
    }

    function AddUpdateModal() {
        $("#flightModalLabel").text("Add Flight");
        $.ajax({
            type: 'GET',
            url: "../ajax/Flight/AddUpdateModal",
            success: function (data) {
                $("#flight-modal-body").html(data);
                ShowModal();
            },
            error: function () {

            }
        });
    }

    ns.InitFlightDatatable = InitFlightDatatable;
    ns.OnSuccess = OnSuccess;
    ns.OnFailure = OnFailure;
    ns.OnClickEdit = OnClickEdit;
    ns.AddUpdateModal = AddUpdateModal;
    ns.OnClickDelete = OnClickDelete;

})(window.Flight = window.Flight || {});


$(document).ready(function () {
    Flight.InitFlightDatatable();
});