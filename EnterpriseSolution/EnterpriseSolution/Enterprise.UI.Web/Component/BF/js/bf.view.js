/*
* 文件名：bf.core.js
* 文件描述：业务流设计器核心脚本
* 说明：BUG-001:修复点击水平与垂直滚动条时,就会同时出现选择层的情形;
*/
var isSELECT = false; //选择工具启用标志
var com = {};
com.xjwgraph = {};
var PathGlobal = com.xjwgraph.PathGlobal = {
    pointTypeLeftUp: 1,
    pointTypeUp: 2,
    pointTypeUpRight: 3,
    pointTypeLeft: 4,
    pointTypeRight: 5,
    pointTypeLeftDown: 6,
    pointTypeDown: 7,
    pointTypeDownRight: 8,
    lineDefIndex: 10,
    lineDefStep: 2,
    modeDefIndex: 10,
    modeDefStep: 2,
    modeInc: 3,
    pauseTime: 10,
    modeHeigh: 0,
    copyModeDec: 10,
    rightMenu: false,
    isPixel: true,
    isAutoLineType: false,
    maxEvent: 17,
    minHeight: 32,
    minWidth: 32,
    selectColor: "C5E7F6",
    clearBoderColor: "blue",
    defaultColor: "green",
    defaultMaxMag: 0.5,
    defaultMinMag: 2,
    lineColor: "black",
    lineCheckColor: "red",
    strokeweight: 1.8,
    dragPointDec: 3,
    switchType: false,
    newGraph: "\u65b0\u5efa\u56fe\u5c42",
    modeCreate: "\u521b\u5efa\u6a21\u5143",
    lineCreate: "\u521b\u5efa\u7ebf\u5143",
    modeMove: "\u79fb\u52a8\u6a21\u5143",
    lineMove: "\u79fb\u52a8\u7ebf\u5143",
    modeDragPoint: "\u7f29\u653e\u6a21\u5143",
    updateMode: "\u7f16\u8f91\u6a21\u5143",
    updateLine: "\u7f16\u8f91\u7ebf\u5143",
    copyMode: "\u62f7\u8d1d\u6a21\u5143",
    removeMode: "\u5220\u9664\u6a21\u5143",
    remodeLine: "\u5220\u9664\u7ebf\u5143",
    baseClear: "\u9009\u62e9\u6a21\u5143",
    toMerge: "\u7ec4\u5408\u6a21\u5143",
    toSeparate: "\u89e3\u7ec4\u6a21\u5143",
    clearContext: "\u6e05\u9664\u533a\u57df",
    contextDivDrag: "\u79fb\u52a8\u533a\u57df",
    toLeft: "\u5de6\u5bf9\u9f50",
    toRight: "\u53f3\u5bf9\u9f50",
    toMiddleWidth: "\u5782\u76f4\u5c45\u4e2d",
    toTop: "\u9876\u5bf9\u9f50",
    toMiddleHeight: "\u6c34\u5e73\u5c45\u4e2d",
    toBottom: "\u5e95\u5bf9\u9f50",
    buildLineAndMode: "\u7ed1\u5b9a\u7ebf\u5143",
    removeLineAndMode: "\u79fb\u9664\u7ed1\u5b9a",
    modeCutter: "\u526a\u5207\u6a21\u5143",
    modeDuplicate: "\u590d\u5236\u6a21\u578b",
    eventName: "\u89e6\u53d1\u4e8b\u4ef6",
    lineProTitle: "\u7ebf\u5c5e\u6027\u8bbe\u7f6e",
    modeProTitle: "\u7f16\u8f91\u6a21\u5143",
    editProp: "\u7f16\u8f91\u5c5e\u6027",
    toSelect: "\u9009\u62e9\u5bf9\u8c61"
};
var UndoRedoEventFactory = com.xjwgraph.UndoRedoEventFactory = function (b) {
    var a = this;
    a.hisMessageDiv = b;
    a.stack = [];
    a.index = 0;
    a.redo = function () {
        stopEvent = true;
        var d = a.stack[a.index];
        if (d) {
            d.redo();
            this.index++
        }
        var c = a.stack.length;
        if (this.index > c) {
            this.index = c
        }
        a.history()
    };
    a.undo = function () {
        stopEvent = true;
        var c = a.stack[a.index - 1];
        if (c) {
            c.undo();
            a.index--
        }
        if (this.index < 1) {
            a.index = 1
        }
        a.history()
    };
    a.addEvent = function (c) {
        a.stack.splice(a.index, (a.stack.length - a.index++), c);
        if (a.stack.length > PathGlobal.maxEvent) {
            a.stack.splice(0, 1);
            this.index = PathGlobal.maxEvent
        }
        a.history()
    }
};
UndoRedoEventFactory.prototype = {
    init: function () {
        var a = new com.xjwgraph.UndoRedoEvent(function () { },
        PathGlobal.newGraph);
        a.setRedo(function () { })
    },
    onHistory: function (c, b) {
        var a = this;
        c.onclick = function () {
            var f = com.xjwgraph.Global;
            f.lineTool.clear();
            f.modeTool.clear();
            stopEvent = true;
            if (b > a.index) {
                for (var d = a.index; d <= b - 1; d++) {
                    var e = a.stack[d];
                    if (e && e.redo) {
                        e.redo()
                    }
                }
            } else {
                if (b < a.index) {
                    for (var d = a.index; d >= b; d--) {
                        var e = a.stack[d];
                        if (e && e.undo) {
                            e.undo()
                        }
                    }
                }
            }
            a.index = b;
            a.history()
        }
    },
    history: function () {
        var f = $id(this.hisMessageDiv);
        if (!f) {
            return
        }
        var a = this;
        f.innerHTML = "";
        var h = a.stack.length,
        e = document,
        c = e.createDocumentFragment();
        for (var b = 0; b < h; b++) {
            var g = e.createElement("div");
            g.style.cssText = "position:relative;text-align:center;border-bottom:1px dotted #cccccc; width:100px;height:20px;line-height:20px;";
            g.innerHTML = a.stack[b].name;
            var d = b + 1;
            a.onHistory(g, d);
            if ((a.index) == d) {
                g.style.backgroundColor = PathGlobal.selectColor
            }
            c.appendChild(g)
        }
        f.appendChild(c)
    },
    clear: function () {
        var a = this;
        delete a.stack;
        a.stack = [];
        a.index = 0;
        a.history()
    }
};
var UndoRedoEvent = com.xjwgraph.UndoRedoEvent = function (c, b) {
    var a = this;
    a.name = b ? b : PathGlobal.eventName;
    a.undo = c;
    a.redo;
    com.xjwgraph.Global.undoRedoEventFactory.addEvent(a);
    a.setUndo = function (d) {
        a.undo = d
    };
    a.setRedo = function (d) {
        a.redo = d
    }
};
var BaseTool = com.xjwgraph.BaseTool = function (c, d, a) {
    var b = this;
    b.pathBody = c;
    b.checkColor = "#00ff00";
    b.areaDiv = document.createElement("div");
    b.initEndDiv(d, a);
    b.initPathBody(b.pathBody);
    b.contextMoveAbale = false;
    b.contextMoveAttempt = false;
    b.contextMap = new Map();
    b.tempContextId = null;
    b.checkBrowser()
};
BaseTool.prototype = {
    initScaling: function (a) {
        var b = this,
        d = com.xjwgraph.Global,
        c = d.smallTool,
        e = d.lineTool;
        b.forEach(b.contextMap,
        function (h) {
            var j = $id(h),
            m = j.style;
            m.top = 0 + "px";
            m.left = 0 + "px";
            var l = 0,
            g = 0,
            i = b.contextMap.get(h),
            k = i.contextModeMap,
            f = i.contextLineMap;
            b.forEach(f,
            function (n) {
                var o = $id(n),
                s = e.getPath(o),
                t = e.getPathArray(s),
                r = t.length;
                for (var q = r; q--; ) {
                    var p = (q % 2 == 1);
                    if (p && (parseInt(m.top) > t[q] || parseInt(m.top) == 0)) {
                        m.top = t[q] - 2 + "px"
                    }
                    if (!p && (parseInt(m.left) > t[q] || parseInt(m.left) == 0)) {
                        m.left = t[q] - 2 + "px"
                    }
                    if (p && (parseInt(g) < parseInt(t[q]))) {
                        g = t[q]
                    }
                    if (!p && (parseInt(l) < parseInt(t[q]))) {
                        l = t[q]
                    }
                }
            });
            b.forEach(k,
            function (u) {
                var s = $id(u),
                p = s.style,
                v = parseInt(p.top),
                o = parseInt(p.left),
                r = parseInt(s.offsetWidth),
                t = parseInt(s.offsetHeight),
                n = parseInt(m.top),
                q = parseInt(m.left);
                if (n > v || n == 0) {
                    m.top = v + "px"
                }
                if (q > o || q == 0) {
                    m.left = o + "px"
                }
                if (l < r + o) {
                    l = r + o
                }
                if (g < t + v) {
                    g = t + v
                }
            });
            m.width = l - parseInt(m.left) + "px";
            m.height = g - parseInt(m.top) + "px"
        })
    },
    getOptionMap: function (b) {
        var a = this,
        e = null;
        if (b) {
            e = a.contextMap.get(b).contextModeMap
        } else {
            var c = com.xjwgraph.Global;
            e = new Map();
            e.putAll(c.modeMap);
            var d = c.baseTool;
            d.forEach(d.contextMap,
            function (f) {
                var h = d.contextMap.get(f).contextModeMap,
                g = $id(f),
                i = g.getAttribute("groups");
                d.forEach(h,
                function (j) {
                    if (i == "true" || i) {
                        e.remove(j)
                    }
                })
            })
        }
        return e
    },
    toLeft: function () {
        var i = this,
        b = i.getOptionMap(i.tempContextId),
        d = -1;
        i.forEach(b,
        function (l) {
            var k = $id(l),
            j = parseInt(k.style.left);
            if (d > j || d == -1) {
                d = j
            }
        });
        var c = com.xjwgraph.Global,
        g = c.modeTool,
        h = c.smallTool,
        f = new Map(),
        e = new Map();
        i.forEach(b,
        function (l) {
            var k = $id(l),
            j = k.style;
            f.put(l, parseInt(j.left));
            j.left = d + "px";
            e.put(l, parseInt(j.left));
            g.showPointer(k);
            g.changeBaseModeAndLine(k, true);
            h.drawMode(k)
        });
        var a = new com.xjwgraph.UndoRedoEvent(function () {
            i.forEach(b,
            function (k) {
                var j = $id(k);
                j.style.left = f.get(k) + "px";
                g.showPointer(j);
                g.changeBaseModeAndLine(j, true);
                h.drawMode(j)
            })
        },
        PathGlobal.toLeft);
        a.setRedo(function () {
            i.forEach(b,
            function (k) {
                var j = $id(k);
                j.style.left = e.get(k) + "px";
                g.showPointer(j);
                g.changeBaseModeAndLine(j, true);
                h.drawMode(j)
            })
        })
    },
    toMiddleWidth: function () {
        var m = this,
        b = m.getOptionMap(m.tempContextId),
        l = [],
        g = 0;
        m.forEach(b,
        function (n) {
            var i = $id(n);
            l[g++] = parseInt(i.style.left) + parseInt(parseInt(i.offsetWidth) / 2)
        });
        l = l.sort(function (n, i) {
            return n - i
        });
        var d = parseInt(l.length / 2),
        f = l[d],
        c = com.xjwgraph.Global,
        j = c.modeTool,
        k = c.smallTool,
        h = new Map(),
        e = new Map();
        m.forEach(b,
        function (p) {
            var o = $id(p),
            n = o.style;
            h.put(p, parseInt(n.left));
            var i = parseInt(parseInt(n.left) + parseInt(parseInt(o.offsetWidth) / 2) - f);
            n.left = parseInt(parseInt(n.left) - i) + "px";
            e.put(p, parseInt(n.left));
            j.showPointer(o);
            j.changeBaseModeAndLine(o, true);
            k.drawMode(o)
        });
        var a = new com.xjwgraph.UndoRedoEvent(function () {
            m.forEach(b,
            function (n) {
                var i = $id(n);
                i.style.left = h.get(n) + "px";
                j.showPointer(i);
                j.changeBaseModeAndLine(i, true);
                k.drawMode(i)
            })
        },
        PathGlobal.toMiddleWidth);
        a.setRedo(function () {
            m.forEach(b,
            function (n) {
                var i = $id(n);
                i.style.left = e.get(n) + "px";
                j.showPointer(i);
                j.changeBaseModeAndLine(i, true);
                k.drawMode(i)
            })
        })
    },
    toRight: function () {
        var i = this,
        b = i.getOptionMap(i.tempContextId),
        h = -1;
        i.forEach(b,
        function (l) {
            var k = $id(l),
            j = parseInt(k.style.left) + parseInt(k.offsetWidth);
            if (h < j) {
                h = j
            }
        });
        var c = com.xjwgraph.Global,
        f = c.modeTool,
        g = c.smallTool,
        e = new Map(),
        d = new Map();
        i.forEach(b,
        function (m) {
            var l = $id(m),
            k = l.style;
            e.put(m, parseInt(k.left));
            var j = parseInt(k.left) + parseInt(l.offsetWidth);
            k.left = (h - j) + parseInt(k.left) + "px";
            d.put(m, parseInt(k.left));
            f.showPointer(l);
            f.changeBaseModeAndLine(l, true);
            g.drawMode(l)
        });
        var a = new com.xjwgraph.UndoRedoEvent(function () {
            i.forEach(b,
            function (k) {
                var j = $id(k);
                j.style.left = e.get(k) + "px";
                f.showPointer(j);
                f.changeBaseModeAndLine(j, true);
                g.drawMode(j)
            })
        },
        PathGlobal.toRight);
        a.setRedo(function () {
            i.forEach(b,
            function (k) {
                var j = $id(k);
                j.style.left = d.get(k) + "px";
                f.showPointer(j);
                f.changeBaseModeAndLine(j, true);
                g.drawMode(j)
            })
        })
    },
    toSelect: function () {
    },
    toTop: function () {
        var i = this,
        b = i.getOptionMap(i.tempContextId),
        f = -1;
        i.forEach(b,
        function (l) {
            var k = $id(l),
            j = parseInt(k.style.top);
            if (f > j || f == -1) {
                f = j
            }
        });
        var c = com.xjwgraph.Global,
        e = c.modeTool,
        g = c.smallTool,
        h = new Map(),
        d = new Map();
        i.forEach(b,
        function (l) {
            var k = $id(l),
            j = k.style;
            h.put(l, parseInt(j.top));
            j.top = f + "px";
            d.put(l, parseInt(j.top));
            e.showPointer(k);
            e.changeBaseModeAndLine(k, true);
            g.drawMode(k)
        });
        var a = new com.xjwgraph.UndoRedoEvent(function () {
            i.forEach(b,
            function (k) {
                var j = $id(k);
                j.style.top = h.get(k) + "px";
                e.showPointer(j);
                e.changeBaseModeAndLine(j, true);
                g.drawMode(j)
            })
        },
        PathGlobal.toTop);
        a.setRedo(function () {
            i.forEach(b,
            function (k) {
                var j = $id(k);
                j.style.top = d.get(k) + "px";
                e.showPointer(j);
                e.changeBaseModeAndLine(j, true);
                g.drawMode(j)
            })
        })
    },
    toMiddleHeight: function () {
        var m = this,
        b = m.getOptionMap(m.tempContextId),
        e = [],
        g = 0;
        this.forEach(b,
        function (n) {
            var i = $id(n);
            e[g++] = parseInt(i.style.top) + parseInt(parseInt(i.offsetHeight) / 2)
        });
        e = e.sort(function (n, i) {
            return n - i
        });
        var d = parseInt(e.length / 2),
        f = e[d],
        c = com.xjwgraph.Global,
        j = c.modeTool,
        k = c.smallTool,
        l = new Map(),
        h = new Map();
        m.forEach(b,
        function (p) {
            var o = $id(p),
            i = o.style,
            n = parseInt(parseInt(i.top) + parseInt(parseInt(o.offsetHeight) / 2) - f);
            l.put(p, parseInt(i.top));
            i.top = parseInt(parseInt(i.top) - n) + "px";
            h.put(p, parseInt(i.top));
            j.showPointer(o);
            j.changeBaseModeAndLine(o, true);
            k.drawMode(o)
        });
        var a = new com.xjwgraph.UndoRedoEvent(function () {
            m.forEach(b,
            function (n) {
                var i = $id(n);
                i.style.top = l.get(n) + "px";
                j.showPointer(i);
                j.changeBaseModeAndLine(i, true);
                k.drawMode(i)
            })
        },
        PathGlobal.toMiddleHeight);
        a.setRedo(function () {
            m.forEach(b,
            function (n) {
                var i = $id(n);
                i.style.top = h.get(n) + "px";
                j.showPointer(i);
                j.changeBaseModeAndLine(i, true);
                k.drawMode(i)
            })
        })
    },
    toBottom: function () {
        var i = this,
        c = i.getOptionMap(i.tempContextId),
        a = -1;
        i.forEach(c,
        function (l) {
            var k = $id(l),
            j = parseInt(k.style.top) + parseInt(k.offsetHeight);
            if (a < j) {
                a = j
            }
        });
        var d = com.xjwgraph.Global,
        f = d.modeTool,
        g = d.smallTool,
        h = new Map(),
        e = new Map();
        i.forEach(c,
        function (m) {
            var l = $id(m),
            j = l.style,
            k = parseInt(j.top) + parseInt(l.offsetHeight);
            h.put(m, parseInt(j.top));
            j.top = (a - k) + parseInt(j.top) + "px";
            e.put(m, parseInt(j.top));
            f.showPointer(l);
            f.changeBaseModeAndLine(l, true);
            g.drawMode(l)
        });
        var b = new com.xjwgraph.UndoRedoEvent(function () {
            i.forEach(c,
            function (k) {
                var j = $id(k);
                j.style.top = h.get(k) + "px";
                f.showPointer(j);
                f.changeBaseModeAndLine(j, true);
                g.drawMode(j)
            })
        },
        PathGlobal.toBottom);
        b.setRedo(function () {
            i.forEach(c,
            function (k) {
                var j = $id(k);
                j.style.top = e.get(k) + "px";
                f.showPointer(j);
                f.changeBaseModeAndLine(j, true);
                g.drawMode(j)
            })
        })
    },
    sumLeftTop: function (a, b, c) {
        if (!b) {
            b = a.offsetLeft
        }
        if (!c) {
            c = a.offsetTop
        }
        var d = a.offsetParent;
        if (d) {
            b += d.offsetLeft;
            c += d.offsetTop;
            return this.sumLeftTop(d, b, c)
        } else {
            return [b, c]
        }
    },
    changStyle: function (a) {
        PathGlobal.isPixel = !PathGlobal.isPixel;
        a.innerHTML = PathGlobal.isPixel ? "Pixel" : "Grid"
    },
    showMenu: function (b, i) {
        //Cancel:主体上不再显示右键菜单
        return;

        this.tempContextId = i;
        b = b || window.event;
        if (!b.pageX) {
            b.pageX = b.clientX
        }
        if (!b.pageY) {
            b.pageY = b.clientY
        }
        var h = b.pageX,
        f = b.pageY,
        d = com.xjwgraph.Global,
        c = d.lineTool.pathBody,
        j = d.baseTool.sumLeftTop(c);
        h = h - parseInt(j[0]) + parseInt(c.scrollLeft);
        f = f - parseInt(j[1]) + parseInt(c.scrollTop);
        var a = $id("isPixel"),
        e = a.style;
        if (i) {
            e.visibility = "hidden"
        } else {
            e.visibility = "visible"
        }
        var g = $id("pathBodyRightMenu");
        pathBodyRightMenuStyle = g.style;
        pathBodyRightMenuStyle.top = f + "px";
        pathBodyRightMenuStyle.left = h + "px";
        pathBodyRightMenuStyle.visibility = "visible";
        pathBodyRightMenuStyle.zIndex = com.xjwgraph.Global.modeTool.getNextIndex()
    },
    toSeparate: function () {
        var b = this,
        a = [],
        c = 0;
        b.forEach(b.contextMap,
        function (f) {
            var g = $id(f);
            if (g.style.borderColor == PathGlobal.defaultColor) {
                a[c++] = g;
                g.setAttribute("groups", false)
            }
        });
        var e = com.xjwgraph.Global;
        var d = new com.xjwgraph.UndoRedoEvent(function () {
            var h = a.length,
            g = e.baseTool;
            for (var f = h; f--; ) {
                var j = a[f];
                j.setAttribute("groups", true)
            }
        },
        PathGlobal.toSeparate);
        d.setRedo(function () {
            var h = a.length,
            g = e.baseTool;
            for (var f = h; f--; ) {
                var j = a[f];
                j.setAttribute("groups", true)
            }
        });
        b.clearContext()
    },
    checkBrowser: function () {
        var b = navigator.userAgent.toLowerCase();
        check = function (c) {
            return c.test(b)
        };
        var a = this;
        a.isOpera = check(/opera/);
        a.isIE = !a.isOpera && check(/msie/);
        a.isIE7 = a.isIE && check(/msie 7/);
        a.isIE8 = a.isIE && check(/msie 8/);
        a.isIE6 = a.isIE && !a.isIE7 && !a.isIE8;
        a.isChrome = check(/chrome/);
        a.isWebKit = check(/webkit/);
        a.isSafari = !a.isChrome && check(/safari/);
        a.isSafari2 = a.isSafari && check(/applewebkit\/4/);
        a.isSafari3 = a.isSafari && check(/version\/3/);
        a.isSafari4 = a.isSafari && check(/version\/4/);
        a.isGecko = !a.isWebKit && check(/gecko/);
        a.isGecko2 = a.isGecko && check(/rv:1\.8/);
        a.isGecko3 = a.isGecko && check(/rv:1\.9/)
    },
    getBrowserName: function () {
        var a = this;
        if (a.isIE) {
            if (a.isIE8) {
                return "IE8"
            } else {
                if (a.isIE7) {
                    return "IE7"
                } else {
                    if (a.isIE6) {
                        return "IE6"
                    } else {
                        return "IE"
                    }
                }
            }
        }
        if (a.isChrome) {
            return "CHROME"
        } else {
            if (a.isWebKit) {
                return "WEBKIT"
            } else {
                if (a.isOpera) {
                    return "OPERA"
                } else {
                    if (a.isGecko) {
                        return "GECKO"
                    } else {
                        if (a.isGecko2) {
                            return "GECKO2"
                        } else {
                            if (a.isGecko3) {
                                return "GECKO3"
                            }
                        }
                    }
                }
            }
        }
        if (a.isSafari) {
            return "SAFARI"
        } else {
            if (a.isSafari2) {
                return "SAFARI2"
            } else {
                if (a.isSafari3) {
                    return "SAFARI3"
                } else {
                    if (a.isSafari4) {
                        return "SAFARI4"
                    }
                }
            }
        }
    },
    printView: function () {
        var b = window.open("view.html", "", "");
        if (this.isChrome || this.isGecko) {
            var c = [],
            a = 0;
            c[a++] = "<html>";
            c[a++] = "<head>";
            c[a++] = '<link href="css/flowPath.css" type="text/css" rel="stylesheet" />';
            c[a++] = '<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />';
            c[a++] = "<title></title>";
            c[a++] = "</head>";
            c[a++] = "<body>";
            c[a++] = document.getElementById("contextBody").innerHTML;
            c[a++] = "</body></html>";
            b.document.write(c.join(""))
        }
        b.document.close()
    },
    toMerge: function () {
        var b = this,
        a = [],
        c = 0;
        b.forEach(b.contextMap,
        function (f) {
            var g = $id(f);
            if (g.style.borderColor == PathGlobal.defaultColor) {
                a[c++] = g;
                g.setAttribute("groups", true);
                g.oncontextmenu = function () {
                    return false
                }
            }
        });
        var e = com.xjwgraph.Global;
        var d = new com.xjwgraph.UndoRedoEvent(function () {
            var h = a.length,
            g = e.baseTool;
            for (var f = h; f--; ) {
                var j = a[f];
                j.setAttribute("groups", false);
                j.oncontextmenu = function (i) {
                    PathGlobal.rightMenu = true;
                    g.showMenu(i, this.id);
                    return false
                }
            }
        },
        PathGlobal.toMerge);
        d.setRedo(function () {
            var h = a.length,
            g = e.baseTool;
            for (var f = h; f--; ) {
                var j = a[f];
                j.setAttribute("groups", true);
                j.oncontextmenu = function (i) {
                    return false
                }
            }
        })
    },
    forEach: function (e, c) {
        var d = e.getKeys(),
        a = d.length;
        for (var b = a; b--; ) {
            if (c) {
                c(d[b])
            }
        }
    },
    removeAll: function () {
        var a = this,
        b = com.xjwgraph.Global.baseTool;
        a.forEach(a.contextMap,
        function (c) {
            var d = $id(c);
            b.contextMap.remove(c);
            b.pathBody.removeChild(d)
        })
    },
    clearContext: function () {
        var b = this;
        b.tempContextId = null;
        var a = [],
        f = [],
        c = 0,
        e = com.xjwgraph.Global.baseTool;
        b.forEach(b.contextMap,
        function (i) {
            var j = $id(i),
            h = j.style;
            h.borderColor = PathGlobal.clearBoderColor;
            h.filter = "alpha(opacity=10)";
            h.opacity = "0.1";
            var g = j.getAttribute("groups");
            if (g == "false" || !g) {
                a[c] = j;
                f[c++] = e.contextMap.get(i);
                e.contextMap.remove(i);
                e.pathBody.removeChild(j)
            }
        });
        if (a.length > 0) {
            var d = new com.xjwgraph.UndoRedoEvent(function () {
                var h = a.length;
                for (var g = h; g--; ) {
                    var j = a[g];
                    e.contextMap.put(j.id, f[g]);
                    e.pathBody.appendChild(j)
                }
            },
            PathGlobal.clearContext);
            d.setRedo(function () {
                var h = a.length;
                for (var g = h; g--; ) {
                    var j = a[g];
                    if (j && j.id && $id(j.id)) {
                        e.contextMap.remove(j.id);
                        e.pathBody.removeChild(j)
                    }
                }
            })
        }
    },
    clear: function () {
        PathGlobal.rightMenu = false;
        //add by qw 2012.12.18 start
        //var j = $id("pathBodyRightMenu");
        //j.style.visibility = "hidden";
        //var f = $id("isPixel");
        //f.style.visibility = "hidden";
        //end
        var k = this,
        d = k.areaDiv.style,
        i = parseInt(d.top),
        c = parseInt(d.left),
        m = parseInt(d.width),
        l = parseInt(d.height);
        if (d.visibility != "visible") {
            return;
        }
        var r = document.createElement("div"),
        t = r.style;
        t.position = "absolute";
        t.fontSize = "0px";
        t.borderWidth = "1px";
        t.borderStyle = "solid";
        t.borderColor = PathGlobal.defaultColor;
        t.visibility = "visible";
        t.top = 0 + "px";
        t.left = 0 + "px";
        t.width = 0 + "px";
        t.height = 0 + "px";
        t.backgroundColor = PathGlobal.selectColor;
        t.filter = "alpha(opacity=20)";
        t.opacity = "0.2";
        var p = com.xjwgraph.Global,
        h = p.modeTool,
        o = p.lineTool,
        n = h.getNextIndex();
        t.zIndex = n;
        r.setAttribute("id", "contextDiv" + n);
        var b = new Map(),
        a = new Map(),
        u = 0,
        q = 0,
        e = com.xjwgraph.Global.baseTool;
        o.clear();
        o.forEach(function (w) {
            var F = $id(w),
            E = o.getPath(F),
            D = o.getPathArray(E),
            C = D.length,
            B = true,
            A = 0,
            z = 0;
            for (var v = C; v--; ) {
                var y = true;
                if (v % 2 == 1) {
                    A = i;
                    z = i + l
                } else {
                    A = c;
                    z = c + m;
                    y = false
                }
                if (!(D[v] >= A && D[v] <= z)) {
                    B = false;
                    break
                }
                if (y && (parseInt(t.top) > D[v] || parseInt(t.top) == 0)) {
                    t.top = D[v] - 2 + "px"
                }
                if (!y && (parseInt(t.left) > D[v] || parseInt(t.left) == 0)) {
                    t.left = D[v] - 2 + "px"
                }
                if (y && (parseInt(q) < parseInt(D[v]))) {
                    q = D[v]
                }
                if (!y && (parseInt(u) < parseInt(D[v]))) {
                    u = D[v]
                }
            }
            if (B) {
                var x = true;
                e.forEach(e.contextMap,
                function (G) {
                    var H = p.baseTool.contextMap.get(G).contextLineMap,
                    I = $id(G),
                    J = I.getAttribute("groups");
                    e.forEach(H,
                    function (K) {
                        if (K == F.id && (J == "true" || J)) {
                            x = false
                        }
                    })
                });
                stopEvent = true;
                if (x) {
                    o.show(F);
                    a.put(w, F)
                }
            }
        });
        h.forEach(function (C) {
            var z = $id(C),
            x = z.style,
            v = $id(C.replace("module", "backImg")),
            D = v.style,
            E = parseInt(x.top),
            w = parseInt(x.left),
            y = parseInt(D.width),
            B = parseInt(D.height),
            A = true;
            e.forEach(e.contextMap,
            function (F) {
                var H = p.baseTool.contextMap.get(F).contextModeMap,
                G = $id(F),
                I = G.getAttribute("groups");
                e.forEach(H,
                function (J) {
                    if (J == z.id && (I == "true" || I)) {
                        A = false
                    }
                })
            });
            if (A && E > i && w > c && w + y < c + m && E + B < i + l) {
                if (parseInt(t.top) > E || parseInt(t.top) == 0) {
                    t.top = E + "px"
                }
                if (parseInt(t.left) > w || parseInt(t.left) == 0) {
                    t.left = w + "px"
                }
                if (u < y + w) {
                    u = y + w
                }
                if (q < B + E) {
                    q = B + E
                }
                stopEvent = true;
                p.modeTool.showPointer(z);
                b.put(z.id, z)
            } else {
                p.modeTool.hiddPointer(z)
            }
        });
        k.clearContext();
        function g(w, v) {
            this.contextModeMap = w;
            this.contextLineMap = v
        }
        if ((b.size() + a.size()) > 1) {
            k.pathBody.appendChild(r);
            var g = new g(b, a);
            k.contextMap.put(r.id, g);
            k.tempContextId = r.id;
            t.width = (u - parseInt(t.left)) + "px";
            t.height = (q - parseInt(t.top)) + "px";
            var e = p.baseTool;
            var s = new com.xjwgraph.UndoRedoEvent(function () {
                if (r && r.id && $id(r.id)) {
                    e.pathBody.removeChild(r);
                    e.contextMap.remove(r.id)
                }
            },
            PathGlobal.baseClear);
            s.setRedo(function () {
                e.pathBody.appendChild(r);
                e.contextMap.put(r.id, g)
            });
            k.contextDivDrag(r, g)
        }
        d.top = 1 + "px";
        d.left = 1 + "px";
        d.width = 1 + "px";
        d.height = 1 + "px";
        d.visibility = "hidden"
    },
    contextDivDrag: function (d, b) {
        var i = d.style,
        c = com.xjwgraph.Global,
        j = c.smallTool,
        h = c.baseTool,
        e = c.modeTool,
        f = c.lineTool,
        a = b.contextModeMap,
        g = b.contextLineMap;
        d.onclick = function () {
            i.borderColor = PathGlobal.defaultColor;
            i.filter = "alpha(opacity=30)";
            i.opacity = "0.3";
            h.forEach(h.contextMap,
            function (k) {
                if (k != d.id) {
                    var m = $id(k);
                    var l = m.style;
                    l.borderColor = PathGlobal.clearBoderColor;
                    l.filter = "alpha(opacity=10)";
                    l.opacity = "0.1"
                }
            })
        };
        d.oncontextmenu = function (k) {
            PathGlobal.rightMenu = true;
            h.showMenu(k, this.id);
            return false
        };
        d.ondragstart = function () {
            return false
        };
        d.onmousedown = function (m) {
            m = m || window.event;
            c.modeTool.clear();
            c.lineTool.clear(); //qw
            h.contextMoveAbale = true;
            i.borderColor = PathGlobal.defaultColor;
            i.filter = "alpha(opacity=20)";
            i.opacity = "0.2";
            i.visibility = "visible";
            h.forEach(h.contextMap,
            function (q) {
                if (q != d.id) {
                    var s = $id(q),
                    r = s.style;
                    r.borderColor = PathGlobal.clearBoderColor;
                    r.filter = "alpha(opacity=10)";
                    r.opacity = "0.1"
                }
            });
            var l = parseInt(i.top),
            p = parseInt(i.left);
            if (d.setCapture) {
                d.setCapture()
            } else {
                if (window.captureEvents) {
                    window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                }
            }
            var k = m.layerX && m.layerX >= 0 ? m.layerX : m.offsetX,
            o = m.layerY && m.layerX >= 0 ? m.layerY : m.offsetY,
            l = parseInt(i.top),
            p = parseInt(i.left),
            n = document;
            n.onmousemove = function (u) {
                h.contextMoveAttempt = true;
                u = u || window.event;
                if (!u.pageX) {
                    u.pageX = u.clientX
                }
                if (!u.pageY) {
                    u.pageY = u.clientY
                }
                var r = u.pageX - k,
                q = u.pageY - o,
                t = com.xjwgraph.Global,
                s = t.lineTool.pathBody,
                v = t.baseTool.sumLeftTop(s);
                r = r - parseInt(v[0]) + parseInt(s.scrollLeft);
                q = q - parseInt(v[1]) + parseInt(s.scrollTop);
                i.left = r + "px";
                i.top = q + "px"
            };
            n.onmouseup = function (C) {
                C = C || window.event;
                if (!C.pageX) {
                    C.pageX = C.clientX
                }
                if (!C.pageY) {
                    C.pageY = C.clientY
                }
                var N = C.pageX - k,
                L = C.pageY - o,
                A = com.xjwgraph.Global,
                r = A.lineTool.pathBody,
                y = A.baseTool.sumLeftTop(r);
                N = N - parseInt(y[0]) + parseInt(r.scrollLeft);
                L = L - parseInt(y[1]) + parseInt(r.scrollTop);
                if (d.releaseCapture) {
                    d.releaseCapture()
                } else {
                    if (window.releaseEvents) {
                        window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                    }
                }
                n.onmousemove = null;
                n.onmouseup = null;
                if (h.contextMoveAttempt) {
                    var v = a.getKeys(),
                    w = v.length,
                    z = g.getKeys(),
                    J = z.length,
                    F = new Map(),
                    P = new Map();
                    for (var G = J; G--; ) {
                        var O = z[G];
                        line = $id(O),
                        newLineLeft = N - p,
                        newLineTop = L - l,
                        path = f.getPath(line),
                        paths = f.getPathArray(path),
                        pathLength = paths.length,
                        lineMode = A.lineMap.get(line.id),
                        xBaseMode = lineMode.xBaseMode,
                        wBaseMode = lineMode.wBaseMode;
                        F.put(O, path);
                        for (var B = pathLength; B--; ) {
                            if (B % 2 == 1) {
                                paths[B] = parseInt(paths[B]) + parseInt(newLineTop)
                            } else {
                                paths[B] = parseInt(paths[B]) + parseInt(newLineLeft)
                            }
                        }
                        var q = f.arrayToPath(paths);
                        P.put(O, q);
                        f.setPath(line, q);
                        f.setDragPoint(line);
                        if (wBaseMode && $id(wBaseMode.id) && !a.containsKey(wBaseMode.id)) {
                            f.removeAllLineAndMode(line, $id(wBaseMode.id))
                        }
                        if (xBaseMode && $id(xBaseMode.id) && !a.containsKey(xBaseMode.id)) {
                            f.removeAllLineAndMode(line, $id(xBaseMode.id))
                        }
                        j.drawLine(line);
                        f.clearLine(O)
                    }
                    function H(S, R) {
                        var Q = this;
                        Q.modeTop = S;
                        Q.modeLeft = R
                    }
                    var M = new Map(),
                    E = new Map();
                    for (var G = w; G--; ) {
                        var x = $id(v[G]),
                        D = x.style,
                        u = N - p,
                        I = L - l;
                        M.put(x.id, new H(parseInt(D.top), parseInt(D.left)));
                        D.left = parseInt(D.left) + u + "px";
                        D.top = parseInt(D.top) + I + "px";
                        E.put(x.id, new H(parseInt(D.top), parseInt(D.left)));
                        e.changeBaseModeAndLine(x, true);
                        j.drawMode(x)
                    }
                    var K = new com.xjwgraph.UndoRedoEvent(function () {
                        i.top = l + "px";
                        i.left = p + "px";
                        for (var S = w; S--; ) {
                            var U = $id(v[S]),
                            R = U.style,
                            T = M.get(U.id);
                            R.left = T.modeLeft + "px";
                            R.top = T.modeTop + "px";
                            e.showPointer(U);
                            e.changeBaseModeAndLine(U, true);
                            j.drawMode(U)
                        }
                        for (var S = J; S--; ) {
                            var Q = z[S];
                            line = $id(Q),
                            oldLine = F.get(Q);
                            f.setPath(line, oldLine);
                            f.show(line);
                            j.drawLine(line)
                        }
                    },
                    PathGlobal.contextDivDrag);
                    var t = parseInt(i.top),
                    s = parseInt(i.left);
                    K.setRedo(function () {
                        i.top = t + "px";
                        i.left = s + "px";
                        for (var S = w; S--; ) {
                            var U = $id(v[S]),
                            R = U.style,
                            T = E.get(U.id);
                            R.left = T.modeLeft + "px";
                            R.top = T.modeTop + "px";
                            e.showPointer(U);
                            e.changeBaseModeAndLine(U, true);
                            j.drawMode(U)
                        }
                        for (var S = J; S--; ) {
                            var Q = z[S];
                            line = $id(Q),
                            q = P.get(Q);
                            f.setPath(line, q);
                            f.show(line);
                            j.drawLine(line)
                        }
                    })
                }
                h.contextMoveAttempt = false;
                h.contextMoveAbale = false
            }
        }
    },
    initPathBody: function (b) {
        var b = $id(b.id),
        a = this,
        e = a.areaDiv,
        c = e.style;
        c.position = "absolute";
        c.width = 1 + "px";
        c.height = 1 + "px";
        c.fontSize = "0px";
        c.borderWidth = "1px";
        c.borderStyle = "solid";
        c.visibility = "hidden";
        c.backgroundColor = PathGlobal.selectColor;
        c.filter = "alpha(opacity=30)";
        c.opacity = "0.3";
        b.appendChild(e);
        b.ondragstart = function () {
            return false
        };
        var d = com.xjwgraph.Global;
        b.onclick = function () {
            d.baseTool.clear();
        };
        b.ondblclick = function () {
            d.baseTool.clear();
            //add by qw 2012.12.18 start 双击取消选择
            var p = com.xjwgraph.Global;
            p.modeTool.clear();
            p.lineTool.clear();
            isSELECT = false; //取消选择
            //end
        };
        b.onmousedown = function (h) {
            c.borderColor = d.baseTool.checkColor;
            h = h || window.event;
            if (!PathGlobal.rightMenu) {
                d.baseTool.clear()
            }
            var f = h.clientX ? h.clientX : h.offsetX,
            j = h.clientY ? h.clientY : h.offsetY,
            g = d.lineTool.pathBody,
            i = d.baseTool.sumLeftTop(g);
            f = f - parseInt(i[0]) + parseInt(g.scrollLeft);
            j = j - parseInt(i[1]) + parseInt(g.scrollTop);
            c.left = f + "px";
            c.top = j + "px";
            if (d.modeTool.moveable == true || d.lineTool.moveable == true || d.baseTool.contextMoveAbale == true) { } else {
                //REP:BUG-001
                if (isSELECT) {
                    c.visibility = "visible";
                }
            }
            b.onmousemove = function (p) {
                p = p || window.event;
                //d.baseTool.clear();
                var l = p.clientX,
                k = p.clientY,
                n = d.lineTool.pathBody,
                q = d.baseTool.sumLeftTop(n);
                l = l - parseInt(q[0]) + parseInt(n.scrollLeft);
                k = k - parseInt(q[1]) + parseInt(n.scrollTop);
                var o = l - f,
                m = k - j;
                if (e && c.visibility == "visible") {
                    if (l >= f) {
                        c.width = o + "px"
                    }
                    if (k >= j) {
                        c.height = m + "px"
                    }
                    if (k < j) {
                        c.top = k + "px";
                        c.height = Math.abs(m) + "px"
                    }
                    if (l < f) {
                        c.left = l + "px";
                        c.width = Math.abs(o) + "px"
                    }
                }
            };
            b.onmouseup = function (k) {
                if (e && c.visibility == "visible" && !PathGlobal.rightMenu) {
                    d.baseTool.clear()
                }
            }
        }
    },
    findBackImgSrc: function (b) {
        for (var a = b.firstChild; a != null; a = a.nextSibling) {
            if (a.id && a.id.indexOf("backGroundImg") >= 0) {
                return a.src
            }
        }
    },
    drag: function (b, c, a) {
        var b = b,
        c = c,
        d = this.findBackImgSrc(b),
        e = com.xjwgraph.Global;
        b.ondragstart = function () {
            return false
        };
        b.onmousedown = function (i) {
            i = i || window.event;
            var k = $id("moveBaseModeImg");
            k.src = d;
            var h = $id("moveBaseMode"),
            g = h.style;
            g.visibility = "visible";
            if (h.setCapture) {
                h.setCapture()
            } else {
                if (window.captureEvents) {
                    document.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                }
            }
            var f = i.clientX ? i.clientX : i.offsetX,
            l = i.clientY ? i.clientY : i.offsetY;
            g.left = f + "px";
            g.top = l + "px";
            var j = document;
            j.onmousemove = function (o) {
                o = o || window.event;
                var n = o.clientX,
                m = o.clientY;
                g.left = n + "px";
                g.top = m + "px"
            };
            j.onmouseup = function (q) {
                q = q || window.event;
                if (h.releaseCapture) {
                    h.releaseCapture()
                } else {
                    if (window.releaseEvents) {
                        document.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                    }
                }
                j.onmousemove = null;
                j.onmouseup = null;
                g.visibility = "hidden";
                if (!q.pageX) {
                    q.pageX = q.clientX
                }
                if (!q.pageY) {
                    q.pageY = q.clientY
                }
                var o = q.pageX,
                m = q.pageY,
                p = e.lineTool.pathBody,
                r = e.baseTool.sumLeftTop(p);
                o = o - parseInt(r[0]) + parseInt(p.scrollLeft);
                m = m - parseInt(r[1]) + parseInt(p.scrollTop);
                var n = o >= 0 && m >= 0;
                if (n) {
                    if (c) {
                        e.lineTool.create(o, m, a)
                    } else {
                        e.modeTool.create(m, o, d)
                    }
                }
            }
        }
    },
    initEndDiv: function (f, b) {
        var d = this;
        d.endDiv = document.createElement("div");
        var e = d.endDiv,
        g = e.style;
        g.left = f + "px";
        g.top = b + "px";
        g.width = "10px";
        g.height = "10px";
        g.fontSize = "10px";
        g.position = "absolute";
        d.pathBody.appendChild(e);
        var a = $id("topCross"),
        c = $id("leftCross");
        a.style.width = f + "px";
        c.style.height = b + "px"
    },
    isSVG: function () {
        return this.VGType() == "SVG"
    },
    VGType: function () {
        return window.SVGAngle || document.implementation.hasFeature("http://www.w3.org/TR/SVG11/feature#BasicStructure", "1.1") ? "SVG" : "VML"
    },
    isVML: function () {
        return this.VGType() == "VML"
    }
};
var LineTool = com.xjwgraph.LineTool = function (d) {
    var c = this;
    c.stepIndex = PathGlobal.lineDefStep;
    c.pathBody = d;
    var e = com.xjwgraph.Global;
    c.tool = e.baseTool;
    c.moveable = false;
    c.isSVG = c.tool.isSVG();
    c.isVML = c.tool.isVML();
    c.pathBody.oncontextmenu = function (g) {
        if (!PathGlobal.rightMenu) {
            PathGlobal.rightMenu = true;
            e.baseTool.showMenu(g)
        }
        return false
    };
    c.baseLineIdIndex = PathGlobal.lineDefIndex;
    if (c.isSVG) {
        var f = document;
        c.svgBody = f.createElementNS("http://www.w3.org/2000/svg", "svg");
        c.svgBody.setAttribute("id", "svgContext");
        c.svgBody.setAttribute("style", "position:absolute;z-index:0;");
        c.svgBody.setAttribute("height", this.pathBody.scrollHeight + "px");
        c.svgBody.setAttribute("width", this.pathBody.scrollWidth + "px");
        var b = f.createElementNS("http://www.w3.org/2000/svg", "marker");
        b.setAttribute("id", "arrow");
        b.setAttribute("viewBox", "0 0 18 20");
        b.setAttribute("refX", "0");
        b.setAttribute("refY", "10");
        b.setAttribute("markerUnits", "strokeWidth");
        b.setAttribute("markerWidth", "3");
        b.setAttribute("markerHeight", "10");
        b.setAttribute("orient", "auto");
        var a = f.createElementNS("http://www.w3.org/2000/svg", "path");
        a.setAttribute("d", "M 0 0 L 20 10 L 0 20 z");
        a.setAttribute("fill", PathGlobal.lineColor);
        a.setAttribute("stroke", PathGlobal.lineColor);
        b.appendChild(a);
        c.svgBody.appendChild(b);
        c.pathBody.appendChild(c.svgBody);
        c.pathBody.addEventListener("scroll",
        function () {
            e.smallTool.initSmallBody()
        },
        false)
    } else {
        if (c.isVML) {
            c.pathBody.attachEvent("onscroll",
            function () {
                e.smallTool.initSmallBody()
            })
        }
    }
};
LineTool.prototype = {
    tempLine: null,
    removeAll: function () {
        var a = this;
        a.forEach(function (b) {
            a.removeNode(b)
        })
    },
    createRect: function (f) {
        var a,
        e = document;
        if (this.isSVG) {
            var d = e.createElementNS("http://www.w3.org/2000/svg", "g");
            d.setAttribute("style", "cursor: pointer;");
            var c = e.createElementNS("http://www.w3.org/2000/svg", "rect");
            c.setAttribute("stroke", "black");
            c.setAttribute("id", f);
            c.setAttribute("fill", "#00FF00");
            c.setAttribute("shape-rendering", "crispEdges");
            c.setAttribute("shapeRendering", "crispEdges");
            c.setAttribute("stroke-width", "1");
            c.setAttribute("strokeWidth", "1");
            c.setAttribute("x", "100");
            c.setAttribute("y", "100");
            c.setAttribute("width", "7");
            c.setAttribute("height", "7");
            c.style.visibility = "hidden";
            d.appendChild(c);
            a = d
        } else {
            if (this.isVML) {
                var c = document.createElement("v:rect");
                c.setAttribute("id", f);
                var b = c.style;
                b.width = "7px";
                b.height = "7px";
                b.position = "absolute";
                b.left = "100px";
                b.top = "100px";
                b.cursor = "pointer";
                b.visibility = "hidden";
                c.fillcolor = "#00FF00";
                c.stroked = "black";
                a = c
            }
        }
        return a
    },
    removeNode: function (a) {
        var d = this,
        c = $id(a);
        var b = null;
        if (d.isVML && c) {
            b = d.pathBody;
            b.removeChild($id(a + "lineHead"));
            b.removeChild($id(a + "lineMiddle"));
            b.removeChild($id(a + "lineEnd"))
        } else {
            if (d.isSVG && c) {
                b = d.svgBody;
                b.removeChild($id(a + "lineHead").parentNode);
                b.removeChild($id(a + "lineMiddle").parentNode);
                b.removeChild($id(a + "lineEnd").parentNode)
            }
        }
        if (c) {
            b.removeChild(c);
            var e = com.xjwgraph.Global;
            e.lineMap.remove(a);
            e.smallTool.removeLine(a);
        }
    },
    formatPath: function (a) {
        if (this.isVML) {
            a = a.replaceAll(",", " "),
            a = a.replaceAll("e", "z"),
            a = a.replaceAll("l", "L ")
        } else {
            a = a.replaceAll(",NaN NaN", ""),
            a = a.replaceAll(",undefined undefined", "")
        }
        return a
    },
    getNextIndex: function () {
        var a = this;
        a.baseLineIdIndex += a.stepIndex;
        return a.baseLineIdIndex
    },
    getActiveLine: function () {
        var a;
        this.forEach(function (b) {
            var c = $id(b);
            if (com.xjwgraph.Global.lineTool.isActiveMode(c)) {
                activeMode = c
            }
        });
        return a
    },
    isActiveLine: function (a) {
        var b,
        c = com.xjwgraph.Global;
        if (c.lineTool.isVML) {
            b = (a.getAttribute("strokecolor") == PathGlobal.lineCheckColor)
        } else {
            if (c.lineTool.isSVG) {
                b = (a.getAttribute("style").indexOf(PathGlobal.lineCheckColor) > 0)
            }
        }
        return b
    },
    forEach: function (c) {
        var d = com.xjwgraph.Global.lineMap.getKeys(),
        b = d.length;
        for (var a = b; a--; ) {
            if (c) {
                c(d[a])
            }
        }
    },
    createBaseLine: function (b, h, a) {
        var e = this,
        d = null,
        g = document;
        var c = null;
        if (e.isSVG) {
            d = g.createElementNS("http://www.w3.org/2000/svg", "path");
            d.setAttribute("id", b);
            e.setPath(d, h);
            d.setAttribute("style", "cursor:pointer; fill:none; stroke:" + PathGlobal.lineColor + "; stroke-width:" + +PathGlobal.strokeweight);
            d.setAttribute("stroke", "purple");
            d.setAttribute("marker-end", "url(#arrow)");
            d.setAttribute("brokenType", a);
            c = e.svgBody;
        } else {
            if (e.isVML) {
                d = g.createElement('<v:shape style="cursor:pointer;WIDTH:100;POSITION:absolute;HEIGHT:100" coordsize="100,100" filled="f" strokeweight="' + PathGlobal.strokeweight + 'px" strokecolor="' + PathGlobal.lineColor + '"></v:shape>');
                var f = g.createElement("<v:stroke EndArrow='classic'/>");
                d.appendChild(f);
                d.setAttribute("id", b);
                d.setAttribute("brokenType", a);
                e.setPath(d, h);
                c = e.pathBody;
            }
        }
        c.appendChild(d);
        c.appendChild(e.createRect(b + "lineHead"));
        c.appendChild(e.createRect(b + "lineMiddle"));
        c.appendChild(e.createRect(b + "lineEnd"));
        e.drag(d);
        return d
    },
    setPath: function (a, c) {
        var b = this;
        if (b.isSVG) {
            c = c.replace("z", "")
        }
        a.setAttribute("d", c);
        a.setAttribute("path", c)
    },
    getMiddle: function (p, g, l) {
        p = p.replace("M", "");
        p = p.replace("m", "");
        p = p.replace("z", "");
        var o = p.split("L"),
        n = this,
        b = n.strTrim(o[1]),
        f,
        q,
        d;
        if (n.isSVG) {
            if (b.indexOf(",") > 0) {
                f = b.split(",");
                var e = n.strTrim(f[0]).split(" "),
                f = n.strTrim(f[1]).split(" "),
                c = parseInt(e[0]),
                m = parseInt(e[1]),
                a = parseInt(f[0]),
                k = parseInt(f[1]);
                d = [c, m, a, k];
                q = [parseInt(Math.abs(c + a) / 2), parseInt(Math.abs(k + m) / 2)]
            } else {
                var j = n.getLineHead(p),
                f = n.getLineEnd(p);
                q = [parseInt(Math.abs(j[0] + f[0]) / 2), parseInt(Math.abs(j[1] + f[1]) / 2)]
            }
        } else {
            if (n.isVML) {
                f = n.strTrim(b).split(" ");
                if (f.length > 2) {
                    var c = parseInt(n.strTrim(f[0])),
                    m = parseInt(n.strTrim(f[1])),
                    a = parseInt(n.strTrim(f[2])),
                    k = parseInt(n.strTrim(f[3]));
                    d = [c, m, a, k];
                    q = [parseInt(Math.abs(c + a) / 2), parseInt(Math.abs(k + m) / 2)]
                } else {
                    var j = n.getLineHead(p),
                    f = n.getLineEnd(p);
                    q = [parseInt(Math.abs(j[0] + f[0]) / 2), parseInt(Math.abs(j[1] + f[1]) / 2)]
                }
            }
        }
        if (l) {
            var i = $id(g + "lineMiddle"),
            h = i.style;
            i.setAttribute("x", q[0] - PathGlobal.dragPointDec);
            i.setAttribute("y", q[1] - PathGlobal.dragPointDec);
            if (n.isActiveLine($id(g))) {
                h.visibility = "";
            }
            h.left = q[0] - PathGlobal.dragPointDec + "px";
            h.top = q[1] - PathGlobal.dragPointDec + "px";
        }
        return d
    },
    getLineHead: function (d) {
        d = d.replace("M", "");
        d = d.replace("m", "");
        d = d.replace("z", "");
        var e = d.split("L"),
        a = this.strTrim(e[0]).split(" "),
        c = parseInt(a[0]),
        b = parseInt(a[1]);
        return [c, b]
    },
    getLineEnd: function (d) {
        d = d.replace("M", "");
        d = d.replace("m", "");
        d = d.replace("z", "");
        if (this.isSVG) {
            var e = d.split("L"),
            c = this,
            b = c.strTrim(e[1]),
            a;
            if (b.indexOf(",") > 0) {
                a = b.split(",");
                a = c.strTrim(a[a.length - 1]).split(" ")
            } else {
                a = b.split(" ");
                a = [a[a.length - 2], a[a.length - 1]]
            }
        } else {
            d = d.replace("L", " ");
            d = d.replace(",", " ");
            d = this.strTrim(d);
            var a = d.split(" ");
            a = [a[a.length - 2], a[a.length - 1]];
            return [parseInt(a[0]), parseInt(a[1])]
        }
        return [parseInt(a[0]), parseInt(a[1])]
    },
    brokenPath: function (i, a) {
        var h = this,
        g = h.getLineHead(i),
        c = g[0],
        f = g[1],
        d = h.getLineEnd(i),
        e = d[0],
        b = d[1];
        if (a == 2) {
            i = h.brokenVertical(c, f, e, b, i)
        } else {
            if (a == 3) {
                i = h.brokenCross(c, f, e, b, i)
            }
        }
        return i
    },
    broken: function (f, e, c, b, a, d) {
        if (a == 2) {
            d = this.brokenVertical(f, e, c, b, d)
        } else {
            if (a == 3) {
                d = this.brokenCross(f, e, c, b, d)
            }
        }
        return d
    },
    brokenVertical: function (g, f, b, a, e) {
        var h = this.getPathArray(e),
        c = h.length;
        if (PathGlobal.switchType || c < 5) {
            var d = a - f,
            e = "M " + g + " " + f + " L " + (g) + " " + (f + parseInt(d / 2)) + "," + (b) + " " + (a - parseInt(d / 2)) + "," + b + " " + a + " z"
        } else {
            h[0] = g;
            h[1] = f;
            h[2] = g;
            h[4] = b;
            h[5] = h[3];
            h[6] = b;
            h[7] = a;
            e = this.arrayToPath(h)
        }
        return e
    },
    brokenCross: function (g, f, b, a, e) {
        var h = this.getPathArray(e),
        c = h.length;
        if (PathGlobal.switchType || c < 5) {
            var d = b - g,
            e = "M " + g + " " + f + " L " + (g + parseInt(d / 2)) + " " + (f) + "," + (g + parseInt(d / 2)) + " " + (a) + "," + b + " " + a + " z"
        } else {
            h[0] = g;
            h[1] = f;
            h[3] = f;
            h[4] = h[2];
            h[5] = a;
            h[6] = b;
            h[7] = a;
            e = this.arrayToPath(h)
        }
        return e
    },
    getPathArray: function (a) {
        a = a.replace("M", ""),
        a = a.replace("m", ""),
        a = a.replace("z", ""),
        a = a.replace("L", ""),
        a = a.replace("  ", " "),
        a = a.replaceAll(",", " ");
        var b = this.strTrim(a).split(" "),
        b = b.join(","),
        b = b.replaceAll(",,", ",");
        return this.strTrim(b).split(",")
    },
    arrayToPath: function (a) {
        return smallPath = "M " + a[0] + " " + a[1] + "  L " + a[2] + " " + a[3] + "," + a[4] + " " + a[5] + "," + a[6] + " " + a[7]
    },
    create: function (d, g, b) {
        var i = this,
        h = i.getNextIndex(),
        j = "M " + d + " " + g + " L " + (d + 100) + " " + g + " z";
        if (b != 1) {
            j = "M " + d + " " + g + " L " + (d + 100) + " " + (g + 60) + " z";
            j = i.brokenPath(j, b)
        }
        var k = i.createBaseLine("line" + h, j, b),
        e = new BuildLine();
        e.id = "line" + h;
        var c = com.xjwgraph.Global;
        c.lineMap.put(e.id, e);
        var f = c.smallTool,
        a = new com.xjwgraph.UndoRedoEvent(function () {
            var n = k && k.id && $id(k.id);
            var m = null,
            l = k.getAttribute("id");
            if (i.isVML && n) {
                m = i.pathBody;
                m.removeChild($id(l + "lineHead"));
                m.removeChild($id(l + "lineMiddle"));
                m.removeChild($id(l + "lineEnd"))
            } else {
                if (i.isSVG && n) {
                    m = i.svgBody;
                    m.removeChild($id(l + "lineHead").parentNode);
                    m.removeChild($id(l + "lineMiddle").parentNode);
                    m.removeChild($id(l + "lineEnd").parentNode)
                }
            }
            if (n) {
                m.removeChild(k)
            }
            c.lineMap.remove(e.id);
            if (n) {
                f.removeLine(e.id)
            }
        },
        PathGlobal.lineCreate);
        a.setRedo(function () {
            var m = null,
            l = k.getAttribute("id");
            if (i.isVML) {
                k.setAttribute("filled", "f");
                k.setAttribute("strokeweight", PathGlobal.strokeweight + "px");
                k.setAttribute("strokecolor", PathGlobal.lineColor);
                m = i.pathBody
            } else {
                if (i.isSVG) {
                    m = i.svgBody
                }
            }
            m.appendChild(k);
            m.appendChild(i.createRect(l + "lineHead"));
            m.appendChild(i.createRect(l + "lineMiddle"));
            m.appendChild(i.createRect(l + "lineEnd"));
            i.drag(k);
            c.lineMap.put(k.id, e);
            f.drawLine(k)
        })
    },
    getPath: function (a) {
        var b = this,
        c = "";
        if (b.isSVG) {
            c = a.getAttribute("d")
        } else {
            c = a.path + ""
        }
        c = b.formatPath(c);
        return c
    },
    distancePoint: function (j, g, m) {
        var k = this,
        l = this.getPath(m),
        h = k.getLineHead(l),
        c = k.getLineEnd(l),
        b = parseInt(h[0]),
        i = parseInt(h[1]),
        a = parseInt(c[0]),
        f = parseInt(c[1]),
        e = Math.abs(Math.sqrt(Math.pow(b - j, 2) + Math.pow(i - g, 2))),
        d = Math.abs(Math.sqrt(Math.pow(a - j, 2) + Math.pow(f - g, 2)));
        return e <= d
    },
    strTrim: function (b) {
        b = b.replace(/^\s+/, "");
        for (var a = b.length - 1; a >= 0; a--) {
            if (/\S/.test(b.charAt(a))) {
                b = b.substring(0, a + 1);
                break
            }
        }
        return b
    },
    initScaling: function (a) {
        var b = this,
        c = com.xjwgraph.Global.smallTool;
        b.forEach(function (d) {
            var e = $id(d),
            h = b.formatPath(b.getPath(e)),
            j = b.getPathArray(h),
            g = j.length;
            for (var f = g; f--; ) {
                j[f] = parseInt(j[f] / a)
            }
            h = b.arrayToPath(j);
            b.setPath(e, h);
            b.setDragPoint(e);
            c.drawLine(e)
        })
    },
    getEndPoint: function (a) {
        var b = a.split("L");
        b[1] = this.strTrim(b[1]);
        return b[1].split(" ")
    },
    getHeadPoint: function (a) {
        var b = a.split("L");
        b[0] = this.strTrim(b[0]);
        return b[0].split(" ")
    },
    endPoint: function (b, h, f, a) {
        var c = this,
        e;
        if (a != 1) {
            var d = c.getLineHead(f);
            e = c.broken(parseInt(d[0]), parseInt(d[1]), b, h, a, f)
        } else {
            var g = f.split("L");
            g[0] = this.strTrim(g[0]);
            e = g[0] + " L " + b + " " + h + " z"
        }
        return e
    },
    headPoint: function (b, h, f, a) {
        var d = this,
        e;
        if (a != 1) {
            var c = d.getLineEnd(f);
            e = d.broken(b, h, parseInt(c[0]), parseInt(c[1]), a, f)
        } else {
            var g = f.split("L");
            g[1] = this.strTrim(g[1]);
            e = "M " + b + " " + h + " L " + g[1]
        }
        return e
    },
    vecMultiply: function (c, b, a) {
        return ((c.x - a.x) * (b.y - a.y) - (b.x - a.x) * (c.y - a.y))
    },
    poInTrigon: function (h, g, e, f) {
        var b = this,
        d = b.vecMultiply(h, f, g),
        c = b.vecMultiply(g, f, e),
        a = b.vecMultiply(e, f, h);
        if (d * c * a == 0) {
            return false
        }
        if ((d > 0 && c > 0 && a > 0) || (d < 0 && c < 0 && a < 0)) {
            return true
        }
        return false
    },
    buildModeAndPoint: function (m, c, e, d) {
        var f = c.offsetWidth,
        b = c.offsetHeight,
        g = new Point(),
        a = new Point();
        a.x = parseInt(c.offsetLeft);
        a.y = parseInt(c.offsetTop);
        var l = new Point();
        l.x = parseInt(c.offsetLeft) + parseInt(f);
        l.y = parseInt(c.offsetTop);
        var k = new Point();
        k.x = parseInt(c.offsetLeft) + parseInt(f) / 2;
        k.y = parseInt(c.offsetTop) + parseInt(b) / 2;
        var i = new Point();
        i.x = e;
        i.y = d;
        var j = this;
        if (j.poInTrigon(a, l, k, i)) {
            g.x = "0px";
            g.y = f / 2 + "px";
            g.index = PathGlobal.pointTypeUp
        }
        l.x = parseInt(c.offsetLeft);
        l.y = parseInt(c.offsetTop) + parseInt(b);
        if (j.poInTrigon(a, l, k, i)) {
            g.x = b / 2 + "px";
            g.y = "0px";
            g.index = PathGlobal.pointTypeLeft
        }
        a.x = parseInt(c.offsetLeft) + parseInt(f);
        a.y = parseInt(c.offsetTop) + parseInt(b);
        if (j.poInTrigon(a, l, k, i)) {
            g.x = b + "px";
            g.y = f / 2 + "px";
            g.index = PathGlobal.pointTypeDown
        }
        l.x = parseInt(c.offsetLeft) + parseInt(f);
        l.y = parseInt(c.offsetTop);
        if (j.poInTrigon(a, l, k, i)) {
            g.x = b / 2 + "px";
            g.y = f + "px";
            g.index = PathGlobal.pointTypeRight
        }
        g.x = parseInt(c.offsetTop) + parseInt(g.x);
        g.y = parseInt(c.offsetLeft) + parseInt(g.y);
        return g
    },
    buildLineAndMode: function (l, g, i, h, d) {
        var k = this,
        j = k.buildModeAndPoint(l, g, i, h),
        c = new BuildLine();
        c.index = j.index;
        c.id = l.id;
        k.pathLine(j.y, j.x, l, d);
        k.setDragPoint(l);
        var b = com.xjwgraph.Global,
        f = b.modeMap.get(g.id);
        c.type = d;
        f.lineMap.put(c.id + "-" + c.type, c);
        var e = b.lineMap.get(l.id);
        //add by qw 2012.12.18 start
        //var modeId = b.modeTool.getModeIndex(g);
        //alert(modeId + "," + g.id);
        if (d) {
            e.xBaseMode = f;
            //e.sNodeId = f.type + modeId;
            e.xIndex = j.index
        } else {
            e.wBaseMode = f;
            //e.eNodeId = f.type + modeId;
            e.wIndex = j.index
        }
        //end
        b.lineMap.put(l.id, e);
        var a = new com.xjwgraph.UndoRedoEvent(function () {
            if (d) {
                e.xBaseMode = null
            } else {
                e.wBaseMode = null
            }
            f.lineMap.remove(c.id + "-" + c.type);
            k.setDragPoint(l)
        },
        PathGlobal.buildLineAndMode);
        a.setRedo(function () {
            if (d) {
                e.xBaseMode = f
            } else {
                e.wBaseMode = f
            }
            f.lineMap.put(c.id + "-" + c.type, c);
            k.setDragPoint(l)
        })
    },
    removeAllLineAndMode: function (a, b) {
        this.removeBuildLineAndMode(a, b, true);
        this.removeBuildLineAndMode(a, b, false)
    },
    removeBuildLineAndMode: function (m, h, d) {
        var b = com.xjwgraph.Global,
        g = b.modeMap.get(h.id),
        j = g.lineMap,
        k = m.id + "-" + d;
        if (j.containsKey(k)) {
            var l = g.lineMap,
            f = l.get(k),
            c = null,
            i = null;
            l.remove(k);
            var e = b.lineMap.get(m.id);
            if (e && e.xBaseMode && e.xBaseMode.id == h.id) {
                c = e.xBaseMode,
                e.xBaseMode = null
            } else {
                if (e && e.wBaseMode && e.wBaseMode.id == h.id) {
                    e.wBaseMode = null;
                    i = e.wBaseMode
                }
            }
            var a = new com.xjwgraph.UndoRedoEvent(function () {
                l.put(k, f);
                e.xBaseMode = c;
                e.wBaseMode = i
            },
            PathGlobal.removeLineAndMode);
            a.setRedo(function () {
                l.remove(k);
                e.xBaseMode = null;
                e.wBaseMode = null
            })
        }
    },
    isMoveBaseMode: function (n, l, p, d) {
        var a = com.xjwgraph.Global,
        m = a.modeMap.getKeys(),
        c = m.length,
        h = a.modeTool;
        for (var f = c; f--; ) {
            var g = $id(m[f]),
            e = g.style,
            b = parseInt(e.left),
            j = g.offsetWidth + b,
            k = parseInt(e.top),
            o = g.offsetHeight + k;
            if (n > b && n < j && l > k && l < o) {
                h.hiddPointer(g);
                h.flip(a.modeTool.getModeIndex(g));
                break
            } else {
                h.hiddPointer(g)
            }
        }
    },
    isCoverBaseMode: function (n, l, r, d) {
        var a = com.xjwgraph.Global,
        m = a.modeMap.getKeys(),
        c = m.length,
        h = a.modeTool,
        p = this,
        q = a.modeTool.getActiveMode();
        if (q) {
            h.hiddPointer(q);
            h.flip(a.modeTool.getModeIndex(q));
            p.buildLineAndMode(r, q, n, l, d)
        }
        for (var f = c; f--; ) {
            var g = $id(m[f]),
            e = g.style,
            b = parseInt(e.left),
            j = g.offsetWidth + b,
            k = parseInt(e.top),
            o = g.offsetHeight + k;
            if (q && q.id == g.id) {
                continue
            } else {
                h.hiddPointer(g);
                p.removeBuildLineAndMode(r, g, d)
            }
        }
    },
    pathLine: function (e, f, b, d) {
        var c = this,
        h = c.getPath(b),
        g,
        a = b.getAttribute("brokenType");
        if (d) {
            g = c.headPoint(parseInt(e), parseInt(f), h, a)
        } else {
            g = c.endPoint(parseInt(e), parseInt(f), h, a)
        }
        c.setPath(b, g);
        com.xjwgraph.Global.smallTool.drawLine(b)
    },
    clearLine: function (a) {
        var b = $id(a),
        e = com.xjwgraph.Global,
        g = e.lineTool;
        if (g.isVML) {
            b.setAttribute("strokecolor", PathGlobal.lineColor)
        } else {
            if (e.lineTool.isSVG) {
                b.setAttribute("style", "cursor:pointer; fill:none; stroke:" + PathGlobal.lineColor + "; stroke-width:2")
            }
        }
        var d = $id(a + "lineHead"),
        c = $id(a + "lineEnd"),
        f = $id(a + "lineMiddle");
        d.style.visibility = "hidden";
        c.style.visibility = "hidden";
        f.style.visibility = "hidden";
        //add by qw 2012.12.23 start
        var sLXHDiv = $id("showLineXH");
        if (sLXHDiv) {
            sLXHDiv.innerHTML = "";
            sLXHDiv.style.visibility = "hidden";
        }
        //end
    },
    clear: function () {
        var b = com.xjwgraph.Global,
        c = b.lineTool;
        this.forEach(function (d) {
            c.clearLine(d)
        });
        PathGlobal.rightMenu = false;
        var a = $id("lineRightMenu");
        a.style.visibility = "hidden";
        c.tempLine = null;
        b.smallTool.clear();
        //add by qw 2012.12.23 start
        var sLXHDiv = $id("showLineXH");
        if (sLXHDiv) {
            sLXHDiv.innerHTML = "";
            sLXHDiv.style.visibility = "hidden";
        }
        //end
    },
    setDragPoint: function (q) {
        var h = com.xjwgraph.Global.lineTool,
        p = h.formatPath(h.getPath(q)),
        g = q.getAttribute("id"),
        i = $id(g + "lineHead"),
        e = $id(g + "lineEnd"),
        l = $id(g + "lineMiddle"),
        m = h.getLineHead(p),
        d = h.getLineEnd(p),
        o = h.getMiddle(p, g, true),
        k = parseInt(m[0]),
        c = parseInt(m[1]),
        b = parseInt(d[0]),
        n = parseInt(d[1]),
        f = q.style;
        i.setAttribute("x", (b - PathGlobal.dragPointDec));
        i.setAttribute("y", (n - PathGlobal.dragPointDec));
        var j = i.style;
        j.left = (b - PathGlobal.dragPointDec) + "px";
        j.top = (n - PathGlobal.dragPointDec) + "px";
        e.setAttribute("x", (k - PathGlobal.dragPointDec));
        e.setAttribute("y", (c - PathGlobal.dragPointDec));
        var a = e.style;
        a.left = (k - PathGlobal.dragPointDec) + "px";
        a.top = (c - PathGlobal.dragPointDec) + "px";
        j.zIndex = 1;
        l.style.zIndex = 1;
        a.zIndex = 1;
        if (h.isActiveLine(q)) {
            j.visibility = "";
            a.visibility = "";
        }
        //add by qw 2012.12.23 start
        var _LineMap = com.xjwgraph.Global.lineMap,
        lineObj = _LineMap.get(g);
        var sLXHDiv = $id("showLineXH");
        if (sLXHDiv && lineObj) {
            sLXHDiv.style.left = parseInt(l.style.left) + 10;
            sLXHDiv.style.top = l.style.top;
            sLXHDiv.innerHTML = lineObj.prop.XH;
            sLXHDiv.style.visibility = "visible";
        }
        //end
    },
    showProperty: function (b) {
        //add by qw 2012.12.18 start 关闭右键显示
        PathGlobal.rightMenu = false;
        var M = $id("lineRightMenu");
        i = M.style;
        i.visibility = "hidden";
        //end
        var i = this.tempLine,
        c = com.xjwgraph.Global,
        d = c.lineMap,
        f = d.get(i.getAttribute("id")),
        a = f.prop,
        h = $id("prop"),
        g = document,
        e = c.clientTool;
        h.style.visibility = "";
        h.innerHTML = "";
        h.appendChild(e.addProItem(a));
        e.showDialog(b, PathGlobal.lineProTitle, f);
    },
    showMenu: function (a, j) {
        PathGlobal.rightMenu = true;
        var i = this;
        i.tempLine = j;
        a = a || window.event;
        if (!a.pageX) {
            a.pageX = a.clientX
        }
        if (!a.pageY) {
            a.pageY = a.clientY
        }
        var f = a.pageX,
        e = a.pageY,
        c = com.xjwgraph.Global,
        b = c.lineTool.pathBody,
        g = c.baseTool.sumLeftTop(b);
        f = f - parseInt(g[0]) + parseInt(b.scrollLeft);
        e = e - parseInt(g[1]) + parseInt(b.scrollTop);
        var d = $id("lineRightMenu"),
        h = d.style;
        h.top = e + "px";
        h.left = f + "px";
        h.visibility = "visible";
        h.zIndex = i.getNextIndex()
    },
    showId: function (a) {
        this.show($id(a))
    },
    show: function (a) {
        if (this.isVML) {
            a.setAttribute("strokecolor", PathGlobal.lineCheckColor)
        } else {
            if (this.isSVG) {
                a.setAttribute("style", "cursor:pointer;fill:none; stroke:" + PathGlobal.lineCheckColor + "; stroke-width:" + PathGlobal.strokeweight)
            }
        }
        this.setDragPoint(a)
    },
    drag: function (i) {
        var b = com.xjwgraph.Global,
        d = i.getAttribute("id"),
        f = $id(d + "lineHead"),
        c = $id(d + "lineEnd"),
        g = $id(d + "lineMiddle"),
        e = b.lineTool,
        a = e.pathBody,
        h = this;
        b.smallTool.drawLine(i);
        i.ondragstart = function () {
            return false
        };
        g.oncontextmenu = c.oncontextmenu = f.oncontextmenu = i.oncontextmenu = function (j) {
            e.showMenu(j, i);
            return false
        };
        c.onmousedown = f.onmousedown = i.onmousedown = function (k) {
            k = k || window.event;
            b.modeTool.clear();
            b.lineTool.clear();
            e.moveable = true;
            var p = b.smallTool,
            j = e.getPath(i),
            r = k.clientX ? k.clientX : k.offsetX,
            o = k.clientY ? k.clientY : k.offsetY,
            q = b.baseTool.sumLeftTop(a);
            r = r - parseInt(q[0]) + parseInt(a.scrollLeft);
            o = o - parseInt(q[1]) + parseInt(a.scrollTop);
            if (!k.pageX) {
                k.pageX = k.clientX
            }
            if (!k.pageY) {
                k.pageY = k.clientY
            }
            var n = k.clientX - r,
            m = k.clientY - o,
            l = e.distancePoint(r, o, i),
            s = document;
            h.show(i);
            s.onmousemove = function (v) {
                v = v || window.event;
                if (e.moveable) {
                    var t = v.clientX ? v.clientX : v.offsetX;
                    var u = v.clientY ? v.clientY : v.offsetY;
                    var w = b.baseTool.sumLeftTop(a);
                    t = t - parseInt(w[0]) + parseInt(a.scrollLeft);
                    u = u - parseInt(w[1]) + parseInt(a.scrollTop);
                    h.pathLine(t, u, i, l);
                    h.setDragPoint(i)
                }
            };
            s.onmouseup = function (G) {
                G = G || window.event;
                var I = G.clientX ? G.clientX : G.offsetX,
                x = G.clientY ? G.clientY : G.offsetY;
                var A = b.baseTool.sumLeftTop(a);
                I = I - parseInt(A[0]) + parseInt(a.scrollLeft);
                x = x - parseInt(A[1]) + parseInt(a.scrollTop);
                e.moveable = false;
                s.onmousemove = null;
                s.onmouseup = null;
                var u = e.getPath(i);
                if (j != u) {
                    var y = e.getLineHead(j),
                    C = e.getLineEnd(j),
                    z = parseInt(y[0]),
                    H = parseInt(y[1]),
                    F = parseInt(C[0]),
                    w = parseInt(C[1]),
                    D = e.getLineHead(u),
                    t = e.getLineEnd(u),
                    E = parseInt(D[0]),
                    v = parseInt(D[1]),
                    B = parseInt(t[0]),
                    K = parseInt(t[1]);
                    if (z !== E || H !== v || F !== B || w !== K) {
                        e.isCoverBaseMode(I, x, i, l)
                    }
                    var J = new com.xjwgraph.UndoRedoEvent(function () {
                        b.lineTool.setPath(i, j);
                        p.drawLine(i);
                        e.setDragPoint(i)
                    },
                    PathGlobal.lineMove);
                    J.setRedo(function () {
                        b.lineTool.setPath(i, u);
                        p.drawLine(i);
                        e.setDragPoint(i)
                    })
                }
            }
        };
        g.onmousedown = function (j) {
            c.onmousedown(j);
            document.onmousemove = function (l) {
                l = l || window.event;
                if (e.moveable) {
                    var m = l.clientX ? l.clientX : l.offsetX;
                    var s = l.clientY ? l.clientY : l.offsetY;
                    var r = b.baseTool.sumLeftTop(a);
                    m = m - parseInt(r[0]) + parseInt(a.scrollLeft);
                    s = s - parseInt(r[1]) + parseInt(a.scrollTop);
                    var u = e.formatPath(e.getPath(i));
                    var q = e.getLineHead(u),
                    n = e.getLineEnd(u),
                    p = $id(d + "lineMiddle"),
                    o = b.smallTool;
                    o.drawLine(i);
                    var k = i.getAttribute("brokenType");
                    h.changeBrokenType(i, m, s);
                    if (k == 3) {
                        var t = "M " + q[0] + " " + q[1] + " L " + m + " " + q[1] + "," + m + " " + n[1] + "," + n[0] + " " + n[1] + " z";
                        e.setPath(i, t);
                        p.setAttribute("x", m - PathGlobal.dragPointDec);
                        p.style.left = m - PathGlobal.dragPointDec + "px"
                    } else {
                        if (k == 2) {
                            var t = "M " + q[0] + " " + q[1] + " L " + q[0] + " " + s + "," + n[0] + " " + s + "," + n[0] + " " + n[1] + " z";
                            e.setPath(i, t);
                            p.setAttribute("y", s - PathGlobal.dragPointDec);
                            p.style.top = s - PathGlobal.dragPointDec + "px"
                        }
                    }
                    e.setDragPoint(i)
                }
            }
        }
    },
    changeBrokenType: function (k, c, i) {
        var j = this.getPath(k),
        b = k.getAttribute("brokenType"),
        h = this.getLineHead(j),
        e = this.getLineEnd(j),
        d = (parseInt(c) > parseInt(h[0]) && parseInt(c) < parseInt(e[0]) || parseInt(c) < parseInt(h[0]) && parseInt(c) > parseInt(e[0])),
        a = (parseInt(i) > parseInt(h[1]) && parseInt(i) < parseInt(e[1]) || parseInt(i) < parseInt(h[1]) && parseInt(i) > parseInt(e[1])),
        g = (parseInt(c) < parseInt(h[0]) && parseInt(c) < parseInt(e[0]) || parseInt(c) > parseInt(h[0]) && parseInt(c) > parseInt(e[0])) && a,
        f = (parseInt(i) < parseInt(h[1]) && parseInt(i) < parseInt(e[1]) || parseInt(i) > parseInt(h[1]) && parseInt(i) > parseInt(e[1])) && d;
        if (g) {
            k.setAttribute("brokenType", 3)
        } else {
            if (f) {
                k.setAttribute("brokenType", 2)
            }
        }
    }
};
var ModeTool = com.xjwgraph.ModeTool = function (a) {
    var b = this;
    b.moveable = false;
    b.optionMode;
    b.baseModeIdIndex = PathGlobal.modeDefIndex;
    b.stepIndex = PathGlobal.modeDefStep;
    b.pathBody = a;
    b.tempMode;
};
ModeTool.prototype = {
    initScaling: function (a) {
        var b = this,
        c = com.xjwgraph.Global.smallTool;
        b.forEach(function (l) {
            var g = $id(l),
            f = g.style,
            h = b.getModeIndex(g),
            i = $id("content" + h),
            j = $id("backImg" + h),
            m = i.style,
            k = j.style,
            e = parseInt(parseInt(g.offsetWidth) / a) + "px",
            d = parseInt(parseInt(g.offsetHeight) / a) + "px";
            f.top = parseInt(parseInt(f.top) / a) + "px";
            f.left = parseInt(parseInt(f.left) / a) + "px";
            m.width = e;
            m.height = d;
            k.width = e;
            k.height = d;
            f.width = e;
            f.height = d;
            b.showPointer(g);
            c.drawMode(g)
        })
    },
    showMenu: function (a, f) {
        PathGlobal.rightMenu = true;
        var j = this;
        j.tempMode = f.parentNode;
        a = a || window.event;
        if (!a.pageX) {
            a.pageX = a.clientX
        }
        if (!a.pageY) {
            a.pageY = a.clientY
        }
        var e = a.pageX,
        d = a.pageY,
        c = com.xjwgraph.Global,
        b = c.lineTool.pathBody,
        h = c.baseTool.sumLeftTop(b);
        e = e - parseInt(h[0]) + parseInt(b.scrollLeft);
        d = d - parseInt(h[1]) + parseInt(b.scrollTop);
        var g = $id("rightMenu"),
        i = g.style;
        i.top = d + "px";
        i.left = e + "px";
        i.visibility = "visible";
        i.zIndex = j.getNextIndex()
    },
    showProperty: function (e) {
        //add by qw 2012.12.18 start 关闭右键显示
        PathGlobal.rightMenu = false;
        var M = $id("rightMenu");
        i = M.style;
        i.visibility = "hidden";
        //end
        //add by qw 2012.12.19 节点的属性信息的从服务端提取 start
        var d = com.xjwgraph.Global,
        c = d.modeMap,
        mTool = d.modeTool,
        cTool = d.controlTool,
        b = c.get(this.tempMode.id);
        var modeDiv = $id(b.id);
        var mIndex = mTool.getModeIndex(modeDiv);
        var nName = $id("title" + mIndex).innerHTML;
        //alert(cTool + "==" + b.id +"========"+ modeDiv.getAttribute("modeContent"));
        var nText = modeDiv.getAttribute("modeContent") || "";
        //alert(b.type + "," + b.id + "," + CommonInfo.BF_VERSION + "," + mIndex + "," + nName + " content==" + (modeDiv.getAttribute("modeContent") || "") + "===" + nText);
        //向服务端提交参数
        var _Param = "?";
        _Param += "bfid=" + CommonInfo.BF_ID;
        _Param += "&bfversion=" + CommonInfo.BF_VERSION;
        _Param += "&nodeid=" + b.id;
        _Param += "&nodename=" + nName;
        _Param += "&nodedesc=" + nText;
        _Param += "&nodetype=" + b.type;
        //alert(encodeURI(_Param));
        $('#tt').propertygrid({
            width: 300,
            height: 'auto',
            url: 'BFWebHandler.ashx' + encodeURI(_Param),
            showGroup: true,
            showHeader: true,
            scrollbarSize: 0,
            onDblClickRow: function (rowIndex, rowData) {
                BFHandler.selcData(rowIndex, rowData);
            }
            //,
            //            onClickCell: function (index, field, value) {
            //                BFHandler.selcData(index, field, value);
            //            }
        });
        //end
    },
    removeAll: function () {
        var a = this;
        a.forEach(function (b) {
            a.removeNode(b)
        })
    },
    removeNode: function (d) {
        var c = $id(d);
        if (c) {
            //add by qw 2012.12.20 start
            BFHandler.delData(d);
            //end
            var b = com.xjwgraph.Global,
            a = b.lineTool.pathBody;
            this.hiddPointer(c);
            b.modeMap.remove(c.id);
            b.smallTool.removeMode(c.id);
            a.removeChild(c);
        }
    },
    cutter: function () {
        var c = this,
        b = c.tempMode.id,
        e = com.xjwgraph.Global,
        g = e.modeMap.get(b),
        f = $id(b),
        a = e.lineTool.pathBody;
        c.removeNode(b);
        var d = new com.xjwgraph.UndoRedoEvent(function () {
            e.modeMap.put(b, g);
            a.appendChild(f);
            c.showPointer(f);
            e.smallTool.drawMode(f)
        },
        PathGlobal.modeCutter);
        d.setRedo(function () {
            c.removeNode(b)
        })
    },
    duplicate: function () {
        var e = com.xjwgraph.Global,
        c = e.lineTool.pathBody,
        b = this,
        a = e.modeTool.copy(b.tempMode),
        f = e.modeMap.get(a.id);
        e.modeTool.hiddPointer(b.tempMode);
        e.smallTool.drawMode(a);
        var d = new com.xjwgraph.UndoRedoEvent(function () {
            b.removeNode(a.id)
        },
        PathGlobal.modeDuplicate);
        d.setRedo(function () {
            e.modeMap.put(a.id, f);
            c.appendChild(a);
            b.showPointer(a);
            e.smallTool.drawMode(a)
        })
    },
    del: function () {
        var a = this;
        a.cutter();
        a.tempMode = null
    },
    getNextIndex: function () {
        var a = this;
        a.baseModeIdIndex += a.stepIndex;
        return a.baseModeIdIndex
    },
    setClass: function (b, a) {
        if (b) {
            b.setAttribute("class", a);
            b.setAttribute("className", a)
        }
    },
    //add by qw 2012.12.18 start
    getModeType: function (_Src) {
        var typeName = "module";
        if (_Src.indexOf("startNode") > 0)
            typeName = "startNode";
        else if (_Src.indexOf("endNode") > 0)
            typeName = "endNode";
        else if (_Src.indexOf("processNode") > 0)
            typeName = "processNode";
        else if (_Src.indexOf("joinNode") > 0)
            typeName = "joinNode";
        else if (_Src.indexOf("subflowNode") > 0)
            typeName = "subflowNode";

        return typeName;
    },
    getModeName: function (_Src) {
        var modeName = "";
        if (_Src.indexOf("startNode") > -1)
            modeName = "\u5f00\u59cb\u8282\u70b9"; //开始节点
        else if (_Src.indexOf("endNode") > -1)
            modeName = "\u5b8c\u6210\u8282\u70b9"; //完成节点
        else if (_Src.indexOf("processNode") > -1)
            modeName = "\u4e1a\u52a1\u8282\u70b9"; //业务节点
        else if (_Src.indexOf("joinNode") > -1)
            modeName = "\u6c47\u5408\u8282\u70b9"; //汇合节点
        else if (_Src.indexOf("subflowNode") > -1)
            modeName = "\u5b50\u6d41\u7a0b\u8282\u70b9"; //子流程节点

        return modeName;
    },
    checkStartAndEndNode: function (_TypeName) {
        var b = com.xjwgraph.Global;
        var mapSize = b.modeMap.size();
        if (mapSize > 0) {
            var a = b.modeMap;
            var baseMapKey = a.getKeys();
            var baseMapKeyLength = baseMapKey.length;
            for (var j = baseMapKeyLength; j--; ) {
                var mObj = a.get(baseMapKey[j]);
                if ((_TypeName == "startNode" || _TypeName == "endNode") &&
                    mObj.type == _TypeName) {
                    return false;
                }
            }
        }
        return true;
    },
    //end
    createBaseMode: function (o, f, a, i, e, l) {
        var p = this,
        u = document,
        j = u.createElement("div"),
        t = u.createElement("div"),
        q = u.createElement("div"),
        s = u.createElement("img");
        j.appendChild(t);
        j.appendChild(q);
        q.appendChild(s);
        var n = j.style;
        n.top = o + "px";
        n.left = f + "px";
        n.zIndex = i;
        p.setClass(j, "module");
        p.setClass(t, "title");
        p.setClass(q, "content");
        j.id = "module" + i;
        t.id = "title" + i;
        q.id = "content" + i;
        s.id = "backImg" + i;
        s.style.width = e;
        s.style.height = l;
        s.src = a;
        var k = u.createElement("div"),
        d = u.createElement("div"),
        m = u.createElement("div"),
        c = u.createElement("div"),
        h = u.createElement("div"),
        b = u.createElement("div"),
        g = u.createElement("div"),
        r = u.createElement("div");
        p.setClass(k, "top_left");
        p.setClass(d, "top_middle");
        p.setClass(m, "top_right");
        p.setClass(c, "middle_left");
        p.setClass(h, "middle_right");
        p.setClass(b, "bottom_left");
        p.setClass(g, "bottom_middle");
        p.setClass(r, "bottom_right");
        k.id = "top_left" + i;
        d.id = "top_middle" + i;
        m.id = "top_right" + i;
        c.id = "middle_left" + i;
        h.id = "middle_right" + i;
        b.id = "bottom_left" + i;
        g.id = "bottom_middle" + i;
        r.id = "bottom_right" + i;
        j.appendChild(k);
        j.appendChild(d);
        j.appendChild(m);
        j.appendChild(c);
        j.appendChild(h);
        j.appendChild(b);
        j.appendChild(g);
        j.appendChild(r);
        return j
    },
    create: function (f, c, j) {
        var k = this,
        i = k.getNextIndex(),
        g = document,
        h = k.createBaseMode(f, c, j, i, "50px", "50px");
        //add by qw 2013.1.7 start
        //判断开始节点和完成节点，只能有一个
        if (!k.checkStartAndEndNode(k.getModeType(j))) {
            $.messager.alert('\u8b66\u544a', '\u5f00\u59cb\u8282\u70b9\u4e0e\u5b8c\u6210\u8282\u70b9\u53ea\u80fd\u5404\u6709\u4e00\u4e2a!', 'warning');
            return;
        }
        //end
        k.pathBody.appendChild(h);
        var d = new BaseMode(); //建立基础模型,内含属性
        d.id = h.id;
        //add by qw 2012.12.18 start
        d.type = k.getModeType(j);
        var T = $id("title" + i);
        T.innerHTML = k.getModeName(j);
        //end
        var b = com.xjwgraph.Global;
        b.modeMap.put(d.id, d);
        this.initEvent(i);
        b.smallTool.drawMode(h);
        var e = b.modeTool;
        e.flip(i);
        var a = new com.xjwgraph.UndoRedoEvent(function () {
            if ($id(h.id)) {
                b.smallTool.removeMode(h.id);
                e.pathBody.removeChild(h);
                b.modeMap.remove(h.id);
            }
        },
        PathGlobal.modeCreate);
        a.setRedo(function () {
            b.modeMap.put(d.id, d);
            e.pathBody.appendChild(h);
            e.showPointer(h);
            e.changeBaseModeAndLine(h, true);
            b.smallTool.drawMode(h);
        })
    },
    initEvent: function (a) {
        var b = com.xjwgraph.Global.modeTool;
        b.drag($id("content" + a));
        b.dragPoint($id("top_left" + a));
        b.dragPoint($id("top_middle" + a));
        b.dragPoint($id("top_right" + a));
        b.dragPoint($id("middle_left" + a));
        b.dragPoint($id("middle_right" + a));
        b.dragPoint($id("bottom_left" + a));
        b.dragPoint($id("bottom_middle" + a));
        b.dragPoint($id("bottom_right" + a));
        $id("content" + a).onclick = function () {
            b.showPointer($id("module" + a))
        }
    },
    clear: function () {
        var b = com.xjwgraph.Global,
        a = b.modeTool;
        this.forEach(function (c) {
            a.hiddPointer($id(c));
        });
        b.smallTool.clear();
    },
    toSelect: function () {
        //REP:BUG-001
        isSELECT = !isSELECT;
    },
    toTop: function () {
        var a = com.xjwgraph.Global.modeTool;
        this.forEach(function (d) {
            var c = $id(d),
            b = c.style;
            if (b.visibility == "visible") {
                b.zIndex = a.getNextIndex()
            } else {
                if (b.zIndex < 1) {
                    b.zIndex = 0
                } else {
                    b.zIndex = b.zIndex - 1
                }
            }
        })
    },
    toBottom: function () {
        this.forEach(function (c) {
            var b = $id(c),
            a = b.style;
            if (a.visibility == "visible") {
                a.zIndex = 0
            } else {
                if (a.zIndex == 0) {
                    a.zIndex = 1
                }
            }
        });
        stopEvent = true
    },
    forEach: function (d) {
        var a = com.xjwgraph.Global.modeMap.getKeys(),
        b = a.length;
        for (var c = b; c--; ) {
            if (d) {
                d(a[c])
            }
        }
        stopEvent = true
    },
    hiddPointer: function (e) {
        var d = this.getModeIndex(e);
        $id("module" + d).style.visibility = "hidden";
        $id("top_left" + d).style.visibility = "hidden";
        $id("top_middle" + d).style.visibility = "hidden";
        $id("top_right" + d).style.visibility = "hidden";
        $id("middle_left" + d).style.visibility = "hidden";
        $id("middle_right" + d).style.visibility = "hidden";
        $id("bottom_left" + d).style.visibility = "hidden";
        $id("bottom_middle" + d).style.visibility = "hidden";
        $id("bottom_right" + d).style.visibility = "hidden";
        var c = $id("rightMenu");
        c.style.visibility = "hidden";
        PathGlobal.rightMenu = false;
        var a = $id("topCross"),
        b = $id("leftCross");
        a.style.visibility = "hidden";
        b.style.visibility = "hidden";
        com.xjwgraph.Global.smallTool.clearMode($id("small" + e.id))
    },
    getModeIndex: function (b) {
        var a;
        if (b.className == "module") {
            a = 6
        } else {
            if (b.className == "content") {
                a = 7
            }
        }
        return b.id.substr(a)
    },
    showPointer: function (a) {
        this.showPointerId(this.getModeIndex(a))
    },
    showPointerId: function (i) {
        var d = $id("smallmodule" + i),
        p = com.xjwgraph.Global;
        if (d) {
            var a = d.style;
            a.borderWidth = "1px";
            a.borderColor = p.smallTool.checkColor;
            a.borderStyle = "solid"
        }
        var e = $id("module" + i);
        e.style.visibility = "visible";
        var r = $id("top_left" + i),
        b = r.style,
        n = r.offsetHeight,
        f = r.offsetWidth,
        k = e.offsetHeight,
        c = e.offsetWidth;
        $id("title" + i).style.width = c + "px";
        b.top = -n / 2 + "px";
        b.left = -f / 2 + "px";
        b.visibility = "visible";
        var g = $id("top_middle" + i).style;
        g.top = -n / 2 + "px";
        g.left = c / 2 - f / 2 + "px";
        g.visibility = "visible";
        var q = $id("top_right" + i).style;
        q.top = -n / 2 + "px";
        q.left = c - f / 2 + "px";
        q.visibility = "visible";
        var l = $id("middle_left" + i).style;
        l.top = k / 2 - n / 2 + "px";
        l.left = -f / 2 + "px";
        l.visibility = "visible";
        var h = $id("middle_right" + i).style;
        h.top = k / 2 - n / 2 + "px";
        h.left = c - f / 2 + "px";
        h.visibility = "visible";
        var o = $id("bottom_left" + i).style;
        o.top = k - n / 2 + "px";
        o.left = -f / 2 + "px";
        o.visibility = "visible";
        var s = $id("bottom_middle" + i).style;
        s.top = k - n / 2 + "px";
        s.left = c / 2 - f / 2 + "px";
        s.visibility = "visible";
        var m = $id("bottom_right" + i).style;
        m.top = k - n / 2 + "px";
        m.left = c - f / 2 + "px";
        m.visibility = "visible";
        var j = $id("backImg" + i).style;
        j.width = (c - 2) + "px";
        j.height = (k - 2) + "px";
        j.top = "0px";
        j.left = "0px";
        p.controlTool.print(i)
    },
    drag: function (f) {
        var b = f.parentNode,
        e = b.style,
        c = com.xjwgraph.Global,
        a = c.modeTool,
        d = c.lineTool;
        f.ondragstart = function () {
            return false
        };
        f.onclick = function () {
            d.clear();
            a.clear();
            a.showPointer(b)
        };
        f.ondblclick = function () {
            a.hiddPointer(b);
            a.flip(c.modeTool.getModeIndex(b))
        };
        f.onmousemove = function () {
            if (d.moveable) {
                a.showPointerId(c.modeTool.getModeIndex(b))
            }
        };
        f.onmouseout = function () {
            if (d.moveable) {
                a.hiddPointer(b)
            }
        };
        f.oncontextmenu = function (g) {
            a.showMenu(g, f);
            return false
        };
        f.onmousedown = function (j) {
            d.clear();
            a.clear();
            a.isModeCross(b);
            a.moveable = true;
            j = j || window.event;
            a.showPointer(b);
            if (b.setCapture) {
                b.setCapture()
            } else {
                if (window.captureEvents) {
                    window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                }
            }
            var h = j.layerX && j.layerX >= 0 ? j.layerX : j.offsetX,
            l = j.layerX && j.layerY >= 0 ? j.layerY : j.offsetY;
            stopEvent = true;
            var k = document,
            g = parseInt(b.offsetLeft),
            i = parseInt(b.offsetTop);
            k.onmousemove = function (p) {
                p = p || window.event;
                if (a.moveable) {
                    if (!p.pageX) {
                        p.pageX = p.clientX
                    }
                    if (!p.pageY) {
                        p.pageY = p.clientY
                    }
                    var n = p.pageX - h,
                    m = p.pageY - l,
                    o = c.lineTool.pathBody,
                    q = c.baseTool.sumLeftTop(o);
                    n = n - parseInt(q[0]) + parseInt(o.scrollLeft);
                    m = m - parseInt(q[1]) + parseInt(o.scrollTop);
                    e.left = n + "px";
                    e.top = m + "px";
                    a.isModeCross(b);
                    a.changeBaseModeAndLine(b, true);
                    a.showPointer(b);
                    c.smallTool.drawMode(b)
                }
            };
            k.onmouseup = function (n) {
                n = n || window.event;
                a.moveable = false;
                if (b.releaseCapture) {
                    b.releaseCapture();
                } else {
                    if (window.releaseEvents) {
                        window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP);
                    }
                }
                k.onmousemove = null;
                k.onmouseup = null;
                var p = parseInt(b.offsetLeft),
                o = parseInt(b.offsetTop);
                if (g != p || i != o) {
                    var m = new com.xjwgraph.UndoRedoEvent(function () {
                        b.style.left = g + "px";
                        b.style.top = i + "px";
                        a.showPointer(b);
                        a.changeBaseModeAndLine(b, true);
                        c.smallTool.drawMode(b)
                    },
                    PathGlobal.modeMove);
                    m.setRedo(function () {
                        e.left = p + "px";
                        e.top = o + "px";
                        a.showPointer(b);
                        a.changeBaseModeAndLine(b, true);
                        c.smallTool.drawMode(b)
                    })
                }
            }
        }
    },
    findModeLine: function (g, b) {
        var a = com.xjwgraph.Global.modeMap.get(g.id),
        f = a.lineMap,
        h = f.getKeys(),
        d = h.length;
        for (var c = d; c--; ) {
            var e = f.get(h[c]);
            if (b.id == e.id) {
                return e
            }
        }
        return null
    },
    changeLineType: function (k, f, b) {
        var i = this,
        j = com.xjwgraph.Global.lineMap.get(k.id),
        a = j.xBaseMode,
        h = j.wBaseMode,
        d,
        e;
        if (a) {
            d = $id(a.id)
        }
        if (h) {
            e = $id(h.id)
        }
        if (a && a.id == f.id) {
            if (e && d) {
                var c = i.findModeLine(e, k);
                if (e.offsetTop - (d.offsetTop + d.offsetHeight) > 0) {
                    b.index = PathGlobal.pointTypeDown;
                    c.index = PathGlobal.pointTypeUp
                } else {
                    if (d.offsetTop - (e.offsetTop + e.offsetHeight) > 0) {
                        b.index = PathGlobal.pointTypeUp;
                        c.index = PathGlobal.pointTypeDown
                    } else {
                        if (d.offsetLeft - (e.offsetLeft + e.offsetWidth) > 0) {
                            b.index = PathGlobal.pointTypeLeft;
                            c.index = PathGlobal.pointTypeRight
                        } else {
                            if (e.offsetLeft - (d.offsetLeft + d.offsetWidth) > 0) {
                                b.index = PathGlobal.pointTypeRight;
                                c.index = PathGlobal.pointTypeLeft
                            }
                        }
                    }
                }
                this.changeBaseModeAndLine(e, false)
            }
        }
        if (h && h.id == f.id) {
            if (e && d) {
                var g = i.findModeLine(d, k);
                if (d.offsetTop - (e.offsetTop + e.offsetHeight) > 0) {
                    b.index = PathGlobal.pointTypeDown;
                    g.index = PathGlobal.pointTypeUp
                } else {
                    if (e.offsetTop - (d.offsetTop + d.offsetHeight) > 0) {
                        b.index = PathGlobal.pointTypeUp;
                        g.index = PathGlobal.pointTypeDown
                    } else {
                        if (e.offsetLeft - (d.offsetLeft + d.offsetWidth) > 0) {
                            b.index = PathGlobal.pointTypeLeft;
                            g.index = PathGlobal.pointTypeRight
                        } else {
                            if (d.offsetLeft - (e.offsetLeft + e.offsetWidth) > 0) {
                                b.index = PathGlobal.pointTypeRight;
                                g.index = PathGlobal.pointTypeLeft
                            }
                        }
                    }
                }
                i.changeBaseModeAndLine(d, false)
            }
        }
        return b
    },
    changeBaseModeAndLine: function (j, l) {
        var q = this,
        o = 0,
        m = 0,
        b = com.xjwgraph.Global,
        g = b.modeMap.get(j.id),
        n = g.lineMap,
        d = n.getKeys(),
        a = d.length;
        for (var e = a; e--; ) {
            var c = n.get(d[e]),
            r = $id(c.id);
            if (r) {
                if (l && PathGlobal.isAutoLineType) {
                    q.changeLineType(r, j, c)
                }
                var p = j.offsetWidth,
                f = j.offsetHeight;
                if (c.index == PathGlobal.pointTypeUp) {
                    o = 0;
                    m = p / 2
                } else {
                    if (c.index == PathGlobal.pointTypeLeft) {
                        o = f / 2;
                        m = 0
                    } else {
                        if (c.index == PathGlobal.pointTypeDown) {
                            o = f;
                            m = p / 2
                        } else {
                            if (c.index == PathGlobal.pointTypeRight) {
                                o = f / 2;
                                m = p
                            }
                        }
                    }
                }
                o += parseInt(j.offsetTop);
                m += parseInt(j.offsetLeft);
                var k = b.lineTool;
                k.pathLine(m, o, r, c.type);
                k.setDragPoint(r)
            }
        }
    },
    dragPoint: function (a) {
        var b = com.xjwgraph.Global;
        a.onmousedown = function (q) {
            var f = a.parentNode,
            g = f.style,
            l = b.modeTool;
            l.isModeCross(f);
            var k = b.modeTool.getModeIndex(f),
            m = $id("backImg" + k),
            d = m.style,
            o = $id("content" + k),
            p = o.style,
            h = a.className,
            e = f.offsetTop,
            t = f.offsetLeft,
            n = f.offsetWidth,
            c = f.offsetHeight,
            r = new com.xjwgraph.UndoRedoEvent(function () {
                g.left = t + "px";
                g.top = e + "px";
                g.width = n + "px";
                g.height = c + "px";
                p.left = "0px";
                p.top = "0px";
                p.width = n + "px";
                p.height = c + "px";
                d.left = "0px";
                d.top = "0px";
                d.width = n + "px";
                d.height = c + "px";
                l.showPointer(f);
                l.changeBaseModeAndLine(f, true);
                b.smallTool.drawMode(f)
            },
            PathGlobal.modeDragPoint);
            b.modeTool.moveable = true;
            q = q || window.event;
            if (f.setCapture) {
                f.setCapture()
            } else {
                if (window.captureEvents) {
                    window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                }
            }
            var j = q.layerX && q.layerX >= 0 ? q.layerX : q.offsetX,
            i = q.layerX && q.layerY >= 0 ? q.layerY : q.offsetY;
            stopEvent = true;
            var s = document;
            s.onmousemove = function (v) {
                v = v || window.event;
                if (b.modeTool.moveable) {
                    if (!v.pageX) {
                        v.pageX = v.clientX
                    }
                    if (!v.pageY) {
                        v.pageY = v.clientY
                    }
                    var A = v.pageX - j,
                    y = v.pageY - i,
                    x = b.lineTool.pathBody,
                    C = b.baseTool.sumLeftTop(x);
                    A = A - parseInt(C[0]) + parseInt(x.scrollLeft);
                    y = y - parseInt(C[1]) + parseInt(x.scrollTop);
                    var w = PathGlobal.minWidth,
                    D = PathGlobal.minHeight;
                    if ("bottom_right" == h) {
                        if ((parseInt(A) - parseInt(f.offsetLeft)) < w) {
                            d.width = w + "px";
                            g.width = w + "px";
                            p.width = w + "px"
                        } else {
                            d.width = parseInt(A) - parseInt(f.offsetLeft) + "px";
                            g.width = parseInt(A) - parseInt(f.offsetLeft) + "px";
                            p.width = parseInt(A) - parseInt(f.offsetLeft) + "px"
                        }
                        if ((parseInt(y) - parseInt(f.offsetTop)) < D) {
                            d.height = D + "px";
                            g.height = D + "px";
                            p.height = D + "px"
                        } else {
                            d.height = parseInt(y) - parseInt(f.offsetTop) + "px";
                            g.height = parseInt(y) - parseInt(f.offsetTop) + "px";
                            p.height = parseInt(y) - parseInt(f.offsetTop) + "px"
                        }
                    } else {
                        if ("bottom_middle" == h) {
                            if ((parseInt(y) - parseInt(f.offsetTop)) < D) {
                                d.height = D + "px";
                                g.height = D + "px";
                                p.height = D + "px"
                            } else {
                                d.height = parseInt(y) - parseInt(f.offsetTop) + "px";
                                g.height = parseInt(y) - parseInt(f.offsetTop) + "px";
                                p.height = parseInt(y) - parseInt(f.offsetTop) + "px"
                            }
                        } else {
                            if ("bottom_left" == h) {
                                if (parseInt(y) - parseInt(f.offsetTop) < D) {
                                    d.height = D + "px";
                                    g.height = D + "px";
                                    p.height = D + "px"
                                } else {
                                    d.height = parseInt(y) - parseInt(f.offsetTop) + "px";
                                    g.height = parseInt(y) - parseInt(f.offsetTop) + "px";
                                    p.height = parseInt(y) - parseInt(f.offsetTop) + "px"
                                }
                                var z = 0;
                                if (parseInt(A) > parseInt(t)) {
                                    z = parseInt(A) - parseInt(t);
                                    z = parseInt(n) - z;
                                    if (z <= w) {
                                        z = w;
                                        A = parseInt(n) - w + parseInt(t)
                                    }
                                } else {
                                    z = parseInt(t) - parseInt(A);
                                    z = parseInt(n) + z;
                                    if (z <= w) {
                                        z = w;
                                        A = w - parseInt(n) + parseInt(t)
                                    }
                                }
                                d.width = z + "px";
                                g.width = z + "px";
                                p.width = z + "px";
                                g.left = parseInt(A) + "px"
                            } else {
                                if ("middle_right" == h) {
                                    if (parseInt(A) - parseInt(f.offsetLeft) < w) {
                                        d.width = w + "px";
                                        g.width = w + "px";
                                        p.width = w + "px"
                                    } else {
                                        d.width = parseInt(A) - parseInt(f.offsetLeft) + "px";
                                        g.width = parseInt(A) - parseInt(f.offsetLeft) + "px";
                                        p.width = parseInt(A) - parseInt(f.offsetLeft) + "px"
                                    }
                                } else {
                                    if ("middle_left" == h) {
                                        var z = 0;
                                        if (parseInt(A) > parseInt(t)) {
                                            z = parseInt(A) - parseInt(t);
                                            z = parseInt(n) - z;
                                            if (z <= w) {
                                                z = w;
                                                A = parseInt(n) - w + parseInt(t)
                                            }
                                        } else {
                                            z = parseInt(t) - parseInt(A);
                                            z = parseInt(n) + z;
                                            if (z <= w) {
                                                z = w;
                                                A = w - parseInt(n) + parseInt(t)
                                            }
                                        }
                                        d.width = z + "px";
                                        g.width = z + "px";
                                        p.width = z + "px";
                                        g.left = parseInt(A) + "px"
                                    } else {
                                        if ("top_right" == h) {
                                            var z = 0;
                                            if (parseInt(A) > (parseInt(t) + parseInt(n))) {
                                                z = parseInt(A) - (parseInt(t) + parseInt(n));
                                                z = parseInt(n) + z;
                                                if (z <= w) {
                                                    z = w
                                                }
                                            } else {
                                                z = (parseInt(t) + parseInt(n)) - parseInt(A);
                                                z = parseInt(n) - z;
                                                if (z <= w) {
                                                    z = w
                                                }
                                            }
                                            d.width = z + "px";
                                            g.width = z + "px";
                                            p.width = z + "px";
                                            var u = 0;
                                            if (parseInt(y) > parseInt(e)) {
                                                u = parseInt(y) - parseInt(e);
                                                u = parseInt(c) - parseInt(u);
                                                if (u <= D) {
                                                    u = D;
                                                    y = parseInt(c) - D + parseInt(e)
                                                }
                                            } else {
                                                u = parseInt(e) - parseInt(y);
                                                u = parseInt(c) + parseInt(u);
                                                if (u <= D) {
                                                    u = D;
                                                    y = D - parseInt(c) + parseInt(e)
                                                }
                                            }
                                            d.height = u + "px";
                                            g.height = u + "px";
                                            p.height = u + "px";
                                            g.top = parseInt(y) + "px"
                                        } else {
                                            if ("top_middle" == h) {
                                                var u = 0;
                                                if (parseInt(y) > parseInt(e)) {
                                                    u = parseInt(y) - parseInt(e);
                                                    u = parseInt(c) - parseInt(u);
                                                    if (u <= D) {
                                                        u = D;
                                                        y = parseInt(c) + parseInt(e) - D
                                                    }
                                                } else {
                                                    u = parseInt(e) - parseInt(y);
                                                    u = parseInt(c) + parseInt(u);
                                                    if (u <= D) {
                                                        u = D;
                                                        y = D - parseInt(c) + parseInt(e)
                                                    }
                                                }
                                                d.height = u + "px";
                                                p.height = u + "px";
                                                g.height = u + "px";
                                                g.top = parseInt(y) + "px"
                                            } else {
                                                if ("top_left" == h) {
                                                    var z = 0;
                                                    if (parseInt(A) > parseInt(t)) {
                                                        z = parseInt(A) - parseInt(t);
                                                        z = parseInt(n) - z;
                                                        if (z <= w) {
                                                            z = w;
                                                            A = parseInt(n) - w + parseInt(t)
                                                        }
                                                    } else {
                                                        z = parseInt(t) - parseInt(A);
                                                        z = parseInt(n) + z;
                                                        if (z <= w) {
                                                            z = w;
                                                            A = w - parseInt(n) + parseInt(t)
                                                        }
                                                    }
                                                    d.width = z + "px";
                                                    g.width = z + "px";
                                                    p.width = z + "px";
                                                    var u = 0;
                                                    if (parseInt(y) > parseInt(e)) {
                                                        u = parseInt(y) - parseInt(e);
                                                        u = parseInt(c) - parseInt(u);
                                                        if (u <= D) {
                                                            u = D;
                                                            y = parseInt(c) + parseInt(e) - D
                                                        }
                                                    } else {
                                                        u = parseInt(e) - parseInt(y);
                                                        u = parseInt(c) + parseInt(u);
                                                        if (u <= D) {
                                                            u = D;
                                                            y = D - parseInt(c) + parseInt(e)
                                                        }
                                                    }
                                                    d.height = u + "px";
                                                    g.height = u + "px";
                                                    p.height = u + "px";
                                                    g.top = parseInt(y) + "px";
                                                    g.left = parseInt(A) + "px"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    var B = b.modeTool;
                    B.isModeCross(f);
                    B.showPointer(f);
                    B.changeBaseModeAndLine(f, true);
                    b.smallTool.drawMode(f)
                }
            };
            s.onmouseup = function (v) {
                v = v || window.event;
                b.modeTool.moveable = false;
                if (f.releaseCapture) {
                    f.releaseCapture()
                } else {
                    if (window.releaseEvents) {
                        window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                    }
                }
                var x = f.offsetTop,
                y = f.offsetLeft,
                w = f.offsetWidth,
                u = f.offsetHeight;
                r.setRedo(function () {
                    g.left = y + "px";
                    g.top = x + "px";
                    g.width = w + "px";
                    g.height = u + "px";
                    d.left = "0px";
                    d.top = "0px";
                    d.width = w + "px";
                    d.height = u + "px";
                    p.top = "0px";
                    p.left = "0px";
                    p.width = w + "px";
                    p.height = u + "px";
                    l.showPointer(f);
                    l.changeBaseModeAndLine(f, true);
                    b.smallTool.drawMode(f)
                });
                s.onmousemove = null;
                s.onmouseup = null
            }
        }
    },
    isActiveMode: function (a) {
        return a.style.visibility == "visible"
    },
    getActiveMode: function () {
        var b,
        a = com.xjwgraph.Global.modeTool;
        this.forEach(function (d) {
            var c = $id(d);
            if (a.isActiveMode(c)) {
                b = c
            }
        });
        return b
    },
    getSonNode: function (e, b) {
        for (var c = e.firstChild; c != null; c = c.nextSibling) {
            if (c.nodeType == 1) {
                var d = c.className;
                if (d == b) {
                    return c
                }
                if (d == "content" && b == "backImg") {
                    for (var a = c.firstChild; a != null; a = a.nextSibling) {
                        if (a.nodeType == 1) {
                            return a
                        }
                    }
                }
            }
        }
    },
    setIndex: function (e, d) {
        e.id = "module" + d;
        for (var b = e.firstChild; b != null; b = b.nextSibling) {
            if (b.nodeType == 1) {
                var c = b.className;
                b.id = c + d;
                if (c == "content") {
                    for (var a = b.firstChild; a != null; a = a.nextSibling) {
                        if (a.nodeType == 1) {
                            a.id = "backImg" + d;
                            break
                        }
                    }
                }
            }
        }
        return e
    },
    copy: function (h) {
        var c = this,
        b = h.cloneNode(true),
        g = c.getNextIndex();
        c.setIndex(b, g);
        var e = b.style;
        e.left = parseInt(e.left) + PathGlobal.copyModeDec + "px";
        e.top = parseInt(e.top) + PathGlobal.copyModeDec + "px";
        var a = new BaseMode();
        a.id = b.id;
        var d = com.xjwgraph.Global;
        d.modeMap.put(a.id, a);
        var f = d.lineTool;
        f.pathBody.appendChild(b);
        this.initEvent(g);
        return b
    },
    flip: function (g, a) {
        var c = com.xjwgraph.Global.modeMap.get("module" + g);
        if (c.isFilp) {
            return
        }
        c.isFilp = true;
        var f = $id("backImg" + g),
        e = f.height,
        d = $id("content" + g),
        i = d.style;
        c.modeHeigh = e;
        i.width = f.width + "px";
        i.fontSize = (e - parseInt(e * 0.15)) + "px";
        i.lineHeight = e + "px";
        i.height = e + "px";
        var b = $id(c.id),
        h = b.style;
        h.width = f.width + "px";
        h.height = e + "px";
        c.inc = c.modeHeigh / 10;
        this.doFlip(g, a)
    },
    doFlip: function (h, d) {
        var b = $id("backImg" + h);
        if (!b) {
            return
        }
        var e = com.xjwgraph.Global,
        c = b.height,
        g = e.modeMap.get("module" + h);
        c = c - g.inc;
        if (c < 1) {
            c = 1
        }
        if (c <= 1) {
            g.inc = -g.inc
        } else {
            if (c >= g.modeHeigh) {
                $id("backImg" + h).style.height = g.modeHeigh + "px";
                g.modeHeigh = 0;
                g.isFilp = false;
                g.inc = -g.inc;
                var a = $id("content" + h).style;
                a.width = 0 + "px";
                a.height = 0 + "px";
                a.lineHeight = 0 + "px";
                a.fontSize = 0 + "px";
                var f = $id("title" + h);
                if (d == "undefined" || !d) { } else {
                    f.innerHTML = d
                }
                this.showPointerId(h);
                return
            } else {
                $id("backImg" + h).style.height = c + "px"
            }
        }
        setTimeout(function () {
            e.modeTool.doFlip(h, d)
        },
        PathGlobal.pauseTime)
    },
    isModeCross: function (k) {
        var e = parseInt(k.offsetLeft),
        c = k.offsetWidth + e,
        a = parseInt(k.offsetWidth / 2) + e,
        h = parseInt(k.offsetTop),
        l = k.offsetHeight + h,
        g = parseInt(k.offsetHeight / 2) + h,
        n = $id("leftCross"),
        w = $id("topCross"),
        u = n.style,
        x = w.style,
        d = com.xjwgraph.Global.modeMap.getKeys(),
        s = false,
        j = false,
        m = d.length;
        for (var t = m; t--; ) {
            var o = $id(d[t]);
            if (k.id == o.id) {
                continue
            }
            var f = parseInt(o.offsetLeft),
            q = o.offsetWidth + f,
            b = parseInt(o.offsetWidth / 2) + f,
            p = parseInt(o.offsetTop),
            r = o.offsetHeight + p,
            v = parseInt(o.offsetHeight / 2) + p;
            if (e == f || e == q) {
                n.style.left = e;
                j = true;
                n.style.visibility = "visible"
            }
            if (c == f || c == q) {
                u.left = c;
                j = true;
                u.visibility = "visible"
            }
            if (a == f || a == b) {
                u.left = a;
                j = true;
                u.visibility = "visible"
            }
            if (a == q) {
                u.left = a;
                j = true;
                u.visibility = "visible"
            }
            if (e == b || c == b) {
                u.left = b;
                j = true;
                u.visibility = "visible"
            }
            if (h == p || h == r) {
                x.top = h;
                s = true;
                x.visibility = "visible"
            }
            if (h == v || v == g || v == l) {
                x.top = v;
                s = true;
                x.visibility = "visible"
            }
            if (g == p || g == r) {
                x.top = g;
                s = true;
                x.visibility = "visible"
            }
            if (v == g) {
                x.top = v;
                s = true;
                x.visibility = "visible"
            }
            if (l == p || l == r) {
                x.top = l;
                s = true;
                x.visibility = "visible"
            }
        }
        if (!s) {
            x.visibility = "hidden"
        }
        if (!j) {
            u.visibility = "hidden"
        }
    }
};
var Map = com.xjwgraph.Map = function () {
    var a = this;
    a.map = new Object();
    a.length = 0
};
Map.prototype = {
    size: function () {
        return this.length
    },
    clear: function () {
        var a = this;
        a.map = new Object();
        a.length = 0
    },
    put: function (b, c) {
        var a = this;
        if (!a.map["_" + b]) {
            ++a.length
        }
        a.map["_" + b] = c
    },
    putAll: function (a) {
        var f = a.getKeys(),
        d = f.length,
        c = this;
        for (var e = d; e--; ) {
            var b = f[e];
            c.put(b, a.get(b))
        }
    },
    remove: function (b) {
        var a = this;
        if (a.map["_" + b]) {
            --a.length;
            return delete a.map["_" + b]
        } else {
            return false
        }
    },
    containsKey: function (a) {
        return this.map["_" + a] ? true : false
    },
    get: function (b) {
        var a = this;
        return a.map["_" + b] ? a.map["_" + b] : null
    },
    inspect: function () {
        var c = "",
        a = this;
        for (var b in a.map) {
            c += "\n" + b + "  Value:" + a.map[b]
        }
        return c
    },
    getKeys: function () {
        var d = new Array(),
        b = 0,
        a = this;
        for (var c in a.map) {
            d[b++] = c.replace("_", "")
        }
        return d
    }
};
var BaseMode = com.xjwgraph.BaseMode = function () {
    var a = this;
    a.id;
    //add by qw 2012.12.18 start
    a.type;
    //a.desc;
    //end
    a.lineMap = new Map();
    //mod by qw 2012.12.18 目前还不需要
    //attri1: "2"
    a.prop = {
};

};
var BuildLine = com.xjwgraph.BuildLine = function () {
    var a = this;
    a.id;
    a.index;
    a.xIndex;
    a.wIndex;
    a.type;
    a.xBaseMode; //起点
    a.wBaseMode; //止点
    a.sNodeId;
    a.eNodeId;
    //attri1: "3",
    a.prop = {
        XH: "1"
    };

};
var Point = com.xjwgraph.Point = function () {
    var a = this;
    a.x = 0;
    a.y = 0;
    a.index = 0
};
var KeyDownFactory = com.xjwgraph.KeyDownFactory = function () { };
KeyDownFactory.prototype = {
    removeNode: function () {
        var o = com.xjwgraph.Global,
        m = o.lineTool,
        g = o.baseTool,
        d = m.pathBody,
        f = m.svgBody,
        k = o.smallTool,
        h = o.modeTool,
        r = [],
        n = [],
        q = 0,
        b = false,
        c = [],
        l = [],
        p = 0,
        t = false,
        a = null;
        h.forEach(function (w) {
            var v = $id(w);
            if (h.isActiveMode(v)) {
                n[q] = o.modeMap.get(v.id);
                r[q++] = v;
                a = o.modeMap.get(w).lineMap,
                baseLineKey = a.getKeys(),
                baseLineKeyLength = baseLineKey.length;
                for (var j = baseLineKeyLength; j--; ) {
                    var u = a.get(baseLineKey[j]),
                    i = $id(u.id);
                    if (i) {
                        l[p] = com.xjwgraph.Global.lineMap.get(i.id);
                        c[p++] = i;
                        o.lineTool.removeNode(u.id)
                    }
                }
                o.modeTool.removeNode(w);
                b = true
            }
        });
        o.baseTool.clearContext();
        if (b) {
            var s = new com.xjwgraph.UndoRedoEvent(function () {
                var B = c.length,
                w = null;
                for (var y = B; y--; ) {
                    var A = c[y],
                    u = A.getAttribute("id");
                    if (m.isVML) {
                        A.setAttribute("coordsize", "100,100");
                        A.setAttribute("filled", "f");
                        A.setAttribute("strokeweight", PathGlobal.strokeweight + "px");
                        A.setAttribute("strokecolor", PathGlobal.lineColor);
                        w = d
                    } else {
                        if (m.isSVG) {
                            w = f
                        }
                    }
                    if (!$id(u)) {
                        w.appendChild(A);
                        w.appendChild(m.createRect(u + "lineHead"));
                        w.appendChild(m.createRect(u + "lineMiddle"));
                        w.appendChild(m.createRect(u + "lineEnd"));
                        m.drag(A);
                        o.lineMAp.put(A.id, l[y]);
                        k.drawLine(A)
                    }
                }
                var x = r.length;
                for (var z = x; z--; ) {
                    var v = r[z];
                    o.modeMap.put(v.id, n[z]);
                    d.appendChild(v);
                    h.showPointer(v);
                    k.drawMode(v)
                }
            },
            PathGlobal.removeMode);
            s.setRedo(function () {
                var x = c.length;
                for (var w = x; w--; ) {
                    var v = c[w];
                    m.removeNode(v.id)
                }
                var u = r.length;
                for (var w = u; w--; ) {
                    var j = r[w];
                    o.modeTool.removeNode(j.id)
                }
            })
        }
        m.forEach(function (i) {
            var j = $id(i);
            if (m.isActiveLine(j)) {
                l[p] = com.xjwgraph.Global.lineMap.get(j.id);
                c[p++] = j;
                m.removeNode(j.id);
                t = true
            }
        });
        if (t) {
            var e = new com.xjwgraph.UndoRedoEvent(function () {
                var x = c.length,
                u = null;
                for (var v = x; v--; ) {
                    var w = c[v],
                    i = w.getAttribute("id");
                    if (m.isVML) {
                        w.setAttribute("coordsize", "100,100");
                        w.setAttribute("filled", "f");
                        w.setAttribute("strokeweight", PathGlobal.strokeweight + "px");
                        w.setAttribute("strokecolor", PathGlobal.lineColor);
                        u = d
                    } else {
                        if (m.isSVG) {
                            u = f
                        }
                    }
                    if (!$id(i)) {
                        u.appendChild(w);
                        u.appendChild(m.createRect(i + "lineHead"));
                        u.appendChild(m.createRect(i + "lineMiddle"));
                        u.appendChild(m.createRect(i + "lineEnd"));
                        m.drag(w);
                        o.lineMap.put(w.id, l[v]);
                        k.drawLine(w)
                    }
                }
            },
            PathGlobal.remodeLine);
            e.setRedo(function () {
                var v = c.length;
                for (var u = v; u--; ) {
                    var j = c[u];
                    m.removeNode(j.id)
                }
            })
        }
    },
    copyNode: function () {
        var f = com.xjwgraph.Global,
        b = f.modeTool,
        a = [],
        d = 0,
        c = f.smallTool;
        b.forEach(function (j) {
            var i = $id(j);
            if (b.isActiveMode(i)) {
                var h = f.modeTool.copy(i);
                a[d++] = h;
                b.hiddPointer(i);
                c.drawMode(h)
            }
        });
        var g = f.lineTool;
        if (a.length > 0) {
            var e = new com.xjwgraph.UndoRedoEvent(function () {
                var j = a.length;
                for (var k = j; k--; ) {
                    var h = a[k];
                    if (h && h.id && $id(h.id)) {
                        f.modeMap.remove(h.id);
                        g.pathBody.removeChild(h);
                        c.removeMode(h.id)
                    }
                }
            },
            PathGlobal.copyMode);
            e.setRedo(function () {
                var k = a.length;
                for (var l = k; l--; ) {
                    var j = a[l];
                    var h = new BaseMode();
                    h.id = j.id;
                    f.modeMap.put(j.id, h);
                    g.pathBody.appendChild(j);
                    b.showPointer(j);
                    c.drawMode(j)
                }
            })
        }
    }
};
var keyDownFactory = new KeyDownFactory();
function KeyDown(a) {
    a = a || window.event;
    if (a.keyCode == 46) {
        keyDownFactory.removeNode()
    }
    if (a.ctrlKey) {
        switch (a.keyCode) {
            case 77:
                keyDownFactory.removeNode();
                break;
            case 86:
                keyDownFactory.copyNode();
                break
        }
    }
}
var SmallMapTool = com.xjwgraph.SmallMapTool = function (c, a) {
    var b = this;
    b.smallMap = $id(c);
    b.body = $id(a);
    b.multiple = b.getMultiple();
    b.defaultColor = PathGlobal.defaultColor;
    b.checkColor = "#00ff00";
    b.widthPercent = b.smallMap.offsetWidth / parseInt(b.body.scrollWidth) / b.multiple;
    b.heightPercent = b.smallMap.offsetHeight / parseInt(b.body.scrollHeight) / b.multiple;
    b.percent = 0;
    b.initPercent();
    b.smallModeMap = new Map();
    b.smallLineMap = new Map();
    var d = document;
    if (com.xjwgraph.Global.lineTool.isSVG) {
        b.svgBody = d.createElementNS("http://www.w3.org/2000/svg", "svg");
        b.svgBody.setAttribute("id", "smallSvgContext");
        b.svgBody.setAttribute("height", "100%");
        b.svgBody.setAttribute("width", "100%");
        b.svgBody.setAttribute("style", "position:absolute;z-index:0;");
        b.smallMap.appendChild(b.svgBody)
    }
    b.smallBody = d.createElement("div");
    b.smallBody.id = "smallBodyId";
    var e = b.smallBody.style;
    e.fontSize = "0px";
    e.borderWidth = "2px";
    e.borderColor = "#0F0";
    e.borderStyle = "solid";
    e.position = "absolute";
    e.cursor = "pointer";
    b.drag(b.smallBody);
    b.smallMap.appendChild(b.smallBody);
    b.scalingDiv = d.createElement("div");
    b.scalingDiv.id = "scalingId";
    b.scalingDiv.setAttribute("class", "scaling");
    b.scalingDiv.setAttribute("className", "scaling");
    b.dragScaling(b.scalingDiv);
    b.smallMap.appendChild(b.scalingDiv);
    b.initSmallBody()
};
SmallMapTool.prototype = {
    dragScaling: function (b) {
        var a = com.xjwgraph.Global;
        b.ondragstart = function () {
            return false
        };
        b.onmousedown = function (c) {
            var l = 1,
            h = a.smallTool,
            e = b.style,
            d = h.smallBody.style,
            f = d.width,
            k = d.height;
            c = c || window.event;
            if (b.setCapture) {
                b.setCapture()
            } else {
                if (window.captureEvents) {
                    window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                }
            }
            var i = c.layerX ? c.layerX : c.offsetX,
            g = c.layerY ? c.layerY : c.offsetY,
            j = document;
            j.onmousemove = function (s) {
                s = s || window.event;
                if (!s.pageX) {
                    s.pageX = s.clientX
                }
                if (!s.pageY) {
                    s.pageY = s.clientY
                }
                var o = s.pageX - i,
                m = s.pageY - g,
                q = h.smallMap,
                p = a.baseTool.sumLeftTop(q);
                o = o - parseInt(p[0]);
                m = m - parseInt(p[1]);
                if (a.baseTool.isIE) {
                    o = o - 4;
                    m = m - 4
                }
                e.left = o + "px";
                e.top = m + "px";
                var r = o + 1 - parseInt(d.left),
                n = m + 1 - parseInt(d.top);
                if (r < 1) {
                    r = 1
                }
                if (n < 1) {
                    n = 1
                }
                d.width = r + "px";
                d.height = n + "px";
                l = parseInt(d.width) / parseInt(f);
                if (l < PathGlobal.defaultMaxMag) {
                    l = PathGlobal.defaultMaxMag
                } else {
                    if (l > PathGlobal.defaultMinMag) {
                        l = PathGlobal.defaultMinMag
                    }
                }
                a.undoRedoEventFactory.clear()
            };
            j.onmouseup = function (m) {
                m = m || window.event;
                if (b.releaseCapture) {
                    b.releaseCapture()
                } else {
                    if (window.releaseEvents) {
                        window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                    }
                }
                a.lineTool.initScaling(l);
                a.modeTool.initScaling(l);
                a.baseTool.initScaling(l);
                h.initSmallBody();
                j.onmousemove = null;
                j.onmouseup = null
            }
        }
    },
    drag: function (a) {
        var b = com.xjwgraph.Global;
        a.ondragstart = function () {
            return false
        };
        a.onmousedown = function (d) {
            d = d || window.event;
            if (a.setCapture) {
                a.setCapture()
            } else {
                if (window.captureEvents) {
                    window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                }
            }
            var c = d.layerX ? d.layerX : d.offsetX,
            f = d.layerY ? d.layerY : d.offsetY,
            e = document;
            e.onmousemove = function (m) {
                m = m || window.event;
                if (!m.pageX) {
                    m.pageX = m.clientX
                }
                if (!m.pageY) {
                    m.pageY = m.clientY
                }
                var h = m.pageX - c,
                g = m.pageY - f,
                l = b.smallTool,
                k = l.smallMap,
                j = b.baseTool.sumLeftTop(k);
                h = h - parseInt(j[0]);
                g = g - parseInt(j[1]);
                if (h < 0) {
                    h = 0
                }
                if (g < 0) {
                    g = 0
                }
                a.style.left = h + "px";
                a.style.top = g + "px";
                var n = b.lineTool,
                l = b.smallTool,
                i = $id(n.pathBody.id);
                i.scrollLeft = parseInt(h / l.widthPercent);
                i.scrollTop = parseInt(g / l.heightPercent);
                l.initSmallBody()
            };
            e.onmouseup = function (g) {
                g = g || window.event;
                if (a.releaseCapture) {
                    a.releaseCapture()
                } else {
                    if (window.releaseEvents) {
                        window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP)
                    }
                }
                e.onmousemove = null;
                e.onmouseup = null
            }
        }
    },
    initSmallBody: function () {
        var a = this,
        e = a.smallBody.style;
        e.left = a.body.scrollLeft * a.widthPercent + "px";
        e.top = a.body.scrollTop * a.heightPercent + "px";
        e.width = a.body.offsetWidth * a.widthPercent + "px";
        e.height = a.body.offsetHeight * a.heightPercent + "px";
        var b = a.scalingDiv.style,
        d = parseInt(e.left) + parseInt(e.width),
        c = parseInt(e.top) + parseInt(e.height);
        if (com.xjwgraph.Global.baseTool.isIE) {
            d = d - 4;
            c = c - 4
        }
        b.left = d + "px";
        b.top = c + "px"
    },
    getMultiple: function () {
        var c = this,
        b = c.body.style,
        a = (parseInt(c.body.scrollWidth) + parseInt(c.body.scrollHeight)) / (parseInt(b.width) + parseInt(b.height));
        if (a > 1.82) {
            a = a - 0.82
        } else {
            if (a < 1.2) {
                a = 1.2
            }
        }
        return a
    },
    initPercent: function () {
        var a = this;
        a.multiple = a.getMultiple();
        a.widthPercent = a.smallMap.offsetWidth / parseInt(a.body.scrollWidth);
        a.heightPercent = a.smallMap.offsetHeight / parseInt(a.body.scrollHeight);
        a.percent = a.heightPercent <= a.widthPercent ? a.heightPercent : a.widthPercent
    },
    activeMode: function (c) {
        var a = com.xjwgraph.Global;
        a.modeTool.clear();
        a.lineTool.clear(); //qw
        var b = $id("small" + c).style;
        b.borderWidth = "1px";
        b.borderColor = a.smallTool.checkColor;
        b.borderStyle = "solid";
        stopEvent = true
    },
    drawMode: function (e) {
        var b = null,
        a = this;
        if ($id("small" + e.id)) {
            b = $id("small" + e.id)
        } else {
            b = document.createElement("img");
            b.ondragstart = function () {
                return false
            };
            b.id = "small" + e.id;
            b.style.position = "absolute";
            b.onclick = function () {
                var f = com.xjwgraph.Global;
                f.modeTool.flip(e.id.substring("modelu".length));
                f.smallTool.activeMode(e.id)
            };
            a.smallMap.appendChild(b)
        }
        a.smallModeMap.put(b.id, b);
        b = $id(b.id);
        var c = e.id.replace("module", "backImg");
        b.src = $id(c).src;
        var d = b.style;
        d.fontSize = "0px";
        d.left = e.offsetLeft * a.widthPercent + "px";
        d.top = e.offsetTop * a.heightPercent + "px";
        d.width = e.offsetWidth * a.percent + "px";
        d.height = e.offsetHeight * a.percent + "px";
        d.borderWidth = "1px";
        d.borderColor = com.xjwgraph.Global.smallTool.checkColor;
        d.borderStyle = "solid"
    },
    _smallPath: function (e) {
        var d = com.xjwgraph.Global.lineTool,
        f = d.getPathArray(e),
        c = f.length,
        a = this;
        for (var b = c; b--; ) {
            if (b % 2 == 1) {
                f[b] = parseInt(f[b] * a.heightPercent)
            } else {
                f[b] = parseInt(f[b] * a.widthPercent)
            }
        }
        return d.arrayToPath(f)
    },
    drawLine: function (m) {
        var d = com.xjwgraph.Global,
        h = d.lineTool,
        l = h.getPath(m),
        i = h.getLineHead(l),
        f = h.getLineEnd(l),
        j = this,
        e = parseInt(i[0]) * j.widthPercent,
        c = parseInt(i[1]) * j.heightPercent,
        a = parseInt(f[0]) * j.widthPercent,
        k = parseInt(f[1]) * j.heightPercent,
        b = m.getAttribute("brokenType");
        l = j._smallPath(l);
        var g = null;
        if (j.smallLineMap.get("small" + m.id) && $id("small" + m.id)) {
            g = $id("small" + m.id);
            d.lineTool.setPath(g, l)
        } else {
            if (h.isSVG) {
                g = document.createElementNS("http://www.w3.org/2000/svg", "path");
                g.setAttribute("id", "small" + m.id);
                g.setAttribute("style", "fill:none; stroke:" + PathGlobal.lineColor + "; stroke-width:1");
                d.lineTool.setPath(g, l);
                j.svgBody.appendChild(g)
            } else {
                if (h.isVML) {
                    g = document.createElement('<v:shape id="small' + m.id + '" style="WIDTH:100;POSITION:absolute;HEIGHT:100" coordsize="100,100" filled="f" strokeweight="1px" strokecolor="' + PathGlobal.lineColor + '" path="' + l + '"></v:shape>');
                    j.smallMap.appendChild(g)
                }
            }
            j.smallLineMap.put(g.id, g)
        }
    },
    drawAll: function () {
        var a = this;
        a.drawAllMode();
        a.drawAllLine()
    },
    drawAllMode: function () {
        var a = com.xjwgraph.Global;
        a.modeTool.forEach(function (b) {
            a.smallTool.drawMode($id(b))
        })
    },
    drawAllLine: function () {
        var a = com.xjwgraph.Global;
        a.lineTool.forEach(function (b) {
            a.smallTool.drawLine($id(b))
        })
    },
    removeAll: function () {
        var a = this;
        a.removeAllMode();
        a.removeAllLine()
    },
    removeAllMode: function () {
        com.xjwgraph.Global.modeTool.forEach(this.removeMode)
    },
    removeAllLine: function () {
        com.xjwgraph.Global.lineTool.forEach(this.removeLine)
    },
    removeMode: function (b) {
        var a = $id("small" + b);
        this.smallModeMap.remove(a.id);
        a.parentNode.removeChild(a)
    },
    removeLine: function (a) {
        var b = $id("small" + a);
        b.parentNode.removeChild(b);
        //add by qw 2012.12.28 start
        var sLXHDiv = $id("showLineXH");
        if (sLXHDiv) {
            sLXHDiv.innerHTML = "";
            sLXHDiv.style.visibility = "hidden";
        }
        //end
    },
    clear: function () {
        this.forEachMode(this.clearMode)
    },
    clearMode: function (a) {
        if (a && a.id) {
            if (a.id.indexOf("module") > 0) {
                a.style.border = "none"
            }
        }
    },
    forEachMode: function (d) {
        var b = this;
        var a = b.smallMap.childNodes.length;
        for (var c = a; c--; ) {
            if (d) {
                d(b.smallMap.childNodes[c])
            }
        }
    },
    initDraw: function () {
        var a = this;
        a.removeAll();
        a.initPercent();
        a.drawAll()
    }
};
var ControlTool = com.xjwgraph.ControlTool = function (b) {
    var a = this,
    c = document;
    a.mainBody = b;
    a.indexId;
    var d = function (f, e) {
        f.onkeydown = function (g) {
            g = g || window.event;
            if (g.keyCode == 13) {
                a.submit();
                //alert("提交数据");
            }
        };
        if (e) {
            return
        }
        f.setAttribute("class", "inputComm");
        f.setAttribute("className", "inputComm");
        f.onclick = function () {
            this.setAttribute("class", "inputClick");
            this.setAttribute("className", "inputClick")
        };
        f.onblur = function () {
            this.setAttribute("class", "inputComm");
            this.setAttribute("className", "inputComm")
        }
    };
    a.inputTitle = $id("inputTitle");
    d(a.inputTitle);
    a.inputWidth = $id("inputWidth");
    d(a.inputWidth);
    a.inputHeight = $id("inputHeight");
    d(a.inputHeight);
    a.inputTop = $id("inputTop");
    d(a.inputTop);
    a.inputLeft = $id("inputLeft");
    d(a.inputLeft);
    a.inputImgSrc = $id("inputImgSrc");
    d(a.inputImgSrc);
    a.modeContent = $id("modeContent");
    d(a.modeContent, true)
};
ControlTool.prototype = {
    submit: function () {
        var a = com.xjwgraph.Global,
        N = a.controlTool;
        if (!$id("module" + N.indexId)) {
            return
        }
        var l = $id("module" + N.indexId),
        e = l.style,
        k = $id("backImg" + N.indexId),
        m = k.style,
        n = $id("content" + N.indexId),
        F = n.style,
        B = $id("title" + N.indexId),
        L = B.style,
        p = parseInt(l.offsetWidth),
        A = parseInt(l.offsetHeight),
        z = parseInt(e.top),
        H = parseInt(e.left),
        u = parseInt(k.offsetWidth),
        b = parseInt(k.offsetHeight),
        y = parseInt(m.top),
        s = parseInt(m.left),
        J = k.src,
        M = parseInt(n.offsetWidth),
        I = parseInt(n.offsetHeight),
        o = parseInt(F.top),
        x = parseInt(F.left),
        r = l.getAttribute("modeContent"),
        E = B.innerHTML,
        w = a.modeTool;
        var f = new com.xjwgraph.UndoRedoEvent(function () {
            if (p) {
                e.width = p + "px"
            }
            if (A) {
                e.height = A + "px"
            }
            if (z) {
                e.top = z + "px"
            }
            if (H) {
                e.left = H + "px"
            }
            if (u) {
                m.width = u + "px"
            }
            if (b) {
                m.height = b + "px"
            }
            if (y) {
                m.top = y + "px"
            }
            if (s) {
                m.left = s + "px"
            }
            if (J) {
                k.src = J
            }
            if (M) {
                F.width = M + "px"
            }
            if (I) {
                F.height = I + "px"
            }
            if (o) {
                F.top = o + "px"
            }
            if (x) {
                F.left = x + "px"
            }
            if (r) {
                l.setAttribute("modeContent", r)
            }
            w.showPointer(l);
            w.changeBaseModeAndLine(l, true);
            B.innerHTML = E;
            a.smallTool.drawMode(l);
        },
        PathGlobal.updateMode);
        e.width = N.inputWidth.value + "px";
        e.height = N.inputHeight.value + "px";
        e.top = N.inputTop.value + "px";
        e.left = N.inputLeft.value + "px";
        m.width = N.inputWidth.value + "px";
        m.height = N.inputHeight.value + "px";
        m.top = N.inputTop.value + "px";
        m.left = N.inputLeft.value + "px";
        k.src = N.inputImgSrc.value;
        F.width = N.inputWidth.value + "px";
        F.height = N.inputHeight.value + "px";
        F.top = N.inputTop.value + "px";
        F.left = N.inputLeft.value + "px";
        l.setAttribute("modeContent", N.modeContent.value);
        w.isModeCross(l);
        w.changeBaseModeAndLine(l, true);
        B.innerHTML = "";
        w.flip(w.getModeIndex(l), N.inputTitle.value);
        a.smallTool.drawMode(l);
        var i = parseInt(l.offsetWidth),
        h = parseInt(l.offsetHeight),
        q = parseInt(e.top),
        v = parseInt(e.left),
        c = parseInt(k.offsetWidth),
        P = parseInt(k.offsetHeight),
        g = parseInt(m.top),
        d = parseInt(m.left),
        t = k.src,
        D = parseInt(n.offsetWidth),
        C = parseInt(n.offsetHeight),
        K = parseInt(F.top),
        O = parseInt(F.left),
        G = N.modeContent.value,
        j = N.inputTitle.value;
        f.setRedo(function () {
            e.width = i + "px";
            e.height = h + "px";
            e.top = q + "px";
            e.left = v + "px";
            m.width = c + "px";
            m.height = P + "px";
            m.top = g + "px";
            m.left = d + "px";
            k.src = t;
            F.width = D + "px";
            F.height = C + "px";
            F.top = K + "px";
            F.left = O + "px";
            l.setAttribute("modeContent", G);
            w.showPointer(l);
            w.changeBaseModeAndLine(l, true);
            B.innerHTML = j;
            a.smallTool.drawMode(l);
        });
    },
    reBack: function () { },
    print: function (d) {
        var f = $id("module" + d),
        c = f.style,
        b = $id("backImg" + d),
        e = $id("title" + d),
        a = this;
        a.indexId = d;
        a.inputWidth.value = parseInt(f.offsetWidth) - 2;
        a.inputHeight.value = parseInt(f.offsetHeight) - 2;
        a.inputTop.value = parseInt(c.top);
        a.inputLeft.value = parseInt(c.left);
        //mod by qw 2013.2.21 start
        //alert(b.src.substring(b.src.indexOf("images/")));
        a.inputImgSrc.value = b.src.substring(b.src.indexOf("images/"));
        //end
        a.inputTitle.value = e.innerHTML;
        //节点描述
        a.modeContent.value = f.getAttribute("modeContent") || "";
    }
};
com.xjwgraph.Global = {};
function $id(a) {
    return document.getElementById(a)
}
var stopEvent = false;
String.prototype.replaceAll = function stringReplaceAll(b, a) {
    raRegExp = new RegExp(b, "g");
    return this.replace(raRegExp, a)
};
function message(c, a) {
    var b = $id("message");
    if (a) {
        b.innerHTML = c
    } else {
        b.innerHTML += c
    }
}
var ContextXML = com.xjwgraph.ContextXML = function () { };
ContextXML.prototype = {
    setAttribute: function (a, b) {
        this[a] = b
    },
    view: function () {
        var r = this,
        g = document.createElement("div");
        for (var q in r) {
            if (q == "view" || q == "setAttribute" || q == "style" || q == "modeIds" || q == "lineIds") {
                continue
            }
            g.setAttribute(q, r[q])
        }
        var d = com.xjwgraph.Global,
        l = d.modeTool,
        n = d.baseTool,
        h = n.contextMap,
        b = new Map(),
        m = new Map(),
        e = r.modeIds.split(","),
        f = e.length;
        for (var j = f; j--; ) {
            var p = e[j];
            b.put(p, $id(p))
        }
        var a = r.lineIds.split(","),
        o = a.length;
        for (var j = o; j--; ) {
            var k = a[j];
            m.put(k, $id(k))
        }
        function c(s, i) {
            this.contextModeMap = s;
            this.contextLineMap = i
        }
        var c = new c(b, m);
        h.put(r.id, c);
        g.style.cssText = r.style;
        var n = d.baseTool;
        n.pathBody.appendChild(g);
        n.contextDivDrag(g, c)
    }
};
var LineXML = com.xjwgraph.LineXML = function () { };
LineXML.prototype = {
    _lineAttrProp: "attr_prop_",
    setAttribute: function (a, b) {
        if (a.indexOf(this._lineAttrProp) > -1) {
            if (this["prop"] == null) {
                this["prop"] = {}
            }
            a = a.substring(this._lineAttrProp.length);
            this["prop"][a] = b
        } else {
            this[a] = b
        }
    },
    view: function () {
        var g = this,
        a = com.xjwgraph.Global,
        f = a.lineTool,
        h = f.createBaseLine(g.id, g.d || g.path, g.brokenType),
        d = new BuildLine();
        d.id = h.id;
        if (this["prop"]) {
            d.prop = this["prop"]
        }
        h.style.cssText = g.style;
        h.setAttribute("strokeweight", g.strokeweight);
        h.setAttribute("strokecolor", g.strokecolor);
        h.setAttribute("brokenType", g.brokenType);
        var e = a.modeTool,
        c = a.beanXml;
        if (g.xBaseMode) {
            var i = function () {
                var j = a.modeMap.get(g.xBaseMode);
                d.xBaseMode = j;
                d.xIndex = g.xIndex;
                var k = new BuildLine();
                k.id = g.id;
                k.type = true;
                k.index = g.xIndex;
                j.lineMap.put(g.id + "-true", k)
            };
            if (a.modeMap.get(g.xBaseMode)) {
                i()
            } else {
                c.delay[c.delayIndex++] = i
            }
        }
        if (g.wBaseMode) {
            var b = function () {
                var j = a.modeMap.get(g.wBaseMode);
                d.wBaseMode = j;
                d.wIndex = g.wIndex;
                var k = new BuildLine();
                k.id = g.id;
                k.type = false;
                k.index = g.wIndex;
                j.lineMap.put(g.id + "-false", k)
            };
            if (a.modeMap.get(g.wBaseMode)) {
                b()
            } else {
                c.delay[c.delayIndex++] = b
            }
        }
        a.smallTool.drawLine(h);
        a.lineMap.put(d.id, d);
        f.baseLineIdIndex = parseInt(g.id.substring(4)) + 1
    }
};
var ModeXML = com.xjwgraph.ModeXML = function () {
    var b = this,
    a = com.xjwgraph.Global.modeTool;
    b.modeDiv = a.createBaseMode(0, 0, "", 0, "50px", "50px");
    b.backImg = a.getSonNode(b.modeDiv, "backImg");
    b.title = a.getSonNode(b.modeDiv, "title");
    //add by qw 2013.1.9 start
    //b.desc = a.getSonNode(b.modeDiv, "desc");
    //end
};
ModeXML.prototype = {
    _modeAttrProp: "attr_prop_",
    setAttribute: function (b, c) {
        var a = this;
        if (b == "backImgSrc") {
            a.backImg.src = c.substring(c.indexOf("images/"));
            //alert(a.backImg.src); //2013.2.27 qw
        } else {
            if (b == "top") {
                a.modeDiv.style.top = c + "px"
            } else {
                if (b == "left") {
                    a.modeDiv.style.left = c + "px"
                } else {
                    if (b == "width") {
                        a.modeDiv.style.widht = c + "px";
                        a.backImg.style.width = c + "px"
                    } else {
                        if (b == "height") {
                            a.modeDiv.style.height = c + "px";
                            a.backImg.style.height = c + "px"
                        } else {
                            if (b == "id") {
                                com.xjwgraph.Global.modeTool.setIndex(a.modeDiv, c)
                            } else {
                                if (b == "title") {
                                    a.title.innerHTML = c
                                } else {
                                    if (b == "zIndex") {
                                        a.modeDiv.style.zIndex = c
                                    } else {
                                        if (b.indexOf(this._modeAttrProp) > -1) {
                                            if (this["prop"] == null) {
                                                this["prop"] = {}
                                            }
                                            b = b.substring(this._modeAttrProp.length);
                                            this["prop"][b] = c
                                        } else {
                                            a.modeDiv.setAttribute(b, c)
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    },
    view: function () {
        var e = new BaseMode(),
        d = this.modeDiv,
        c = com.xjwgraph.Global,
        b = c.modeTool;
        b.pathBody.appendChild(d);
        var a = b.getModeIndex(d);
        e.id = d.id;
        if (this["prop"]) {
            e.prop = this["prop"]
        }
        //add by qw 2012.12.20 start
        var q = $id("backImg" + a);
        e.type = b.getModeType(q.src);
        //e.desc = this.desc;
        //end
        c.modeMap.put(e.id, e);
        b.initEvent(a);
        b.showPointerId(a);
        b.hiddPointer(d);
        c.smallTool.drawMode(d);
        b.baseModeIdIndex = parseInt(a) + 1
    }
};
var BeanXML = com.xjwgraph.BeanXML = function () {
    var a = this;
    a.delay = [];
    a.delayIndex = 0;
    a.doc = null;
    a.create();
    a.root = a.initBeanXML()
};
BeanXML.prototype = {
    create: function () {
        var a = this;
        a.doc = null;
        if (document.all) {
            var e = ["Msxml2.DOMDocument.6.0", "Msxml2.DOMDocument.5.0", "Msxml2.DOMDocument.4.0", "Msxml2.DOMDocument.3.0", "MSXML2.DOMDocument", "MSXML.DOMDocument", "Microsoft.XMLDOM"];
            var c = e.length;
            for (var b = c; b--; ) {
                try {
                    a.doc = new ActiveXObject(e[b]);
                    break
                } catch (d) {
                    continue
                }
            }
        } else {
            a.doc = document.implementation.createDocument("", "", null)
        }
    },
    initBeanXML: function () {
        var b = this,
        c = b.doc.createProcessingInstruction("xml", "version='1.0' encoding='utf8'");
        b.doc.appendChild(c);
        var a = b.doc.createElement("modes");
        b.doc.appendChild(a);
        return a
    },
    getNodeAttribute: function (f) {
        var d = [],
        b = 0,
        a = f.attributes,
        g = a.length;
        for (var c = g; c--; ) {
            var e = a[c];
            d[b++] = " ";
            d[b++] = e.nodeName;
            d[b++] = '="';
            d[b++] = e.nodeValue;
            d[b++] = '"'
        }
        return d.join("")
    },
    getText: function (d, f) {
        var e = [],
        b = 0,
        j = this;
        if (f) {
            e[b++] = "<";
            e[b++] = d.nodeName
        }
        var h = d.childNodes,
        g = h.length;
        for (var c = g; c--; ) {
            var a = h[c];
            e[b++] = "<";
            e[b++] = a.nodeName;
            if (a.nodeType == 1) {
                e[b++] = j.getNodeAttribute(a)
            }
            e[b++] = ">";
            if (a.hasChildNodes()) {
                e[b++] = j.getText(a, false)
            }
            e[b++] = "</";
            e[b++] = a.nodeName;
            e[b++] = ">"
        }
        if (f) {
            e[b++] = "</";
            e[b++] = d.nodeName;
            e[b++] = ">"
        }
        return e.join("")
    },
    createNode: function (b, d) {
        var a = this,
        c = a.doc.createElement(b);
        if (d) {
            d.appendChild(c)
        } else {
            a.root.appendChild(c)
        }
        return c
    },
    clearNode: function () {
        var a = this;
        if (a.root) {
            var d = a.root.childNodes,
            c = d.length;
            for (var b = c; b--; ) {
                a.root.removeChild(d[b])
            }
        }
    },
    _formatValue: function (a) {
        //add by qw 2012.12.20 start
        a = a.replaceAll("#", "@");
        //        a = a.replaceAll("&", "&amp;");
        //        a = a.replaceAll("'", "&apos;");
        //        a = a.replaceAll('"', "&quot;");
        //        a = a.replaceAll(">", "&gt;");
        //        a = a.replaceAll("<", "&lt;");
        //end
        return a
    },
    toXML: function (sign) {
        var a = this;
        a.clearNode();
        var c = com.xjwgraph.Global,
        d = c.baseTool,
        e = d.contextMap;
        d.forEach(e,
        function (q) {
            var m = a.createNode("context"),
            j = $id(q),
            o = j.attributes,
            n = o.length;
            for (var p = n; p--; ) {
                var k = o[p];
                if (k.nodeValue) {
                    m.setAttribute(k.name, k.nodeValue)
                }
            }
            m.setAttribute("style", j.style.cssText);
            var h = e.get(q),
            g = h.contextModeMap,
            t = h.contextLineMap,
            v = g.getKeys(),
            w = t.getKeys(),
            s = v.length,
            u = w.length,
            l = [],
            f = [],
            r = 0;
            for (var p = s; p--; ) {
                l[r++] = v[p]
            }
            m.setAttribute("modeIds", l.join(","));
            r = 0;
            for (var p = u; p--; ) {
                f[r++] = w[p]
            }
            m.setAttribute("lineIds", f.join(","))
        });
        d.forEach(c.modeMap,
        function (u) {
            var o = $id(u),
            m = o.style,
            k = o.attributes,
            j = k.length,
            h = a.createNode("mode");
            for (var l = j; l--; ) {
                var g = k[l];
                if (g.name == "style" || g.name == "id") {
                    continue
                }
                if (g.nodeValue) {
                    h.setAttribute(g.name, g.nodeValue)
                }
            }
            var p = c.modeMap.get(u);
            var t = p.prop;
            //add by qw 2012.12.18 start
            h.setAttribute("type", p.type);
            //h.setAttribute("desc", p.desc);
            //alert(p.id + "==" +p.type);
            //end
            for (var f in t) {
                h.setAttribute("attr_prop_" + f, t[f])
            }
            var s = c.modeTool.getModeIndex(o);
            h.setAttribute("id", s);
            var r = $id("title" + s).innerHTML;
            h.setAttribute("title", r);
            var q = $id("backImg" + s),
            //add by qw 2013.2.27 start
            n = q.src.substring(q.src.indexOf("images/"));
            //end
            h.setAttribute("backImgSrc", n);
            h.setAttribute("top", parseInt(m.top));
            h.setAttribute("left", parseInt(m.left));
            h.setAttribute("zIndex", parseInt(m.zIndex));
            h.setAttribute("width", parseInt(q.offsetWidth));
            h.setAttribute("height", parseInt(q.offsetHeight))
        });
        d.forEach(c.lineMap,
        function (r) {
            var u = $id(r),
            l = a.createNode("line"),
            n = u.attributes,
            m = n.length,
            q = u.style;
            var p = u.getAttribute("strokeweight"),
            j = u.getAttribute("strokecolor");
            l.setAttribute("strokeweight", p || q.strokeWidth);
            l.setAttribute("strokecolor", j || q.stroke);
            for (var o = m; o--; ) {
                var h = n[o];
                if (h.name == "style" || h.name == "marker-end") {
                    continue;
                }
                if (h.nodeValue) {
                    l.setAttribute(h.name, h.nodeValue);
                }
            }
            var k = q.strokeWidth ? "" : ";fill: none; stroke: " + j + "; stroke-width: " + (p + 0.45);
            l.setAttribute("style", q.cssText + k);
            l.setAttribute("marker-end", "url(#arrow)");
            var g = c.lineMap.get(u.id);
            //add by qw 2012.12.21 start
            g.sNodeId = g.xBaseMode.type + "_" + g.xBaseMode.id;
            g.eNodeId = g.wBaseMode.type + "_" + g.wBaseMode.id;
            //end
            for (var t in g) {
                if (t === "prop") {
                    continue
                }
                if (typeof (g[t]) == "string" || typeof (g[t]) == "number") {
                    l.setAttribute(t, g[t])
                } else {
                    if (typeof (g[t]) == "object") {
                        l.setAttribute(t, g[t] && g[t].id ? g[t].id : "")
                    } else {
                        l.setAttribute(t, g[t] + " is unSupport")
                    }
                }
            }
            if (g && g.prop) {
                var f = g.prop;
                for (var s in f) {
                    l.setAttribute("attr_prop_" + s, f[s])
                }
            }
        });
        var b = a.getTextXml(a.doc);
        //add by qw 2012.12.20 向服务端提交 start
        if (sign == true) {
            //alert(b);
            BFHandler.saveXmlData(b);
            //a.viewTextXml(b);
        }
        else {
            //alert(b);
            BFHandler.saveLayoutXML(b);
        }
        //end
    },
    loadXmlText: function () {
        if (document.all && window.ActiveXObject) {
            var a = this;
            return function (c) {
                var g = ["Msxml2.DOMDocument.6.0", "Msxml2.DOMDocument.5.0", "Msxml2.DOMDocument.4.0", "Msxml2.DOMDocument.3.0", "MSXML2.DOMDocument", "MSXML.DOMDocument", "Microsoft.XMLDOM"];
                var e = g.length;
                var b = null;
                for (var d = e; d--; ) {
                    try {
                        b = new ActiveXObject(g[d]);
                        break
                    } catch (f) {
                        continue
                    }
                }
                b.async = "false";
                b.loadXML(c);
                return b
            }
        } else {
            return function (b) {
                return new DOMParser().parseFromString(b, "text/xml")
            }
        }
    } (),
    viewTextXml: function (b) {
        b = b.replaceAll("<", "&lt").replaceAll(">", "&gt");
        var c = window.open("saveXml.html", "", ""),
        a = 0,
        d = [];
        d[a++] = "<html>";
        d[a++] = "<head>";
        d[a++] = '<link href="css/flowPath.css" type="text/css" rel="stylesheet" />';
        d[a++] = '<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />';
        d[a++] = "<title></title>";
        d[a++] = "</head>";
        d[a++] = "<body>";
        d[a++] = b;
        d[a++] = "<hr/>" + encodeURI(b);
        d[a++] = "</body></html>";
        c.document.write(d.join(""));
        c.document.close()
    },
    getTextXml: function (c) {
        var b = "";
        if (c) {
            b = c.xml;
            if (!b) {
                if (c.innerHTML) {
                    b = c.innerHTML
                } else {
                    var a = new XMLSerializer();
                    b = a.serializeToString(c)
                }
            } else {
                b = b.replace(/\r\n\t[\t]*/g, "").replace(/>\r\n/g, ">").replace(/\r\n/g, "\n")
            }
        }
        b = b.replace(/\n/g, "");
        b = this._formatValue(b);
        return b
    },
    clearHTML: function () {
        var a = com.xjwgraph.Global;
        a.undoRedoEventFactory.clear();
        a.lineTool.removeAll();
        a.modeTool.removeAll();
        a.baseTool.removeAll()
    },
    toHTML: function () {
        var q = this;
        q.clearHTML();
        if (!q.doc) {
            return
        }
        var d = q.doc.childNodes,
        a = d.length;
        for (var h = a; h--; ) {
            if (d[h].nodeName == "modes") {
                q.root = q.doc.childNodes[h];
                break
            }
        }
        if (q.root) {
            var p = q.root.childNodes,
            o = p.length;
            for (var h = o; h--; ) {
                var c = p[h],
                n = c.nodeName,
                f = c.attributes,
                g = f.length,
                l;
                if (n == "mode") {
                    l = new ModeXML();
                } else {
                    if (n == "line") {
                        l = new LineXML();
                    } else {
                        if (n == "context") {
                            l = new ContextXML();
                        }
                    }
                }
                for (var e = g; e--; ) {
                    var b = f[e];
                    //alert(b.name + "," + b.value);
                    l.setAttribute(b.name, b.value);
                }
                l.view();
            }
            var m = q.delay,
            k = m.length;
            for (var h = k; h--; ) {
                m[h]()
            }
            delete q.delay;
            q.delay = [];
            q.delayIndex = 0
        }
    }
};
var client = com.xjwgraph.ClientTool = function (a) {
    this.dialog = $("#" + a.prop);
    $id(a.prop).style.width = a.dialogWidth || 328 + "px"
};
client.prototype = {
    _deepCopyProp: function (a) {
        var c = {};
        for (var b in a) {
            c[b] = a[b]
        }
        return c
    },
    _isDiffJson: function (d, c) {
        var b = false;
        for (var a in d) {
            if (d[a] !== c[a]) {
                b = true;
                break
            }
        }
        return b
    },
    _close: function (b) {
        var a = $(".panel-tool-close");
        if (a.length > 0) {
            a = a[0];
            a.click(b)
        }
    },
    showDialog: function (c, e, d) {
        var b = this._deepCopyProp(d.prop),
        a = this;
        this.dialog.dialog({
            title: e,
            modal: true,
            _attri_prop: null,
            buttons: [{
                text: "ok",
                handler: function () {
                    var i = d.prop;
                    for (var f in i) {
                        var h = $id("lineAttr_" + f);
                        i[f] = h.value
                    }
                    a._close(c);
                    var g = new com.xjwgraph.UndoRedoEvent(function () {
                        d.prop = b
                    },
                    PathGlobal.editProp);
                    g.setRedo(function () {
                        d.prop = i
                    })
                }
            },
            {
                text: "rest",
                handler: function () {
                    var h = d.prop = b;
                    for (var f in h) {
                        var g = $id("lineAttr_" + f);
                        g.value = h[f]
                    }
                }
            }]
        })
    },
    addProItem: function (e) {
        var c = document,
        d = c.createElement("div");
        var b = "<table>";
        for (var a in e) {
            b += '<tr><td align="right">&nbsp;' + a + '&nbsp;:&nbsp;</td><td><input type="text" id="lineAttr_' + a + '" value="' + e[a] + '" /></td></tr>'
        }
        b += "</table>";
        d.innerHTML = b;
        return d
    }
};
var Utils = com.xjwgraph.Utils = {
    create: function (e) {
        this.global = com.xjwgraph.Global;
        this.global.modeMap = new com.xjwgraph.Map();
        this.global.lineMap = new com.xjwgraph.Map();
        this.global.beanXml = new com.xjwgraph.BeanXML();
        var g = e.contextBody,
        a = $id(g),
        h = e.width,
        c = e.height;
        this.global.baseTool = new com.xjwgraph.BaseTool(a, h, c);
        this.global.modeTool = new com.xjwgraph.ModeTool(a);
        this.global.lineTool = new com.xjwgraph.LineTool(a);
        this.global.clientTool = new com.xjwgraph.ClientTool(e);
        var b = e.smallMap;
        this.global.smallTool = new com.xjwgraph.SmallMapTool(b, g);
        var f = $id(e.mainControl);
        this.global.controlTool = new com.xjwgraph.ControlTool(f);
        var d = e.historyMessage;
        this.global.undoRedoEventFactory = new com.xjwgraph.UndoRedoEventFactory(d);
        this.global.undoRedoEventFactory.init();
        return this
    },
    showLinePro: function () {
        this.global.lineTool.showProperty()
    },
    showModePro: function () {
        this.global.modeTool.showProperty()
    },
    toMerge: function () {
        this.global.baseTool.toMerge()
    },
    toSplit: function () {
        this.global.baseTool.toSeparate()
    },
    toSelect: function () {
        this.global.modeTool.toSelect()
    },
    toTop: function () {
        this.global.modeTool.toTop()
    },
    toBottom: function () {
        this.global.modeTool.toBottom()
    },
    printView: function () {
        this.global.baseTool.printView()
    },
    undo: function () {
        this.global.undoRedoEventFactory.undo()
    },
    redo: function () {
        this.global.undoRedoEventFactory.redo()
    },
    //add by qw 2013.1.7 start
    checkLine: function () {
        var lineSize = this.global.lineMap.size();
        if (lineSize > 0) {
            var a = this.global.lineMap;
            var baseLineKey = a.getKeys();
            var baseLineKeyLength = baseLineKey.length;
            for (var j = baseLineKeyLength; j--; ) {
                var u = a.get(baseLineKey[j]);
                if (u.xBaseMode == undefined || u.xBaseMode == "" ||
                    u.wBaseMode == undefined || u.wBaseMode == "") {
                    //alert(u.xBaseMode + "," + u.wBaseMode);
                    return false;
                }
            }
        }
        return true;
    },
    //保存布局
    saveLayout: function () {
        this.global.beanXml.toXML(false)
    },
    //end
    saveXml: function () {
        this.global.beanXml.toXML(true)
    },
    loadXml: function () {
        this.global.beanXml.toHTML()
    },
    loadTextXml: function (a) {
        this.global.beanXml.doc = null;
        this.global.beanXml.doc = this.global.beanXml.loadXmlText(a);
        this.loadXml();
    },
    clearHtml: function () {
        this.global.beanXml.clearHTML()
    },
    copyNode: function () {
        keyDownFactory.copyNode()
    },
    removeNode: function () {
        keyDownFactory.removeNode()
    },
    alignLeft: function () {
        this.global.baseTool.toLeft();
        this.global.baseTool.clearContext()
    },
    alignRight: function () {
        this.global.baseTool.toRight();
        this.global.baseTool.clearContext()
    },
    verticalCenter: function () {
        this.global.baseTool.toMiddleWidth();
        this.global.baseTool.clearContext()
    },
    alignTop: function () {
        this.global.baseTool.toTop();
        this.global.baseTool.clearContext()
    },
    horizontalCenter: function () {
        this.global.baseTool.toMiddleHeight();
        this.global.baseTool.clearContext()
    },
    bottomAlignment: function () {
        this.global.baseTool.toBottom();
        this.global.baseTool.clearContext()
    },
    nodeDrag: function (b, a, c) {
        this.global.baseTool.drag(b, a, c)
    },
    closeAutoLineType: function () {
        PathGlobal.isAutoLineType = false
    },
    openAutoLineType: function () {
        PathGlobal.isAutoLineType = true
    }
};