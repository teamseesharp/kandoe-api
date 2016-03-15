using System;
using System.Collections.Generic;
using System.Web.Configuration;

using Jose;

namespace Kandoe.Web.Auth0 {
    public static class TokenFactory {
        public static string ClientId { get; private set; }
        public static string ClientSecret { get; private set; }
        public static string Domain { get; private set; }

        public static string Connection { get; private set; }
        public static string UserId { get; private set; }

        public static void Configure() {
            // thomasvd, acc #1
            string connection = "Username-Password-Authentication";
            string userId = "auth0|56d4591317aca91f1aff5dfb";

            Configure(connection, userId);
        }

        public static void Configure(string connection, string userId) {
            ClientId = WebConfigurationManager.AppSettings["auth0:ClientId"];
            ClientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];
            Domain = WebConfigurationManager.AppSettings["auth0:Domain"];

            Connection = connection;
            UserId = userId;
        }

        public static string GetToken() {
            byte[] secretKey = Base64UrlDecode(ClientSecret);
            DateTime issued = DateTime.Now;
            DateTime expire = DateTime.Now.AddHours(10);

            var payload = new Dictionary<string, object>() {
                {"iss", String.Format("{0}{1}{2}", "https://", Domain, "/")},
                {"aud", ClientId},
                //{"sub", String.Format("{0}|{1}", Connection, UserId)},
                {"sub", UserId},
                {"iat", ToUnixTime(issued).ToString()},
                {"exp", ToUnixTime(expire).ToString()}
            };

            string token = Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);

            return token;
        }

        /// <remarks>
        /// Take from http://stackoverflow.com/a/33113820
        /// </remarks>
        static byte[] Base64UrlDecode(string arg) {
            string s = arg;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length % 4) { // Pad with trailing '='s
                case 0:
                    break; // No pad chars in this case
                case 2:
                    s += "==";
                    break; // Two pad chars
                case 3:
                    s += "=";
                    break; // One pad char
                default:
                    throw new System.Exception(
             "Illegal base64url string!");
            }
            return Convert.FromBase64String(s); // Standard base64 decoder
        }

        static long ToUnixTime(DateTime dateTime) {
            return (int) (dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}