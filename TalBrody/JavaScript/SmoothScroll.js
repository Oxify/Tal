﻿/*
function SmoothScroll(element) {
    var offset = $element.offset().top;

}
*/
//<script type="text/javascript" src="JavaScript/SmoothScroll.js"></script>
$(document).ready(function () {
    function filterPath(string) {
        return string
        .replace(/^\//, '')
        .replace(/(index|default).[a-zA-Z]{3,4}$/, '')
        .replace(/\/$/, '');
    }
    var locationPath = filterPath(location.pathname);
    var scrollElem = scrollableElement('html', 'body');

    $('a[href*=#]:not([href=#])').each(function () {
        var thisPath = filterPath(this.pathname) || locationPath;
        if (locationPath == thisPath
        && (location.hostname == this.hostname || !this.hostname)
        && this.hash.replace(/#/, '')) {
            var $target = $(this.hash), target = this.hash;
            if (target) {
                var targetOffset = $target.offset().top;
                $(this).click(function (event) {
                    event.preventDefault();
                    $(scrollElem).animate({ scrollTop: targetOffset }, 1000, function () {
                        location.hash = target;
                    });
                    return false;
                });
            }
        }
    });

    // use the first element that is "scrollable"
    function scrollableElement(els) {
        for (var i = 0, argLength = arguments.length; i < argLength; i++) {
            var el = arguments[i],
            $scrollElement = $(el);
            if ($scrollElement.scrollTop() > 0) {
                return el;
            } else {
                $scrollElement.scrollTop(1);
                var isScrollable = $scrollElement.scrollTop() > 0;
                $scrollElement.scrollTop(0);
                if (isScrollable) {
                    return el;
                }
            }
        }
        return [];
    }

});


/*
$(function () {
    $('a[href*=#]:not([href=#])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    });
});

*/