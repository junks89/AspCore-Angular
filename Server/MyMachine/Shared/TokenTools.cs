using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class TokenTools
    {
        /// <summary>
        /// Secret-Key fuer diese Applikation
        /// </summary>
        string _secret = "MyTopSecretEPSSecret";
        /// <summary>
        /// User
        /// </summary>
        string _audience = "gerhard";
        /// <summary>
        /// Aussteller
        /// </summary>
        string _issuer = "gerhardsservice";
        /// <summary>
        /// Benutzerrolle
        /// </summary>
        string _role = "Administrator";
        /// <summary>
        /// Email als Identifier
        /// </summary>
        string _emailIdentifier = "gerhard@eps-software.at";
        /// <summary>
        /// Etwaige Fehlermeldung bei der Validierung
        /// </summary>
        /// <returns></returns>
        public string ErrorValidationMessage { get; set; }

        public string CreateToken()
        {
            var signingKey = GetSigningKey();
            var signingCredentials = new SigningCredentials(signingKey,
                SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, _emailIdentifier),
                    new Claim(ClaimTypes.Role, _role),
                    new Claim("MyAdditionalInfo", "bla bla ga ga")
                }, "Custom");
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _audience,
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.Now.AddMinutes(15),
                Issuer = _issuer
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);
            return signedAndEncodedToken;
        }

        private SymmetricSecurityKey GetSigningKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        }

        public bool ValidateToken(string token, AuthorizationModel model = null)
        {
            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();
            SecurityToken validatedToken;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
                var ob = new JwtSecurityToken(token);
                if (model != null)
                {
                    model.Role = ob.Payload["role"].ToString();
                    model.MyAdditionalInfo = ob.Payload["MyAdditionalInfo"].ToString();
                }
                return true;
            }
            catch (Exception e)
            {
                ErrorValidationMessage = e.Message;
                return false;
            }
        }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidAudiences = new string[] { _audience },
                ValidateIssuer = true,
                ValidIssuers = new string[] { _issuer },
                IssuerSigningKey = GetSigningKey()
            };
        }
    }
}
