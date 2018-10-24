using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace DAL.Utilities.Security
{
    /// <summary>
    /// Lånt implementasjon fra sikkerhets-kompendiet.
    /// </summary>
    public class PasswordEncryption
	{
		public static byte[] toHash(string password, byte[] salt)
		{
			const int keyLength = 24;
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
			return pbkdf2.GetBytes(keyLength);
		}

		public static byte[] addSalt()
		{
			var csprng = new RNGCryptoServiceProvider();
			var salt = new byte[24];
			csprng.GetBytes(salt);
			return salt;

		}
	
	}
}