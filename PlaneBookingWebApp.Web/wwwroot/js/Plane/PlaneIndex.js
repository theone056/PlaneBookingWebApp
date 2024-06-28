(function (ns) {
    function InitPlaneDatatable() {
        $("#plane-datatable").DataTable();
    }

    function OnSuccess() {
        InitPlaneDatatable();
        HideModal();
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#success-alert").slideUp(500);
        });
    }

    function HideModal() {
        $("#plane-modal").modal("hide");
    }

    function ShowModal() {
        $("#plane-modal").modal("show");
    }

    function OnFailure(result) {
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#danger-alert").slideUp(500);
        });
    }

    function OnClickEdit(Id) {
        $("#planeModalLabel").text("Update Plane");
        $.ajax({
            type: 'GET',
            url: "../ajax/Plane/UpdateAirportModal",
            data: { Id: Id },
            async: true,
            success: function (data) {
                $("#plane-modal-body").html(data);
            },
            error: function () {
                    
            }
        })
    }

    function OnClickDelete(Id) {
        if (confirm("Are you sure you want to continue?") === true) {
            $.ajax({
                type: 'POST',
                url: "../ajax/Plane/DeletePlane",
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
        $("#planeModalLabel").text("Add Plane");
        $.ajax({
            type: 'GET',
            url: "../ajax/Plane/AddUpdateModal",
            success: function (data) {
                $("#plane-modal-body").html(data);
                ShowModal();
            },
            error: function () {

            }
        });
    }

    ns.InitPlaneDatatable = InitPlaneDatatable;
    ns.OnSuccess = OnSuccess;
    ns.OnFailure = OnFailure;
    ns.OnClickEdit = OnClickEdit;
    ns.AddUpdateModal = AddUpdateModal;
    ns.OnClickDelete = OnClickDelete;

})(window.Plane = window.Plane || {});


$(document).ready(function () {
    Plane.InitPlaneDatatable();
});