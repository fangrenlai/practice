$(document).ready(function () {
    //$('.linkedMenu').click(function () {
    //    var addr = $(this).val();
    //    //alert("addr = " + addr);
    //    window.parent.frames["mainFrame"].src = addr;
    //});
    //
    $('#menu_tree').tree({
        method: 'GET',
        url: '/Menu/GetMenuTree',
        onClick: function (node) {
            window.parent.frames["mainFrame"].src = node.attributes.url;
        }

    });

});