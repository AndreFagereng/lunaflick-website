// A document for a little more general scripts.

// Venter med å vise sidens innhold til alt er lastet inn. Foreløpig fjernet siden den fusket på min side.
/*
$(window).load(function() {
    $("body").fadeIn(500);
})
*/


// Setter fokus på brukernavn-inputten når man åpner login-modal
$('.modal').on('shown.bs.modal', function (e) {
    $('.modal input[type="text"]')[0].select();
});

// Check if cart is empty, and if it's not, activate checkout-button
// Sjekker om handlekurven er tom, og viser innhold avhengig av den sjekken. 
var priser = $(".cart_item").find(".checkoutCount");

function checkIfItemsInCart() { 
    if(priser.length < 1) {
        $('#checkoutButton').attr("disabled", true);
        $('#checkoutButton').css('background-color', 'grey');
        $('#emptyCartMsg').show();
    } else {
        $('#checkoutButton').attr("disabled", false);
        $('#checkoutButton').css('background-color', 'rgb(230,0,6)');
        $('#emptyCartMsg').hide();
    }
}

// Legger funksjonen til knappen som åpner handlekurven.
$("#cartLink").click(checkIfItemsInCart);