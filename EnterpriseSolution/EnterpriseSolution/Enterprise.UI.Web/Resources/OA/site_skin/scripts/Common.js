//上传窗口弹出
function openwin(url) {
    //alert("aaa");
    $('#upwin').window('open');
    $('#upwin').html("<iframe Scrolling=\"yes\" Frameborder=\"0\" Src=\"" + url + "\" Style=\"width:98%;height:97%;\"></iframe>");
}

function DoNothing(arrmsg) {

}

function openwin(winid, url) {
    //alert("bbb");
    $('#' + winid).window('center');
    $('#' + winid).window('open');
    $('#' + winid).html("<iframe Scrolling=\"yes\" Frameborder=\"0\" Src=\"" + url + "\" Style=\"width:98%;height:97%;\"></iframe>");
}

function openwin(winid, url, ww, hh) {
    //alert("ccc" + event.x + "==" +event.y);
    var e = event ? event : window.event;    
    $('#' + winid).window({
        left: e.x+10,
        top: e.y+10,
        zindex: 10000,
        draggable: true,
        width: ww,
        height: hh,
        modal: false
    });
    //$('#' + winid).window('center');
    $('#' + winid).window('open');
    //window.showModalDialog(url, "", "dialogWidth=" + ww + "px;dialogHeight=" + hh + "px");
    $('#' + winid).html("<iframe Scrolling=\"yes\" Frameborder=\"0\" Src=\"" + url + "\" Style=\"width:98%;height:97%;\"></iframe>");
}

//project-table 隔行换色
$(document).ready(function () {
    $(".project-table tr").mouseover(function () {
        //如果鼠标移到class为stripe的表格的tr上时，执行函数  
        $(this).addClass("over");
    }).mouseout(function () {
        //给这行添加class值为over，并且当鼠标一出该行时执行函数  
        $(this).removeClass("over");
    }) //移除该行的class  
    $(".project-table tr:even").addClass("alt");
    //给class为stripe的表格的偶数行添加class值为alt
});

//在Iframe中调用父窗口的Tree重新加载数据
function ReloadProjectRunningTree() {
    parent.$('#ProjectRunningTree').tree('reload');
}
function showLoading() {
    var win = $.messager.progress({
        title: '请您稍侯',
        msg: '正在加载数据...'
    });
    setTimeout(function () {
        $.messager.progress('close');
    }, 30000)
    return true;
}

