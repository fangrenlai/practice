$(document).ready(function () {
    //loadGrid();// js方式
});
function formatterDate(date) {
    var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();
    var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"
    + (date.getMonth() + 1);
    return date.getFullYear() + '-' + month + '-' + day;
}
// “清空”查询条件
function doClear() {
    $('#query_name').val('');
}
// “查询”
function doSearch() {
    //alert("查询");
    $('#tablelist').datagrid('reload', {
        query_name: $('#query_name').val().trim()
    });
}
// “新增”
function add() {
    $('#addWin').dialog('open');
    $('#addfm').form('clear');
    //$('#published_at').datebox('setValue', formatterDate(new Date()));
}
// “保存”
function save() {
    $('#addfm').form('submit', {
        url: 'AddRole',
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.result == 1) {
                $.messager.show({
                    title: '提示信息',
                    msg: result.msg,
                    timeout: 2000
                });
                $('#addWin').dialog('close');		// close the dialog
                doSearch();
            } else {
                $.messager.show({
                    title: '提示信息',
                    msg: result.msg
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
        url: 'UpdateRole',
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.result == 1) {
                $.messager.show({
                    title: '提示信息',
                    msg: result.msg,
                    timeout: 2000
                });
                $('#editWin').dialog('close');		// close the dialog
                doSearch();
            } else {
                $.messager.show({
                    title: '提示信息',
                    msg: result.msg
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
                $.post('DeleteRoles', { ids: ids.join(',') }, function (result) {
                    if (1 == result.result) {
                        $.messager.show({	// show error message
                            title: '提示信息',
                            msg: result.msg,
                            timeout: 2000
                        });
                        doSearch();
                    } else {
                        $.messager.show({	// show error message
                            title: '提示信息',
                            msg: result.msg
                        });
                    }
                }, 'json');
            }
        });
    } else {
        $.messager.alert("提示信息", "请至少选择一条记录");
    }
}


