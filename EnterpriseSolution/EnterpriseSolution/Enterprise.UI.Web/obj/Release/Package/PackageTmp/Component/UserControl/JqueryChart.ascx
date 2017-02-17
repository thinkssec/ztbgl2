<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JqueryChart.ascx.cs" Inherits="Enterprise.UI.Web.Component.UserControl.JqueryChart" %>

<script type="text/javascript"> 
    String.prototype.replaceAll  = function(s1,s2){  
        return this.replace(new RegExp(s1,"gm"),s2);   //这里的gm是固定的，g可能表示global，m可能表示multiple。 
    }
    function LoadChart(chartid,tableid,rowIndex,dataStartColumnIndex,dataEndColumnIndex,title) {
        //var datat = [['a',1],['b',2],['c',3],['d',4]];
        $('#'+chartid).empty();
        var data = new Array();
        for (var i = dataStartColumnIndex; i <= dataEndColumnIndex; i++) {
            var p = new Array();
            var txt = $('#' + tableid + ' thead tr:eq(0) th:eq('+i+')').text();
            var strVal = $('#' + tableid + ' tbody tr:eq('+rowIndex+') td:eq('+i+')').text();
            strVal = strVal.replaceAll(",","");
            var val = Number(strVal); 
            data.push([txt, val]);
        }
        var plot1 = $.jqplot(chartid, [data], {
            title:title,
            seriesDefaults: {
                renderer: $.jqplot.<%=ChartType.ToString()%>,
                rendererOptions: {
                    showDataLabels: true
                }
            },
            legend: { show: false },
            highlighter: {
                show: true,
                sizeAdjust: 10,
                tooltipLocation: 'n',
                tooltipAxes: 'pieref',
                tooltipAxisX: 60,
                tooltipAxisY: 90,
                useAxesFormatters: false,
                formatString: '%s, %P'
            }
        });
    }
</script>
