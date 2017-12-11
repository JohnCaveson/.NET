$(document).ready(function () {
    var getQuote = function () {
        $.ajax({
            url: "/quote/randomquote/",
            success: function (response) {
                let quoteInfo = response;
                $("#theQuote").fadeOut(250, function () {
                    // TODO: insert the quote into the h2 element with id theQuote
                    $('#theQuote').html(quoteInfo.quote)
                    // TODO: fade in theQuote over 250 ms
                    $('#theQuote').fadeIn(250)
                });

                $("#whoSaidIt").fadeOut(250, function () {
                    // TODO: insert who said it into the h3 element with id whoSaidIt
                    $('#whoSaidIt').html(quoteInfo.whoSaidIt)
                    // TODO: fade in whoSaidit over 250 ms
                    $('#whoSaidIt').fadeIn(250)
                });
            },
            error: function () {
                // TODO: insert an error message into the h2 element with id theQuote
                $('#theQuote').html("Still goofing kid.")
            }
        });
    };

    var hideCreate = function () {
        $.ajax({
            success: function (response) {
                let createHide = response;
                $('#createArea').hide();
            }
        })
    }

    var showButtons = function () {
        $.ajax({
            success: function (response) {
                let buttonShow = response;
                $('#createQuoteBtn').on('click', function () {
                    $('#createArea').fadeIn(1000)
                    $('#createQuoteBtn').fadeOut(1000)
                })
            }
        })
    }

    var cancelButton = function () {
        $.ajax({
            success: function (response) {
                let buttonHide = response;
                $('#cancelQuoteCreate').on('click', function () {
                    $('#createArea').fadeOut(1000);
                    $('#createQuoteBtn').fadeIn(1000);
                })
            }
        })
    }

    var createQuote = function () {
        let quoteWeWant = $('#quoteMeBro').val();
        let whoSaidIt = $('#whoSad').val();
        $.ajax({
            type: "POST",
            success: function (response) {
                $('#submitQuoteCreate').on('click', function () {
                    console.log("Success");
                    $('#createArea').hide();
                    $('#createQuotebtn').show();
                })
            },
            error: function () {
                console.log("Failed to submit quote.");
            },
            data: {
                TheQuote: quoteWeWant, WhoSaidIt: whoSaidIt
            }
        })
    }

    // Initial call
    getQuote();
    hideCreate();
    showButtons();
    cancelButton();
    createQuote();

    // Make the call every 3 seconds
    var handle = setInterval(function () {
        getQuote();
    }, 3000);

    // Clean up the interval timer when we navigate from the page
    $(window).on('unload', function () {
        clearInterval(handle);
    });


});
