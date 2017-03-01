$(document).ready(function () {
    $('.claim-view').click(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            url: '@Url.Action("ClaimDone")',
            success: function (result) {
            }
        });
    });
});

$(document).ready(function () {
    $('.claim-view').click(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'GET',
            dataType: 'html',
            data: $(this).serialize(),
            url: '@Url.Action("Claim")',
            success: function (result) {
                $('.display-claim').html(result);
            }
        });
    });
});

$(document).ready(function () {
    $('.pending-view').submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            url: '@Url.Action("PendingJob", "Jobs")',
            success: function (result) {
                var resultMessage = "<strong>" + result.title + " - " + "</strong>" + result.description;
                $('.display-pending').html(resultMessage);
            }
        });
    });
});

$(document).ready(function () {
    $('.completed-view').submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            url: '@Url.Action("CompletedJob", "Jobs")',
            success: function (result) {
                var resultMessage = "<strong>" + result.title + " - " + "</strong>" + result.description;
                $('.display-completed').html(resultMessage);
            }
        });
    });
});


