using BusBookingSystem.Models;
using System.Security.Cryptography;
using System.Text;

namespace BusBookingSystem.Common
{
    public class Algorithms
    {
        public Credentials GenerateSaltedHash(string Password)
        {

            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password, salt);

            return new Credentials { salt=salt, hashedPassword=hashedPassword };

        }

        public Credentials GeneratePlainText(string Password)
        {

            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password, salt);

            return new Credentials { salt = salt, hashedPassword = hashedPassword };

        }
    }
}
