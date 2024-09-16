using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Providers.Entities
{
    public class User
    {
        /// <summary>
        /// Gets or sets the user's id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
    }
}
