
$(document).ready(function () {
    var elements = document.getElementsByClassName('ScrollButton');
    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }
    elements = document.getElementsByClassName('scroll-icon');
    for (i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }

    

});

function ScrollToTarget() {
    var el = document.getElementById(this.attributes['data-goto'].value);
    try {
        jQuery.scrollTo(el, 1000, { easing: 'easeOutQuad' });

    } catch (e) {

    }
    return false;
}




