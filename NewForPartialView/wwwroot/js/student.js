$(document).ready(function () {

    $('#partialViewContainer').load('/Home/Student_Information');

    $('#fetchDataButton').click(function () {
        $.ajax({
            url: '/Home/Student_Information',
            type: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#partialViewContainer').html(data);

            }
        });
    });
});
function addStudent() {
    var student = new FormData();
    student.append("Name", $('#name').val());
    student.append("Roll", $('#roll').val());
    student.append("Address", $('#address').val());
    student.append("City", $('#city').val());
    student.append("Image", $('#file')[0].files[0]); // Use [0] to access the first selected file
    student.append("ImageUrl", $('#file')[0]); // Use [0] to access the first selected file

    $.ajax({
        url: '/Home/AddStud',
        type: 'POST',
        data: student,
        processData: false, // Prevent jQuery from automatically processing the data
        contentType: false, // Prevent jQuery from setting the content type
        success: function (data) {
            $('#partialViewContainer').load('/Home/Student_Information');
            clearForm();
        },
        error: function () {
            alert('Failed to add the student. Please check your data.');
        }
    });
}

function editStudent(id) {
    var student = {
        Id: id,
        Name: $('#name').val(),
        Roll: $('#roll').val(),
        Address: $('#address').val(),
        City: $('#city').val()
    };

    $.ajax({
        url: '/Home/UpdateStud', // Correct the URL
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(student),
        success: function (data) {
            $('#partialViewContainer').load('/Home/Student_Information');
            clearForm();
        },
        error: function () {
            alert('Failed to update the student. Please check your data.');
        }
    });
}

function deleteStudent(id) {
    $.ajax({
        url: '/Home/DeleteStud/' + id, // Correct the URL and pass the ID
        type: 'POST',
        success: function (data) {
            $('#partialViewContainer').load('/Home/Student_Information');
        }
    });
}

function clearForm() {
    $('#name').val('');
    $('#roll').val('');
    $('#address').val('');
    $('#city').val('');
}