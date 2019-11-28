function hideModal(id) {
    $(id).modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
};

function deleteItem(id) {
    $(id).remove();
};

function deleteComment(commentId, counterId) {
    $(commentId).remove();

    let counterValue = $(counterId).text();
    $(counterId).html(counterValue - 1);
};

function updateCard(id) {
    let titleValue = $("#titleInput_" + id).val();
    let descriptionValue = $("#descriptionInput_" + id).val();

    $("#title_" + id).html(titleValue);
    $("#description_" + id).html(descriptionValue);
};

function clearContentInput(id) {
    $("#contentInput_" + id).val("");
};
