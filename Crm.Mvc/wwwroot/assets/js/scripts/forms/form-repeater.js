/*=========================================================================================
    File Name: Form-Repeater.js
    Description: form repeater page specific js
==========================================================================================*/

$(document).ready(function () {
	// form repeater jquery
	$('.file-repeater, .contact-repeater, .repeater-default').repeater({
		show: function () {
			$(this).slideDown();
		},
		hide: function (deleteElement) {
            $(this).slideUp(deleteElement);
			
		}
	});

});