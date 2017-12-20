// ScrollTop_BTN
$(function(){
  $('#topBTN').click(function(){
    var $body = (window.opera) ? (document.compatMode == "CSS1Compat" ? $('html') : $('body')) : $('html,body');
    $body.animate({
      scrollTop: 0
    }, 600);
    return false;
  });
  $(window).scroll(function () {
    var scrollVal = $(this).scrollTop();
    if(scrollVal > 200){
      $('#topBTN').fadeIn();
    }else{
      $('#topBTN').fadeOut();  
    };
  });
});










// datepicker中文
$( function() {
  $( "#datepicker" ).datepicker({
    numberOfMonths: 2,
    showButtonPanel: true
  });
  //設定中文語系
  $.datepicker.regional['zh-TW']={
     dayNames:["星期日","星期一","星期二","星期三","星期四","星期五","星期六"],
     dayNamesMin:["日","一","二","三","四","五","六"],
     monthNames:["1月","2月","3月","4月","5月","6月","7月","8月","9月","10月","11月","12月"],
     monthNamesShort:["1月","2月","3月","4月","5月","6月","7月","8月","9月","10月","11月","12月"],
     prevText:"上月",
     nextText:"次月",
     weekHeader:"週"
  };
  //將預設語系設定為中文
  $.datepicker.setDefaults($.datepicker.regional["zh-TW"]);
  //套用到表單
  $(function() {
    $( "#日期欄位" ).datepicker({dateFormat: 'yy/mm/dd'});
  });
} );













// search展開收合
$( function() {
  $('.searchMoreBtn').click(function(){
    $(this).hide();
    $('.searchCriteria').show();
  });
  $('.cancelSearch').click(function(){
    $('.searchCriteria').hide();
    $('.searchMoreBtn').show();
  });
});












// 左右滑
 /*
$(document).ready(function(){ 
  var list = 0;
  $(".star-left01").click(function(){ 
    if (list > 0) {
        $(".star-list01").animate({ left: "+=380px" }, 5);
        list -= 1;
    }
    else {
        $(".star-list01").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-right01").click(function(){ 
    if (list < 4) { //小於總數減1
        $(".star-list01").animate({ left: "-=380px" }, 5);
        list += 1;
    }
    else {
        $(".star-list01").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-left02").click(function(){ 
    if (list > 0) {
        $(".star-list02").animate({ left: "+=380px" }, 5);
        list -= 1;
    }
    else {
        $(".star-list02").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-right02").click(function(){ 
    if (list < 4) {
        $(".star-list02").animate({ left: "-=380px" }, 5);
        list += 1;
    }
    else {
        $(".star-list02").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-left03").click(function(){ 
    if (list > 0) {
        $(".star-list03").animate({ left: "+=380px" }, 5);
        list -= 1;
    }
    else {
        $(".star-list03").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-right03").click(function(){ 
    if (list < 4) {
        $(".star-list03").animate({ left: "-=380px" }, 5);
        list += 1;
    }
    else {
        $(".star-list03").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-left04").click(function(){ 
    if (list > 0) {
        $(".star-list04").animate({ left: "+=380px" }, 5);
        list -= 1;
    }
    else {
        $(".star-list04").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-right04").click(function(){ 
    if (list < 5) {
        $(".star-list04").animate({ left: "-=380px" }, 5);
        list += 1;
    }
    else {
        $(".star-list04").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-left05").click(function(){ 
    if (list > 0) {
        $(".star-list05").animate({ left: "+=380px" }, 5);
        list -= 1;
    }
    else {
        $(".star-list05").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
  $(".star-right05").click(function(){ 
    if (list < 5) {
        $(".star-list05").animate({ left: "-=380px" }, 5);
        list += 1;
    }
    else {
        $(".star-list05").animate({ left: "0px" }, 5);
        list = 0;
    }
  }); 
}); 


*/










// 光箱開收
$(function(){
  $('.lightboxOpen-control01').click(function(){
    $('.lightboxOpen01').fadeIn();
  });
  $('.lightboxOpen-control02').click(function(){
    $('.lightboxOpen02').fadeIn();
  });
  $('.lightboxOpen-control03').click(function(){
    $('.lightboxOpen03').fadeIn();
  });
  $('.lightboxOpen-control04').click(function(){
    $('.lightboxOpen04').fadeIn();
  });
  /*$('.lightbox-moreGroup-open').click(function(){
    $('.lightbox-moreGroup').fadeIn();
  });
  */
  $('.lightboxClose').click(function(){
    $('.lightboxOpen').fadeOut();
  });
});
















// 日曆開收

$(function(){
  $('.travel-calendar-open').click(function(){
    $('.travel-calendar-open').hide();
    $('.travel-calendar').fadeIn();
  });
  $('.travel-calendar-close-btn').click(function(){
    $('.travel-calendar').hide();
    $('.travel-calendar-open').fadeIn();
  });
});


















//innerMenu
$(function(){
    $(window).load(function () {
    if ($('#travel-traffic').position())
    $(window).bind('scroll resize', function () {
　　var $this = $(this);
　　var $this_Top=$this.scrollTop() + 100;

　　//當高度小於100時，關閉區塊 
　　if($this_Top < 850){
　　　$('#travel-innerMenu-fixed').stop().animate({top:"-150px"});
　　}
　　if($this_Top > 850){
　　　$('#travel-innerMenu-fixed').stop().animate({top:"0px"});
　　}
    $('#travel-innerMenu-fixed li').removeClass('active')
　　//if($this_Top > $('#travel-traffic').position().top){
  　　//}
  if($this_Top < $('#travel-characteristics').offset().top ){
    $('.fixed-menu-1').addClass('active');
  }
  else if ($this_Top < $('#travel-itinerary').offset().top) {
    　　　$('.fixed-menu-2').addClass('active');
    // 　　　$('.fixed-menu-2').removeClass('active');
  }
  else if ($this_Top < $('#travel-cost').offset().top) {
    　　　$('.fixed-menu-3').addClass('active');
    // 　　　$('.fixed-menu-3').removeClass('active');
  }
  else if ($this_Top < $('#travel-description').offset().top) {
    　　　$('.fixed-menu-4').addClass('active');
    // 　　　$('.fixed-menu-4').removeClass('active');
  } else {

    $('.fixed-menu-5').addClass('active');
  }
//     if ($this_Top < $('#travel-description').position().top) {
// 　　　$('.fixed-menu-5').removeClass('active');
//     }
//     if ($this_Top < $('#travel-cost').position().top) {
// 　　　$('.fixed-menu-4').removeClass('active');
//     }
//     if ($this_Top < $('#travel-itinerary').position().top) {
// 　　　$('.fixed-menu-3').removeClass('active');
//     }
//     if ($this_Top < $('#travel-characteristics').position().top) {
// 　　　$('.fixed-menu-2').removeClass('active');
//     }
//     if ($this_Top < $('#travel-traffic').position().top) {
// 　　　$('.fixed-menu-1').removeClass('active');
// 　　}


　　}).scroll();
　});
});



















// chooseDestination
$(function(){
  $('#destination-open').click(function(){
    $('.chooseDestination').fadeIn();
  });
  $('.destination-close').click(function(){
    $('.chooseDestination').fadeOut();
  });

});



// chooseDate
/*$(function(){
  $('#choose-date').click(function(){
    $('.chooseDate').fadeIn();
  });
  $('.date-btn>a').click(function(){
    $('.chooseDate').fadeOut();
  });

});*/









// 旅遊契約書
$(function(){
  $('.travelContractBook-Mopen').click(function(){
    $('.travelContractBook-Mopen').hide();
    $('.travelContractBook-Mclose').show();
    $('.travelContractBook').fadeIn();
  });
  $('.travelContractBook-Mclose').click(function(){
    $('.travelContractBook-Mclose').hide();
    $('.travelContractBook-Mopen').show();
    $('.travelContractBook').fadeOut();
  });
});

















// 付款-請注意
$(function(){
  $('.open-paymentInfo').click(function(){
    $('.open-paymentInfo-block').show();
  });
});














//看更多
$(function(){
  $('.travelInformation-more-mobile>a').click(function(){
    $('.travelInformation').css('height','auto');
    $('.travelInformation-more-mobile').hide();
  });
  $('.travel-itinerary-day-more>a').click(function(){
    $(this).parent().parent().css('height','auto');
    $(this).parent().hide();
  });
});



















// 手機板搜尋
$(function(){
  $('.mobile-searchLine').click(function(){
    $('.searchCriteria-mobiel').fadeIn();
  });
  $('.searchCriteria-mobiel-close').click(function(){
    $('.searchCriteria-mobiel').fadeOut();
  });
});


// 手機板搜尋-目的地
$(function(){
  $('#mobile-destination-open').click(function(){
    $('.mobile-destination').fadeIn();
  });
  $('.mobile-destination-close').click(function(){
    $('.mobile-destination').fadeOut();
  });

});

// 手機板搜尋-目的地關鍵字
$(function(){
  $('#mobile-destination-keyword').click(function(){
    $('.mobile-destination2').fadeIn();
  });
  $('.mobile-destination2-close').click(function(){
    $('.mobile-destination2').fadeOut();
  });

});


// 手機板搜尋-日期
$(function(){
  $('#mobile-datepick-open').click(function(){
    $('.mobile-chooseDate').fadeIn();
  });
  $('.mobile-chooseDate-close').click(function(){
    $('.mobile-chooseDate').fadeOut();
  });

});

var beforePrint = function () {
    //console.log('Functionality to run before printing.');
    $('#print-area1').html('')
    $('#print-area2').html('')
    $('#print-area3').html('')
    $('#print-area1').append($('.travelInformation')[0].outerHTML)
    $('#print-area1').append($('#travel-traffic')[0].outerHTML)
    $('#print-area2').append($($('#travel-characteristics')[0].outerHTML).removeClass('hidden-xs'))
    $('#print-area2').append('<div style="position:relative;">' + $('#travel-itinerary').html() + '</div>')
    $('#print-area3').append($('#travel-cost').html())
    $('#print-area3').append($('#travel-description').html())
    //$('.content.content-gray>.star-container').clone().text().appendTo('.print-area')
    //console.log($('.print-area').html())
};

$(function () {
    $('.icon-print').click(function () {
        beforePrint();
        window.print();
    })

});

(function () {
    
    var afterPrint = function () {
        console.log('Functionality to run after printing');
    };

    if (window.matchMedia) {
        var mediaQueryList = window.matchMedia('print');
        mediaQueryList.addListener(function (mql) {
            if (mql.matches) {
                beforePrint();
            } else {
                afterPrint();
            }
        });
    }

    window.onbeforeprint = beforePrint;
    window.onafterprint = afterPrint;
}());
