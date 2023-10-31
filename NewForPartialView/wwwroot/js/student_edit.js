$(document).ready(function () {
    var studentId = getParameterByName("id");
    if (studentId) {
        fetchStudentDataForEdit(studentId);
    }

    //$('#saveButton').click(function () {
    //    saveStudent();
    //});
});

// Function to retrieve a query parameter by name from the URL
function getParameterByName(name) {
    var url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

// Function to fetch student data by ID for editing
function fetchStudentDataForEdit(id) {
    $.ajax({
        url: '/Home/GetStudent/' + id,
        type: 'GET',
        success: function (data) {
            if (data) {
                $('#name').val(data.name);
                $('#roll').val(data.roll);
                $('#address').val(data.address);
                $('#city').val(data.city);

                if (data.imageUrl) {
                    $('#selectedImage').attr('src', data.imageUrl);
                    $('#selectedImage').css('display', 'block');
                }
                console.log(data);
                $('#saveButton').data('student-id', data.id); // Set the student ID for updating

            }
        }
    });
}

//function fetchStudentDataForEdit(id) {
//    $.ajax({
//        url: '/Home/GetStudent/' + id,
//        type: 'GET',
//        success: function (data) {
//            if (data) {
//                $('#name').val(data.name);
//                $('#roll').val(data.roll);
//                $('#address').val(data.address);
//                $('#city').val(data.city);

//                // Clear the previous images
//                $('#imageContainer').empty();

//                if (data.imageUrl && data.imageUrl.length > 0) {
//                    // Create image elements for each URL
//                    data.imageUrl.forEach(function (imageUrl) {
//                        var imageElement = $('<img>');
//                        imageElement.attr('src', imageUrl);
//                        imageElement.css('max-width', '50px');
//                        imageElement.css('max-height', '100px');
//                        $('#imageContainer').append(imageElement);
//                    });
//                }

//                $('#saveButton').data('student-id', data.id); // Set the student ID for updating
//            }
//        }
//    });
//}


//$(document).ready(function () {
//    var studentId = getParameterByName("id");
//    if (studentId) {
//        fetchStudentDataForEdit(studentId);
//    }
//});


//// Function to retrieve a query parameter by name from the URL
//function getParameterByName(name) {
//    var url = window.location.href;
//    name = name.replace(/[\[\]]/g, "\\$&");
//    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
//        results = regex.exec(url);
//    if (!results) return null;
//    if (!results[2]) return '';
//    return decodeURIComponent(results[2].replace(/\+/g, " "));
//}

//// Function to fetch student data by ID for editing
//// Function to fetch student data by ID for editing
//function fetchStudentDataForEdit(id) {
//    $.ajax({
//        url: '/Home/GetStudent/' + id,
//        type: 'GET',
//        success: function (data) {
//            if (data) {
//                $('#name').val(data.name);
//                $('#roll').val(data.roll);
//                $('#address').val(data.address);
//                $('#city').val(data.city);

//                if (data.imageUrl) {
//                    // Set the image source
//                    $('#selectedImage').attr('src', data.imageUrl);
//                    $('#selectedImage').css('display', 'block');
//                }

//                // Store the student ID for updating
//                $('#saveButton').data('student-id', data.id);
//            }
//        }
//    });
//}
