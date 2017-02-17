//显示进度提示条
function showLoading() {
    try {
        var win = $.messager.progress({
            title: '请您稍侯',
            msg: '正在提交数据...',
            style: {
                right: '',
                top: document.body.scrollTop + document.documentElement.scrollTop,
                bottom: ''
            }
        });
        setTimeout(function () {
            $.messager.progress('close');
        }, 10000);
    } catch (e) { }
}
//在顶部提示
function showTopMsg(title, msg) {
    try {
        $.messager.show({
            title: title,
            msg: msg,
            height: '100',
            showType: 'show',
            timeout: 2000,
            style: {
                right: '',
                top: document.body.scrollTop + document.documentElement.scrollTop,
                bottom: ''
            }
        });
    } catch (e) { }
}
