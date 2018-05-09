function onSelect(selection)
{
    if (selection === 1)
    {
        if (!$('#addCourseInfoForm').hasClass('hide'))
        {
            $('#addCourseInfoForm').addClass('hide');
        }

        onGetTranscript($('#studentId').val());
    }
    else if (selection === 2)
    {
        onGetAcademicPlan($('#studentId').val());
    }
}

function onGetTranscript(studentId)
{
    $.ajax({
        url: 'http://localhost:60548/api/Transcript/GetTranscript',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        crossDomain: true,
        data: {
            studentId: studentId.value
        },
        success: function (data) {
            $(".transcript-body").empty();

            for (var i in data) {
                $(".transcript-body").append(
                    '<div class="col-md-12 form-body">' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="course' + i + '" value="' + data[i].CourseId + '"/>' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="section' + i + '" value="' + data[i].CourseName + '" />' +
                        '</div>' +
                        '<div class="col-md-6 form-group">' +
                            '<input class="form-control" id="description' + i + '" value="' + data[i].Description + '" />' +
                        '</div>' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="semester' + i + '" value="' + data[i].Semester + '" />' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="grade' + i + '" value="' + data[i].Grade + '" />' +
                        '</div>' +
                    '</div>')
            }
        },
        error: function () {
            console.log('Something went wrong!');
        }
    });
}

function onGetAcademicPlan() {
    $.ajax({
        url: 'http://localhost:60548/api/Transcript/GetAcademicPlan',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        crossDomain: true,
        data: {
            studentId: studentId.value
        },
        success: function () {
            $(".transcript-body").empty();

            for (var i in data.CoursesTaken) {
                $(".transcript-body").append(
                    '<div class="col-md-12 form-body">' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="course' + i + '" />' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="section' + i + '" />' +
                        '</div>' +
                        '<div class="col-md-6 form-group">' +
                            '<input class="form-control" id="description' + i + '" />' +
                        '</div>' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="semester' + i + '" />' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="grade' + i + '" />' +
                        '</div>' +
                    '</div>')
            }
            for (var j in data.CoursesNeeded) {
                $(".transcript-body").append(
                    '<div class="col-md-12 form-body">' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="course' + j + '"/>' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="section' + j + '" />' +
                        '</div>' +
                        '<div class="col-md-6 form-group">' +
                            '<input class="form-control" id="description' + j + '" />' +
                        '</div>' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="semester' + j + '" />' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="grade' + j + '" />' +
                        '</div>' +
                    '</div>')
            }
        },
        error: function () {
            console.log('Something went wrong!');
        }
    });
}

function onModifyTranscript(form) {
    $.ajax({
        url: 'http://localhost:60548/api/Transcript/ModifyTranscript',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        crossDomain: true,
        data: {
            studentId: studentId.value,
            courseId: courseId.value,
            grade: grade.value
        },
        success: function (data) {
            $(".transcript-body").empty();

            for (var i in data) {
                $(".transcript-body").append(
                    '<div class="col-md-12 form-body">' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="course' + i + '"/>' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="section' + i + '" />' +
                        '</div>' +
                        '<div class="col-md-6 form-group">' +
                            '<input class="form-control" id="description' + i + '" />' +
                        '</div>' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="semester' + i + '" />' +
                        '</div>' +
                        '<div class="col-md-1 form-group">' +
                            '<input class="form-control" id="grade' + i + '" />' +
                        '</div>' +
                    '</div>')
            }
        },
        error: function () {
            console.log('Something went wrong!');
        }
    });
}