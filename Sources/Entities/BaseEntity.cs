using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the user's id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
