
$(document).ready(function () {

    var elements = document.getElementsByClassName('ScrollButton');
    for (var i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }
    elements = document.getElementsByClassName('scroll-icon');
    for (i = 0; i < elements.length; i++) {
        elements[i].onclick = ScrollToTarget;
    }



    $("a.gallary-image").fancybox({
        'transitionIn': 'elastic',
        'transitionOut': 'elastic',
        'speedIn': 600,
        'speedOut': 200,
        'overlayShow': false,
    });


    $('.slick-box').slick({
        arrows: true,
        dots: true,
        infinite: false,
        rtl: true,
        speed: 1000,
        slidesToShow: 1,
        slidesToScroll: 1,
        respondTo: 'min',
        varibleWidth: true,
        responsive: [
          {
              breakpoint: 800,
              settings: {
                  slidesToShow: 2,
                  slidesToScroll: 2
              }
          },
          {
              breakpoint: 600,
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


    //$('.slick-box').slick({
    //    arrows: true,
    //    dots: true,
    //    infinite: false,
    //    rtl: true,
    //    speed: 300,
    //    slidesToShow: 3,
    //    slidesToScroll: 3,
    //    respondTo: 'min',
    //    centerMode: true,
    //    centerPadding: '10px',
    //    responsive: [
    //      {
    //          breakpoint: 1024,
    //          settings: {
    //              slidesToShow: 3,
    //              slidesToScroll: 3,
    //              infinite: true,
    //              dots: true
    //          }
    //      },
    //      {
    //          breakpoint: 800,
    //          settings: {
    //              slidesToShow: 2,
    //              slidesToScroll: 2
    //          }
    //      },
    //      {
    //          breakpoint: 768,
    //          settings: {
    //              slidesToShow: 1,
    //              slidesToScroll: 1
    //          }
    //      }
    //      // You can unslick at a given breakpoint now by adding:
    //      // settings: "unslick"
    //      // instead of a settings object
    //    ]
    //});
});

function ScrollToTarget() {
    var el = document.getElementById(this.attributes['data-goto'].value);
    try {
        jQuery.scrollTo(el, 1000, { easing: 'easeOutQuad' });

    } catch (e) {

    }
    return false;
}




