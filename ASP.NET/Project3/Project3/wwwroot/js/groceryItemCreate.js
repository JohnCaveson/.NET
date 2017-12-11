$(document).ready(function () {
    var hideCreate = function () {
        $.ajax({
            success: function () {
                $('#createNewGroceryItem').hide();
            }
        })
    }

    var renderCreateFields = function () {
        $.ajax({
            success: function () {
                $('#createGroceryItemButton').on('click', function () {
                    $('#createGroceryItemButton').hide();
                    $('#createNewGroceryItem').show();
                })
            }
        })
    };

    //updates current fiels
    $('#updateBtn').on('click', function () {
        location.reload();
    });

    //hides create area
    $(document).on("click", "#cancelCreate", function () {
        $('#createNewGroceryItem').hide();
        $('#createGroceryItemButton').show();
    })

    //grocery submissions to list
    $(document).on("submit", "#createGroceryForm", function (event) {
        var $form = $(this);
        $.ajax({
            beforeSend: function () {
                if ($('#groceryName').val() == '' || $('#groceryAmount').val() == '') {
                    alert("You must complete the form before you submit!");
                }
            },
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            success: function (response) {
                $('#groceryName').val('');
                $('#groceryAmount').val('0');
                location.reload();
            }
        });
        event.preventDefault();
    });

    //removes a grocery item from the list
    $('.groceryRow').on("click", ".btn-clicky", function (event) {
        $.ajax({
            url: $('#removeGroceryItem').attr('action'),
            type: $('#removeGroceryItem').attr('method'),
            data: { groceryListId: $('#groceryListId').val(), groceryItemId: $(this).prev('.groceryId').val() },
            success: function (response) {
                console.log(response);
                location.reload();
            },
            error: function (response) {
                console.log(response);
            }
        })
        event.preventDefault();
    });

    //removes a grocery item, with style
    $('.groceryRow').on("click", ".checker", function (event) {
        if ($(this).is(':checked')) {
            $(this).closest('tr').css('text-decoration', 'line-through');
        }
        else {
            $(this).closest('tr').css('text-decoration', 'none');
        }
    })

    //refreshes the page again
    $('#refreshBtn').on('click', function () {
        $('input[type=checkbox]').each(function () {
            if ($(this).is(':checked')) {
                $.ajax({
                    url: $('#removeGroceryItem').attr('action'),
                    type: $('#removeGroceryItem').attr('method'),
                    data: { groceryListId: $('#groceryListId').val(), groceryItemId: $(this).prev('.groceryId').val() },
                    success: function () {
                        location.reload();
                    }
                })
            }
        })
    })

    hideCreate();
    renderCreateFields();
});