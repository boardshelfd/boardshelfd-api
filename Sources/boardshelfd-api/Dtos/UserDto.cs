using System.ComponentModel;

namespace Dtos
{
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the user's id.
        /// </summary>
        [Description("The user's id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        [Description("The user's name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's Email.
        /// </summary>
        [Description("The user's Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's games ids.
        /// </summary>
        [Description("The user's games ids")]
        public IEnumerable<int> GamesIds { get; set; }
    }
}
