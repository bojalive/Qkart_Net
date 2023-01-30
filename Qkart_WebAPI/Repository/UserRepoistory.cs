
using Microsoft.IdentityModel.Tokens;
using Qkart_WebAPI.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Qkart_WebAPI.Repository
{
    public class UserRepoistory<T> : IUserRespository<T> where T : class
    {
        private readonly QkartDbContext _dbContext;
        private readonly string secretKey;
        private readonly DbSet<LocalUser> _dbSet;
        public UserRepoistory(QkartDbContext db, IConfiguration configuration)
        {
            this._dbContext = db;

            _dbSet = _dbContext.Set<LocalUser>();

            secretKey = configuration.GetValue<string>("ApiSetting:Secret");// ["Secret"];
        }

        public bool isUserUnique(string userName)
        {

            if (_dbSet.FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower()) != null) return false;

            return true;

        }
        public async Task<LocalUser> UserRegistration(RegistrationRequestDTO userRequest)
        {
            var newUser = new LocalUser()
            {
                UserName = userRequest.UserName,
                Password = userRequest.Password,
                Name = userRequest.Name,
                Role = userRequest.Role,
            };
            await _dbSet.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            newUser.Password = "";
            return newUser;
        }

        public async Task<LoginResponseDTO> UserLogin(LoginRequestDTO userRequest)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.UserName.ToLower() == userRequest.UserName.ToLower() && u.Password == userRequest.Password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Role,user.Role)
                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };

            return loginResponseDTO;
        }


    }
}
