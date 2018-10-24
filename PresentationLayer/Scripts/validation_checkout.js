// Dette dokumentet inneholder alle funksjonene som kreves for front-end validering av kreditt-informasjon. 
// Har valgt å ikke vise feilmeldinger hvis felt er tomme, da vi ikke overdrive med feilmeldinger som vises hele tiden. Knappen for å gå videre
// er forøvrig ikke aktivert før alle felt er fylt ut. 

$(function () {

    // Gjemmer alle feilmeldingene
    $("#checkout-card-number-error").hide();
    $("#checkout-card-date-error").hide();
    $("#checkout-card-cvc-error").hide();
    $("#checkout-zipnr-error").hide();
    $('#buyButton').attr("disabled", true);
    $('#buyButton').css('background-color', 'grey');

    // Variabler som brukes for å sjekke om alle felt er fylt inn
    var error_card_number = false;
    var error_card_date = false;
    var error_card_cvc = false;
    var error_name = false;
    var error_address = false;
    var error_zipnr = false;
    var error_city = false;

    // Metodene under kjøres på input for live validering. Ikke like bra ytelse som hvis vi hadde kjørt metodene på focus out,
    // men ytelsen blir ikke nevnverdig dårligere.

    // Kredittkort-nummer. Bytter også automatisk til neste felt hvis kortnummeret er på godkjent format.
    $("#form-credit-card").on('input', function() {
        check_creditcard_nr()
        check_all();
        if(error_card_number == true){
            $("#form-credit-date").focus();
        }
    })

    // Automatisk sett inn mellomrom etter hvert fjerde siffer
    $("#form-credit-card").on('keypress change', function() {
        $(this).val(function (index, value) {
            return value.replace(/\W/gi, '').replace(/(.{4})/g, '$1 ');
        });
    })

    // Kredittkort-dato. Bytter også automatisk til neste felt hvis datoen er på godkjent format.
    $("#form-credit-date").on('input', function() {
        check_creditcard_date();
        check_all();
        if(error_card_date == true){
            $("#form-credit-cvc").focus();
        }
    })

    // Automatisk sett inn mellomrom etter de to første sifrene.
    $("#form-credit-date").on('keypress change', function() {
        $(this).val(function (index, value) {
            return value.replace(/\W/gi, '').replace(/(.{2})/i, '$1 ');
        });
    })
    
    // Kredittkort-CVC. Bytter også automatisk til neste felt hvis CVC er på godkjent format.
    $("#form-credit-cvc").on('input', function() {
        check_creditcard_cvc();
        check_all();
        if(error_card_cvc == true){
            $("#checkout-name").focus();
        }
    })

    // Fult navn. Godkjent hvis den ikke er tom
    $("#checkout-name").on('input', function() {
        check_name();
        check_all();
    })

    // Adresse. Godkjent hvis den ikke er tom
    $("#checkout-address").on('input', function() {
        check_address();
        check_all();
    })

    // Zip-nummer. Godkjent hvis ved 4 siffer.
    $("#checkout-form-zip").on('input', function() {
        check_zip();
        check_all();
    })

    // By. Godkjent hvis den ikke er tom
    $("#checkout-city").on('input', function() {
        check_city();
        check_all();
    })

    // Funksjon for å sjekke at kredittkort-nr er 12 siffer på riktig format, og kun tall. 
    function check_creditcard_nr() {
        var regex = new RegExp(/^[0-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}$/i)
        var length = $("#form-credit-card").val().length;
        var error_id = "#checkout-card-number-error";
        var input_id = "#form-credit-card";

        if(length == 0){
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_card_number = false;
        } else if (regex.test($(input_id).val())) {
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_card_number = true;
        } else {
            $(error_id).show();
            $(input_id).addClass('input-error-border');
            error_card_number = false;
        }

    }

    // Funksjon for å sjekke at kredittkort-nr er 6 siffer på riktig format, og kun tall. 
    function check_creditcard_date() {
        var regex = new RegExp(/^[0-9]{2}\s[0-9]{4}$/i)
        var length = $("#form-credit-date").val().length;
        var error_id = "#checkout-card-date-error";
        var input_id = "#form-credit-date";

        if(length == 0){
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_card_date = false;
        } else if (regex.test($(input_id).val())) {
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_card_date = true;
        } else {
            $(error_id).show();
            $(input_id).addClass('input-error-border');
            error_card_date = false;
        }
    }

    // Funksjon for å sjekke at kredittkort-cvc er 3 siffer, og kun tall. 
    function check_creditcard_cvc() {
        var regex = new RegExp(/^[0-9]{3}$/i)
        var length = $("#form-credit-cvc").val().length;
        var error_id = "#checkout-card-cvc-error";
        var input_id = "#form-credit-cvc";

        if(length == 0){
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_card_cvc = false;
        } else if (regex.test($(input_id).val())) {
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_card_cvc = true;
        } else {
            $(error_id).show();
            $(input_id).addClass('input-error-border');
            error_card_cvc = false;
        }

    }

    // Funksjon for å sjekke at navn ikke er tomt.
    function check_name() {
        var name_length = $("#checkout-name").val().length;

        if(name_length < 1){
            error_name = false;
        } else {
            error_name = true;
        }   
    }

    // Funksjon for å sjekke at adresse ikke er tom.
    function check_address() {
        var name_length = $("#checkout-address").val().length;

        if(name_length < 1){
            error_address = false;
        } else {
            error_address = true;
        }
    }

    // Funksjon for å sjekke at zip er akkurat 4 siffer
    function check_zip() {
        var regex = new RegExp(/^[0-9]{4}$/i);
        var length = $("#checkout-form-zip").val().length;
        var error_id = "#checkout-zipnr-error";
        var input_id = "#checkout-form-zip";

        if(length == 0){
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_zipnr = false;
        } else if (regex.test($(input_id).val())) {
            $(error_id).hide();
            $(input_id).removeClass('input-error-border');
            error_zipnr = true;
        } else {
            $(error_id).show();
            $(input_id).addClass('input-error-border');
            error_zipnr = false;
        }
    }

    // Funksjon for å sjekke at by ikke er tom.
    function check_city() {
        var name_length = $("#checkout-city").val().length;

        if(name_length < 1){
            error_city = false;
        } else {
            error_city = true;
        }
    }
     
    // Funksjon for å sjekke at alle felt er fylt ut, og hvis de er det, aktivere knappen.
    function check_all() {
        if(error_card_number == true && error_card_date == true && error_card_cvc == true && error_name == true && error_address == true && error_zipnr == true && error_city == true) {
            $('#buyButton').attr("disabled", false);
            $('#buyButton').css('background-color', 'rgb(0, 204, 102)');
        } else {
            $('#buyButton').attr("disabled", true);
            $('#buyButton').css('background-color', 'grey');
        }
    }

    

})