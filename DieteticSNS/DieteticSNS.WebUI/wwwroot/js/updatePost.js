function hideDeleteModal(id) {

    $("#deleteModal_" + id).modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
};

function deleteCard(id) {
    $("#postCard" + id).remove();
};

function hideEditModal(id) {

    $("#editModal_" + id).modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
};

function updateCard(id) {
    let titleValue = $("#titleInput_" + id).val();
    let descriptionValue = $("#descriptionInput_" + id).val();

    $("#title_" + id).html(titleValue);
    $("#description_" + id).html(descriptionValue);
};
