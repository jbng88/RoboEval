function onSelect(selection)
{
    if (selection === 2)
    {
        onGetTranscript($('#studentId').val());
    }
    else if (selection === 4)
    {
        onGetEdPlan($('#studentId').val());
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
            studentId: studentId
        },
        success: function (courses) {
            $("#transcript").empty();

            for (var i in courses) {
                $("#transcript").append(
                    '<div class="col-md-12 form-body">' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="course' + i + '" value="' + courses[i].CourseId + '" disabled />' +
                        '</div>' +
                        '<div class="col-md-8 form-group">' +
                            '<input class="form-control" id="section' + i + '" value="' + courses[i].Name + '" disabled />' +
                        '</div>' +
                        '<div class="col-md-2 form-group">' +
                            (courses[i].Grade ?
                                ('<input class="form-control" id="grade' + i + '" value="' + courses[i].Grade + '" disabled />')
                                : ('<input class="form-control" id="grade' + i + '" />')) +
                        '</div>' +
                    '</div>')
            }
        },
        error: function () {
            console.log('Something went wrong!');
        }
    });
}

function onGetEdPlan() {
    $.ajax({
        url: 'http://localhost:60548/api/Transcript/GetStudentEdPlan',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        crossDomain: true,
        data: {
            studentId: studentId.value
        },
        success: function (edPlan) {
            $("#transcript").empty();

            for (var i in edPlan.CoursesTaken) {
                $("#transcript").append(
                    '<div class="col-md-12 form-body">' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="course' + i + '" value="' + edPlan.CoursesTaken[i].CourseId + '" disabled />' +
                        '</div>' +
                        '<div class="col-md-8 form-group">' +
                            '<input class="form-control" id="section' + i + '" value="' + edPlan.CoursesTaken[i].Name + '" disabled />' +
                        '</div>' +
                        '<div class="col-md-2 form-group">' +
                            (edPlan.CoursesTaken[i].Grade ?
                                ('<input class="form-control" id="grade' + i + '" value="' + edPlan.CoursesTaken[i].Grade + '" disabled />')
                                : ('<input class="form-control" id="grade' + i + '" />')) +
                        '</div>' +
                    '</div>')
            }
            for (var j in edPlan.CoursesNeeded) {
                $("#coursesNeeded").append(
                    '<div class="col-md-12">Courses Needed:</div>' +
                    '<div class="col-md-12 form-body">' +
                        '<div class="col-md-2 form-group">' +
                            '<input class="form-control" id="course' + j + '" value="' + edPlan.CoursesNeeded[j].CourseId + '" disabled />' +
                        '</div>' +
                        '<div class="col-md-8 form-group">' +
                            '<input class="form-control" id="section' + j + '" value="' + edPlan.CoursesNeeded[j].Name + '" disabled />' +
                        '</div>' +
                        '<div class="col-md-2 form-group">' +
                            (edPlan.CoursesNeeded[j].Grade ?
                                    ('<input class="form-control" id="grade' + j + '" value="' + edPlan.CoursesNeeded[j].Grade + '" disabled />')
                                    : ('<input class="form-control" id="grade' + j + '" disabled />')) +
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
    var transcriptDto = {
        TranscriptId: 1,
        Courses: []
    };
    var courseId = 0;
    var name = null;

    for (var i in form)
    {
        if (i % 3 === 0) {
            courseId = form[i].value;
        }
        else if (i % 3 === 1) {
            name = form[i].value;
        }
        if (i % 3 === 2) {
            transcriptDto.Courses.push({
                CourseId: courseId,
                Name: name,
                Grade: form[i].value
            });
        }
    }

    $.ajax({
        url: 'http://localhost:60548/api/Transcript/ModifyTranscript',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        crossDomain: true,
        data: JSON.stringify(transcriptDto),
        error: function (data) {
            onGetTranscript($('#studentId').val());
        }
    });
}