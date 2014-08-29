
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

    var autoCompleteAndAjaxSubmitForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var $form = $input.parents("form:first");
        $form.submit();
    }

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-autocomplete"),
            select: autoCompleteAndAjaxSubmitForm
        }

        $input.autocomplete(options);
    }

    $('#searchTerm').submit(ajaxSubmitForm);
    $('#searchTerm').bind('input', function () {
        $("#searchForm").submit();
    });
    $("input[data-autocomplete]").each(createAutocomplete);
});

