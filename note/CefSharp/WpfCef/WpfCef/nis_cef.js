window.onload = function () {
    CefSharp.BindObjectAsync("boundAsync");
}

//接收Wpf方法Demo1
function jsFunction1(listdata) {

    alert(listdata["age"])
}
//接收Wpf方法Demo2
function jsFunction2(listdata) {

    return listdata["age"]
}
//调用Wpf方法，无返回值Demo
async function jsCallCSharpDemo1() {
    await boundAsync.showMessage("aaaa")
}
//调用Wpf方法，有返回值Demo
async function jsCallCSharpDemo2() {
    sum = await boundAsync.add(6, 7)
    alert(sum)
}