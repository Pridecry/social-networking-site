function followToggle(value) {
    if (value == true) {
        $("#followButton").removeClass("d-none");
        $("#unfollowButton").addClass("d-none");
        $("#followDescription").text("Interested in my activity?");
        decrement("#followersCounter");
    } else {
        $("#followButton").addClass("d-none");
        $("#unfollowButton").removeClass("d-none");
        $("#followDescription").text("Not interested in my activity?");
        increment("#followersCounter");
    }
};
