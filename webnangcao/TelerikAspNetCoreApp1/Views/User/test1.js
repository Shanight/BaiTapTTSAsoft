$(document).on("click", ".k-grid-delete", function () {
    var grid = $("#UserTable").data("kendoGrid");
    var dataItem = grid.dataItem($(this).closest("tr"));
    // Prompt user to confirm by entering the UserID again
    kendo.prompt("To confirm deletion, please enter the UserID (" + dataItem.UserID + "):").then(function (result) {
        if (result === dataItem.UserID) {
            // Perform the delete action
            $.ajax({
                url: "@Url.Action("User_Delete", "Home")",
                type: "POST",
                data: { userId: dataItem.UserID },
                success: function (result) {
                    // Refresh the grid
                    grid.dataSource.read();
                },
                error: function (xhr, status, error) {
                    alert("An error occurred while deleting the record.");
                }
            });
        } else {
            // Inform user that deletion was canceled
            alert("Deletion canceled. You entered a different UserID.");
        }
    });
});