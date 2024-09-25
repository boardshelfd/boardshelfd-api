using Providers.Entities;

namespace Dtos.Mappers
{
    public static class UserMapper 
    {

        // --- ToDto --- //

        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                GamesIds = user.GameCollection?.Where(x => x != null).Select(c => c.GameId) ?? Enumerable.Empty<int>()
            };
        }

        public static IEnumerable<UserDto> ToDto(IEnumerable<User> users)
        {
            return users.Select(ToDto) ?? Enumerable.Empty <UserDto>();
        }

        // --- ToEntity --- //

        public static User ToEntity(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email
            };
        }

        public static ICollection<User> ToEntity(IEnumerable<UserDto> dtos)
        {
            return dtos.Select(ToEntity).ToList() ?? Enumerable.Empty<User>().ToList();
        }
    }
}