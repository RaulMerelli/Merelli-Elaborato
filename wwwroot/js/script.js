var divs = [".div0", ".div1", ".div2", ".div3", ".div4"];

$(document).ready(function () {
    resize();
    raise(0);
    $("h1").animate({ opacity: '0.8', fontSize: '2.3vw' }, 1250, function () { });
});

$(window).on('resize', function () {
    resize();
});

function resize() {
    for (var i = 0; i < 5; i += 1) {
        var div = $(divs[i]);
        var width = div.width();

        div.css('height', (width / 4) * 3);
    }
}


function raise(i) {
    if (i == 5)
        return;
    else {
        $(divs[i]).animate({ bottom: '50%', opacity: '1' }, 250, function () {
            raise(i += 1);
        });
    }
}
