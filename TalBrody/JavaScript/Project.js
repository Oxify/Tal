
$(document).ready(function () {

   
    var elements = document.getElementsByClassName('scroll-icon');
    for (var i = 0; i < elements.length; i++) {
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
        slidesToShow: 3,
        slidesToScroll: 3,
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
              breakpoint: 768,
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




function cycleImages() {
    var $active = $('#cycler .star-active');
    var $next = ($active.next().length > 0) ? $active.next() : $('#cycler img:first');
    $next.css('z-index', 2);//move the next image up the pile
    $active.fadeOut(500, function () {//fade out the top image
        $active.css('z-index', 1).show().removeClass('star-active');//reset the z-index and unhide the image
        $next.css('z-index', 3).addClass('star-active');//make the next image the top one
    });
}

$(document).ready(function () {
    // run every 1s
    setInterval('cycleImages()', 1000);
})