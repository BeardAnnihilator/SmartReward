
$(function () {

    var ajaxSubmitForm = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $("#searchResult");
            $target.replaceWith(data);
        });

        return false;
    }

    $('#searchTerm').submit(ajaxSubmitForm);

    $('#searchTerm').bind('input', function () {
        $("#searchForm").submit();
    });
});

