function id(elementId) {
    return document.getElementById(elementId);
}

window.onload = function () {

    //constants
    var MAX_WIDHT = 200,
        MAX_HEIGHT = 200;

    var URL = window.webkitURL || window.URL;

    var inputFile = id('pic');

    inputFile.addEventListener('change', function (event) {

        var file = event.target.files[0];

        //elements
        var canvas = id('preview'),
            ctx = canvas.getContext('2d'),
            url = URL.createObjectURL(file);

        var img = new Image();

        img.onload = function () {

            var width = img.width,
                height = img.height;

            //resize
            if (width > height) {
                if (width > MAX_WIDHT) {
                    height *= MAX_WIDHT / width;
                    width = MAX_WIDHT;
                }
                else {
                    if (height > MAX_HEIGHT) {
                        width *= MAX_HEIGHT / height;
                        height = MAX_HEIGHT;
                    }
                }
            }

            canvas.width = width;
            canvas.height = height;

            ctx.drawImage(img, 0, 0, width, height);

            //Form data (POST)

            console.log(file);

            //name
            var imageName = id('imageName');
            imageName.value = file.name;

            //contentType
            var contentType = id('contentType');
            contentType.value = file.type;

            //image data
            var imageData = id('imageData'),
             dataUrl = id('preview').toDataURL('image/png').replace('data:image/png;base64,', '');

            imageData.value = dataUrl;


            //(AJAX)
            //id('btnSave').addEventListener('click', function (e) {

            //    e.preventDefault();

            //    console.log("AJAX way");
            //    var formData = new FormData();

            //    formData.append('imageName', file.name);
            //    formData.append('contentType', file.type);
            //    formData.append('imageData', dataUrl);

            //    $.ajax({
            //        type: 'POST',
            //        url: '/Home/UploadImage',
            //        data: formData,
            //        processData: false,
            //        contentType: false,
            //        success: function (result) {
            //            var imgElement = document.createElement('img');
            //            imgElement.src = 'data:image/png;base64,' + result;

            //            id('result').appendChild(imgElement);
            //        }
            //    });

            //});

        };

        img.src = url;

    });

};