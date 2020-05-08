
var GigController = function (attendanceService) {

    var button;

    var init = function () {
        $('.js-toggle-gig').on('click',toggleAttendance);
    }


    var toggleAttendance = function (e) {
        button = $(e.target);
        if (button.hasClass('btn-default')) {

            attendanceService.addAttendence(button.attr('data-gig-id'), success, fail);

        }
        else {
            attendanceService.deleteAttendance(button.attr('data-gig-id'), success, fail);

        }
    }


    var success = function () {
        var text = button.text();
        text = (text == "Going") ? "Going?" : "Going";
        button.toggleClass('btn-info').toggleClass('btn-default').text(text);
    }

    var fail = function () {
        alert('somting wrong happen');
    }


    return {

        init: init
    }

}(AttendanceService);