$(document).ready(function () {
    //loadGrid();// js方式
});
//function formatterDate(date) {
//    var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();
//    var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"
//    + (date.getMonth() + 1);
//    return date.getFullYear() + '-' + month + '-' + day;
//}
// “清空”查询条件
function doClear() {
    $('#query_login_name').val('');
    $('#nick_name').val('');
}
// “查询”
function doSearch() {
    $('#tablelist').datagrid('load', {
        query_login_name: $('#query_login_name').val().trim(),
        nick_name: $('#nick_name').val().trim()
    });
}
// “新增”
function add() {
    $('#addWin').dialog('open');
    $('#addfm').form('clear');
}
// “保存”
function save() {
    $('#addfm').form('submit', {
        url: 'SaveUser',
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.result == 1) {
                $.messager.show({
                    title: '提示信息',
                    msg: '新增成功',
                    timeout: 2000
                });
                $('#addWin').dialog('close');		// close the dialog
                doSearch();
            } else {
                $.messager.show({
                    title: '提示信息',
                    msg: '出错了：' + result.msg
                });
            }

        }
    });
}
//“修改”
function edit() {
    var row = $('#tablelist').datagrid('getSelected');
    if (row) {
        $('#editWin').dialog('open');
        $('#editfm').form('load', row);
    } else {
        $.messager.alert("提示信息", "请至少选择一条记录");
    }
}
// 确定修改
function update() {
    $('#editfm').form('submit', {
        url: 'EditUser',
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.result == 1) {
                $.messager.show({
                    title: '提示信息',
                    msg: '修改成功',
                    timeout: 2000
                });
                $('#editWin').dialog('close');		// close the dialog
                doSearch();
            } else {
                $.messager.show({
                    title: '提示信息',
                    msg: '出错了：' + result.msg
                });
            }

        }
    });
}
// “删除”
function del() {
    var rows = $('#tablelist').datagrid('getSelections');
    if (rows.length > 0) {
        var ids = [];
        for (var i = 0; i < rows.length; i++) {
            ids.push(rows[i].id);
        }
        $.messager.confirm('确认', '您确定删除这' + ids.length + '条记录吗？', function (r) {
            if (r) {
                $.post('DeleteUsers', { ids: ids.join(',') }, function (result) {
                    if (1 == result.result) {
                        $.messager.show({	// show error message
                            title: '提示信息',
                            msg: '删除成功',
                            timeout: 2000
                        });
                        doSearch();
                    } else {
                        $.messager.show({	// show error message
                            title: '提示信息',
                            msg: '出错了:' + result.msg
                        });
                    }
                }, 'json');
            }
        });
    } else {
        $.messager.alert("提示信息", "请至少选择一条记录");
    }
}

// 角色配置
function roleConfig() {
    var row = $('#tablelist').datagrid('getSelected');
    if (row) {
        $('#roleConfigWin').dialog('open');
        $('#roleConfigTree').tree({
            url: 'GetUserRoles?userId=' + row.id,
            method: 'GET',
            checkbox: true
        });
    } else {
        $.messager.alert("提示信息", "请至少选择一条记录");
    }
}
// 保存“角色配置”
function saveRoleConfig() {
    //id：绑定节点的标识值。
    //text：显示的节点文本。
    //iconCls：显示的节点图标CSS类ID。
    //checked：该节点是否被选中。
    //state：节点状态，'open' 或 'closed'。
    //attributes：绑定该节点的自定义属性。
    //target：目标DOM对象。
    var row = $('#tablelist').datagrid('getSelected');
    var user_id = row.id;// 获取选中记录的用户id
    //alert('userId = ' + userId);
    var nodes_array = $('#roleConfigTree').tree('getChecked');// get checked nodes
    var ids_array = [];
    var ids = "";
    for (var i = 0; i < nodes_array.length; i++) {
        ids_array.push(nodes_array[i].id);
    }
    //ids = ids_array.join(',');// 用逗号拼接角色id
    // alert('ids = ' + ids);
    $.post('SaveRoleConfig', { userId: user_id, ids: ids_array.join(',') }, function (result) {
        if (1 == result.result) {
            $.messager.show({
                title: '提示信息',
                msg: result.msg,
                timeout: 2000
            });
            doSearch();
        } else {
            $.messager.show({
                title: '提示信息',
                msg: result.msg
            });
        }
    }, 'json');
}
// 查看权限
function authConfig() {
    var row = $('#tablelist').datagrid('getSelected');
    if (row) {
        $('#authConfigWin').dialog('open');
        $('#authLoginName').html(row.loginName);
        $('#tt').tree({
            url: 'GetUserAuth?userId=' + row.id,
            method: 'GET',
            checkbox: true
        });
    } else {
        $.messager.alert("提示信息", "请至少选择一条记录");
    }
}

