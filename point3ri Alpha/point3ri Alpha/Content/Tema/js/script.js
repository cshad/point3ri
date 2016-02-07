$(document).ready(function(){

	/* Navbar */
	$(window).scroll(function(){
		if( $(window).scrollTop() > 80){
			$('.navbar').removeClass('navbar-transparent');
		}else{
			$('.navbar').addClass('navbar-transparent');
		}
	});

  if( $(window).scrollTop() > 80){
    $('.navbar').removeClass('navbar-transparent');
  }


  /* Parallax Background */
  $('#header').parallax();


  /* Filtering Image */
  var $wrapper = $('.wrapper-portfolio');
    $wrapper.isotope({
      filter: '*',
      animationOptions: {
          duration: 750,
          easing: 'easeOutBounce',
          queue: false
      }
  });

  $('.portfolio-sort > li').on('click', function(){
      $('.portfolio-sort > li.active').removeClass('active');
      $(this).addClass('active');

      var selector = $(this).attr('data-filter');
      $wrapper.isotope({
          filter: selector,
          animationOptions: {
              duration: 750,
              easing: 'easeOutBounce',
              queue: false
          }
       });
      setProjects();
      
      return false;
  });

  /* Set Column Portfolio */
  function splitColumns() { 
    var winWidth = $(window).width(), columnNumb = 1;
    if (winWidth > 1200) {
      columnNumb = 4;
    } else if (winWidth > 992 && winWidth < 1200) {
      columnNumb = 4;
    } else if (winWidth > 768 && winWidth < 992) {
      columnNumb = 2;
    } else if (winWidth > 662 && winWidth < 768) {
      columnNumb = 2;
    } else if(winWidth < 662 || winWidth < 480) {
      columnNumb = 1;
    }
    return columnNumb;
  }

  function setColumns() { 
    var winWidth = $(window).width(), columnNumb = splitColumns(), postWidth = Math.floor(winWidth / columnNumb);
    $wrapper.find('.wrapper-portfolio li').each(function () { 
      $(this).css( { 
        width : postWidth + 'px' 
      });
    });
  }

  function setProjects() { 
    setColumns();
    $wrapper.isotope('reLayout');
  }

  $wrapper.imagesLoaded(function () { 
    setColumns();
  });

  $(window).bind('resize', function () { 
    setProjects();          
  });
 
  /* Masonry Blog Layout */
	var $container = $('.container-post');
	$container.imagesLoaded( function(){
    	$container.masonry();
	});

	/* Maps */
	$("#map").gmap3({
        map: {
            options: {
              center: [-7.866315,110.389574],
              zoom: 10,
              scrollwheel: false
            }  
         },
        marker:{
            latLng: [-7.866315,110.389574],
            options: {
             icon: new google.maps.MarkerImage(
               "https://dl.dropboxusercontent.com/u/29545616/Preview/location.png",
               new google.maps.Size(48, 48, "px", "px")
             )
            }
         }
    });
	
});