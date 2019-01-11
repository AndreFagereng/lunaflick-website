using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.AdminModel
{
    public class Login
    {
        [Required(ErrorMessage= "Vennligst oppgi brukernavn for administrator")]
        public string Username { get; set; }
        [Required(ErrorMessage="Vennligst oppgi passord for administrator")]
        public string Password { get; set; }
    }

    public class AdminUser
    {
        [Key]
        public string Username { get; set; }
        public byte[] Password { get; set; }
		public byte[] Salt { get; set; }
    }


}
