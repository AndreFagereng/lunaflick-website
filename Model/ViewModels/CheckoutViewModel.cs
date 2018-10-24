using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.ViewModels
{
    /// <summary>
    /// En ViewModel for innhenting av kortnr, samt kort-brukers informasjon.
    /// Denne dataen har vi valgt å ikke lagre i en database da dette ikke er nødvendig(i vårt tilfelle).
    /// Siden vi støtte på noen små validerings problemer(Se README filen), ønsket vi mer server-side validering, 
    /// derfor opprettet vi denne ViewModellen. 
    /// </summary>
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Kortnr må oppgis")]
        [DisplayName("XXXX XXXX XXXX XXXX")]
        public string CardNr { get; set; }
        [Required(ErrorMessage = "Kort-dato må oppgis")]
        [DisplayName("MM YYYY")]
        public string CardDate { get; set; }
        [Required(ErrorMessage = "CCV må oppgis")]
        [DisplayName("CCV")]
        public string CCV { get; set; }
        [Required(ErrorMessage = "Navn må oppgis")]
        [DisplayName("Fullt navn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Adresse må oppgis")]
        [DisplayName("Addresse")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Postnummer må oppgis")]
        [DisplayName("Postnummer")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Poststed må oppgis")]
        [DisplayName("Poststed")]
        public string PostalArea { get; set; }
        public User User { get; set; }
    }
}