

var ArtistController = function (followingService) {

    var button;
    var init = function () {
        $('.js-toggle-follow').on('click',toggleFollower);
    }

    var toggleFollower = function (e) {

        button = $(e.target);

      

        if (button.text().trim() == "Following")
            followingService.DeleteFollower(button.attr("data-artist-id"), success, fail);

        else
            followingService.AddFollower(button.attr("data-artist-id"), success, fail);

    }
   

    var success = function () {

        var text = (button.text().trim() == "Following") ? "Follow" : "Following";
        button.toggleClass('btn-info').toggleClass('btn-default').text(text);

    }

    var fail = function () {
        alert("error occurs");
    }


    return {
        init:init
    }
}(FollowingService);