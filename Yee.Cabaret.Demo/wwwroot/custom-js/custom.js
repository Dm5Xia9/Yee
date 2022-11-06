// Custom Js
jQuery(document).ready(function () {
    "use strict";

    // Prevent Dropdown li act as a link
    jQuery("li.has-dropdown > a").on("click", function (e) {
        e.preventDefault();
    });

    // Search Overlay Toggle
    jQuery(document).on("click", ".open-search-btn", function (e) {
        e.preventDefault();
        jQuery(".cab-search-overlay").addClass("show");
    });
    jQuery(document).on("click", ".close-search-overlay", function () {
        jQuery(".cab-search-overlay").removeClass("show");
    });

    // Add smooth scrolling to all links
    jQuery(".smooth-scroll").on('click', function (event) {
        if (this.hash !== "") {
            event.preventDefault();
            var hash = this.hash;
            jQuery('html, body').animate({
                scrollTop: jQuery(hash).offset().top
            }, 1000);
        }
    });

    // Sticky header v2
    if (jQuery("nav").hasClass("stickOnScroll")) {
        window.onscroll = function () { fixedHeaderV2() };
        var navbar = document.querySelector(".stickOnScroll");
        var sticky = navbar.offsetTop;

        function fixedHeaderV2() {
            if (window.pageYOffset >= sticky) {
                navbar.classList.add("sticky");
            } else {
                navbar.classList.remove("sticky");
            }
        }
    }

    // Open Mobile Main Nav v1
    jQuery(".open-side-nav.v1").on("click", function () {
        jQuery(".cab-sidebar-nav").addClass("open");
    });
    jQuery(".close-side-nav-btn").on("click", function () {
        jQuery(".cab-sidebar-nav").removeClass("open");
    });

    // Open Mobile Main Nav v2
    jQuery(".open-side-nav.v2").on("click", function () {
        jQuery(".cab-main-left-links-box").addClass("open");
    });
    jQuery(".close-sidebar-v2").on("click", function () {
        jQuery(".cab-main-left-links-box").removeClass("open");
    });

    // Splitting Big Heading text
    jQuery('.cab-hero-slider .cab-big-heading h1').html(function (index, html) {
        return html.replace(/\S/g, '<span>$&</span>');
    });

    // Main Hero Section
    if (jQuery(".cab-hero-slider").length) {
        let cabHeroSliderV1 = new Swiper('.cab-hero-slider', {
            slidesPerView: 1,
            spaceBetween: 0,
            speed: 1000,
            effect: 'fade',
            fade: true,
            loop: false,
            autoplay: {
                delay: 5000,
                disableOnInteraction: true,
            },
            navigation: {
                nextEl: '.cab-hero-slider .swiper-button-next',
                prevEl: '.cab-hero-slider .swiper-button-prev',
            },
            init: false,
        });
        // init Swiper
        cabHeroSliderV1.on('init', function () {
            animHeroSliderContent(0.2);
        });
        cabHeroSliderV1.init();
        // Onchange
        cabHeroSliderV1.on('slideChange', function () {
            setTimeout(function () {
                animHeroSliderContent(0.2);
            }, 200);
        });
        // GSAP Animations on Main Hero Slider
        function animHeroSliderContent(delay) {
            let heroSubHeading = jQuery('.cab-hero-slider .swiper-slide-active').find('.cab-sub-heading-box');
            let headingChars = jQuery('.cab-hero-slider .swiper-slide-active .cab-big-heading h1 span');
            let heroCtnBtn = jQuery('.cab-hero-slider .swiper-slide-active').find('.cab-hero-cta-btn-box');

            let heroSliderTl = gsap.timeline({ delay: delay });
            heroSliderTl.staggerFrom(headingChars, 0.7, {
                y: -40,
                autoAlpha: 0,
                ease: Back.easeOut
            }, 0.05).from(heroSubHeading, 1, {
                y: -10,
                opacity: 0,
                ease: Back.easeOut
            }, "=-0.6").from(heroCtnBtn, 1, {
                y: 10,
                opacity: 0,
                ease: Back.easeOut
            }, "=-1");

            heroSliderTl.timeScale(1);
        }
    }

    // Date Picker Js
    jQuery('.dateOnly').daterangepicker({
        singleDatePicker: true,
        showDropdowns: false,
        maxYear: parseInt(moment().format('YYYY'), 10),
        opens: "right"
    });

    // Time Picker Js
    jQuery('.timeOnly').daterangepicker({
        singleDatePicker: true,
        timePicker: true,
        opens: "right",
        timePickerIncrement: 5,
        timePicker24Hour: false,
        locale: {
            format: 'hh:mm A'
        }
    }).on('show.daterangepicker', function (ev, picker) {
        picker.container.find(".calendar-table").hide(); //Hide calendar
    });

    // Custom Select Style
    jQuery('.my-select').selectpicker();

    // Testimonials v1 Slider
    if(jQuery('.cab-testimonials-slider-box.v1 .swiper-container')){
        var swiper = new Swiper('.cab-testimonials-slider-box.v1 .swiper-container', {
            slidesPerView: 1,
            autoHeight: false,
            initialSlide: 1,
            spaceBetween: 0,
            speed: 600,
            fadeEffect: { crossFade: true },
            effect: 'fade',
            fade: true,
            loop: true,
            grabCursor: true,
            autoplay: {
                delay: 7000,
                disableOnInteraction: true,
            },
            pagination: {
                el: '.cab-testimonials-slider-box .swiper-pagination',
                clickable: true,
            },
        });
    }
    
    // Testimonials v2 Slider
    if(jQuery('.cab-testimonials-slider-box.v2 .swiper-container')){
        var swiper = new Swiper('.cab-testimonials-slider-box.v2 .swiper-container', {
            slidesPerView: 2,
            autoHeight: false,
            spaceBetween: 30,
            speed: 600,
            effect: 'slide',
            loop: true,
            grabCursor: true,
            autoplay: {
                delay: 7000,
                disableOnInteraction: true,
            },
            breakpoints: {
                0: {
                    slidesPerView: 1,
                    spaceBetween: 20,
                },
                768: {
                    slidesPerView: 2,
                    spaceBetween: 40,
                },
                1024: {
                    slidesPerView: 2,
                    spaceBetween: 50,
                },
            }
        });
    }

    // Cab Master Chef Slider Slider
    if(jQuery('.cab-master-chef-slider .swiper-container')){
        var swiper = new Swiper('.cab-master-chef-slider .swiper-container', {
            slidesPerView: 3,
            autoHeight: false,
            spaceBetween: 30,
            speed: 700,
            effect: 'slide',
            loop: true,
            grabCursor: true,
            autoplay: {
                delay: 7000,
                disableOnInteraction: true,
            },
            pagination: {
                el: '.cab-master-chef-slider .swiper-pagination',
                clickable: true,
            },
            breakpoints: {
                0: {
                    slidesPerView: 1,
                },
                768: {
                    slidesPerView: 2,
                },
                1024: {
                    slidesPerView: 3,
                },
            }
        });
    }
    
    // FAQs Accordian
    if(jQuery('.js-accordion').length){
        var accordion = (function () {
            var $accordion = jQuery('.js-accordion');
            var $accordion_header = $accordion.find('.js-accordion-header');
            var $accordion_item = jQuery('.js-accordion-item');
            var settings = {
                speed: 400,
                oneOpen: false
            };
            return {
                // pass configurable object literal
                init: function ($settings) {
                    $accordion_header.on('click', function () {
                        accordion.toggle(jQuery(this));
                    });
                    $.extend(settings, $settings);
                    if (settings.oneOpen && jQuery('.js-accordion-item.active').length > 1) {
                        jQuery('.js-accordion-item.active:not(:first)').removeClass('active');
                    }
                    jQuery('.js-accordion-item.active').find('> .js-accordion-body').show();
                },
                toggle: function ($this) {
                    if (settings.oneOpen && $this[0] != $this.closest('.js-accordion').find('> .js-accordion-item.active > .js-accordion-header')[0]) {
                        $this.closest('.js-accordion')
                            .find('> .js-accordion-item')
                            .removeClass('active')
                            .find('.js-accordion-body')
                            .slideUp()
                    }
                    // show/hide the clicked accordion item
                    $this.closest('.js-accordion-item').toggleClass('active');
                    $this.next().stop().slideToggle(settings.speed);
                }
            }
        })();
        accordion.init({ speed: 300, oneOpen: true });
    }
    

    // Blog Posts Images Slider
    if(jQuery('.post-img-slider .swiper-container').length){
        var swiper = new Swiper('.post-img-slider .swiper-container', {
            slidesPerView: 1,
            speed: 600,
            effect: 'slide',
            loop: true,
            // autoplay: {
            //     delay: 1000,
            //     disableOnInteraction: true,
            // },
            navigation: {
                nextEl: '.post-img-slider .swiper-button-next',
                prevEl: '.post-img-slider .swiper-button-prev',
            },
        });
    }

    // Controlling Play Button for blogs videos
    jQuery('.togglePlayBtn').on("click", function () {
        var clickedBtn = jQuery(this);
        var sibling = jQuery(this).siblings(".video-box").find("video");
        if (!sibling.hasClass("playing")) {
            sibling.addClass("playing");
            clickedBtn.addClass("playing");
            sibling.trigger('play');
            jQuery(this).html('<i class="ti-control-pause"></i>');
        } else {
            sibling.removeClass("playing")
            clickedBtn.removeClass("playing");
            sibling.trigger('pause');
            jQuery(this).html('<i class="flaticon-play"></i>');
        }
        sibling.on('ended', function () {
            sibling.removeClass("playing");
            clickedBtn.removeClass("playing");
            if (!sibling.hasClass("playing")) {
                clickedBtn.html('<i class="flaticon-play"></i>');
            }
        });
    });

    // Reply Form Toggle
    jQuery(".reply-form-open").on("click", function () {
        if (jQuery(this).parent().hasClass("show-form")) {
            return false;
        } else {
            jQuery(".reply-form-open").parent().removeClass("show-form");
            jQuery(".reply-form-open").parent().find(".add-reply-form-box").hide();
            jQuery(this).parent().addClass("show-form");
            if (jQuery(this).parent().hasClass("show-form")) {
                var replyForm = jQuery(".add-reply-form-box");
                jQuery(this).parent().append(replyForm);
                replyForm.slideDown();
            }
        }
    });
    // Cancel Reply Form
    jQuery(".cancel-reply").on("click", function () {
        jQuery(this).parents(".reply-box").removeClass("show-form");
        jQuery(this).parents(".add-reply-form-box").slideUp();
    });

    // Filter Price Script
    if(jQuery("#slider-range").length){
        jQuery(function () {
            jQuery("#slider-range").slider({
                range: true,
                orientation: "horizontal",
                min: 0,
                max: 400,
                values: [110, 300],
                step: 10,
    
                slide: function (event, ui) {
                    jQuery("#low-price-range").html("$" + ui.values[0]);
                    jQuery("#high-price-range").html("$" + ui.values[1]);
                }
            });
    
            jQuery("#low-price-range").html("$" + jQuery("#slider-range").slider("values", 0));
            jQuery("#high-price-range").html("$" + jQuery("#slider-range").slider("values", 1));
    
        });
    }


    // Rating starts in shop page
    if(jQuery(".rateProduct").length){
        jQuery(".rateProduct").rateYo({
            rating: 5,
            fullStar: true,
            readOnly: true,
            starWidth: "13px",
            normalFill: "#ebebeb",
            ratedFill: "#f5cc0c",
            spacing: "2px",
            onSet: function (rating, rateYoInstance) {
                console.log("Rating is set to: " + rating);
            }
        });
    }

    // Insert Custom Angle down to selct v2
    setTimeout(() => {
        jQuery(".custom-select-style.v2 .btn-default").find(".bs-caret").empty().append("<i class='ti-angle-down'></i>");
    }, 600);

    // Toggle Grid Type
    jQuery(".grid-type a").on("click", function () {
        jQuery(".grid-type a").removeClass("active");
        jQuery(this).addClass("active");
        var targetLayoutType = jQuery(this).data("layout");
        if (targetLayoutType == "list") {
            jQuery(".cab-shop-products-container .cab-product-grid-layout").fadeOut('fast');
            jQuery(".cab-shop-products-container .cab-product-list-layout").fadeIn();
        } else if (targetLayoutType == "grid") {
            jQuery(".cab-shop-products-container .cab-product-grid-layout").fadeIn();
            jQuery(".cab-shop-products-container .cab-product-list-layout").fadeOut('fast');
        }
        return false;
    });

    // Single Page Product Gallery Slider
    if(jQuery(".single-product-main-slider").length){
        var galleryTop = new Swiper('.single-product-main-slider', {
            spaceBetween: 10,
            loop: true,
            loopedSlides: 4,
            speed: 700,
            effect: 'fade',
            fade: true,
        });
        var galleryThumbs = new Swiper('.single-product-thumbs', {
            spaceBetween: 12,
            centeredSlides: true,
            slidesPerView: 5,
            touchRatio: 0.2,
            slideToClickedSlide: true,
            loop: true,
            loopedSlides: 4,
            breakpoints: {
                0:{
                    slidesPerView: 3,
                },
                575: {
                  slidesPerView: 3,
                },
                768: {
                  slidesPerView: 5,
                },
                1024: {
                  slidesPerView: 5,
                }
              }
        });
        galleryTop.controller.control = galleryThumbs;
        galleryThumbs.controller.control = galleryTop;
    }


    // Product Count Spinner
    jQuery("#decrease_no").on("click", function(){
        decreaseValue();
    });
    jQuery("#increase_no").on("click", function(){
        increaseValue();
    });
    function increaseValue() {
        var value = parseInt(document.getElementById('no_of_products').value, 10);
        value = isNaN(value) ? 0 : value;
        value++;
        document.getElementById('no_of_products').value = value;
    }
    
    function decreaseValue() {
        var value = parseInt(document.getElementById('no_of_products').value, 10);
        value = isNaN(value) ? 0 : value;
        value < 1 ? value = 1 : '';
        value--;
        document.getElementById('no_of_products').value = value;
    }

    // Single Product Page Rating Reviews
    if(jQuery(".rateSingleProduct").length){
        jQuery(".rateSingleProduct").rateYo({
            rating: 0,
            fullStar: true,
            readOnly: false,
            starWidth: "18px",
            normalFill: "#233d62",
            ratedFill: "#FFD600",
            spacing: "2px",
            "starSvg": "<svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24'>"+
                     "<path d='M12 6.76l1.379 4.246h4.465l-3.612 2.625 1.379"+
                               " 4.246-3.611-2.625-3.612 2.625"+
                               " 1.379-4.246-3.612-2.625h4.465l1.38-4.246zm0-6.472l-2.833"+
                               " 8.718h-9.167l7.416 5.389-2.833 8.718 7.417-5.388"+
                               " 7.416 5.388-2.833-8.718"+
                               " 7.417-5.389h-9.167l-2.833-8.718z'></path>"+
                    "</svg>",
            onSet: function (rating, rateYoInstance) {
                console.log("Rating is set to: " + rating);
            }
        });
    }
    

});