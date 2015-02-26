
$(document).ready(function () {

    var elements = document.getElementsByClassName('ScrollButton');
    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }
    elements = document.getElementsByClassName('scroll-icon');
    for (i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }

    $('.slick-box').slick({
        arrows: true,
        rtl: true,
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        responsive: [
          {
              breakpoint: 1024,
              settings: {
                  slidesToShow: 3,
                  slidesToScroll: 3,
                  infinite: true,
                  dots: true
              }
          },
          {
              breakpoint: 600,
              settings: {
                  slidesToShow: 2,
                  slidesToScroll: 2
              }
          },
          {
              breakpoint: 480,
              settings: {
                  slidesToShow: 1,
                  slidesToScroll: 1
              }
          }
          // You can unslick at a given breakpoint now by adding:
          // settings: "unslick"
          // instead of a settings object
        ]
    });


});

function ScrollToTarget() {
    var el = document.getElementById(this.attributes['data-goto'].value);
    try {
        jQuery.scrollTo(el, 1000, { easing: 'easeOutQuad' });

    } catch (e) {

    }
    return false;
}




