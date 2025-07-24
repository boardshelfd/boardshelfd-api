using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        [Required, MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's password (hashed).
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's Email.
        /// </summary>
        [Required, MaxLength(128)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the users games.
        /// </summary>
        public virtual ICollection<UserGameCollection> GameCollection { get; set; }
    }
}
