$(document).ready(function () {
    var hideCreate = function () {
        $('#createPrivUser').hide();
    };

    var renderCreateFields = function () {
        $.ajax({
            success: function () {
                $('#grantPermission').on('click', function () {
                    $('#grantPermission').hide();
                    $('#createPrivUser').show();
                })
            }
        })
    };

    //permission submission... ayyyyyyyye
    $('#permForm').on('submit', function (event) {
        let $form = $(this);
        let listId = $('#listId').val();
        let selectValue = $('#selectValue :selected').val();
        $.ajax({
            url: $form.attr('action'),
            type: $form.attr('method'),
            data: {
                listId: listId, personId: selectValue
            },
            success: function (response) {
                console.log(response);
            },
            error: function (response) {
                location.reload();
                console.log(response);
            }
        })
        event.preventDefault();
    })

    //hides the create windows
    $(document).on("click", "#cancelCreate", function () {
        $('#createPrivUser').hide();
        $('#grantPermission').show();
    })

    //Jquery post back to remove permissions
    $('.personRow').on('click', '.revokePerm', function () {
        let $form = $('#revokePermForm');
        $.ajax({
            url: $form.attr('action'),
            type: $form.attr('method'),
            data: { listId: $('#listId').val(), personId: $(this).prev('.personId').val() },
            success: function () {
                location.reload();
            },
            error: function () {
                location.reload();
            }
        })
    })

    //refreshes the current screen
    $('#updateBtn').on('click', function () {
        location.reload();
    });

    hideCreate();
    renderCreateFields();
});