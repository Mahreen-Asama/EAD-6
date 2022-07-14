// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $('#b1').click(function () {
        alert("call");
        $.get('/Home/PartialViewMethod', function (result) {
            $('#tableshow').html(result);
        })
    })
})

function f1() {
    alert("f1 call");
    document.getElementById("div1").innerHTML="<h1>radio 1 click</h1>"
}
function f2() {
    alert("f2 call");
    document.getElementById("div2").innerHTML = "<h1>radio 2 click</h1>"
}