
$(document).ready(function () {
    $('#partialViewContainer').load('/Home/Student_Information');

    $('#saveButton').click(function () {
        saveStudent();
    });
    //$('#saveButton').click(function () {
    //    myDropzone.processQueue(); 
    //});
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
Dropzone.autoDiscover = false;
var myDropzone = new Dropzone("#my-dropzone", {
    url: '/Home/AddStud', 
    paramName: "images", 
    maxFilesize: 5, 
    acceptedFiles: "image/*", 
    addRemoveLinks: true,
    autoProcessQueue: false,
    init: function () {
        this.on('success', function (file, response) {
           

        });

        this.on('error', function (file, response) {
           
        });
    },
});


$('#my-dropzone').on('change', function () {
    

});

$('#file').on('change', function () {
    var fileInput = $(this)[0];
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#selectedImage').attr('src', e.target.result);
            $('#selectedImage').css('display', 'block');
        };
        reader.readAsDataURL(fileInput.files[0]);
    } else {
        // Handle case when no file is selected or browser doesn't support File API
        $('#selectedImage').css('display', 'none');
    }
});


function editStudent(id) {
    window.location.href = '/Home/AddDataToTable?id=' + id;
}





function saveStudent() {

    

    
        var data = new FormData();
        var studentId = $('#saveButton').data('student-id');
        data.append("Name", $('#name').val());
        data.append("Roll", $('#roll').val());
        data.append("Address", $('#address').val());
        data.append("City", $('#city').val());
    var uploadedFiles = myDropzone.getAcceptedFiles();
    for (var i = 0; i < uploadedFiles.length; i++) {
        data.append("images", uploadedFiles[i]);
    }

        //console.log(data);
        //// Append an array of files for images
        //var fileInput = $('#file')[0];
        //for (var i = 0; i < fileInput.files.length; i++) {
        //    data.append("images", fileInput.files[i]);
        //}

        if (studentId) {
            data.append("Id", studentId);
            console.log(data);

            $.ajax({
                url: '/Home/UpdateStud/' + studentId,
                type: 'POST',
                data: data,
                processData: false,
                contentType: false,
                success: function (data) {
                    window.location.href = '/Home/Student_Information';
                },
                error: function () {
                    alert('Failed to update the student. Please check your data.');
                }


            });
        } else {
            console.log(data);

            $.ajax({
                url: '/Home/AddStud',
                type: 'POST',
                data: data,
                processData: false,
                contentType: false,
                success: function (data) {
                    window.location.href = '/Home/Student_Information';
                },
                error: function () {
                    alert('Failed to save the student. Please check your data.');
                }


            });
        }
    
}



function deleteStudent(id) {
    $.ajax({
        url: '/Home/DeleteStud/' + id,
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

function scrollToSection(sectionId) {
    $('html, body').animate({
        scrollTop: $(sectionId).offset().top
    }, 1000);

}


