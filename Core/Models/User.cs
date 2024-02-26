using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LibraryProject.Core.DTO;

namespace LibraryProject.Core.Model
{
    public class User
    {
        public User()
        {
            BorrowBook = new Collection<BorrowBookDTO>();
        }


        [JsonIgnore]
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [JsonIgnore]
        public ICollection<BorrowBookDTO>? BorrowBook { get; set; }
    }
}
