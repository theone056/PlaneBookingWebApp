(function (ns) {
    function InitBookingDatatable() {
        $("#booking-datatable").DataTable();
    }

    function OnSuccess() {
        InitBookingDatatable();
        HideModal();
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#success-alert").slideUp(500);
        });
    }

    function HideModal() {
        $("#booking-modal").modal("hide");
    }

    function ShowModal() {
        $("#booking-modal").modal("show");
    }

    function OnFailure(result) {
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#danger-alert").slideUp(500);
        });
    }

    function OnClickEdit(Id) {
        $("#bookingModalLabel").text("Update Booking");
        $.ajax({
            type: 'GET',
            url: "../ajax/Booking/UpdateBookingModal",
            data: { Id: Id },
            async: true,
            success: function (data) {
                $("#booking-modal-body").html(data);
            },
            error: function () {
                    
            }
        })
    }

    function OnClickDelete(Id) {
        if (confirm("Are you sure you want to continue?") === true) {
            $.ajax({
                type: 'POST',
                url: "../ajax/Booking/DeleteBooking",
                data: { Id: Id },
                success: function (data) {
                    $("#booking-table-container").html(data);
                    OnSuccess();
                },
                error: function () {

                }
            });
        }
    }

    function AddUpdateModal() {
        $("#bookingModalLabel").text("Add Booking");
        $.ajax({
            type: 'GET',
            url: "../ajax/Booking/AddUpdateModal",
            success: function (data) {
                $("#booking-modal-body").html(data);
                ShowModal();
            },
            error: function () {

            }
        });
    }

    ns.InitBookingDatatable = InitBookingDatatable;
    ns.OnSuccess = OnSuccess;
    ns.OnFailure = OnFailure;
    ns.OnClickEdit = OnClickEdit;
    ns.AddUpdateModal = AddUpdateModal;
    ns.OnClickDelete = OnClickDelete;

})(window.Booking = window.Booking || {});


$(document).ready(function () {
    Booking.InitBookingDatatable();
});