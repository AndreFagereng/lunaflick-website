using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.ViewModels
{
    /// <summary>
    /// En view-modell for user-modellen. Required-attributtene fungerer ikke
    /// slik vi ønsker da modalen for registrering og logg-inn ligger sammen
    /// og gjør at valideringen aldri vil kunne bli gjennomført. Derfor tenker
    /// vi at å separere userviewmodel inn i to klasser kan være en løsning senere
    /// i oppgaven.
    /// </summary>
	public class UserViewModel
	{

        public int UserId { get; set; }
        [DisplayName("Epost")]
        [Required(ErrorMessage = "Epost må oppgis")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passord må oppgis")]
        [DisplayName("Passord")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Fornavn må oppgis")]
        [DisplayName("Fornavn")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Etternavn må oppgis")]
        [DisplayName("Etternavn")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Adresse må oppgis")]
        [DisplayName("Adresse")]
        public string Address { get; set; }
        //[Required(ErrorMessage = "Postnummer må oppgis")]
        //[RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnummer må være 4 siffer")]
        [DisplayName("Postnummer")]
        public string ZipCode { get; set; }
        //[Required(ErrorMessage = "Poststed må oppgis")]
        [DisplayName("Poststed")]
        public string PostalArea { get; set; }

	}
}