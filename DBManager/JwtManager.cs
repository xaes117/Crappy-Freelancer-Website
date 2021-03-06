using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    class JwtManager
    {
        public static string getWebToken(string email) 
        {

            DataManager dataManager = new DataManager();

            try {
                
                
                string uid = dataManager.Select("select uid from users where users.email = '" + email + "';")[0][0];

                string getLatestTokenQuery = "select web_tokens.jwt, max(web_tokens.expiry) from web_tokens, users u "
                        + "where u.uid = web_tokens.uid and u.email = '" + email + "';";

                List<List<string>> tokenInfo = dataManager.Select(getLatestTokenQuery);

                DateTime expiryDate = DateTime.Parse(tokenInfo[0][1]);
                string hashHMACHex = tokenInfo[0][0];

                if (hashHMACHex == null || expiryDate < DateTime.Now)
                {
                    hashHMACHex = CreateToken(JwtManager.randomString(), email);

                    string newExpiration = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
                    string createJwtQuery = "INSERT INTO `soft7003`.`web_tokens` (`jwt`, `uid`, `expiry`) VALUES ('" + hashHMACHex + "', '" + uid + "', '" + newExpiration + "');";
                    dataManager.Insert(createJwtQuery);
                }
                return hashHMACHex;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }

        }

        private static string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        private static string randomString()
        {
            int stringLength = 250;
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[new Random().Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
