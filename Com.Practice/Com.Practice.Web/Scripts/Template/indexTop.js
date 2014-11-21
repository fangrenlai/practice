$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "/Template/GetCurrentUserInfo",
        data: "",
        dataType: "JSON",
        success: function (data) {
            if (0 > data.result) {
                console.log("获取当前在线用户信息失败~");
                $('#loginDiv').show();
            } else {
                console.log("获取当前在线用户信息成功~");
                $('#logoutDiv').show();
                var curTime = new Date();
                var welcomeWord = '欢迎您：' + data.UserModel.nick_name;
                console.log('welcomeWord = ' + welcomeWord);
                $('#welcomeWord').html(welcomeWord);
                
                setInterval("showCurrentTime();", 1000);
            }
        }
    });
});
function showCurrentTime() {
    var curTime = getCurrentTime();
    $('#time').html(',当前时间是：' + curTime);
}
function getCurrentTime() {
    var today, hour, second, minute, year, month, date;
    var strDate;
    today = new Date();
    var n_day = today.getDay();
    switch (n_day) {
        case 0: {
            strDate = "星期日"
        } break;
        case 1: {
            strDate = "星期一"
        } break;
        case 2: {
            strDate = "星期二"
        } break;
        case 3: {
            strDate = "星期三"
        } break;
        case 4: {
            strDate = "星期四"
        } break;
        case 5: {
            strDate = "星期五"
        } break;
        case 6: {
            strDate = "星期六"
        } break;
        case 7: {
            strDate = "星期日"
        } break;
    }
    year = today.getFullYear();
    month = today.getMonth() + 1;
    date = today.getDate();
    hour = today.getHours();
    minute = today.getMinutes();
    second = today.getSeconds();
    if (hour < 10) {
        hour = "0" + hour;
    }
    if (minute < 10) {
        minute = "0" + minute;
    }
    if (second < 10) {
        second = "0" + second;
    }
    return year + "年" + month + "月" + date + "日" + strDate + " " + hour + ":" + minute + ":" + second;
}