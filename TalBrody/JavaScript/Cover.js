
$(document).ready(function () {
    var elements = document.getElementsByClassName('ScrollButton');
    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }

//    var el = document.getElementById('ScrollDown');
//    el.onclick = ScrollToTarget;

});

function ScrollToTarget() {
    var el = document.getElementById(this.attributes['data-goto'].value);
    try {
        jQuery.scrollTo(el, 1000, { easing: 'easeInOutBack' });

    } catch (e) {
  
    }
    return false;
}

function ShowRegister() {
//    debugger;
//    var el = document.getElementById('overlay');
//    el.style.opacity = 0.3;
//    el.show().css({ "opacity": "0.3" });


}