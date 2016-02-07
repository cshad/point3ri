$(document).ready(function(){
	$('.demo-btn').on('click', function(){
	    $('.demo-container').slideToggle();
	});

	$('.color-option').on('click', function(){
		var color = $(this).attr('data-color-value');
		$('#color-style').attr('href', 'css/'+color+'.min.css');
		//$('#color-script').attr('src', 'js/script-'+color+'.js');
		$('#color-script').remove();
		$('#js-demo').before('<script src="js/script-'+color+'.js" id="color-script"></script>');
		$('#text-dot').attr('class','');
		$('#text-dot').addClass('text-'+color);
	});
})