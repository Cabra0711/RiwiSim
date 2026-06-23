using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LogisticMVP.Data;
using LogisticMVP.Enums;
using LogisticMVP.Models;
using LogisticMVP.Response;
using LogisticMVP.Service.Interface;
using LogisticMVP.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LogisticMVP.Service;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly UserValidator _userValidator;
    private readonly IConfiguration _configuration;
    
    public AuthService(ApplicationDbContext context, UserValidator userValidator,  IConfiguration configuration)
    {
        _context = context;
        _userValidator = userValidator;
        _configuration = configuration;
    }

    public async Task<ServiceResponse<User>> CreateUser(User user)
    {
        var response = new ServiceResponse<User>();
        var userValidator = _userValidator.Validate(user);
        if (!userValidator.IsValid)
        {
            response.Success = false;
            return response;
        }
        
        var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
        if (userExists != null)
        {
            response.Success = false;
            response.Message = "User already exists in the system";
            return response;
        }
        else
        {
            user.Role = UserRole.Admin;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            response.Message = "User created successfully";
            response.Success = true;
            response.Data = user;
            
            return response;
        }
    }

    public async Task<ServiceResponse<User>> Login(string email, string password)
    {
        var response = new ServiceResponse<User>();
        var userExists = await _context.Users.SingleOrDefaultAsync(u => EF.Functions.Like(u.Email, email));

        if (userExists == null)
        {
            response.Success = false;
            response.Message = "User not found int the system";
            return response;
        }

        var verificationResult = BCrypt.Net.BCrypt.Verify(password, userExists.PasswordHash);
        if (verificationResult == true)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(secretKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var data = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userExists.Email),
                    new Claim(ClaimTypes.Role, userExists.Role.ToString()),
                }),
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials,
            };
            var objet = tokenHandler.CreateToken(data);
            var token = tokenHandler.WriteToken(objet);
            
            userExists.Token = token;
            response.Success = true;
            response.Message = "Login Successful....";
            response.Data = userExists;
            
        }
        else
        {
            response.Success = false;
            response.Message = "Enter your credentials again...";
            return response;
        }
        return response;
    }
}