
$(document).ready(function () {
    var elements = document.getElementsByClassName('ScrollButton');
    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        var elem = document.getElementsByClassName('whatsapp-box');
        for ( i = 0; i < elements.length; i++) {
            elements[i].style.display = 'inline-block';
        }
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




