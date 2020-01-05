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

function increment(id) {
    let counterValue = parseInt($(id).text());
    $(id).html(counterValue + 1);
};

function decrement(id) {
    let counterValue = parseInt($(id).text());
    $(id).html(counterValue - 1);
};

function postLikeToggle(value, id) {
    if (value == false) {
        $("#postLikeButton_" + id).removeClass("d-none");
        $("#postLikedButton_" + id).addClass("d-none");
        decrement("#postLikeCounter_" + id);
    } else {
        $("#postLikeButton_" + id).addClass("d-none");
        $("#postLikedButton_" + id).removeClass("d-none");
        increment("#postLikeCounter_" + id);
    }
};

function commentLikeToggle(value, id) {
    if (value == false) {
        $("#commentLikeButton_" + id).removeClass("d-none");
        $("#commentLikedButton_" + id).addClass("d-none");
        decrement("#commentLikeCounter_" + id);
    } else {
        $("#commentLikeButton_" + id).addClass("d-none");
        $("#commentLikedButton_" + id).removeClass("d-none");
        increment("#commentLikeCounter_" + id);
    }
};

function disableReportPostButton(id) {
    $("#reportPostButton_" + id).attr('disabled', true); 
};

function disableReportCommentButton(id) {
    $("#reportCommentButton_" + id).attr('disabled', true);
};

function updateView(type, postId) {
    if (type === 'newPost') {
        return isRequestValid()
            ? window.location.reload(true)
            : false;
    } else if (type === 'comment') {
        localStorage.setItem('currentCommentWindow', postId);
        return window.location.reload(true)
    }
}

var updateWallView = updateView.bind(null, 'newPost');
var updateCommentView = updateView.bind(null, 'comment');

function isRequestValid() {
    return !document.querySelector('.field-validation-error');
}

function initialLoadHandler() {
    var currentCommentWindow = localStorage.getItem('currentCommentWindow');

    if (currentCommentWindow) {
        document.getElementById('comments_' + currentCommentWindow).style.display = 'block';
        return localStorage.removeItem('currentCommentWindow');
    }
}

initialLoadHandler();