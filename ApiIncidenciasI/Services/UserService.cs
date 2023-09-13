using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiIncidenciasI.Dtos;
using ApiIncidenciasI.Helpers;
using ApiIncidenciasI.Services;
using Application.Contracts;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiIncidencias.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IJwtGenerator _jwtGenerator;

    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt,
        IPasswordHasher<User> passwordHasher, IJwtGenerator jwtGenerator)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var userr = new User
        {

            Email = registerDto.Email,
            UserName = registerDto.Username,

        };

        userr.Password = _passwordHasher.HashPassword(userr, registerDto.Password);

        var userExist = _unitOfWork.Users
                                    .Find(u => u.UserName.ToLower() == registerDto.Username.ToLower())
                                    .FirstOrDefault();

        if (userExist == null)
        {
            var defaultRole = _unitOfWork.Roles
                                    .Find(u => u.Name == Authorization.default_role.ToString())   
                                    .First();
            try
            {
                userr.Roles.Add(defaultRole);
                _unitOfWork.Users.Add(userr);
                await _unitOfWork.SaveAsync();

                return $"El usuario  {registerDto.Username} ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"El usuario con {registerDto.Username} ya se encuentra registrado.";
        }
    }


    /*public async Task<DatosUsuarioDto> GetTokenAsync(LoginDto model)
    {
        DatosUsuarioDto datosUsuarioDto = new DatosUsuarioDto();
        var usuario = await _unitOfWork.Usuarios
                    .GetByUsernameAsync(model.Username);

        if (usuario == null)
        {
            datosUsuarioDto.EstaAutenticado = false;
            datosUsuarioDto.Mensaje = $"No existe ningún usuario con el username {model.Username}.";
            return datosUsuarioDto;
        }

        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

        if (resultado == PasswordVerificationResult.Success)
        {
            datosUsuarioDto.EstaAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
            datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            datosUsuarioDto.Email = usuario.Email;
            datosUsuarioDto.UserName = usuario.Username;
            datosUsuarioDto.Roles = usuario.Roles
                                            .Select(u => u.Nombre)
                                            .ToList();
            return datosUsuarioDto;
        }
        datosUsuarioDto.EstaAutenticado = false;
        datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.Username}.";
        return datosUsuarioDto;
    }*/

    public async Task<string> AddRoleAsync(AddRoleDto model)
    {
        var usuario = await _unitOfWork.Users
                    .GetByUsernameAsync(model.Username);
        if (usuario == null)
        {
            return $"No existe algún usuario registrado con la cuenta {model.Username}.";
        }
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);
        if (resultado == PasswordVerificationResult.Success)
        {
            var rolExiste = _unitOfWork.Roles
                                        .Find(u => u.Name.ToLower() == model.Role.ToLower())
                                        .FirstOrDefault();
            if (rolExiste != null)
            {
                var usuarioTieneRol = usuario.Roles
                                            .Any(u => u.Id == rolExiste.Id);

                if (usuarioTieneRol == false)
                {
                    usuario.Roles.Add(rolExiste);
                    _unitOfWork.Users.Update(usuario);
                    await _unitOfWork.SaveAsync();
                }
                return $"Rol {model.Role} agregado a la cuenta {model.Username} de forma exitosa.";
            }
            return $"Rol {model.Role} no encontrado.";
        }
        return $"Credenciales incorrectas para el usuario {usuario.Username}.";
    }
    public async Task<UserDataDto> GetTokenAsync(LoginDto model)
    {
        UserDataDto datosUsuarioDto = new UserDataDto();
        var usuario = await _unitOfWork.Users
                    .GetByUsernameAsync(model.Username);
        if (usuario == null)
        {
            datosUsuarioDto.EstaAutenticado = false;
            datosUsuarioDto.Mensaje = $"No existe ningún usuario con el username {model.Username}.";
            return datosUsuarioDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);
        if (result == PasswordVerificationResult.Success)
        {

            datosUsuarioDto.Mensaje = "Ok";
            datosUsuarioDto.EstaAutenticado = true;
            datosUsuarioDto.UserName = usuario.Username;
            datosUsuarioDto.Email = usuario.Username;
            datosUsuarioDto.Token = _jwtGenerator.CrearToken(usuario);
            return datosUsuarioDto;

        }
        datosUsuarioDto.EstaAutenticado = false;
        datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.Username}.";
        return datosUsuarioDto;

    }
    private JwtSecurityToken CreateJwtToken(User user)
    {
        var roles = user.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Nombre));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                                new Claim("uid", user.Id.ToString())
                        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        Console.WriteLine("", symmetricSecurityKey);
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }

    public async Task<LoginDto> UserLogin(LoginDto model)
    {
        var usuario = await _unitOfWork.Users.GetByUsernameAsync(model.Username);
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

        if (resultado == PasswordVerificationResult.Success)
        {
            return model;
        }
        return null;
    }


}