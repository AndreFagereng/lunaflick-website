// Dette dokumentet inneholder alle funksjonene som kreves for front-end validering av bruker-informasjon. 
// Har valgt å ikke vise feilmeldinger hvis felt er tomme, da vi ikke overdrive med feilmeldinger som vises hele tiden. Knappen for å gå videre
// er forøvrig ikke aktivert før alle felt er fylt ut. 

$(function () {
    // Gjemmer alle feilmeldingene
    $("#email-error").hide();
    $("#zipnr-error").hide();
    $("#password-error").hide();
    $('#registerButton').attr("disabled", true);
    $('#registerButton').css('background-color', 'grey');

    // Variabler som brukes for å sjekke om alle felt er fylt inn
    var error_firstname = false;
    var error_lastname = false;
    var error_email = false;
    var error_address = false;
    var error_zipnr = false;
    var error_city = false;
    var error_password = false;


    ///////////// VALIDATION ON INPUT /////////////////

    // Funksjonene under sjekker at input-felt ikke er tomme, og følger riktig regex hvis det kreves.
    $("#form-firstname").on('input', function() {
        check_firstname();
        checkAll();
    })

    $("#form-lastname").on('input', function() {
        check_lastname();
        checkAll();
    })
    

    $("#form-email").on('input', function() {
        check_email();
        checkAll();
    })

    $("#form-address").on('input', function() {
        check_address();
        checkAll();
    })

    $("#form-zipnr").on('input', function() {
        check_zip();
        checkAll();
    })

    $("#form-city").on('input', function() {
        check_city();
        checkAll();
    })

    $("#form-password").on('input', function() {
        check_password();
        checkAll();
    })

    // Sjekker at fornavn ikke er tomt.
    function check_firstname() {
        var name_length = $("#form-firstname").val().length;

        if(name_length < 1){
            error_firstname = false;
        } else {
            error_firstname = true;
        }   
    }

    // Sjekker at etternavn ikke er tomt.
    function check_lastname() {
        var name_length = $("#form-lastname").val().length;

        if(name_length < 1){
            error_lastname = false;
        } else {
            error_lastname = true;
        }   
    }

    // Sjekker at email ikke er tom, og at den er på riktig format ved hjelp av regex. 
    function check_email() {
        var regex = new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);
        var email_length = $("#form-email").val().length;

        if(email_length == 0){
            $("#email-error").hide();
            $("#form-email").removeClass('input-error-border');
            error_email = false;
        } else if (regex.test($("#form-email").val())) {
            $("#email-error").hide();
            $("#form-email").removeClass('input-error-border');
            error_email = true;
        } else {
            $("#email-error").show();
            $("#form-email").addClass('input-error-border');
            error_email = false;
        }
    }

    // Sjekker at adressen ikke er tom.
    function check_address() {
        var name_length = $("#form-address").val().length;

        if(name_length < 1){
            error_address = false;
        } else {
            error_address = true;
        }   
    }

    // Sjekker at zipnr er akkurat 4 siffer. 
    function check_zip() {
        var regex = new RegExp(/^[0-9]{4}$/i);
        var zip_length = $("#form-zipnr").val().length;
        
        if (zip_length == 0){
            $("#zipnr-error").hide();
            $("#form-zipnr").removeClass('input-error-border');
        } else if (regex.test($("#form-zipnr").val())) {
            $("#zipnr-error").hide();
            $("#form-zipnr").removeClass('input-error-border');
            error_zipnr = true;
        }else {
            $("#zipnr-error").show();
            $("#form-zipnr").addClass('input-error-border');
            error_zipnr = false;
        }
    }

    // Sjekker at by ikke er tomt
    function check_city() {
        var name_length = $("#form-city").val().length;

        if(name_length < 1){
            error_city = false;
        } else {
            error_city = true;
        }   
    }

    // Sjekker at passord ikke er tomt, og minst 8 tegn.
    function check_password() {
        var name_length = $("#form-password").val().length;

        if(name_length == 0) { 
            $("#password-error").hide();
            $("#form-password").removeClass("input-error-border");
            error_password = false;
        } else if(name_length < 8){
            $("#password-error").show();
            $("#form-password").addClass("input-error-border");
            error_password = false;
        } else {
            $("#password-error").hide();
            $("#form-password").removeClass("input-error-border");
            error_password = true;
        }
    }

    // Funksjon for å sjekke at alle felt er fylt ut, og hvis de er det, aktivere knappen.
    function checkAll() {
        if(error_firstname == true && error_lastname == true && error_email == true && error_address == true && error_zipnr == true && error_city == true && error_password == true) {
            $('#registerButton').attr("disabled", false);
            $('#registerButton').css('background-color', 'rgb(230,0,6)');
        } else {
            $('#registerButton').attr("disabled", true);
            $('#registerButton').css('background-color', 'grey');
        }
    }



})