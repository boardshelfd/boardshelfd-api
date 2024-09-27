using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Providers;
using Providers.Entities;

namespace Business.Services
{
    public class UserService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<UserService> _logger;

        /// <summary>
        /// The database context
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Error prefix for the service
        /// </summary>
        private const String ERROR_PREFIX = "EXCEPTION.USER.";
        
        /// <summary>
        /// The user service constructor
        /// </summary>
        /// <param name="logger">The logger instance</param>
        public UserService(UnitOfWork unitOfWork, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork)); ;
            _logger = logger;
        }
        
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The list of trait stack</returns>
        public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _unitOfWork._dbContext.User.Include(c => c.GameCollection).OrderBy(x => x.Id).ToListAsync(cancellationToken);
        }

        public async Task<User> GetUserByIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _unitOfWork._dbContext.User.Where(u => u.Id == userId).Include(c => c.GameCollection).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<User>> GetUsersByNameAsync(string userName, CancellationToken cancellationToken)
        {
            return await _unitOfWork._dbContext.User.Where(u => u.Name.ToLower().Contains(userName)).Include(c => c.GameCollection).OrderBy(x => x.Id).ToListAsync(cancellationToken);
        }

        public async Task<int> CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Try to create trait strack {Id}", user.Id);
            await _unitOfWork._dbContext.AddAsync(user, cancellationToken);
            var result = await _unitOfWork._dbContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Success to create trait strack {Id}", user.Id);
            return result;
        }
    }    
}