$(window).scroll(function(){
$('header').toggleClass('scrolled', $(this).scrollTop() > 500)
});

var btn = $('#button');

$(window).scroll(function() {
  if ($(window).scrollTop() > 300) {
    btn.addClass('show');
  } else {
    btn.removeClass('show');
  }
});

btn.on('click', function(e) {
  e.preventDefault();
  $('html, body').animate({scrollTop:0}, '300');
});


$(window, document, undefined).ready(function () {

  $('.input').blur(function () {
      var $this = $(this);
      if ($this.val())
          $this.addClass('used'); else

          $this.removeClass('used');
  });

});


$('#tab1').on('click', function () {
  $('#tab1').addClass('login-shadow');
  $('#tab2').removeClass('signup-shadow');
});

$('#tab2').on('click', function () {
  $('#tab2').addClass('signup-shadow');
  $('#tab1').removeClass('login-shadow');


});

$('#area-de-texto').keyup( function() {
  $(this).val( $(this).val().replace( /\r?\n/gi, '' ) );
});
