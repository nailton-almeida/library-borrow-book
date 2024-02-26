using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LibraryProject.Core.DTO;

namespace LibraryProject.Core.Model;

public class Book
{
    public Book()
    {
        BorrowBook = new Collection<BorrowBookDTO>();
    }

    [JsonIgnore]
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }
    [Required]
    [StringLength(30)]
    public string? Author { get; set; }
    [Required]
    [StringLength(20)]
    public string? ISBN { get; set; }
    [Required]
    public int YearPublication { get; set; }

    [JsonIgnore]
    public ICollection<BorrowBookDTO>? BorrowBook { get; set; }
}
