var divs = [".div0", ".div1", ".div2", ".div3", ".div4"];

$(document).ready(function () {
    var element = document.getElementById("hostname");
    var element2 = document.getElementById("hostname2");
    var element3 = document.getElementById("hostname3");
    var element4 = document.getElementById("hostname4");
    element.innerHTML = location.hostname;
    element2.innerHTML = location.hostname;
    element3.innerHTML = location.hostname;
    element4.innerHTML = location.hostname;
    $("h1").animate({ opacity: '0.8', fontSize: '2.3em' }, 1250, function () { });
    $(".links").animate({ opacity: '0.9', }, 650, function () {
        $(".description").animate({ opacity: '0.9', }, 850, function () { });
    });
});
