var FollowingService = function () {

    var AddFollower = function (artistId, success, fail) {
        $.post("/api/Following",
           { "ArtistId": artistId })
           .success(success)
           .error(fail);
    };

    var DeleteFollower = function (artistId, success, fail) {
        $.ajax({
            url: "/api/Following/" + artistId,
            method: 'DELETE'
        })
            .done(success)
            .fail(fail);
    }

    return {

        AddFollower: AddFollower,
        DeleteFollower: DeleteFollower
    }

}();