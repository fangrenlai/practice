$(document).ready(function () {
    //alert("JS loaded...");
});


// 重置按钮点击事件
function reset() {
    $('#loginName').val('');
    $('#pwd').val('');
    $('#loginNameInfo').html('');
    $('#pwdInfo').val('');
}

// 登录按钮点击事件
function login() {
    var loginName = $('#loginName').val();
    var pwd = $('#pwd').val();
    $.post("/Login/DoLogin", { "loginName": loginName, "pwd": pwd },
    function (data) {
        console.log("data = " + data)
        if ("1" == data) {
            window.location.href = "/Home/Index";
        } else if ("0" == data) {
            alert("错误的账号和密码，请使用admin和admin重试");
        } else{
            alert("未知错误，检查数据库是否打开，然后使用admin和admin重试");
        }
    });

}