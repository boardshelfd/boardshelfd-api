using Providers.Entities;

namespace Dtos.Mappers
{
    public static class UserMapper 
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public static IEnumerable<UserDto> ToDto(IEnumerable<User> users)
        {
            return users.Select(ToDto);
        }

        public static User ToEntity(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email
            };
        }

        public static IEnumerable<User> ToDto(IEnumerable<UserDto> dtos)
        {
            return dtos.Select(ToEntity);
        }
    }
}