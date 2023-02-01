
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string secretKey;
        private readonly DbSet<LocalUser> _dbSet;
        public UserRepoistory(QkartDbContext db, IConfiguration configuration,
            UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            this._dbContext = db;
            this._userManager = userManager;
            this._mapper = mapper;
            this._roleManager = roleManager;
            _dbSet = _dbContext.Set<LocalUser>();

            secretKey = configuration.GetValue<string>("ApiSetting:Secret");// ["Secret"];
        }

        public bool isUserUnique(string userName)
        {

            if (_dbContext.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower()) != null) return false;

            return true;

        }
        public async Task<UserDTO> UserRegistration(RegistrationRequestDTO userRequest)
        {
            var newUser = new ApplicationUser()
            {
                UserName = userRequest.UserName,
                Email = userRequest.UserName,
                NormalizedEmail = userRequest.UserName.ToUpper(),
                Name = userRequest.Name,

            };
            try
            {
                var result = await _userManager.CreateAsync(newUser, userRequest.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("user"));
                    }
                    await _userManager.AddToRoleAsync(newUser, userRequest.Role.ToLower());
                    ApplicationUser userToReturn = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Name == userRequest.Name);
                    return _mapper.Map<UserDTO>(userToReturn);
                }
            }
            catch (Exception ex)
            {

                // thr
            }
            return new UserDTO();
        }

        public async Task<LoginResponseDTO> UserLogin(LoginRequestDTO userRequest)
        {
            var user = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName.ToLower() == userRequest.UserName.ToLower());
            bool isPassValid = await _userManager.CheckPasswordAsync(user, userRequest.Password);
            if (user == null || !isPassValid) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = await getClaimsIdentity(user), /*new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Name),

                     }),*/

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = userDTO,

            };

            return loginResponseDTO;
        }

        public async Task<ClaimsIdentity> getClaimsIdentity(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return new ClaimsIdentity(
                await getClaims()
                );

            async Task<Claim[]> getClaims()
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
                return claims.ToArray();
            }

        }

    }
}
