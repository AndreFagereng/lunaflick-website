// All javascript for the admin panel

///////////////////////////// USER ORDER SCROLL //////////////////////////////

function scrollToDiv(userClass) {
	$(userClass).click(function() {
	    $([document.documentElement, document.body]).animate({
	        scrollTop: $(this).offset().top
	    }, 500);
	})
};

/////////////////////////////////// ORDERS ///////////////////////////////////

if ($('body').is('.orders')) {

    // Hide the user table by default
    $('#userTable').css('display', 'none');

    // Show table for user when user selected in selectbox
    $('#userSelect').on('change', function() {
        showTableIfUserSelected();
    });

    // The function that checks if a value has been selected in the selectbox
    function showTableIfUserSelected() {
        var s = $('#userSelect').val();
        if (s != null) {
            $('#userTable').css('display', '');
        } else {
            $('#userTable').css('display', 'none');
        }
    };
};  


/////////////////////////////////// PAGE LOAD ///////////////////////////////////

$(window).load(function() {

    $('a.admin-nav-link').on('mouseover', function() {
        $(this).css('color', 'rgb(237, 4, 4)');
    }).on('mouseout', function() {
          $(this).css('color', 'rgb(51, 51, 51)');
    });

    if ($('body').is('.orders')) {
        // Checks value of selectbox on page refresh. If this check is not in place, the table wouldnt show when you refresh the site after you have chosen a value 
        showTableIfUserSelected();
        $('.feedback-message span').click(function() {
        $('.feedback-message').slideUp();
    });
    } else {
        return undefined;
    }
});