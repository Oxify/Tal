
$(document).ready(function () {
    var elements = document.getElementsByClassName('Scroller');
    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }

    var el = document.getElementById('ScrollDown');
    el.onclick = ScrollToTarget;

});

function showFoo() {
    //debugger;

    var el = document.getElementById(this.attributes['data-goto'].value);
    try {
        jQuery.scrollTo(el, 1000, { easing: 'swing' });

    } catch (e) {

    }
    return false;
}


function ScrollToTarget() {
    var el = document.getElementById(this.attributes['data-goto'].value);
    try {
        jQuery.scrollTo(el, 1000, { easing: 'swing' });

    } catch (e) {

    }
    return false;
}