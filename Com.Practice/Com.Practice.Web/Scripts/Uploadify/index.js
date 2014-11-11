$(function () {
    //var auth = "<% = Request.Cookies[FormsAuthentication.FormsCookieName]==null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value %>";
    //var ASPSESSID = "<%= Session.SessionID %>";

    //
    $("#file_upload").uploadify({
        'auto': false,// 设置是否自动上传
        //'buttonClass': 'btn-success',//A class name to add to the Uploadify button.
        'buttonCursor': 'hand',//Sets which cursor to display when hovering over the browse button.  The possible values are ‘hand’ and ‘arrow’.
        //'buttonImage':'',//The path to an image to use as the background of the browse button.  If using the default styles, you can create a hover state for the button by stacking the off state above the hover state in the image.  This option is a convenience option and the best way to assign an image to the button is in the CSS file.
        'buttonText': '添加文件...',
        //'checkExisting':'',//The path to a file that checks whether the name of the file being uploaded currently exists in the destination folder.  The script should return 1 if the file name exists or 0 if the file name does not exist.
        'debug': false,//Set to true to turn on the SWFUpload debugging mode.
        'fileObjName': 'Filedata',// The name of the file object to use in your server-side script.  For example, in PHP, if this option is set to ‘the_files’, you can access the files that have been uploaded using $_FILES['the_files'];
        'fileSizeLimit': '1000KB',//The maximum size allowed for a file upload.  This value can be a number or string.  If it’s a string, it accepts a unit (B, KB, MB, or GB).  The default unit is in KB.  You can set this value to 0 for no limit.
        'fileTypeDesc': '可选文件',//The description of the selectable files.  This string appears in the browse files dialog box in the file type drop down.
        'fileTypeExts': '*.gif; *.jpg; *.png',//A list of allowable extensions that can be uploaded.  A manually typed in file name can bypass this level of security so you should always check file types in your server-side script.  Multiple extensions should be separated by semi-colons (i.e. ‘*.jpg; *.png; *.gif’).
        'formData': { 'id': 1, 'page': 1, 'rows': 10, 'folder': '/UploadifyFiles' },//An object containing additional data to send via get or post with each file upload.  If you plan on setting these values dynamically, this should be done using the ‘settings’ method in the onUploadStart event.  You can access these values in the server-side script using the $_GET or $_POST arrays (PHP).
        'height': 50,
        'width': 150,//无单位哦
        //'itemTemplate': '<div id="${fileID}" class="uploadify-queue-item">\
		//			<div class="cancel">\
		//				<a href="javascript:$(\'#${instanceID}\').uploadify(\'cancel\', \'${fileID}\')">X</a>\
		//			</div>\
		//			<span class="fileName">${fileName} (${fileSize})</span><span class="data"></span>\
		//		</div>',
        //The itemTemplate option allows you to specify a special HTML template for each item that is added to the queue.
        //Four template tags are available:
        //instanceID – The ID of the Uploadify instance
        //fileID – The ID of the file added to the queue
        //fileName – The name of the file added to the queue
        //fileSize – The size of the file added to the queue
        //Template tags are inserted into the template like such: ${fileName}.
        'method': 'post',
        'multi': true,//Set to false to allow only one file selection at a time.
        //'overrideEvents' : ['onUploadProgress'],  // The progress will not be updated
        //An array of event names for which you would like to bypass the default scripts for.  You can tell which events can be overridden on the documentation page for each event.
        'preventCaching': true,//If set to true, a random value is added to the SWF file URL so it doesn’t cache.  This will conflict with any existing querystring parameters on the SWF file URL.
        'progressData': 'speed',//The two options are ‘percentage’ or ‘speed’.
        'queueID': 'fileQueue',// 列表DIV的ID
        'queueSizeLimit': 10,// 最多上传10个文件onSelectError
        'removeCompleted': false,// Set to false to keep files that have completed uploading in the queue.
        'removeTimeout': 10,// The delay in seconds before a completed upload is removed from the queue.
        'requeueErrors': false,//If set to true, files that return errors during an upload are requeued and the upload is repeatedly tried.
        'successTimeout': 5,//The time in seconds to wait for the server’s response when a file has completed uploading.  After this amount of time, the SWF file will assume(假定、认为) success.

        //The path to the server-side upload script (uploadify.php).  This should be a path that is relative to the root is possible to avoid issues, but it will also accept a path that is relative to the current script.  For more information about setting up a custom server-side upload script, see our article on Setting Up a Custom Server-Side Upload Script.
        'uploader': '/Handler/Uploadify/UploadifyHandler.ashx',
        //'uploader': '/Handler/Uploadify/UploadifyHandler.ashx',
        'swf': '/Plugins/uploadify3.2/uploadify.swf',
        //The path to the uploadify.swf file.  This path should be relative to the root if possible to avoid issues, but will also accept paths relative to the current script.
        'onCancel': function (file) {
            console.log('onCancel');
        },
        'onClearQueue': function (queueItemCount) {
            console.log('onClearQueue');
        },
        'onDestroy': function () {
            console.log('onDestroy');
        },
        'onFallback': function () {
            console.log('onFallback');
        },
        'onSelect': function (file) {
            $('#file_upload').uploadify('settings', { 'folder': 'UploadifyFiles' });
            console.log('onSelect');
        },
        'onComplete': function (file, data, response) {
            console.log("onComplete response = " + response + "data  = " + data);
        },
        'onQueueComplete': function () {
            console.log("onQueueComplete！");
        },
        'onSelectError': function (file, errorCode, errorMsg) {
            console.log("onSelectError！errorMsg = " + errorMsg + ",errorCode=" + errorCode);
        },
        'onUploadStart': function (file) {
            console.log('Attempting to upload: ' + file.name);
        },
        'onUploadSuccess': function (file, data, response) {
            console.log('The file ' + file.name + ' was successfully uploaded with a response of ' + response + ',data = ' + data);
            alert("data = " + data);
            if (response) {
                var htmlStr = '<img src=' + data + '  style="height:180px;width:320px;"/>';
                $('#uploadedFilesDiv').append(htmlStr);
            } else {
                $('#uploadResultInfoDiv').append(data);
            }
            
        },
        'onUploadComplete': function (file) {
            console.log('The file ' + file.name + ' finished processing.');
        }
    });
});

