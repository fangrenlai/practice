$(function () {
    'use strict';
    //var str = "男/女/老的少的";
    //alert(str.split("/").join('//'));
    // Initialize the jQuery File Upload widget:
    $('#fileupload').fileupload();

    $('#fileupload').fileupload('option', {
        maxFileSize: 500000000,
        resizeMaxWidth: 1920,
        resizeMaxHeight: 1200
    });

    //
    $('#getUploadedFiles').click(function () {

        getUploadedFiles();

    });

    //
    $('#dataSubmitBtn').click(function () {
        var namea = $('#name1').val().trim();
        var nameb = $('#name2').val().trim();
        if ("" == namea || "" == nameb) {// 要通过验证才进行下一步操作
            alert("表格数据不符合要求");
            return false;
        } else {
            // 做一次提交，把数据提交到一个模拟API上，该API会组合两个字并直接返回
            console.log('表格数据通过验证');
            $.ajax({
                type: "POST",
                url: "SaveFormData",
                dataType: "json",
                data: { name1: namea, name2: nameb },
                success: function (result) {
                    console.log("result.result = " + result.result);
                    console.log("result.data = " + result.data);
                    if (1 == result.result) {
                        $('#dataSubmitBtn').hide();
                        $('#dataResetBtn').hide();
                        $('#fileupload').show();
                    } else {
                        alert("result.data =  " + result.data);
                    }
                }
            });
        }
    });
});

//
function getUploadedFiles() {
    console.log("getUploadedFiles");
    $('#uploadedFilesTable').html('');
    $.ajax({
        type: "GET",
        url: "/Handler/Upload/FormUploadHandler.ashx",
        dataType: "json",
        data: { folderPath: "D:/ComPracticeFiles/", matchExpression: "frl-*.*", f: "" },
        success: function (result) {
            console.log("result.length  = " + result.length);
            console.log("result  = " + result);
            var filesHTMLStr = "";
            if (0 < result.length) {
                for (var i = 0; i < result.length; i++) {
                    filesHTMLStr += '<tr>';
                    filesHTMLStr += '<td class="preview"><a href="' + result[i].url + '" title="' + result[i].name + '" rel="gallery" download="' + result[i].name + '"><img style="width:80px;height:65px;" src="' + result[i].thumbnail_url + '"></a></td>';
                    filesHTMLStr += '<td class="name"><a href="' + result[i].url + '" title="' + result[i].name + '" rel="' + result[i].thumbnail_url + '" download="' + result[i].name + '">' + result[i].name + '</a></td>';
                    filesHTMLStr += '<td class="size"><span>' + formatFileSize(result[i].size) + '</span></td>';
                    filesHTMLStr += '<td></td><td></td>';
                    filesHTMLStr += '<td class="delete"><button onclick="deleteUploadedFile(this)" class="btn btn-danger" data-type="' + result[i].delete_type + '" data-url="' + result[i].delete_url + '"><i class="icon-trash icon-white"></i><span>删除</span></button></td>';
                    filesHTMLStr += '</tr>';
                }
            } else {
                filesHTMLStr += '<th>没有相关的文件</th>';
            }
            $('#uploadedFilesTable').append(filesHTMLStr);
        }
    });

}

//
function deleteUploadedFile(target) {
    var deleteURL = $(target).attr("data-url");
    var deleteType = $(target).attr("data-type");
    console.log("deleteURL = " + deleteURL);
    //
    $.ajax({
        type: deleteType,
        url: deleteURL,
        dataType: "json",
        data: {},
        statusCode: {
            500: function () {
                alert('艾玛，删除失败，请重试');
            },
            404: function () {
                alert('艾玛，删除失败，请重试');
            },
            405: function () {
                alert('艾玛，删除失败，请重试');
            },
            200: function () {
                alert('删除成功，刷新文件列表');
                getUploadedFiles();
            }
        }
    });
}

function formatFileSize(bytes) {
    if (typeof bytes !== 'number') {
        return '';
    }
    if (bytes >= 1000000000) {
        return (bytes / 1000000000).toFixed(2) + ' GB';
    }
    if (bytes >= 1000000) {
        return (bytes / 1000000).toFixed(2) + ' MB';
    } else {
        return (bytes / 1000).toFixed(2) + ' KB';
    }
}
