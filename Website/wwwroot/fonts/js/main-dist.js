$(document).ready((function(){let e=$(window).scrollTop(),s=$(".scroll-panel-0").position().top,a=$(".scroll-panel-1").position().top+$(".scroll-panel-1").height()/2;e>s&&($(".header").addClass("transition"),$(".sticky-panel-1").addClass("show-panel"),$(".sticky-panel-2").removeClass("show-panel")),e>a&&($(".sticky-panel-1").removeClass("show-panel"),$(".sticky-panel-2").addClass("show-panel")),$(window).scroll((function(){let e=$(window).scrollTop();e<100?($(".sticky-panel-1").removeClass("show-panel"),$(".sticky-panel-2").removeClass("show-panel")):e<$(".scroll-panel-2").position().top-200&&e>100?($(".sticky-panel-1").addClass("show-panel"),$(".sticky-panel-2").removeClass("show-panel")):($(".sticky-panel-1").removeClass("show-panel"),$(".sticky-panel-2").addClass("show-panel"))}));var o=0;$(window).scroll((function(e){var s=$(this).scrollTop();s>o?$(".header").addClass("transition"):$(".header").removeClass("transition"),o=s})),$(".services-layout").hover((function(e){$(".services-layout").removeClass("active"),$(this).addClass("active")}));new Swiper(".swiper-container",{scrollbar:{el:".swiper-scrollbar"},slidesPerView:"auto",paginationClickable:!0,spaceBetween:30});let n=$(".projects .owl-carousel");n.on("initialized.owl.carousel changed.owl.carousel",(function(e){if(e.namespace){var s=e.relatedTarget;$("#counter").text(s.relative(s.current())+1+"/"+s.items().length)}})).owlCarousel({items:1,loop:!0,autoplay:!1,dots:!1,responsive:{0:{nav:!1},1024:{nav:!0,navText:["<span class='prev'><svg width='28' height='54' viewBox='0 0 28 54' fill='none' xmlns='http://www.w3.org/2000/svg'><path d='M27 1L1 27L27 53' stroke='#424B5A' stroke-linecap='round' stroke-linejoin='round'/></svg></span>","<span class='next'><svg width='28' height='54' viewBox='0 0 28 54' fill='none' xmlns='http://www.w3.org/2000/svg'><path d='M1 53L27 27L1 1' stroke='#424B5A' stroke-linecap='round' stroke-linejoin='round'/></svg></span>"]}}}),n.on("dragged",".owl-stage",(function(e){e.deltaY>0?n.trigger("next.owl"):n.trigger("prev.owl"),e.preventDefault()})),$(".header .menu").click((function(e){$("body").css("overflow","hidden"),$(".header").addClass("active"),$("#open-menu").addClass("active")})),$("#open-menu .menu").click((function(e){$("body").css("overflow",""),$(".header").removeClass("active"),$("#open-menu").removeClass("active")})),$(".links li a").hover((function(e){let s=$(this).attr("data-src");$("#open-menu .right img").attr("src",s)})),$(".copy .slide-button div").hover((function(e){$(".copy .slide-button div").removeClass("active"),$(this).addClass("active")})),$(".banner-ads .close").click((function(e){$(".banner-ads").addClass("hidden")}))}));