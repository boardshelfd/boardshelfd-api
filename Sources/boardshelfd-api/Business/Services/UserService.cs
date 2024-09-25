using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            _unitOfWork = unitOfWork;
            _logger = logger;

            _unitOfWork._dbContext.Add(new User() { Id = 0, Email = "test", Name = "test" });
            _unitOfWork._dbContext.Add(new User() { Id = 1, Email = "test2", Name = "test2" });
            _unitOfWork._dbContext.SaveChanges();
        }
        
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The list of trait stack</returns>
        public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _unitOfWork._dbContext.User.OrderBy(x => x.Id).ToListAsync(cancellationToken);
        }
    }    
}