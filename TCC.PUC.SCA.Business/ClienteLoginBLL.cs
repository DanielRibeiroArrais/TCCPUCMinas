using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Login;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class ClienteLoginBLL
    {
        private readonly AppSettings _appSettings;

        public ClienteLoginBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public ClientLoginResponse AuthenticationRequest(ClientLoginRequest clientLoginRequest)
        {
            try
            {
                ClientLoginResponse clientLoginResponse = new ClientLoginResponse();

                Usuario usuario = new UsuarioBLL(_appSettings).ObterLista().Where(x => x.NomeUsuario.Equals(clientLoginRequest.Usuario) && x.Senha.Equals(clientLoginRequest.Senha)).FirstOrDefault();

                if (usuario != null)
                {
                    clientLoginResponse.Authenticated = true;
                    clientLoginResponse.CreationDate = DateTime.UtcNow;
                    clientLoginResponse.ExpirationDate = DateTime.UtcNow.AddHours(Convert.ToInt32(_appSettings.ExpirationHours));
                    clientLoginResponse.AccessToken = GerarJwt(usuario);
                    clientLoginResponse.Message = "OK!";
                }
                else
                {
                    clientLoginResponse.Authenticated = false;
                    clientLoginResponse.CreationDate = null;
                    clientLoginResponse.ExpirationDate = null;
                    clientLoginResponse.Message = "Authentication Failure.";
                }

                return clientLoginResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GerarJwt(Usuario usuario)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _appSettings.Emitter,
                    Audience = _appSettings.ValidOn,

                    Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, usuario.NomeUsuario.ToString()),
                        new Claim(ClaimTypes.Role, usuario.Role.ToString())
                        }),

                    Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                });

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
