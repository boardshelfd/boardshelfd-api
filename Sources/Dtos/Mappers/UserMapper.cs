using Providers.Entities;

namespace Dtos.Mappers
{
    public static class UserMapper 
    {

        // --- ToDto --- //

        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Email = user.Email,
                GamesIds = user.GameCollection?.Where(x => x != null).Select(c => c.GameId) ?? Enumerable.Empty<int>()
            };
        }

        public static IEnumerable<UserDto> ToDto(this IEnumerable<User> users)
        {
            return users.Select(ToDto) ?? Enumerable.Empty <UserDto>();
        }

        // --- ToEntity --- //

        public static User ToEntity(this UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Password = dto.Password,
                Email = dto.Email
            };
        }

        public static ICollection<User> ToEntity(this IEnumerable<UserDto> dtos)
        {
            return dtos.Select(ToEntity).ToList() ?? Enumerable.Empty<User>().ToList();
        }
    }
}