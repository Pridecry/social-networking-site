function hideModal(id) {

    $("#deleteModal_" + id).modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
};

function deleteCard(id) {
    $("#postCard" + id).remove();
};
