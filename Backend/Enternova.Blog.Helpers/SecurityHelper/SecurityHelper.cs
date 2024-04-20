using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Enternova.Blog.Helpers.SecurityHelper
{
    /// <summary>
    /// Metodos estaticos para el Helper de seguridad
    /// </summary>
    public static class SecurityHelper
    {
        /// <summary>
        /// Metodo para obtener un Token apartir de una lista de Claims
        /// </summary>
        public static string GetToken(this List<Claim> Claims, string SecurityKey)
        {
            SecurityKey Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            SigningCredentials Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken Token =
                new JwtSecurityToken(issuer: null, audience: null, claims: Claims, notBefore: null, expires: DateTime.Now.AddDays(30), signingCredentials: Credentials);

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
