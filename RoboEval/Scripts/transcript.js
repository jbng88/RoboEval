function onSelect(selection)
{
    if ($('.unhide') !== null)
    {
        $('.unhide').addClass('hide');
        $('.hide').removeClass('unhide');
    }

    if (selection === 1)
    {
        $.ajax({
            url: 'http://localhost/api/',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            success: function(data) {
                $(".transcript-body").empty();

                for(var i in data)
                {
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
    else if (selection === 2)
    {
        $('.hide').addClass('unhide');
        $('.hide').removeClass('hide');
    }
}

function onSubmit() {
    $.ajax({
        url: 'http://localhost/api/',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: {
            CourseId: $('#course').val(),
            SectionId: $('#section').val(),
            Description: $('#description').val(),
            Semester: $('#semester').val(),
            Grade: $('#grade').val(),
        },
        success: function () {
            $('#course').val(null);
            $('#section').val(null);
            $('#description').val(null);
            $('#semester').val(null);
            $('#grade').val(null);
        },
        error: function () {
            console.log('Something went wrong!');
        }
    });
}