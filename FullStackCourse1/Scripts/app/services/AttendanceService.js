var AttendanceService = function () {


    var addAttendence = function (gigId, success, fail) {

        $.post("/api/Attendences",
              { "GigId": gigId })
              .success(success)
              .error(fail);
    }

    var deleteAttendance = function (gigId, success, fail) {
        $.ajax({
            url: '/api/Attendences/' + gigId,
            method: 'Delete'
        })
            .success(success)
            .error(fail);
    }

    return {
        addAttendence: addAttendence,
        deleteAttendance: deleteAttendance

    }
}();
