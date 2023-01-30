using Qkart_WebAPI.Data;

namespace Qkart_WebAPI.Repository
{
    public class UserRepoistory<T> : IUserRespository<T> where T : class
    {
        private readonly QkartDbContext _dbContext;
        private readonly DbSet<LocalUser> _dbSet;
        public UserRepoistory(QkartDbContext db)
        {
            this._dbContext = db;
            _dbSet = _dbContext.Set<LocalUser>();
        }

        public bool isUserUnique(LocalUser localUser)
        {
            if (_dbSet.Where(x => x.UserName == localUser.UserName) != null) return false;

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

        public async Task<LoginResponseDTO> IUserRespository<T>.UserLogin(LoginRequestDTO userRequest)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.UserName.ToLower() == userRequest.UserName.ToLower() && u.Password == userRequest.Password);
            if (user == null) return null;



        }


    }
}
