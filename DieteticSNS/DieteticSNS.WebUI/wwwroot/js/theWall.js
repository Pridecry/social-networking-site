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

function updateWallView() {
    return isRequestValid()
        ? window.location.reload(true)
        : false;
}

function isRequestValid() {
    return !document.querySelector('.field-validation-error');
}

////SignalR

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/wallHub").build();

connection.on("ReceiveCommentLike", function (likeId, commentId) {
    var id = "#commentLikedForm_" + commentId;
    var url = "/Likes/DeleteLike/" + likeId;
    $(id).attr('action', url);
});

connection.on("ReceivePostLike", function (likeId, postId) {
    var id = "#postLikedForm_" + postId;
    var url = "/Likes/DeleteLike/" + likeId;
    $(id).attr('action', url);
});

connection.on("ReceivePostComment", function (commentId, postId, content) {
    var FullName = $("#userFullName").text();
    var AvatarPath = $("#avatarPath_" + postId).attr('src');

    var html = `
        <div class="pb-2" id="postComment_${commentId}">
            <div class="row flex-nowrap">
                <div class="col-auto">
                    <img class="rounded-circle img-fluid border border-dark" style="height: 2.5rem; width: 2.5rem" src="${AvatarPath}" asp-append-version="true" alt="Avatar">
                </div>
                <div class="col-auto px-0 mb-0 flex-shrink-1">
                    <div class="jumbotron px-3 py-2 mb-0">
                        <b>${FullName}:</b>
                        <span class="text-break">${content}</span>
                    </div>
                </div>
                <div class="col-auto my-auto pl-2">
                    <div class="dropdown d-inline">
                        <a href="#" data-toggle="dropdown" style="color: inherit; text-decoration:none">
                            <i class="fas fa-ellipsis-h"></i>
                        </a>

                        <div class="dropdown-menu dropdown-menu-right">
                            <form id="deleteCommentForm_${commentId}" action="/Comments/DeleteComment/${commentId}" method="post" data-ajax="true" data-ajax-method="post" data-ajax-complete="hideModal('#deleteCommentModal_${commentId}')" data-ajax-success="setTimeout(deleteComment, 400, '#postComment_${commentId}', '#commentCounter_${postId}')">
                                <button type="button" class="dropdown-item" data-toggle="modal" data-target="#deleteCommentModal_${commentId}">Delete comment <i class="far fa-trash-alt"></i></button>
                            </form>
                        </div>

                        <div class="modal fade" id="deleteCommentModal_${commentId}" tabindex="-1">
                            <div class="modal-dialog modal-sm modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Delete confirmation</h5>
                                        <button type="button" class="close" style="outline: none" data-dismiss="modal"><span>&times;</span></button>
                                    </div>
                                    <div class="modal-body">
                                        Are you sure to delete this comment?
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                        <button type="submit" class="btn btn-danger" form="deleteCommentForm_${commentId}">Delete</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-auto">
                    <div style="width: 2.5rem"></div>
                </div>
                <div class="col-auto">
                    <form id="commentLikedForm_${commentId}" action="/Likes/DeleteLike" method="post" class="d-inline" data-ajax="true" data-ajax-method="post" data-ajax-success="setTimeout(commentLikeToggle, 300, false, ${commentId})">
                        <button id="commentLikedButton_${commentId}" type="submit" class="btn btn-link text-decoration-none text-dark p-0 d-none"><small><i class="far fa-thumbs-up text-primary"></i> Liked</small></button>
                    </form>
                    <form action="/Likes/CreateCommentLike/${commentId}" method="post" class="d-inline" data-ajax="true" data-ajax-method="post" data-ajax-success="setTimeout(commentLikeToggle, 300, true, ${commentId})">
                        <button id="commentLikeButton_${commentId}" type="submit" class="btn btn-link text-decoration-none text-dark p-0"><small><i class="far fa-thumbs-up"></i> Like</small></button>
                    </form>

                    <button class="btn btn-link text-decoration-none text-dark p-0"><small>(<span id="commentLikeCounter_${commentId}">0</span>)</small></button>
                </div>
                <div class="col-auto px-0" style="padding-top: 0.15rem">
                    <small>just now</small>
                </div>
            </div>
        </div>
    `;

    $(`#comments_${postId} > div:last`).before(html);
    increment("#commentCounter_" + postId);
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});
