using System;
using System.Text;

namespace Dota2Service.UserService.Token
{
    public class TokenGenerator
    {
        private static readonly Random random = new Random();
        private const string UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialChars = "#@-=";

        public static string GenerateToken()
        {
            string part1 = RandomString(8, UpperLetters + LowerLetters + Digits);

            string part2 = RandomString(5, LowerLetters + SpecialChars);

            string part3 = RandomString(2, Digits);

            return part1 + part2 + part3;
        }

        private static string RandomString(int length, string chars)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }

}
