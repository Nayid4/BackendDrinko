using Domain.Usuarios;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace Application.Custom
{
    public class Utilidades
    {
        private readonly IConfiguration _configuration;
        public Utilidades(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string encriptarSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el Hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                // Convertir el array de bytes a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string generarJWT(Usuario usuario)
        {
            // Crear la informacion del usuario para token
            var UserClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.Valor.ToString()),
                new Claim(ClaimTypes.Email, usuario.Correo.ToString()),
                new Claim(ClaimTypes.Role, usuario.Rol.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentias = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Crear detalle del token
            var jwtConfig = new JwtSecurityToken(
                claims: UserClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentias
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
