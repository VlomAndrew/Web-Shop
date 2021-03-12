// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function RedirectToIndex() {
    window.location.href = '/Goods';
}

function TimerAndPrint(source_time) {
    var time = source_time;
    PrintTime(time);
    setInterval(function () {
        time--;
        PrintTime(time)
    }, 1000);
}

function PrintTime(time) {
    p = document.getElementById("text_time");
    p.innerHTML = 'Время до возврата осталось: ' + time.toString();
    console.log(time);
    if (time <= 0) {
        RedirectToIndex();
    }

}


