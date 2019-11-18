$(document).ready(function () {
    $(document).on('change', '.custom-file-input', function () {
        var fileName = $(this).val().split('\\').pop();
        $(this).next('.custom-file-label').html(fileName);
    })
});
