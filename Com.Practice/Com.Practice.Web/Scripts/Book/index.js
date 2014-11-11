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
    $('#id').val('');
    $('#name').val('');
    $('#version').val('');
    $('#published_at_start').datebox('setValue', '');
    $('#published_at_end').datebox('setValue', '');
}
// “查询”
function doSearch() {
    $('#tablelist').datagrid('load', {
        id: $('#id').val().trim(),
        name: $('#name').val().trim(),
        version: $('#version').val().trim(),
        published_at_start: $('#published_at_start').datebox('getValue').trim(),
        published_at_end: $('#published_at_end').datebox('getValue').trim()
    });
}
// “新增”
function add() {
    $('#addWin').dialog('open');
    $('#addfm').form('clear');
    $('#published_at').datebox('setValue', formatterDate(new Date()));
}
// “保存”
function save() {
    $('#addfm').form('submit', {
        url: 'SaveBook',
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
                //$('#tablelist').datagrid('reload');	// reload the data
                $('#tablelist').datagrid('reload', {
                    id: $('#id').val().trim(),
                    name: $('#name').val().trim(),
                    version: $('#version').val().trim(),
                    published_at_start: $('#published_at_start').datebox('getValue').trim(),
                    published_at_end: $('#published_at_end').datebox('getValue').trim()
                });
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
        url: 'EditBook',
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
                //$('#tablelist').datagrid('reload');	// reload the  data
                $('#tablelist').datagrid('reload', {
                    id: $('#id').val().trim(),
                    name: $('#name').val().trim(),
                    version: $('#version').val().trim(),
                    published_at_start: $('#published_at_start').datebox('getValue').trim(),
                    published_at_end: $('#published_at_end').datebox('getValue').trim()
                });
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
                $.post('DeleteBooks', { ids: ids.join(',') }, function (result) {
                    if (1 == result.result) {
                        $.messager.show({	// show error message
                            title: '提示信息',
                            msg: '删除成功',
                            timeout: 2000
                        });
                        //$('#tablelist').datagrid('reload');	// reload the data
                        $('#tablelist').datagrid('reload', {
                            id: $('#id').val().trim(),
                            name: $('#name').val().trim(),
                            version: $('#version').val().trim(),
                            published_at_start: $('#published_at_start').datebox('getValue').trim(),
                            published_at_end: $('#published_at_end').datebox('getValue').trim()
                        });
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

// js方式布局、获取datagrid里面的数据
//function loadGrid() {
//    $('#tablelist').datagrid({
//        title: '书籍列表信息',
//        toolbar: [{
//            text:'添加',
//            iconCls: 'icon-add',
//            handler: function () { alert('添加') }
//        }, '-', {
//            text: '删除',
//            iconCls: 'icon-remove',
//            handler: function () { alert('删除') }
//        }, '-', {
//            text: '修改',
//            iconCls: 'icon-edit',
//            handler: function () { alert('修改') }
//        },'-'],
//        height: 498,
//        striped: true,// 是否显示斑马线效果。
//        pagination: true,//如果为true，则在DataGrid控件底部显示分页工具栏。
//        fitColumns: true,//真正的自动展开/收缩列的大小，以适应网格的宽度，防止水平滚动。
//        pageList: [10],//每页的个数 
//        nowrap: true,//如果为true，则在同一行中显示数据。设置为true可以提高加载性能。
//        idField: 'id',//指明哪一个字段是标识字段。
//        loadMsg: '数据加载中,请稍后……',//在从远程站点加载数据的时候显示提示消息。
//        url: 'GetBooksByPage',
//        rownumbers: true,//如果为true，则显示一个行号列。
//        columns: [[//DataGrid列配置对象
//	        { field: 'id', title: '书号', width: 100 },
//	        { field: 'name', title: '书名', width: 100 },
//	        { field: 'version', title: '版本', width: 100 },
//	        { field: 'published_at', title: '出版时间', width: 100 },
//	        { field: 'created_by', title: '创建人', width: 100 },
//	        { field: 'created_at', title: '创建时间', width: 100 },
//	        { field: 'updated_by', title: '更新人', width: 100 },
//	        { field: 'updated_at', title: '最后更新时间', width: 100 }
//        ]],
//        singleSelect: false, //如果为true，则只允许选择一行。
//        selectOnCheck: true,//如果为true，单击复选框将永远选择行。如果为false，选择行将不选中复选框。
//        checkOnSelect: true,//如果为true，当用户点击行的时候该复选框就会被选中或取消选中。如果为false，当用户仅在点击该复选框的时候才会呗选中或取消。
//        pagePosition: 'both'//定义分页工具栏的位置。可用的值有：'top','bottom','both'。
//    });
//}

